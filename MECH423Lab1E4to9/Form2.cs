using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Collections.Concurrent;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MECH423Lab1E4to9
{
    public partial class Form2 : Form
    {
        int state_var;
        const int state_normal = 0;
        const int state_x = 1;
        const int state_y = 2;
        const int state_z = 3;
        double time = 0;

        const int orientation_limit_plus=140;
        const int orientation_limit_minus = 105;

        int dequeueAx;
        int dequeueAy;
        int dequeueAz;


        int result;
        int prevResultAx;
        int prevResultAy;
        int prevResultAz;
        int changeAx;
        int changeAy;
        int changeAz;

        ConcurrentQueue<Int32> rawDataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AxDataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AyDataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AzDataQueue = new ConcurrentQueue<Int32>();

        ConcurrentQueue<Int32> AxDerivativeQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AyDerivativeQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AzDerivativeQueue = new ConcurrentQueue<Int32>();
        
        StreamWriter outputFile;

        string serialDataString;
        public Form2()
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

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            SerialPort.DtrEnable = true;
            SerialPort.Open();


        }

        private void DisconnectSerial_Click(object sender, EventArgs e)
        {
            SerialPort.Close();
            return;
        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int newByte = 0;
            int bytesToRead;

            bytesToRead = SerialPort.BytesToRead;

            while (bytesToRead != 0)
            {
                newByte = SerialPort.ReadByte();
                rawDataQueue.Enqueue(Convert.ToInt32(newByte));
                serialDataString = serialDataString + newByte.ToString() + (", ");
                bytesToRead = SerialPort.BytesToRead;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (SerialPort.IsOpen)
                txtBytesToRead.Text = SerialPort.BytesToRead.ToString();


            txtQueueItems.Text = rawDataQueue.Count.ToString();
            //txtStrLen.Text=serialDataString.Length.ToString();    

             
            while (rawDataQueue.Count > 0)
            {

                rawDataQueue.TryDequeue(out result);
                DataStream.AppendText(result.ToString());
                DataStream.AppendText(", ");

                if (result == 255 && state_var == state_normal)
                {
                    state_var = state_x;
                }

                else
                {
                    switch(state_var)
                    {
                        case state_x:
                            AxDataQueue.Enqueue(result);

                            changeAx = result - prevResultAx;
                            AxDerivativeQueue.Enqueue(changeAx);

                            txtDeltaAx.Text=changeAx.ToString();
                            txtAx.Text=result.ToString();

                            if (result > orientation_limit_plus)
                            {
                                txtOrientation.Text = "+X";
                            }
                            else if(result<orientation_limit_minus)
                            {
                                txtOrientation.Text = "-X";

                            }
                            prevResultAx = result;
                            state_var = state_y;

                            break;

                        case state_y:
                            AyDataQueue.Enqueue(result);
                            changeAy=result - prevResultAy;
                            AyDerivativeQueue.Enqueue(changeAy);
                            txtDeltaAy.Text=changeAy.ToString();
                            txtAy.Text= result.ToString();


                            if (result > orientation_limit_plus)
                            {
                                txtOrientation.Text = "+Y";
                            }
                            else if (result < orientation_limit_minus)
                            {
                                txtOrientation.Text = "-Y";

                            }
                            prevResultAy=result;
                            state_var = state_z;
                            break;
                        case state_z:
                            AzDataQueue.Enqueue(result);
                            changeAz=result - prevResultAz;
                            AzDerivativeQueue.Enqueue(changeAz);
                            txtDeltaAz.Text=changeAz.ToString();
                            txtAz.Text= result.ToString();


                            if (result > orientation_limit_plus)
                            {
                                txtOrientation.Text = "+Z";
                            }
                            else if (result < orientation_limit_minus)
                            {
                                txtOrientation.Text = "-Z";

                            }
                            prevResultAz=result;
                            state_var = state_normal;
                            break;
                    }

                    serialDataString="";
                }
            }

            }

        private void SaveToFile_CheckedChanged(object sender, EventArgs e)
        {
            if (SaveToFile.Checked)
            {
                outputFile = new StreamWriter(txtFileName.Text);
                while (AxDataQueue.Count > 0 || AyDataQueue.Count > 0 || AzDataQueue.Count > 0)
                {

                    //outputFile.Write(DateTime.Now.ToLongTimeString());
                    //outputFile.Write(time);
                    //outputFile.Write(", ");

                    AxDerivativeQueue.TryDequeue(out dequeueAx);
                    outputFile.Write(dequeueAx);
                    outputFile.Write(", ");

                    AyDerivativeQueue.TryDequeue(out dequeueAy);
                    outputFile.Write(dequeueAy);
                    outputFile.Write(", ");

                    AzDerivativeQueue.TryDequeue(out dequeueAz);
                    outputFile.Write(dequeueAz);

                    outputFile.Write("\n");

                    //time += timer1.Interval / 1000 ;
                }


                outputFile.Close();
                SerialPort.Dispose();


            }
            else
            {
                outputFile.Close();
            }
        }

        private void SelectFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog myDialogBox = new SaveFileDialog();
            myDialogBox.InitialDirectory = @"C:\Users\Lachlan Reynolds\Desktop\MECH 423\Labs";
            myDialogBox.ShowDialog();
            txtFileName.Text = myDialogBox.FileName.ToString() + ".CSV";


        }
    }

 
    }

