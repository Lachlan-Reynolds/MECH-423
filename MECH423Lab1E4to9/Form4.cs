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
using static System.Windows.Forms.AxHost;
using System.Timers;
using System.Threading;

namespace MECH423Lab1E4to9
{
    public partial class Form4 : Form
    {

        const int orientation_limit_plus = 140;
        const int orientation_limit_minus = 110;

        const int gestureLimitPlusAx = 30;
        const int gestureLimitMinusAx = -40;

        const int gestureLimitPlusAy = 30;
        const int gestureLimitMinusAy = -40;

        const int gestureLimitPlusAz = 30;
        const int gestureLimitMinusAz = -40;

        int dataState;
        const int state_normal = 0;
        const int state_x = 1;
        const int state_y = 2;
        const int state_z = 3;

        const int averageOver = 100;
        const int stdDevOver = 0;


        int gestureState=0;

        const int gestureStateSearch = 0;
        const int gestureState1 = 1; //+X
        const int gestureState2 = 2; //+X+Y (intermediate)
        const int gestureState3 = 3; //+X+Y+Y
        const int gestureState4 = 4; //+Z (intermediate)
        const int gestureState5 = 5; //+Z+X
        
        int result;
        int dequeueAx;
        int dequeueAy;
        int dequeueAz;

        int sumAx = 0;
        int sumAy = 0;
        int sumAz = 0;

        int prevResultAx=127; //assume starting flat
        int prevResultAy=126;
        int prevResultAz=154;
        
        int changeAx;
        int changeAy;
        int changeAz;

        ConcurrentQueue<Int32> rawDataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AxDataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AyDataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AzDataQueue = new ConcurrentQueue<Int32>();

        ConcurrentQueue<Int32> avgAxDataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> avgAyDataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> avgAzDataQueue = new ConcurrentQueue<Int32>();

        ConcurrentQueue<Int32> AxDerivativeQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AyDerivativeQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AzDerivativeQueue = new ConcurrentQueue<Int32>();


        int tempMaxAx=0;
        int tempMaxAy=0;
        int tempMaxAz=0;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            serialPort.Open();
            //labAvg.Text = "Max in g over last " + averageOver.ToString() + " data points";
        }

        private  void timer_Tick(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                txtSerialBufSize.Text = serialPort.BytesToRead.ToString();
                txtQueueSize.Text = rawDataQueue.Count.ToString();
            }

            //txtGesture.Text = receivedDataPoints.ToString();
            while (rawDataQueue.Count > 0)
            {

                rawDataQueue.TryDequeue(out result);

                if (result == 255 && dataState == state_normal)
                {
                    dataState = state_x;
                }

                else
                {
                    switch (dataState)
                    {
                        case state_x:
                            AxDataQueue.Enqueue(result);
                            avgAxDataQueue.Enqueue(result);
                            
                            
                            changeAx = result - prevResultAx;
                            AxDerivativeQueue.Enqueue(changeAx);

                            txtDeltaAx.Text=changeAx.ToString();
                            txtAx.Text = result.ToString();
                            displayOrientation(state_x);
                            
                            prevResultAx = result;

                            if(avgAxDataQueue.Count>100)
                            {
                                double mean = avgAxDataQueue.Average();

                                double sumOfSquares = avgAxDataQueue.Sum(point => Math.Pow(point - mean, 2));

                                double stdDev = Math.Sqrt(sumOfSquares / 100);
                                textBox1.Text = ((stdDev)/27).ToString();
                                avgAxDataQueue.TryDequeue(out int something1);
                            }


                            if(AxDataQueue.Count>averageOver)
                            {
                                if (Math.Abs(result-127) > tempMaxAx)
                                {
                                    tempMaxAx = result-127;
                                    AxDataQueue.TryDequeue(out int something);

                                }
                                txtAvgX.Text = ((float)tempMaxAx/27f).ToString();
                            }

                            dataState = state_y;
                            break;

                        case state_y:
                            AyDataQueue.Enqueue(result);
                            avgAyDataQueue.Enqueue(result);

                            changeAy = result - prevResultAy;
                            AyDerivativeQueue.Enqueue(changeAy);
                            txtDeltaAy.Text=changeAy.ToString();
                            txtAy.Text = result.ToString();
                            displayOrientation(state_y);
                            prevResultAy = result;


                            if (avgAyDataQueue.Count > 100)
                            {
                                double mean = avgAyDataQueue.Average();

                                double sumOfSquares = avgAyDataQueue.Sum(point => Math.Pow(point - mean, 2));

                                double stdDev = Math.Sqrt(sumOfSquares / 100);
                                textBox2.Text = ((stdDev) / 27).ToString();
                                avgAyDataQueue.TryDequeue(out int something1);
                            }

                            if (AyDataQueue.Count > averageOver)
                            {
                                if (Math.Abs(result - 127) > tempMaxAy)
                                {
                                    tempMaxAy = result - 127;
                                    AyDataQueue.TryDequeue(out int something);
                                }
                                txtAvgY.Text = ((float)tempMaxAy / 27f).ToString();
                            }
                            dataState = state_z;

                            break;

                        case state_z:
                            AzDataQueue.Enqueue(result);
                            avgAzDataQueue.Enqueue(result);

                            changeAz = result - prevResultAz;
                            AzDerivativeQueue.Enqueue(changeAz);
                            txtDeltaAz.Text=changeAz.ToString();    
                            txtAz.Text = result.ToString();
                            displayOrientation(state_z);
                            prevResultAz = result;

                            if (avgAzDataQueue.Count > 100)
                            {
                                double mean = avgAzDataQueue.Average();

                                double sumOfSquares = avgAzDataQueue.Sum(point => Math.Pow(point - mean, 2));

                                double stdDev = Math.Sqrt(sumOfSquares / 100);
                                textBox3.Text = ((stdDev) / 27).ToString();
                                avgAzDataQueue.TryDequeue(out int something1);
                            }


                            if (AzDataQueue.Count > averageOver)
                            {
                                if (Math.Abs(result - 127) > tempMaxAz)
                                {
                                    tempMaxAz = result - 127;
                                    AzDataQueue.TryDequeue(out int something);

                                }
                                txtAvgZ.Text = ((float)tempMaxAz / 27f).ToString();
                            }
                            dataState = state_normal;
                            break;

                    }

                    AxDerivativeQueue.TryDequeue(out dequeueAx);
                    AyDerivativeQueue.TryDequeue(out dequeueAy);
                    AzDerivativeQueue.TryDequeue(out dequeueAz);
                    
                    debug.Text = gestureState.ToString();
                    /*
                    Task.Delay(1000);
                    //Thread.Sleep(1000);
                    debug.Text = "";
                    */

                    

                    switch (gestureState)
                    {
                        
                        case gestureStateSearch: //look for anomaly in Ax, Ay, Az (case 0

                            if (dequeueAz > gestureLimitPlusAz) //first way to leave the search state is to find high +X
                            {
                                gestureState = gestureState1; //0->1
                                resetTimeout();
                                break;
                            }

                            else if (dequeueAz < gestureLimitMinusAz)
                            {
                                gestureState = gestureState4;  //0->4
                                resetTimeout();
                                break;
                            }
                            break;


                        case gestureState1:
                            //debug.Text = "1";
                            waitNumPoints(10);

                            if (dequeueAy > gestureLimitPlusAy)
                            {
                                gestureState = gestureState2;
                                resetTimeout();
                            }
                            break;

                        case gestureState2:
                            //debug.Text= "2";
                            waitNumPoints(10);
                            if (dequeueAy < gestureLimitMinusAy)
                            {
                                gestureState = gestureState3;
                                resetTimeout();

                            }

                            break;

                        case gestureState3:                      
                            waitNumPoints(5);
                            break;

                        case gestureState4:
                            debug.Text = "4";
                            waitNumPoints(10);

                            if (dequeueAx > gestureLimitPlusAx)
                            {
                                debug.Text = "A";
                                gestureState=gestureState5;
                                resetTimeout();

                            }
                            
                            break;

                        case gestureState5:
                            break;

                    }
                
                
                    
                    

                }



                }
            }

            private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
            {
                int newByte = 0;
                int bytesToRead;

                bytesToRead = serialPort.BytesToRead;

                while (bytesToRead != 0)
                {
                    newByte = serialPort.ReadByte();
                    rawDataQueue.Enqueue(Convert.ToInt32(newByte));
                    bytesToRead = serialPort.BytesToRead;
                }
            }

            private void displayOrientation(int state)
            {
                switch (state)
                {
                    case state_x:

                        if (result > orientation_limit_plus)
                        {
                            txtOrientation.Text = "+X";
                        }
                        else if (result < orientation_limit_minus)
                        {
                            txtOrientation.Text = "-X";
                        }

                        break;

                    case state_y:
                        if (result > orientation_limit_plus)
                        {
                            txtOrientation.Text = "+Y";
                        }
                        else if (result < orientation_limit_minus)
                        {
                            txtOrientation.Text = "-Y";

                        }
                        break;

                    case state_z:
                        if (result > orientation_limit_plus)
                        {
                            txtOrientation.Text = "+Z";
                        }
                        else if (result < orientation_limit_minus)
                        {
                            txtOrientation.Text = "-Z";

                        }
                        break;
                }

            }

            private float computeAverage(int state, int N)
            {

                switch (state)
                {
                    case state_x:
                        avgAxDataQueue.Enqueue(result);
                        
                        sumAx += result;

                        if (avgAxDataQueue.Count > N)
                        {
                            avgAxDataQueue.TryDequeue(out result);
                            sumAx -= result;
                            return sumAx / N;
                        }
                        else { 
                        return 0f; }



                    case state_y:
                        avgAyDataQueue.Enqueue(result);
                        sumAy += result;

                        if (avgAyDataQueue.Count > N)
                        {
                            avgAyDataQueue.TryDequeue(out result);
                            sumAy -= result;
                        return sumAy / N;
                        }
                        else
                        {
                        return 0f;
                        }


                case state_z:
                        avgAzDataQueue.Enqueue(result);
                        sumAz += result;
                        if (avgAzDataQueue.Count > N)
                        {
                            avgAzDataQueue.TryDequeue(out result);
                            sumAz -= result;
                            return sumAz / N;

                        }
                    else
                    {
                        return 0f;
                    }
                default:
                        return 0;
                }
            }

            private void waitNumPoints(int numPoints)
            {
                for(int i = 0; i < numPoints; i++)
                {
                    AxDataQueue.TryDequeue(out int result1);
                    AyDataQueue.TryDequeue(out int result2);
                    AyDataQueue.TryDequeue(out int result3);

            }

        }

        private void timeOut_Tick(object sender, EventArgs e)
        {
            txtGesture.Text = "";

            //txtGesture.Text="doing";

            switch (gestureState)
            {
                
                case gestureState4:
                    displayGesture("Free fall!");
                    break;

                    /*
                case gestureState2:
                    displayGesture("Nothing");
                    break;
                    */
                case gestureState3:
                    displayGesture("Wave!");
                    break;

                       /*
                case gestureState4:
                    displayGesture("Nothing");
                    break;
                       */
                case gestureState5:
                    displayGesture("Grave Digger!");
                    break;

                default:
                    displayGesture("Nothing.");
                    break;

            }
            gestureState = gestureStateSearch;
              

        }

        private void displayGesture(string message)
        {
            txtGesture.Text = message;
            //Task.Delay(1000);
            //txtGesture.Text = "";
        }

       
        private void resetTimeout()
        {
            timeOut.Enabled = false;
            timeOut.Enabled = true;
        }

        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Space)
            {
                MessageBox.Show("yay");
            }
        }
    }

        


    }


