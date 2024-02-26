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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Media;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Net.Mime.MediaTypeNames;

namespace MECH423Lab1E4to9
{
    public partial class Form6 : Form
    {

        //public event EventHandler allPictureBoxesDisabled;
        //Reading Value from accelerometer
        int dataState;
        const int state_normal = 0;
        const int state_x = 1;
        const int state_y = 2;
        const int state_z = 3;

        //Individual Separate Dequeues
        int dequeueAx;
        int dequeueAy;
        int dequeueAz;

        int changeAx;
        int changeAy;
        int changeAz;

        int prevResultAx = 127; //assume starting flat
        int prevResultAy = 126;
        int prevResultAz = 154;

        int result;

        //Velocities
        int initialVelocityX;
        int initialVelocityY;
        int velocityX;
        int velocityY;
        int steveVelocity;
        double pitch;

        //accelerations
        const int globalAcceleration = 2;
        const double globalElasticity = 0.8;
        const int gestureLimitPlus = 140;
        const int gestureLimitMinus = 105;

        //Data Acquisition Queues
        ConcurrentQueue<Int32> rawDataQueue = new ConcurrentQueue<Int32>();

        ConcurrentQueue<Int32> AxDataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AyDataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AzDataQueue = new ConcurrentQueue<Int32>();

        ConcurrentQueue<Int32> AxDerivativeQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AyDerivativeQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> AzDerivativeQueue = new ConcurrentQueue<Int32>();

        //Trajectory plot
        private Point[] trajectoryPoints;
        private int pointIndex = 0;

        //Choose a ball
        private Random random = new Random();
        const int totalTargets = 3;
        const int numSteve = 1;
        const int numPig = 2;
        const int numFox = 3;
        const int minValue = numSteve;
        const int maxValue = totalTargets;
        int ballState;
        Boolean flyingFlag = false;
        int numTargets = totalTargets;
        
        //sound effics
        System.Media.SoundPlayer shot = new SoundPlayer(@"C:\Users\Lachlan Reynolds\Downloads\Cannon_Back_Powder_Shot.wav");
        System.Media.SoundPlayer rope = new SoundPlayer(@"C:\Users\Lachlan Reynolds\Downloads\rope-under-tension-7144.wav");
        System.Media.SoundPlayer creeperCollision = new SoundPlayer(@"C:\Users\Lachlan Reynolds\Downloads\minecraft-explode1.wav");
        System.Media.SoundPlayer endermanCollision = new SoundPlayer(@"C:\Users\Lachlan Reynolds\Downloads\death---endermen-made-with-Voicemod-technology.wav");
        System.Media.SoundPlayer zombieCollision = new SoundPlayer(@"C:\Users\Lachlan Reynolds\Downloads\steve_ooh_alpha_minecraft.wav");
        System.Media.SoundPlayer starting = new SoundPlayer(@"C:\Users\Lachlan Reynolds\Downloads\minecraft-starting-song.wav");
        System.Media.SoundPlayer backgroundMusic = new SoundPlayer(@"C:\Users\Lachlan Reynolds\Downloads\stal_3gLVUnL.wav");

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            serialPort.Open();
            background.Paint += background_Paint;
            this.MouseWheel += new MouseEventHandler(background_MouseWheel);
            ballState = initializeBalls();
            //ballState = 1;
            tutorialSetup();
            starting.Play();
            
            creeper.EnabledChanged += target_EnabledChanged;
            enderman.EnabledChanged += target_EnabledChanged;
            zombie.EnabledChanged += target_EnabledChanged;
            
        }


        private void timerMain_Tick(object sender, EventArgs e)
        {
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
                            changeAx = result - prevResultAx;
                            AxDerivativeQueue.Enqueue(changeAx);
                            textBox1.Text = result.ToString();
                            prevResultAx = result;
                            dataState = state_y;

                            break;

                        case state_y:
                            AyDataQueue.Enqueue(result);
                            changeAy = result - prevResultAy;
                            AyDerivativeQueue.Enqueue(changeAy);
                            textBox2.Text = result.ToString();
                            prevResultAy = result;
                            dataState = state_z;
                            break;

                        case state_z:
                            AzDataQueue.Enqueue(result);
                            changeAz = result - prevResultAz;
                            AzDerivativeQueue.Enqueue(changeAz);
                            textBox3.Text = result.ToString();
                            prevResultAz = result;
                            dataState = state_normal;
                            break;

                    }

                    if (AxDataQueue.TryDequeue(out dequeueAx) && AyDataQueue.TryDequeue(out dequeueAy) && AzDataQueue.TryDequeue(out dequeueAz))
                    {
                        pitch = calculatePitch(dequeueAx, dequeueAy, dequeueAz); //in rad
                        textBox4.Text = Math.Round(180 * pitch / Math.PI, 0).ToString();

                        if (dequeueAx > gestureLimitPlus && ballState == numPig)
                        {
                            velocityX = (int)(velocityY * 1.2); //pig's special ability is to accelerate downwards
                        }

                        if (dequeueAx < gestureLimitMinus && ballState == numFox)
                        {
                            velocityX = (int)(velocityX * 1.2); //fox's special ability is to go faster when away flick 


                        }


                    }


                }

            }

        }


        private void timerGraphics_Tick(object sender, EventArgs e)
        {
            AxDataQueue.TryDequeue(out dequeueAx);

            const int numPoints = 100;
            trajectoryPoints = new Point[numPoints];

            Point newLocationBall;

            switch (ballState)
            {
                case numSteve:


                    //do everything for steve
                    velocityY = velocityY + globalAcceleration;
                    newLocationBall = new Point(steve.Location.X + velocityX, steve.Location.Y + velocityY);
                    steve.Location = newLocationBall;


                    if (steve.Location.Y >= Height - 2 * steve.Height)
                    {
                        velocityY = velocityY * -1;
                    }

                    if (steve.Bounds.IntersectsWith(platformTop.Bounds) 
                        || steve.Bounds.IntersectsWith(platformMid.Bounds) 
                        || steve.Bounds.IntersectsWith(platformBot.Bounds))
                    {
                        if (steve.Location.Y + steve.Height > platformBot.Location.Y //detect vertical wall to 
                            || steve.Location.Y + steve.Height > platformMid.Location.Y
                            || steve.Location.Y + steve.Height > platformTop.Location.Y)
                        {
                            velocityY = (int)(velocityY * -1 * globalElasticity);
                        }

                        /*
                        if (steve.Location.X + steve.Width > platformBot.Location.X //detect vertical wall to 
                            || steve.Location.X + steve.Width > platformMid.Location.X
                            || steve.Location.X + steve.Width > platformTop.Location.X)
                        {
                            velocityX = (int)(velocityX * -1 * globalElasticity);
                        }
                        */
                    }

                   
                    
                    

                    if (steve.Bounds.IntersectsWith(creeper.Bounds))
                    {
                        creeperCollision.Play();
                        creeper.BackgroundImage = null;
                        creeper.Enabled = false;
                        creeper.Visible=false;

                    }

                    if (steve.Bounds.IntersectsWith(enderman.Bounds))
                    {
                        endermanCollision.Play();
                        enderman.BackgroundImage = null;
                        enderman.Enabled = false;
                        enderman.Visible=false;

                    }

                    if (steve.Bounds.IntersectsWith(zombie.Bounds))
                    {
                        zombieCollision.Play();
                        zombie.BackgroundImage = null;
                        zombie.Enabled = false;
                        zombie.Visible = false;
                    }

                    if (steve.Location.X > Width || steve.Location.X < -1 * (steve.Width + 1))
                    {
                        pig.Enabled = true;
                        pig.Visible = true;
                        ballState = numPig;
                        initialConditions();
                    }
                    
                    
                    
                    break;

                case numPig:
                    //do everything for pig
                    velocityY = velocityY + globalAcceleration;
                    newLocationBall = new Point(pig.Location.X + velocityX, pig.Location.Y + velocityY);
                    pig.Location = newLocationBall;

                    if (pig.Location.Y >= Height - 2 * pig.Height)
                    {
                        velocityY = velocityY * -1;
                    }

                    if (pig.Bounds.IntersectsWith(platformTop.Bounds)
                        || pig.Bounds.IntersectsWith(platformMid.Bounds)
                        || pig.Bounds.IntersectsWith(platformBot.Bounds))
                    {
                        if (pig.Location.Y + pig.Height > platformBot.Location.Y //detect vertical wall to 
                            || pig.Location.Y + pig.Height > platformMid.Location.Y
                            || pig.Location.Y + pig.Height > platformTop.Location.Y)
                        {
                            velocityY = (int)(velocityY * -1 * globalElasticity);
                        }

                        /*
                        if (pig.Location.X + pig.Width > platformBot.Location.X //detect vertical wall to 
                            || pig.Location.X + pig.Width > platformMid.Location.X
                            || pig.Location.X + pig.Width > platformTop.Location.X)
                        {
                            velocityX = (int)(velocityX * -1 * globalElasticity);
                        }
                        */
                    }

                    if (pig.Bounds.IntersectsWith(creeper.Bounds))
                    {
                        creeperCollision.Play();
                        creeper.BackgroundImage = null;
                        creeper.Enabled = false;
                        creeper.Visible = false;

                    }

                    if (pig.Bounds.IntersectsWith(enderman.Bounds))
                    {
                        endermanCollision.Play();
                        enderman.BackgroundImage = null;
                        enderman.Enabled = false;
                        enderman.Visible = false;

                    }

                    if (pig.Bounds.IntersectsWith(zombie.Bounds))
                    {
                        zombieCollision.Play();
                        zombie.BackgroundImage = null;
                        zombie.Enabled = false;
                        zombie.Visible = false;

                    }



                    if (pig.Location.X > Width || pig.Location.X<-1*(pig.Width+1))
                    {
                        fox.Enabled = true;
                        fox.Visible = true;
                        ballState=numFox;
                        initialConditions();
                    }
                    break;

                case numFox:
                    //do everything for fox
                    velocityY = velocityY + globalAcceleration;
                    newLocationBall = new Point(fox.Location.X + velocityX, fox.Location.Y + velocityY);
                    fox.Location = newLocationBall;

                    if (fox.Location.Y >= Height - 2 * fox.Height)
                    {
                        velocityY = velocityY * -1;
                    }

                    if (fox.Bounds.IntersectsWith(platformTop.Bounds)
                        || fox.Bounds.IntersectsWith(platformMid.Bounds)
                        || fox.Bounds.IntersectsWith(platformBot.Bounds))
                    {
                        if (fox.Location.Y + fox.Height > platformBot.Location.Y //detect vertical wall to 
                            || fox.Location.Y + fox.Height > platformMid.Location.Y
                            || fox.Location.Y + fox.Height > platformTop.Location.Y)
                        {
                            velocityY = (int)(velocityY * -1 * globalElasticity);
                        }

                        /*
                        if (fox.Location.X + fox.Width > platformBot.Location.X //detect vertical wall to 
                            || fox.Location.X + fox.Width > platformMid.Location.X
                            || fox.Location.X + fox.Width > platformTop.Location.X)
                        {
                            velocityX = (int)(velocityX * -1 * globalElasticity);
                        }
                        */
                    }

                    if (fox.Bounds.IntersectsWith(creeper.Bounds))
                    {
                        creeperCollision.Play();
                        creeper.BackgroundImage = null;
                        creeper.Enabled = false;
                        creeper.Visible = false;

                    }

                    if (fox.Bounds.IntersectsWith(enderman.Bounds))
                    {
                        enderman.BackgroundImage = null;
                        endermanCollision.Play();
                        enderman.Enabled = false;
                        enderman.Visible = false;

                    }

                    if (fox.Bounds.IntersectsWith(zombie.Bounds))
                    {
                        zombie.BackgroundImage = null;
                        zombieCollision.Play();
                        zombie.Enabled = false;
                        zombie.Visible = false;
                    }



                    if (fox.Location.X > Width|| fox.Location.X<-1*(fox.Width+1))
                    {
                        steve.Enabled = true;
                        steve.Visible = true;
                        ballState = numSteve;
                        initialConditions();
                    }

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

            return Math.Atan2((-1 * Ay), Math.Sqrt(Ax * Ax + Az * Az));
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

        private void initializeTrajectory()
        {
            const int numPoints = 100;
            trajectoryPoints = new Point[numPoints];

            switch (ballState)
            {

                case numSteve:
                    //trajectoryPoints[0]=new Point(steve.Location.X,steve.Location.Y);
                    for (int i = 0; i < numPoints; i++)
                    {
                        int x = steve.Location.X + steve.Width / 2 + 5 * i;
                        //int x=
                        int y = steve.Location.Y + steve.Height / 2 - (int)(calculateTrajectory(x - steve.Location.X, pitch, steveVelocity));
                        //int y = (int)(x * Math.Tan(pitch) - (globalAcceleration * Math.Pow(x, 2))/(2.0*Math.Pow(steveVelocity*Math.Cos(pitch),2)));
                        trajectoryPoints[i] = new Point(x, y);
                    }


                    break;

                case numPig:
                    for (int i = 0; i < numPoints; i++)
                    {
                        int x = pig.Location.X + pig.Width / 2 + 5 * i;
                        //int x=
                        int y = pig.Location.Y + pig.Height / 2 - (int)(calculateTrajectory(x - steve.Location.X, pitch, steveVelocity));
                        //int y = (int)(x * Math.Tan(pitch) - (globalAcceleration * Math.Pow(x, 2))/(2.0*Math.Pow(steveVelocity*Math.Cos(pitch),2)));
                        trajectoryPoints[i] = new Point(x, y);
                    }

                    break;

                case numFox:
                    for (int i = 0; i < numPoints; i++)
                    {
                        int x = fox.Location.X + fox.Width / 2 + 5 * i;
                        //int x=
                        int y = fox.Location.Y + fox.Height / 2 - (int)(calculateTrajectory(x - fox.Location.X, pitch, steveVelocity));
                        //int y = (int)(x * Math.Tan(pitch) - (globalAcceleration * Math.Pow(x, 2))/(2.0*Math.Pow(steveVelocity*Math.Cos(pitch),2)));
                        trajectoryPoints[i] = new Point(x, y);
                    }


                    break;

            }

            //trajectoryPoints[0]=new Point(steve.Location.X,steve.Location.Y);
            for (int i = 0; i < numPoints; i++)
            {
                int x = steve.Location.X + steve.Width / 2 + 5 * i;
                //int x=
                int y = steve.Location.Y + steve.Height / 2 - (int)(calculateTrajectory(x - steve.Location.X, pitch, steveVelocity));
                //int y = (int)(x * Math.Tan(pitch) - (globalAcceleration * Math.Pow(x, 2))/(2.0*Math.Pow(steveVelocity*Math.Cos(pitch),2)));
                trajectoryPoints[i] = new Point(x, y);
            }
        }

        private void background_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Pen pen = new Pen(System.Drawing.Color.Blue, 2);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int i = 0; i < pointIndex - 1; i++)
            {
                g.DrawLine(pen, trajectoryPoints[i], trajectoryPoints[i + 1]);
            }

        }

        private void timerTrajectory_Tick(object sender, EventArgs e)
        {
            if (pointIndex < trajectoryPoints.Length)
            {
                background.Invalidate();
                pointIndex++;
            }
            else
            {
                timerTrajectory.Stop();
            }
        }

        private double calculateTrajectory(int x, double pitch, int velocity)
        {
            double term1 = x * Math.Tan(pitch);
            double term2 = globalAcceleration * x * x;
            double term3 = 2.0 * velocity * velocity * Math.Cos(pitch) * Math.Cos(pitch);

            return term1 - term2 / term3;
        }

        private int initializeBalls()
        {
            steve.Visible = false;
            steve.Enabled = false;

            pig.Visible = false;
            pig.Enabled = false;

            fox.Visible = false;
            fox.Enabled = false;

            int randomNumber = random.Next(minValue, maxValue + 1);

            switch (randomNumber)
            {
                case numSteve:
                    steve.Visible = true;
                    steve.Enabled = true;
                    break;
                case numPig:
                    pig.Visible = true;
                    pig.Enabled = true;
                    break;
                case numFox:
                    fox.Visible = true;
                    fox.Enabled = true;
                    break;
            }

            return randomNumber;
        }

        private void initialConditions()
        {
            steveVelocity = 0;
            velocityX = 0;
            velocityY = 0;
            timerGraphics.Enabled = false;
            flyingFlag = false;
        } 

        private void background_MouseDown(object sender, MouseEventArgs e)
        {
            if (flyingFlag)
            {
                return;
            }

            if(e.Button == MouseButtons.Left) //shoot
            {
                flyingFlag = true;
                initialVelocityX = (int)(steveVelocity * Math.Cos(pitch));
                initialVelocityY = -(int)(steveVelocity * Math.Sin(pitch));
                velocityX = initialVelocityX;
                velocityY = initialVelocityY;
                shot.Play();
                timerGraphics.Enabled = true;
            }

            if(e.Button == MouseButtons.Right) //preview trajectory
            {
                initializeTrajectory();
                pointIndex = 0; // Reset point index
                timerTrajectory.Start(); // Start the animation
            }

        }

        private void tutorialSetup()
        {
            string line1 = "Tutorial: \r\n";
            string line2 = "Scroll Up increases speed \r\n";
            string line3 = "Scroll Down decreases speed \r\n";
            string line4 = "Pitch up to increase angle \r\n";
            string line5 = "Pitch down to decrease angle \r\n";
            string line6 = "Left Click to preview trajectory \r\n";
            string line7 = "Right Click to shoot \r\n";
            string line8 = "Roll towards for Pig Special Ability \r\n";
            string line9 = "Roll away for Fox Special Ability \r\n";
            string line10 = "Click when ready!";
            //tutorial.Text = line1 +"\n" + line2 + line3 + line4 + line5 + line6 + line7 + line8+line9;
            tutorial.AppendText(line1);
            tutorial.AppendText(line2);
            tutorial.AppendText(line3);
            tutorial.AppendText(line4);
            tutorial.AppendText(line5);
            tutorial.AppendText(line6);
            tutorial.AppendText(line7);
            tutorial.AppendText(line8);
            tutorial.AppendText(line9);
            tutorial.AppendText(line10);

            
        }

        private void background_MouseWheel(object sender, MouseEventArgs e)
        {
            int delta = e.Delta;

            if (delta > 0)
            {
                steveVelocity++;
            }

            else if (delta < 0)
            {
                steveVelocity--;
            }

        }

        private void tutorial_MouseClick(object sender, MouseEventArgs e)
        {
            tutorial.Visible = false;
            starting.Stop();
            //backgroundMusic.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

        }
        
        private void target_EnabledChanged(object sender, EventArgs e)
        {
            if (creeper.Enabled == false && enderman.Enabled == false && zombie.Enabled == false)
            {
                MessageBox.Show("You Win!");
                System.Windows.Forms.Application.Exit();
            }
        }
        
    }
}

