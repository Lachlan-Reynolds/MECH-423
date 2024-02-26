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

namespace MECH423Lab1E4to9
{
    public partial class Form1 : Form
    {
        int temp;
        ConcurrentQueue<Int32> dataQueue=new ConcurrentQueue<Int32>();
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if(comboBox1.Items.Count == 0 )
            {
                comboBox1.Text = "No COM Ports";
            }
            else
                comboBox1.SelectedIndex = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
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

            while(bytesToRead!=0)
            {
                newByte = SerialPort.ReadByte();
                dataQueue.Enqueue(Convert.ToInt32(newByte));
                bytesToRead = SerialPort.BytesToRead;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(SerialPort.IsOpen)
                txtBytesToRead.Text=SerialPort.BytesToRead.ToString();
            //txtStrLen.Text = dataQueue.Count.ToString();
            textBox3.Text = dataQueue.Count.ToString();


            while (dataQueue.Count>0)
            {
                dataQueue.TryDequeue(out temp);
                DataStream.AppendText(temp.ToString());
                DataStream.AppendText(", ");
            }


        }

        private void txtConnectSerial_Click(object sender, EventArgs e)
        {
            SerialPort.Open(); 
        }
    }
}
