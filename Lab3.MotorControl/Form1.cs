using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Lab3.MotorControl
{
    public partial class Form1 : Form
    {
        int max_duty=65535;
        int duty_cycle;
        byte value_8_bit_high;
        byte value_8_bit_low;
        const byte start_byte = 255;
        byte command_byte;
        byte escape_byte;
        byte[] charactersToSend = new byte[5];
        int trackBarRange;
        int upper_limit;
        int lower_limit = 1000;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MCUSerial.DtrEnable = true;
            //MCUSerial.Open();

            txtByte1.Visible = false;
            txtByte2.Visible = false;
            txtByte3.Visible = false;
            txtByte4.Visible = false;
            txtByte5.Visible = false;
        }

        private void checkByte1_CheckStateChanged(object sender, EventArgs e)
        {
            txtByte1.Visible = !txtByte1.Visible;
        }

        private void checkByte2_CheckStateChanged(object sender, EventArgs e)
        {
            txtByte2.Visible= !txtByte2.Visible;
        }

        private void checkByte3_CheckStateChanged(object sender, EventArgs e)
        {
            txtByte3.Visible= !txtByte3.Visible;
        }

        private void checkByte4_CheckStateChanged(object sender, EventArgs e)
        {
            txtByte4.Visible= !txtByte4.Visible;
        }

        private void checkByte5_CheckStateChanged(object sender, EventArgs e)
        {
            txtByte5.Visible= !txtByte5.Visible;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            MCUSerial.Open();

            if(MCUSerial.IsOpen)
            {
                buttonConnect.Text = "Connected";
            }

        }

        private void transmit_Click(object sender, EventArgs e)
        {
            byte[] charactersToSend = new byte[5];

            // Check and convert each TextBox entry to a character


            charactersToSend[0] = (byte) Convert.ToInt32(txtByte1.Text);
            charactersToSend[1] = (byte)Convert.ToInt32(txtByte2.Text);
            charactersToSend[2] = (byte)Convert.ToInt32(txtByte3.Text);
            charactersToSend[3] = (byte)Convert.ToInt32(txtByte4.Text);
            charactersToSend[4] = (byte)Convert.ToInt32(txtByte5.Text);

            MCUSerial.Write(charactersToSend, 0, 5);

        }



        private void timer1_Tick(object sender, EventArgs e)
        {

            if(CheckuseSlider.Checked)
            {
                //use slider to decompose  duty cycle into input to write buffer
                value_8_bit_low = (byte)(duty_cycle & 0xFF);
                value_8_bit_high = (byte) ((duty_cycle >> 8) & 0xFF);

                if(value_8_bit_high==255)
                {
                    escape_byte = 2;

                }
                else if(value_8_bit_low==255)
                {
                    escape_byte=1;
                }
                else if(value_8_bit_low==255 && value_8_bit_high==255)
                {
                    escape_byte=3;
                }

                if(txtCommand.Text!=null)
                {
                    charactersToSend[0] = start_byte;
                    charactersToSend[1] = command_byte;                 //command byte
                    charactersToSend[2] = value_8_bit_high;                                     //Data byte high
                    charactersToSend[3] = value_8_bit_low;                                      //Data byte low
                    charactersToSend[4] = escape_byte;

                    MCUSerial.Write(charactersToSend, 0, 5);
                    textBox1.AppendText(duty_cycle.ToString());
                }



            }

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            trackBarRange = trackBar1.Maximum - trackBar1.Minimum;
            if(trackBar1.Value>trackBarRange/2)
            {

                command_byte = 0;
                if(trackBar1.Value<trackBar1.Maximum/2 +lower_limit)
                {
                    duty_cycle = 2*Math.Abs(trackBar1.Value+lower_limit - trackBar1.Maximum);
                }
                else
                {
                    duty_cycle = 2 * Math.Abs(trackBar1.Value - trackBar1.Maximum);
                }
            }
            else
            {
                command_byte=1;
                if(trackBar1.Value > trackBar1.Maximum / 2 - lower_limit)
                {
                    duty_cycle = 2*(trackBar1.Value + lower_limit);
                }
                else
                {
                    duty_cycle = 2 * trackBar1.Value;
                }
                    
            }



        }

        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            MCUSerial.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            command_byte = 3;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
