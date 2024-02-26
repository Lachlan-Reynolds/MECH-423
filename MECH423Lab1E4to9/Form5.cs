using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.Media;
using System.Security.Cryptography;

namespace MECH423Lab1E4to9
{

    public partial class Form5 : Form
    {
        int dataState;
        const int state_normal = 0;
        const int state_x = 1;
        const int state_y = 2;
        const int state_z = 3;

        int dequeueAx;
        int dequeueAy;
        int dequeueAz;

        int result;

        const int ballMass = 5;
        const int plankMass = 3;
        
        int plankVelocityX;
        int plankVelocityY;

        double pitch;
        int ballVelocity;
        Boolean collisionFlag = false;

        const int globalAcceleration = 2;
        const double collisionElasticity = 0.6;
        //string plankPNG = @"C:\Users\Lachlan Reynolds\Desktop\plank.png";
        Bitmap originalImage = new Bitmap(@"C:\Users\Lachlan Reynolds\Desktop\plank.png");
        int positionX=0;
        int positionY=0;
        
        int initialVelocityX;
        int initialVelocityY;
        int ballVelocityX;
        int ballVelocityY;

        ConcurrentQueue<Int32> rawDataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AxDataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AyDataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AzDataQueue = new ConcurrentQueue<Int32>();

        System.Media.SoundPlayer shot = new SoundPlayer(@"C:\Users\Lachlan Reynolds\Downloads\Cannon_Back_Powder_Shot.wav");
        System.Media.SoundPlayer rope = new SoundPlayer(@"C:\Users\Lachlan Reynolds\Downloads\rope-under-tension-7144.wav");

        private Random random = new Random();

        Point[] trajectoryPoints;
        int pointIndex = 0;
        public Form5()
        {
            InitializeComponent();
           
        }

        private void timer_Tick(object sender, EventArgs e)
        {

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
                            textBox1.Text =result.ToString();   
                            dataState = state_y;
                            break;

                        case state_y:
                            AyDataQueue.Enqueue(result);
                            textBox2.Text =result.ToString();
                            dataState = state_z;
                            
                            break;

                        case state_z:
                            AzDataQueue.Enqueue(result);
                            textBox3.Text =result.ToString();   
                            dataState = state_normal;
                            break;

                    }

                    if (AxDataQueue.TryDequeue(out dequeueAx)&& AyDataQueue.TryDequeue(out dequeueAy) && AzDataQueue.TryDequeue(out dequeueAz))
                    {
                        pitch = calculatePitch(dequeueAx, dequeueAy, dequeueAz);
                        textBox1.Text = Math.Round(180*pitch/Math.PI,0).ToString();
                    }


                    textBox4.Text=ballVelocity.ToString();
                }

            }

            if (pointIndex < trajectoryPoints.Length)
            {
                background.Invalidate();
                pointIndex++;
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

        private void Form5_Load(object sender, EventArgs e)
        {
            //initializeTrajectory();

            serialPort.Open();

            ball.Visible = false;
            ball.Enabled = false;

            ball2.Visible = false;
            ball2.Enabled = false;

            ball3.Visible = false;
            ball3.Enabled = false;

            int minValue = 1;
            int maxValue = 3;
            int randomNumber = random.Next(minValue, maxValue + 1);

            ballnum.Text = randomNumber.ToString();

            switch (randomNumber)
            {
                case 1:
                    //normal ball
                    ball.Visible = true;
                    ball.Enabled = true;
                    break;
                case 2:
                    //triple ball
                    ball2.Visible = true;
                    ball2.Enabled = true;
                    break;
                case 3:
                    ball3.Visible= true;
                    ball3.Enabled = true;
                    break;
            }

        }

        private double calculatePitch(int dequeueAx, int dequeueAy, int dequeueAz)
        {
            double Ax;
            double Ay;
            double Az;


            Ax = ((double)(dequeueAx - 127));
            Ay = ((double)(dequeueAy - 126));
            Az = ((double)(dequeueAz - 129));

            return Math.Atan2((-1 * Ay),Math.Sqrt(Ax * Ax + Az * Az)) ;
        }

        private void speed_Scroll(object sender, EventArgs e)
        {
            ballVelocity = speed.Value;
        }

        private void timerGraphics_Tick(object sender, EventArgs e)
        {
            Point newLocationBall;
            ballVelocityY = ballVelocityY +globalAcceleration;
            newLocationBall = new Point(ball.Location.X + ballVelocityX, ball.Location.Y + ballVelocityY); 
            ball.Location = newLocationBall;



            if (ball.Location.Y >= Height - 2*ball.Height)
            {
                ballVelocityY = ballVelocityY * -1;
            }
            /*
            if(ball.Bounds.IntersectsWith(target1.Bounds))
            {
                target1.Image = null;
                target1.Image = Image.FromFile(@"C:\Users\Lachlan Reynolds\Desktop\00ae53a95ee7af0be395f5291d792c9a_w200.gif");
                await Task.Delay(2000);
                target1.Visible = false;
                target1.Enabled = false;
            }
            */
            if (ball.Bounds.IntersectsWith(plankLeft.Bounds))
            {

                plankVelocityX = (int)(ballVelocityX * ballMass*collisionElasticity / plankMass);
                plankVelocityY =(int)(ballVelocityY * ballMass*collisionElasticity / plankMass);
                ballVelocityX = (int)((1-collisionElasticity)*ballVelocityX);
                ballVelocityY = (int)((1 - collisionElasticity) * ballVelocityY);
                collisionFlag = true;
            }

            if (collisionFlag)
            {
                plankVelocityY += globalAcceleration;
            }

            Point newLocationPlankLeft;
            newLocationPlankLeft = new Point(plankLeft.Location.X +plankVelocityX, plankLeft.Location.Y+plankVelocityY);
            plankLeft.Location = newLocationPlankLeft;




        }

        private void shootBall_Click(object sender, EventArgs e)
        {
            initialVelocityX = (int)(ballVelocity * Math.Cos(pitch));
            initialVelocityY = -(int)(ballVelocity * Math.Sin(pitch));
            ballVelocityX = initialVelocityX;
            ballVelocityY = initialVelocityY;
            timerGraphics.Enabled = true;

            rope.Stop();
            shot.Play();

        }

        private void speed_ValueChanged(object sender, EventArgs e)
        {
            rope.Play();


        }

        private void initializeTrajectory()
        {
            const int numPoints = 100;
            trajectoryPoints=new Point[numPoints];

            for(int i=0; i < numPoints; i++)
            {
                int x = 5*i;
                int y = (int)(-0.1 * Math.Pow(x - 50, 2) + 100);
                trajectoryPoints[i] = new Point(x, y);
            }
        }

        private void background_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g=e.Graphics)
            {
                g.SmoothingMode=System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen pen =new Pen(Color.Blue,2);
                
                for(int i = 0;i<pointIndex-1;i++)
                {
                    g.DrawLine(pen, trajectoryPoints[i], trajectoryPoints[i + 1]);
                }
            }
        }
    }
}
