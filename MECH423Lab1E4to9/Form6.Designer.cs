namespace MECH423Lab1E4to9
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.timerGraphics = new System.Windows.Forms.Timer(this.components);
            this.steve = new System.Windows.Forms.PictureBox();
            this.background = new System.Windows.Forms.PictureBox();
            this.timerTrajectory = new System.Windows.Forms.Timer(this.components);
            this.pig = new System.Windows.Forms.PictureBox();
            this.fox = new System.Windows.Forms.PictureBox();
            this.enderman = new System.Windows.Forms.PictureBox();
            this.zombie = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.platformTop = new System.Windows.Forms.PictureBox();
            this.platformBot = new System.Windows.Forms.PictureBox();
            this.creeper = new System.Windows.Forms.PictureBox();
            this.platformMid = new System.Windows.Forms.PictureBox();
            this.tutorial = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.steve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enderman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zombie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platformTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platformBot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.creeper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platformMid)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.PortName = "COM3";
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // timerMain
            // 
            this.timerMain.Enabled = true;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // timerGraphics
            // 
            this.timerGraphics.Interval = 50;
            this.timerGraphics.Tick += new System.EventHandler(this.timerGraphics_Tick);
            // 
            // steve
            // 
            this.steve.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("steve.BackgroundImage")));
            this.steve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.steve.Location = new System.Drawing.Point(165, 987);
            this.steve.Name = "steve";
            this.steve.Size = new System.Drawing.Size(100, 100);
            this.steve.TabIndex = 21;
            this.steve.TabStop = false;
            // 
            // background
            // 
            this.background.BackColor = System.Drawing.Color.Transparent;
            this.background.Location = new System.Drawing.Point(34, 12);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(2428, 1270);
            this.background.TabIndex = 22;
            this.background.TabStop = false;
            this.background.Paint += new System.Windows.Forms.PaintEventHandler(this.background_Paint);
            this.background.MouseDown += new System.Windows.Forms.MouseEventHandler(this.background_MouseDown);
            // 
            // timerTrajectory
            // 
            this.timerTrajectory.Interval = 50;
            this.timerTrajectory.Tick += new System.EventHandler(this.timerTrajectory_Tick);
            // 
            // pig
            // 
            this.pig.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pig.BackgroundImage")));
            this.pig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pig.Location = new System.Drawing.Point(165, 987);
            this.pig.Name = "pig";
            this.pig.Size = new System.Drawing.Size(100, 100);
            this.pig.TabIndex = 26;
            this.pig.TabStop = false;
            // 
            // fox
            // 
            this.fox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fox.BackgroundImage")));
            this.fox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fox.Location = new System.Drawing.Point(165, 987);
            this.fox.Name = "fox";
            this.fox.Size = new System.Drawing.Size(100, 100);
            this.fox.TabIndex = 27;
            this.fox.TabStop = false;
            // 
            // enderman
            // 
            this.enderman.BackColor = System.Drawing.Color.Transparent;
            this.enderman.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("enderman.BackgroundImage")));
            this.enderman.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.enderman.Location = new System.Drawing.Point(2123, 823);
            this.enderman.Name = "enderman";
            this.enderman.Size = new System.Drawing.Size(166, 311);
            this.enderman.TabIndex = 29;
            this.enderman.TabStop = false;
            // 
            // zombie
            // 
            this.zombie.BackColor = System.Drawing.Color.Transparent;
            this.zombie.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("zombie.BackgroundImage")));
            this.zombie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zombie.Location = new System.Drawing.Point(984, 172);
            this.zombie.Name = "zombie";
            this.zombie.Size = new System.Drawing.Size(201, 305);
            this.zombie.TabIndex = 30;
            this.zombie.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(2122, 151);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 38);
            this.textBox1.TabIndex = 31;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(2158, 259);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(284, 38);
            this.textBox2.TabIndex = 32;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(2172, 357);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(202, 38);
            this.textBox3.TabIndex = 33;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(2213, 456);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(192, 38);
            this.textBox4.TabIndex = 34;
            // 
            // platformTop
            // 
            this.platformTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("platformTop.BackgroundImage")));
            this.platformTop.Location = new System.Drawing.Point(901, 436);
            this.platformTop.Name = "platformTop";
            this.platformTop.Size = new System.Drawing.Size(400, 50);
            this.platformTop.TabIndex = 35;
            this.platformTop.TabStop = false;
            // 
            // platformBot
            // 
            this.platformBot.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("platformBot.BackgroundImage")));
            this.platformBot.Location = new System.Drawing.Point(2039, 1107);
            this.platformBot.Name = "platformBot";
            this.platformBot.Size = new System.Drawing.Size(350, 50);
            this.platformBot.TabIndex = 36;
            this.platformBot.TabStop = false;
            // 
            // creeper
            // 
            this.creeper.BackColor = System.Drawing.Color.Transparent;
            this.creeper.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("creeper.BackgroundImage")));
            this.creeper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.creeper.Cursor = System.Windows.Forms.Cursors.Cross;
            this.creeper.Location = new System.Drawing.Point(1588, 357);
            this.creeper.Name = "creeper";
            this.creeper.Size = new System.Drawing.Size(258, 276);
            this.creeper.TabIndex = 28;
            this.creeper.TabStop = false;
            // 
            // platformMid
            // 
            this.platformMid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("platformMid.BackgroundImage")));
            this.platformMid.Cursor = System.Windows.Forms.Cursors.Cross;
            this.platformMid.Location = new System.Drawing.Point(1522, 595);
            this.platformMid.Name = "platformMid";
            this.platformMid.Size = new System.Drawing.Size(350, 50);
            this.platformMid.TabIndex = 38;
            this.platformMid.TabStop = false;
            // 
            // tutorial
            // 
            this.tutorial.Font = new System.Drawing.Font("Lucida Calligraphy", 20.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tutorial.Location = new System.Drawing.Point(165, 151);
            this.tutorial.Multiline = true;
            this.tutorial.Name = "tutorial";
            this.tutorial.Size = new System.Drawing.Size(2224, 1015);
            this.tutorial.TabIndex = 39;
            this.tutorial.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tutorial_MouseClick);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(2568, 1317);
            this.Controls.Add(this.tutorial);
            this.Controls.Add(this.platformMid);
            this.Controls.Add(this.platformBot);
            this.Controls.Add(this.platformTop);
            this.Controls.Add(this.fox);
            this.Controls.Add(this.pig);
            this.Controls.Add(this.steve);
            this.Controls.Add(this.creeper);
            this.Controls.Add(this.enderman);
            this.Controls.Add(this.zombie);
            this.Controls.Add(this.background);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox4);
            this.ForeColor = System.Drawing.Color.Coral;
            this.HelpButton = true;
            this.Name = "Form6";
            this.Text = "Form6";
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.steve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enderman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zombie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platformTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platformBot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.creeper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platformMid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.Timer timerGraphics;
        private System.Windows.Forms.PictureBox steve;
        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.Timer timerTrajectory;
        private System.Windows.Forms.PictureBox pig;
        private System.Windows.Forms.PictureBox fox;
        private System.Windows.Forms.PictureBox enderman;
        private System.Windows.Forms.PictureBox zombie;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.PictureBox platformTop;
        private System.Windows.Forms.PictureBox platformBot;
        private System.Windows.Forms.PictureBox creeper;
        private System.Windows.Forms.PictureBox platformMid;
        private System.Windows.Forms.TextBox tutorial;
    }
}