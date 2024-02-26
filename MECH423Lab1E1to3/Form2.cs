using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CsGettingStarted
{
    public partial class Form2 : Form
    {


        Queue<Int32> dataQueue = new Queue<Int32>();
        public Form2()
        {
            InitializeComponent();
        }

        private void Enqueue_Click(object sender, EventArgs e)
        {
            dataQueue.Enqueue(Convert.ToInt32(txtEnqueue.Text));
            txtNumItems.Text = dataQueue.Count.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDequeue_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Dequeue_Click(object sender, EventArgs e)
        {
            if (dataQueue.Count == 0)
            {
                MessageBox.Show("Queue Empty\n");
                return;
            }
            txtDequeue.Text=dataQueue.Peek().ToString();
            dataQueue.Dequeue();
            txtNumItems.Text = dataQueue.Count.ToString();




        }

        public void UpdateQueue(Queue<Int32> queue)
        {
            Contents.Text = ""; //clears the text box
            foreach (Int32 item in dataQueue)
            {
                Contents.AppendText(item.ToString());
                Contents.AppendText(", ");

            }
        }

        private void txtNumItems_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateQueue(dataQueue);
        }

        private void AverageQueue_Click(object sender, EventArgs e)
        {
            if (dataQueue.Count == 0 || txtN.Text=="" ||  Convert.ToInt32(txtN.Text)>dataQueue.Count)
            {
                MessageBox.Show("Insufficient number of items");
                return;
            }


            txtAverage.Text = TakeAverage(dataQueue).ToString();
            txtN.Text = dataQueue.Count.ToString();
            dataQueue.Clear();
            txtNumItems.Text = dataQueue.Count.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtN_TextChanged(object sender, EventArgs e)
        {

        }

        private float TakeAverage(Queue<Int32> queue)
        {
            float sum = 0;

            foreach (Int32 item in dataQueue)
            {
                sum += item;
            }
            return sum / dataQueue.Count;
        }

    }
}
