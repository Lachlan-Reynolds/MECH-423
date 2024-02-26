namespace MECH423Lab1E4to9
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.ball = new System.Windows.Forms.PictureBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.shootBall = new System.Windows.Forms.Button();
            this.speed = new System.Windows.Forms.TrackBar();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.timerGraphics = new System.Windows.Forms.Timer(this.components);
            this.plankTop = new System.Windows.Forms.PictureBox();
            this.plankRight = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.plankLeft = new System.Windows.Forms.PictureBox();
            this.ballnum = new System.Windows.Forms.TextBox();
            this.ball2 = new System.Windows.Forms.PictureBox();
            this.ball3 = new System.Windows.Forms.PictureBox();
            this.background = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plankTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plankRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plankLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            this.SuspendLayout();
            // 
            // ball
            // 
            this.ball.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ball.BackgroundImage")));
            this.ball.InitialImage = null;
            this.ball.Location = new System.Drawing.Point(102, 504);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(100, 100);
            this.ball.TabIndex = 1;
            this.ball.TabStop = false;
            // 
            // serialPort
            // 
            this.serialPort.DtrEnable = true;
            this.serialPort.PortName = "COM3";
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Location = new System.Drawing.Point(43, 133);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(107, 38);
            this.textBox1.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox4.Location = new System.Drawing.Point(344, 44);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(80, 38);
            this.textBox4.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox3.Location = new System.Drawing.Point(163, 44);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(139, 38);
            this.textBox3.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox2.Location = new System.Drawing.Point(43, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(82, 38);
            this.textBox2.TabIndex = 3;
            // 
            // shootBall
            // 
            this.shootBall.Location = new System.Drawing.Point(783, 44);
            this.shootBall.Name = "shootBall";
            this.shootBall.Size = new System.Drawing.Size(207, 76);
            this.shootBall.TabIndex = 6;
            this.shootBall.Text = "FIRE!";
            this.shootBall.UseVisualStyleBackColor = true;
            this.shootBall.Click += new System.EventHandler(this.shootBall_Click);
            // 
            // speed
            // 
            this.speed.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.speed.Location = new System.Drawing.Point(1085, 44);
            this.speed.Maximum = 50;
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(860, 114);
            this.speed.TabIndex = 7;
            this.speed.Tag = "";
            this.speed.Scroll += new System.EventHandler(this.speed_Scroll);
            this.speed.ValueChanged += new System.EventHandler(this.speed_ValueChanged);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(189, 133);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(184, 38);
            this.textBox5.TabIndex = 8;
            // 
            // timerGraphics
            // 
            this.timerGraphics.Tick += new System.EventHandler(this.timerGraphics_Tick);
            // 
            // plankTop
            // 
            this.plankTop.BackColor = System.Drawing.SystemColors.Desktop;
            this.plankTop.Location = new System.Drawing.Point(1810, 778);
            this.plankTop.Name = "plankTop";
            this.plankTop.Size = new System.Drawing.Size(300, 50);
            this.plankTop.TabIndex = 12;
            this.plankTop.TabStop = false;
            // 
            // plankRight
            // 
            this.plankRight.BackColor = System.Drawing.SystemColors.Desktop;
            this.plankRight.Location = new System.Drawing.Point(1439, 533);
            this.plankRight.Name = "plankRight";
            this.plankRight.Size = new System.Drawing.Size(300, 50);
            this.plankRight.TabIndex = 13;
            this.plankRight.TabStop = false;
            // 
            // plankLeft
            // 
            this.plankLeft.BackColor = System.Drawing.SystemColors.Desktop;
            this.plankLeft.Location = new System.Drawing.Point(1117, 751);
            this.plankLeft.Name = "plankLeft";
            this.plankLeft.Size = new System.Drawing.Size(300, 50);
            this.plankLeft.TabIndex = 16;
            this.plankLeft.TabStop = false;
            // 
            // ballnum
            // 
            this.ballnum.Location = new System.Drawing.Point(85, 236);
            this.ballnum.Name = "ballnum";
            this.ballnum.Size = new System.Drawing.Size(100, 38);
            this.ballnum.TabIndex = 17;
            // 
            // ball2
            // 
            this.ball2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ball2.BackgroundImage")));
            this.ball2.Location = new System.Drawing.Point(220, 778);
            this.ball2.Name = "ball2";
            this.ball2.Size = new System.Drawing.Size(100, 100);
            this.ball2.TabIndex = 18;
            this.ball2.TabStop = false;
            // 
            // ball3
            // 
            this.ball3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ball3.BackgroundImage")));
            this.ball3.Location = new System.Drawing.Point(337, 403);
            this.ball3.Name = "ball3";
            this.ball3.Size = new System.Drawing.Size(100, 100);
            this.ball3.TabIndex = 19;
            this.ball3.TabStop = false;
            // 
            // background
            // 
            this.background.Location = new System.Drawing.Point(344, 254);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(2018, 802);
            this.background.TabIndex = 20;
            this.background.TabStop = false;
            this.background.Paint += new System.Windows.Forms.PaintEventHandler(this.background_Paint);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2534, 1552);
            this.Controls.Add(this.ball3);
            this.Controls.Add(this.ball2);
            this.Controls.Add(this.ballnum);
            this.Controls.Add(this.plankLeft);
            this.Controls.Add(this.plankRight);
            this.Controls.Add(this.plankTop);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.shootBall);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.background);
            this.Name = "Form5";
            this.Text = "\'";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plankTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plankRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plankLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ball;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button shootBall;
        private System.Windows.Forms.TrackBar speed;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Timer timerGraphics;
        private System.Windows.Forms.PictureBox plankTop;
        private System.Windows.Forms.PictureBox plankRight;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox plankLeft;
        private System.Windows.Forms.TextBox ballnum;
        private System.Windows.Forms.PictureBox ball2;
        private System.Windows.Forms.PictureBox ball3;
        private System.Windows.Forms.PictureBox background;
    }
}