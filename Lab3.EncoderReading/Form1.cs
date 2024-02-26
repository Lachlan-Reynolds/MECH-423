using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab3.EncoderReading
{
    public partial class Form1 : Form
    {
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        private int encoderCountA0 = 0;
        private int encoderCountA1 = 0;
        private DateTime lastTimeStamp;
        private int temp;
        private int previousCountsA0;
        List<double> speedData = new List<double>();
        int duty_cycle;
        byte value_8_bit_high;
        byte value_8_bit_low;
        byte escape_byte;
        byte[] charactersToSend = new byte[5];
        const byte start_byte = 255;
        byte command_byte;
        double prevPosition = 0;
        List<double> positionData = new List<double>();
        List<double> chartTime = new List<double>();
        double current_time = 0;
        int max_duty_cycle = 65535;

        double alpha = 0.5;
        double lastFilteredVal;
        double inputVal;
        double filteredVal;

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBox1.Items.Count == 0)
            {
                comboBox1.Text = "No COM Ports";
            }
            else
                comboBox1.SelectedIndex = 0;

            lastTimeStamp = DateTime.Now;
        }

        private void MCUSerial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int newByte = 0;
            int bytesToRead;

            bytesToRead = MCUSerial.BytesToRead;

            while (bytesToRead != 0)
            {
                newByte = MCUSerial.ReadByte();
                dataQueue.Enqueue(newByte);
                bytesToRead = MCUSerial.BytesToRead;
            }

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            MCUSerial.Open();
            if (MCUSerial.IsOpen)
            {
                buttonConnect.Text = "Connected";
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            current_time += timer1.Interval / 1000;

            // Process data in the queue during the timer tick event
            while (dataQueue.Count > 0)
            {
                dataQueue.TryDequeue(out temp);
                if (temp == 255)
                {
                    dataQueue.TryDequeue(out temp);
                    int highByteA0 = temp;
                    dataQueue.TryDequeue(out temp);
                    int lowByteA0 = temp;
                    dataQueue.TryDequeue(out temp);
                    int highByteA1 = temp;
                    dataQueue.TryDequeue(out temp);
                    int lowByteA1 = temp;

                    // Calculate encoder counts
                    int countsA0 = (highByteA0 << 8) | lowByteA0;
                    int countsA1 = (highByteA1 << 8) | lowByteA1;


                    // Calculate rotational velocity in Hz
                    double currentPosition = (countsA0 - countsA1);

                    double velocityHz = (currentPosition - prevPosition) / (200 * 0.1);
                    double positionChange = Math.Abs(currentPosition - prevPosition);

                    // Calculate rotational velocity in RPM
                    double velocityRPM = velocityHz * 60;

                    // Update UI or display the results
                    speed_Hz.Text = velocityHz.ToString();
                    speed_RPM.Text = velocityRPM.ToString();

                    prevPosition = currentPosition;

                    //filter the speed data somehow



                    if (Math.Abs(velocityRPM) < 500 && Math.Abs(positionChange) < 500)
                    {
                        filteredVal = filter(velocityRPM, alpha);

                        chartTime.Add(current_time);

                        speedData.Add(filteredVal);
                        positionData.Add(currentPosition * 360 / 200);

                        // Update the Chart control

                        chart1.Series["SpeedData"].Points.DataBindXY(chartTime, speedData);

                        chart2.Series["Current Position"].Points.DataBindXY(chartTime, positionData);
                    }



                    if (chartTime.Count > 200)
                    {
                        chartTime.RemoveAt(0);
                        speedData.RemoveAt(0);
                        positionData.RemoveAt(0);
                    }


                }
            }

            if (MCUSerial.IsOpen)
            {
                textBox1.AppendText(duty_cycle.ToString());
                //use slider to decompose  duty cycle into input to write buffer
                value_8_bit_low = (byte)(duty_cycle & 0xFF);
                value_8_bit_high = (byte)((duty_cycle >> 8) & 0xFF);

                if (value_8_bit_high == 255)
                {
                    escape_byte = 2;
                    value_8_bit_high = 0;

                }
                else if (value_8_bit_low == 255)
                {
                    escape_byte = 1;
                    value_8_bit_low = 0;
                }
                else if (value_8_bit_low == 255 && value_8_bit_high == 255)
                {
                    escape_byte = 3;
                    value_8_bit_high = 0;
                    value_8_bit_low = 0;
                }
                else
                {
                    escape_byte = 0;
                }

                charactersToSend[0] = start_byte;
                charactersToSend[1] = command_byte;
                charactersToSend[2] = value_8_bit_high;                                     //Data byte high
                charactersToSend[3] = value_8_bit_low;                                      //Data byte low
                charactersToSend[4] = escape_byte;

                MCUSerial.Write(charactersToSend, 0, 5);
            }

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            duty_cycle = trackBar1.Value;
            textBoxTB_duty.Text = trackBar1.Value.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                command_byte = 0;
            }
            else
            {
                command_byte = 1;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create a chart area
            ChartArea chart1Area = new ChartArea();
            chart1.ChartAreas.Add(chart1Area);
            chart1.Series.Clear();
            chart1Area.AxisX.Title = "Time";
            chart1Area.AxisY.Title = "Speed in RPM";
            chart1.Series.Add("SpeedData");
            chart1.Series["SpeedData"].ChartType = SeriesChartType.Line;

            chart1Area.AxisX.LabelStyle.Enabled = true;
            chart1Area.AxisX.LabelStyle.Format = "F2"; // Example format for X-axis labels
            chart1Area.AxisY.LabelStyle.Enabled = true;
            chart1Area.AxisY.LabelStyle.Format = "F2"; // Example format for Y-axis labels

            // Create a chart area
            ChartArea chart2Area = new ChartArea();
            chart2.ChartAreas.Add(chart2Area);
            chart2.Series.Clear();
            chart2Area.AxisX.Title = "Time";
            chart2Area.AxisY.Title = "Position in Counts";
            chart2.Series.Add("Current Position");
            chart2.Series["Current Position"].ChartType = SeriesChartType.Line;


            chart2Area.AxisX.LabelStyle.Enabled = true;
            chart2Area.AxisX.LabelStyle.Format = "F2"; // Example format for X-axis labels
            chart2Area.AxisY.LabelStyle.Enabled = true;
            chart2Area.AxisY.LabelStyle.Format = "F2"; // Example format for Y-axis labels

        }

        private void SelectFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog myDialogBox = new SaveFileDialog();
            myDialogBox.InitialDirectory = @"C:\Users\Lachlan Reynolds\Desktop\MECH 423\Labs";
            myDialogBox.ShowDialog();
            txtFileName.Text = myDialogBox.FileName.ToString() + ".CSV";
        }

        private StreamWriter outputFile;

        private void saveToFile_CheckedChanged(object sender, EventArgs e)
        {
            if (saveToFile.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtFileName.Text))
                {
                    MessageBox.Show("Please select a file name before saving data.");
                    saveToFile.Checked = false;
                    return;
                }

                outputFile = new StreamWriter(txtFileName.Text);

                // Write a header line
                outputFile.WriteLine("Time,Speed in RPM,Position in Counts,Linear Position");

                MessageBox.Show("Data saving has started.");
            }
            else
            {
                if (outputFile != null)
                {
                    for (int i = 0; i < chartTime.Count; i++)
                    {
                        double time = chartTime[i];
                        double speed = speedData[i];
                        double positionCounts = positionData[i];
                        double linearPosition = positionCounts * Math.PI / 180 * 7; // Adjust the conversion factor

                        outputFile.WriteLine($"{time},{speed},{positionCounts},{linearPosition}");
                    }

                    outputFile.Close();
                    outputFile = null;
                    MessageBox.Show("Data saving has stopped.");
                }
                else
                {
                    MessageBox.Show("File saving was not enabled.");
                }
            }
        }


        private void txtDutyCycle_TextChanged(object sender, EventArgs e)
        {
            
            if (int.TryParse(txtDutyCycle.Text, out int newDutyCycle))
            {
                duty_cycle = max_duty_cycle / 100 * newDutyCycle;
            }
            else
            {
                MessageBox.Show("Please enter a valid duty cycle as an integer.");
            }
            
            //duty_cycle = max_duty_cycle*Convert.ToInt32(txtDutyCycle.Text)/100;

        }


        public double filter(double inputVal, double alpha)
        {
            lastFilteredVal= alpha * inputVal + (1 - alpha) * lastFilteredVal;
            return lastFilteredVal;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
    }
}
