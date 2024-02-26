using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MECH423Lab1E4to9
{
    public partial class Form3 : Form
    {
        int state_var;
        const int state_normal = 0;
        const int state_x = 1;
        const int state_y = 2;
        const int state_z = 3;
        double time = 0;

        const int x_limit_plus = 140;
        const int x_limit_minus = 105;

        const int limit_plus = 140;
        const int limit_minus = 105;
       
        const int y_limit_plus = 140;
        const int y_limit_minus = 105;
       
        const int z_limit_plus = 140;
        const int z_limit_minus = 105;

        int dequeueAx;
        int dequeueAy;
        int dequeueAz;

        int popAx;
        int popAy;
        int popAz;

        const int waitForData = 0;
        const int xPOS = 1;
        const int xNEG = 2;
        const int yPOS = 3;
        const int yNEG = 4;
        const int zPOS = 5;
        const int zNEG = 6;
        int gestureState = waitForData;


        int result;
        int dataPointsToWait; //Single action
        

        ConcurrentQueue<Int32> rawDataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AxDataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AyDataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AzDataQueue = new ConcurrentQueue<Int32>();

        ConcurrentStack<Int32> AxDataStack = new ConcurrentStack<Int32>();
        ConcurrentStack<Int32> AyDataStack = new ConcurrentStack<Int32>();
        ConcurrentStack<Int32> AzDataStack = new ConcurrentStack<Int32>();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
        }

        private void processNew_Click(object sender, EventArgs e)
        {

            while (rawDataQueue.Count > 0)
            {

                rawDataQueue.TryDequeue(out result);
                // txtHistory.AppendText(result.ToString());


                if (result == 255 && state_var == state_normal)
                {
                    state_var = state_x;
                }

                else
                {
                    switch (state_var)
                    {
                        case state_x:
                            AxDataQueue.Enqueue(result);
                            AxDataStack.Push(result);
                            txtAx.Text = result.ToString();
                            state_var = state_y;
                            break;
                        case state_y:
                            AyDataQueue.Enqueue(result);
                            AyDataStack.Push(result);
                            txtAy.Text = result.ToString();
                            state_var = state_z;
                            break;
                        case state_z:
                            AzDataQueue.Enqueue(result);
                            AzDataStack.Push(result);
                            txtAz.Text = result.ToString();
                            state_var = state_normal;
                            break;
                    }


                }
            }
            /*
            AxDataQueue.TryDequeue(out dequeueAx);
            AyDataQueue.TryDequeue(out dequeueAy);
            AzDataQueue.TryDequeue(out dequeueAz);
            */

            AxDataStack.TryPop(out popAx);
            AyDataStack.TryPop(out popAy);
            AzDataStack.TryPop(out popAz);

            

            if (popAx > x_limit_plus)
            {
                gestureState = xPOS;                    //punch;
                
            }
            else if (popAx < x_limit_minus)
            {
                gestureState = xNEG;
            }
            else if (popAy > y_limit_plus)
            {
                gestureState =yPOS;
            }
            else if (popAy < y_limit_minus)
            {
                gestureState=yNEG;
            }
            else if (popAz > z_limit_plus)
            {
                gestureState = zPOS;
            }
            else if (popAz < z_limit_minus)
            {
                gestureState = zNEG;
            }
           

            addNewDataPoint(popAx,popAy,popAz,gestureState);
            txtCurrentState.Text = gestureState.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int newByte = 0;
            int bytesToRead;

            bytesToRead = serialPort1.BytesToRead;

            while (bytesToRead > 0)
            {
                newByte = serialPort1.ReadByte();
                rawDataQueue.Enqueue(Convert.ToInt32(newByte));
                bytesToRead = serialPort1.BytesToRead;

            }

        }


        private void addNewDataPoint(int deqAx, int deqAy, int deqAz, int state)
        {
            txtHistory.AppendText("(");
            txtHistory.AppendText(deqAx.ToString());
            txtHistory.AppendText(", ");
            txtHistory.AppendText(deqAy.ToString());
            txtHistory.AppendText(", ");
            txtHistory.AppendText(deqAz.ToString());
            txtHistory.AppendText(", ");
            txtHistory.AppendText(state.ToString());
            txtHistory.AppendText(")");

        }

        private int findMax(int test,  int prevMax)
        {
            if(test>prevMax)
            {
                return test;
            }

            return prevMax;
        }



    }
}
