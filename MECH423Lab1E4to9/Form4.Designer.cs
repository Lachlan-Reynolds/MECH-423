namespace MECH423Lab1E4to9
{
    partial class Form4
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
            this.labAx = new System.Windows.Forms.Label();
            this.labAy = new System.Windows.Forms.Label();
            this.labAz = new System.Windows.Forms.Label();
            this.labOrientation = new System.Windows.Forms.Label();
            this.labSerialBufSize = new System.Windows.Forms.Label();
            this.labQueueSize = new System.Windows.Forms.Label();
            this.txtAx = new System.Windows.Forms.TextBox();
            this.txtAy = new System.Windows.Forms.TextBox();
            this.txtAz = new System.Windows.Forms.TextBox();
            this.txtOrientation = new System.Windows.Forms.TextBox();
            this.txtSerialBufSize = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labAvgX = new System.Windows.Forms.Label();
            this.txtQueueSize = new System.Windows.Forms.TextBox();
            this.txtAvgX = new System.Windows.Forms.TextBox();
            this.txtAvgY = new System.Windows.Forms.TextBox();
            this.txtAvgZ = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labAvg = new System.Windows.Forms.Label();
            this.labGesture = new System.Windows.Forms.Label();
            this.txtGesture = new System.Windows.Forms.TextBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.deltaAx = new System.Windows.Forms.Label();
            this.deltaAy = new System.Windows.Forms.Label();
            this.deltaAz = new System.Windows.Forms.Label();
            this.txtDeltaAx = new System.Windows.Forms.TextBox();
            this.txtDeltaAy = new System.Windows.Forms.TextBox();
            this.txtDeltaAz = new System.Windows.Forms.TextBox();
            this.timeOut = new System.Windows.Forms.Timer(this.components);
            this.debug = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labAx
            // 
            this.labAx.AutoSize = true;
            this.labAx.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAx.Location = new System.Drawing.Point(24, 30);
            this.labAx.Name = "labAx";
            this.labAx.Size = new System.Drawing.Size(78, 53);
            this.labAx.TabIndex = 0;
            this.labAx.Text = "Ax";
            // 
            // labAy
            // 
            this.labAy.AutoSize = true;
            this.labAy.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAy.Location = new System.Drawing.Point(260, 30);
            this.labAy.Name = "labAy";
            this.labAy.Size = new System.Drawing.Size(76, 53);
            this.labAy.TabIndex = 1;
            this.labAy.Text = "Ay";
            // 
            // labAz
            // 
            this.labAz.AutoSize = true;
            this.labAz.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAz.Location = new System.Drawing.Point(496, 30);
            this.labAz.Name = "labAz";
            this.labAz.Size = new System.Drawing.Size(77, 53);
            this.labAz.TabIndex = 2;
            this.labAz.Text = "Az";
            // 
            // labOrientation
            // 
            this.labOrientation.AutoSize = true;
            this.labOrientation.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labOrientation.Location = new System.Drawing.Point(788, 30);
            this.labOrientation.Name = "labOrientation";
            this.labOrientation.Size = new System.Drawing.Size(252, 53);
            this.labOrientation.TabIndex = 3;
            this.labOrientation.Text = "Orientation";
            // 
            // labSerialBufSize
            // 
            this.labSerialBufSize.AutoSize = true;
            this.labSerialBufSize.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSerialBufSize.Location = new System.Drawing.Point(25, 364);
            this.labSerialBufSize.Name = "labSerialBufSize";
            this.labSerialBufSize.Size = new System.Drawing.Size(382, 53);
            this.labSerialBufSize.TabIndex = 4;
            this.labSerialBufSize.Text = "Serial Buffer Size";
            // 
            // labQueueSize
            // 
            this.labQueueSize.AutoSize = true;
            this.labQueueSize.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labQueueSize.Location = new System.Drawing.Point(25, 520);
            this.labQueueSize.Name = "labQueueSize";
            this.labQueueSize.Size = new System.Drawing.Size(267, 53);
            this.labQueueSize.TabIndex = 5;
            this.labQueueSize.Text = "Queue Size";
            // 
            // txtAx
            // 
            this.txtAx.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAx.Location = new System.Drawing.Point(33, 100);
            this.txtAx.Name = "txtAx";
            this.txtAx.Size = new System.Drawing.Size(168, 62);
            this.txtAx.TabIndex = 6;
            // 
            // txtAy
            // 
            this.txtAy.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAy.Location = new System.Drawing.Point(269, 104);
            this.txtAy.Name = "txtAy";
            this.txtAy.Size = new System.Drawing.Size(168, 62);
            this.txtAy.TabIndex = 7;
            // 
            // txtAz
            // 
            this.txtAz.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAz.Location = new System.Drawing.Point(505, 104);
            this.txtAz.Name = "txtAz";
            this.txtAz.Size = new System.Drawing.Size(168, 62);
            this.txtAz.TabIndex = 8;
            // 
            // txtOrientation
            // 
            this.txtOrientation.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrientation.Location = new System.Drawing.Point(797, 104);
            this.txtOrientation.Name = "txtOrientation";
            this.txtOrientation.Size = new System.Drawing.Size(292, 62);
            this.txtOrientation.TabIndex = 9;
            // 
            // txtSerialBufSize
            // 
            this.txtSerialBufSize.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialBufSize.Location = new System.Drawing.Point(34, 424);
            this.txtSerialBufSize.Name = "txtSerialBufSize";
            this.txtSerialBufSize.Size = new System.Drawing.Size(373, 62);
            this.txtSerialBufSize.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(464, 520);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 53);
            this.label7.TabIndex = 11;
            this.label7.Text = "Y";
            // 
            // labAvgX
            // 
            this.labAvgX.AutoSize = true;
            this.labAvgX.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAvgX.Location = new System.Drawing.Point(463, 433);
            this.labAvgX.Name = "labAvgX";
            this.labAvgX.Size = new System.Drawing.Size(54, 53);
            this.labAvgX.TabIndex = 12;
            this.labAvgX.Text = "X";
            // 
            // txtQueueSize
            // 
            this.txtQueueSize.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQueueSize.Location = new System.Drawing.Point(34, 606);
            this.txtQueueSize.Name = "txtQueueSize";
            this.txtQueueSize.Size = new System.Drawing.Size(373, 62);
            this.txtQueueSize.TabIndex = 13;
            // 
            // txtAvgX
            // 
            this.txtAvgX.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvgX.Location = new System.Drawing.Point(557, 433);
            this.txtAvgX.Name = "txtAvgX";
            this.txtAvgX.Size = new System.Drawing.Size(306, 62);
            this.txtAvgX.TabIndex = 14;
            // 
            // txtAvgY
            // 
            this.txtAvgY.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvgY.Location = new System.Drawing.Point(557, 517);
            this.txtAvgY.Name = "txtAvgY";
            this.txtAvgY.Size = new System.Drawing.Size(306, 62);
            this.txtAvgY.TabIndex = 15;
            // 
            // txtAvgZ
            // 
            this.txtAvgZ.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvgZ.Location = new System.Drawing.Point(557, 606);
            this.txtAvgZ.Name = "txtAvgZ";
            this.txtAvgZ.Size = new System.Drawing.Size(306, 62);
            this.txtAvgZ.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(465, 596);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 53);
            this.label1.TabIndex = 17;
            this.label1.Text = "Z";
            // 
            // labAvg
            // 
            this.labAvg.AutoSize = true;
            this.labAvg.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAvg.Location = new System.Drawing.Point(463, 364);
            this.labAvg.Name = "labAvg";
            this.labAvg.Size = new System.Drawing.Size(291, 53);
            this.labAvg.TabIndex = 18;
            this.labAvg.Text = "Max, std dev";
            // 
            // labGesture
            // 
            this.labGesture.AutoSize = true;
            this.labGesture.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGesture.Location = new System.Drawing.Point(797, 203);
            this.labGesture.Name = "labGesture";
            this.labGesture.Size = new System.Drawing.Size(191, 53);
            this.labGesture.TabIndex = 19;
            this.labGesture.Text = "Gesture";
            // 
            // txtGesture
            // 
            this.txtGesture.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGesture.Location = new System.Drawing.Point(797, 259);
            this.txtGesture.Name = "txtGesture";
            this.txtGesture.Size = new System.Drawing.Size(457, 62);
            this.txtGesture.TabIndex = 20;
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
            // deltaAx
            // 
            this.deltaAx.AutoSize = true;
            this.deltaAx.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deltaAx.Location = new System.Drawing.Point(25, 192);
            this.deltaAx.Name = "deltaAx";
            this.deltaAx.Size = new System.Drawing.Size(189, 53);
            this.deltaAx.TabIndex = 21;
            this.deltaAx.Text = "delta Ax";
            // 
            // deltaAy
            // 
            this.deltaAy.AutoSize = true;
            this.deltaAy.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deltaAy.Location = new System.Drawing.Point(260, 192);
            this.deltaAy.Name = "deltaAy";
            this.deltaAy.Size = new System.Drawing.Size(187, 53);
            this.deltaAy.TabIndex = 22;
            this.deltaAy.Text = "delta Ay";
            // 
            // deltaAz
            // 
            this.deltaAz.AutoSize = true;
            this.deltaAz.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deltaAz.Location = new System.Drawing.Point(496, 192);
            this.deltaAz.Name = "deltaAz";
            this.deltaAz.Size = new System.Drawing.Size(178, 53);
            this.deltaAz.TabIndex = 23;
            this.deltaAz.Text = "deltaAz";
            // 
            // txtDeltaAx
            // 
            this.txtDeltaAx.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeltaAx.Location = new System.Drawing.Point(33, 259);
            this.txtDeltaAx.Name = "txtDeltaAx";
            this.txtDeltaAx.Size = new System.Drawing.Size(168, 62);
            this.txtDeltaAx.TabIndex = 24;
            // 
            // txtDeltaAy
            // 
            this.txtDeltaAy.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeltaAy.Location = new System.Drawing.Point(269, 259);
            this.txtDeltaAy.Name = "txtDeltaAy";
            this.txtDeltaAy.Size = new System.Drawing.Size(168, 62);
            this.txtDeltaAy.TabIndex = 25;
            // 
            // txtDeltaAz
            // 
            this.txtDeltaAz.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeltaAz.Location = new System.Drawing.Point(505, 259);
            this.txtDeltaAz.Name = "txtDeltaAz";
            this.txtDeltaAz.Size = new System.Drawing.Size(168, 62);
            this.txtDeltaAz.TabIndex = 26;
            // 
            // timeOut
            // 
            this.timeOut.Enabled = true;
            this.timeOut.Interval = 2000;
            this.timeOut.Tick += new System.EventHandler(this.timeOut_Tick);
            // 
            // debug
            // 
            this.debug.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debug.Location = new System.Drawing.Point(642, 766);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(373, 62);
            this.debug.TabIndex = 27;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial Narrow", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(984, 447);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(199, 38);
            this.textBox1.TabIndex = 28;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Arial Narrow", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(928, 541);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(199, 38);
            this.textBox2.TabIndex = 29;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Arial Narrow", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(928, 623);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(199, 38);
            this.textBox3.TabIndex = 30;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 916);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.debug);
            this.Controls.Add(this.txtDeltaAz);
            this.Controls.Add(this.txtDeltaAy);
            this.Controls.Add(this.txtDeltaAx);
            this.Controls.Add(this.deltaAz);
            this.Controls.Add(this.deltaAy);
            this.Controls.Add(this.deltaAx);
            this.Controls.Add(this.txtGesture);
            this.Controls.Add(this.labGesture);
            this.Controls.Add(this.labAvg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAvgZ);
            this.Controls.Add(this.txtAvgY);
            this.Controls.Add(this.txtAvgX);
            this.Controls.Add(this.txtQueueSize);
            this.Controls.Add(this.labAvgX);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSerialBufSize);
            this.Controls.Add(this.txtOrientation);
            this.Controls.Add(this.txtAz);
            this.Controls.Add(this.txtAy);
            this.Controls.Add(this.txtAx);
            this.Controls.Add(this.labQueueSize);
            this.Controls.Add(this.labSerialBufSize);
            this.Controls.Add(this.labOrientation);
            this.Controls.Add(this.labAz);
            this.Controls.Add(this.labAy);
            this.Controls.Add(this.labAx);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form4_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labAx;
        private System.Windows.Forms.Label labAy;
        private System.Windows.Forms.Label labAz;
        private System.Windows.Forms.Label labOrientation;
        private System.Windows.Forms.Label labSerialBufSize;
        private System.Windows.Forms.Label labQueueSize;
        private System.Windows.Forms.TextBox txtAx;
        private System.Windows.Forms.TextBox txtAy;
        private System.Windows.Forms.TextBox txtAz;
        private System.Windows.Forms.TextBox txtOrientation;
        private System.Windows.Forms.TextBox txtSerialBufSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labAvgX;
        private System.Windows.Forms.TextBox txtQueueSize;
        private System.Windows.Forms.TextBox txtAvgX;
        private System.Windows.Forms.TextBox txtAvgY;
        private System.Windows.Forms.TextBox txtAvgZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labAvg;
        private System.Windows.Forms.Label labGesture;
        private System.Windows.Forms.TextBox txtGesture;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label deltaAx;
        private System.Windows.Forms.Label deltaAy;
        private System.Windows.Forms.Label deltaAz;
        private System.Windows.Forms.TextBox txtDeltaAx;
        private System.Windows.Forms.TextBox txtDeltaAy;
        private System.Windows.Forms.TextBox txtDeltaAz;
        private System.Windows.Forms.Timer timeOut;
        private System.Windows.Forms.TextBox debug;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}