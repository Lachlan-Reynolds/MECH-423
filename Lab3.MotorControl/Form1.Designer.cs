namespace Lab3.MotorControl
{
    partial class Form1
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
            this.MCUSerial = new System.IO.Ports.SerialPort(this.components);
            this.buttonConnect = new System.Windows.Forms.Button();
            this.checkByte1 = new System.Windows.Forms.CheckBox();
            this.checkByte2 = new System.Windows.Forms.CheckBox();
            this.checkByte3 = new System.Windows.Forms.CheckBox();
            this.checkByte4 = new System.Windows.Forms.CheckBox();
            this.checkByte5 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtByte1 = new System.Windows.Forms.TextBox();
            this.txtByte2 = new System.Windows.Forms.TextBox();
            this.txtByte3 = new System.Windows.Forms.TextBox();
            this.txtByte4 = new System.Windows.Forms.TextBox();
            this.txtByte5 = new System.Windows.Forms.TextBox();
            this.CheckuseSlider = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.transmit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // MCUSerial
            // 
            this.MCUSerial.DtrEnable = true;
            this.MCUSerial.PortName = "COM10";
            this.MCUSerial.RtsEnable = true;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnect.Location = new System.Drawing.Point(460, 12);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(258, 61);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // checkByte1
            // 
            this.checkByte1.AutoSize = true;
            this.checkByte1.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkByte1.Location = new System.Drawing.Point(34, 221);
            this.checkByte1.Name = "checkByte1";
            this.checkByte1.Size = new System.Drawing.Size(219, 57);
            this.checkByte1.TabIndex = 1;
            this.checkByte1.Text = "Byte #1";
            this.checkByte1.UseVisualStyleBackColor = true;
            this.checkByte1.CheckStateChanged += new System.EventHandler(this.checkByte1_CheckStateChanged);
            // 
            // checkByte2
            // 
            this.checkByte2.AutoSize = true;
            this.checkByte2.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkByte2.Location = new System.Drawing.Point(301, 221);
            this.checkByte2.Name = "checkByte2";
            this.checkByte2.Size = new System.Drawing.Size(219, 57);
            this.checkByte2.TabIndex = 2;
            this.checkByte2.Text = "Byte #2";
            this.checkByte2.UseVisualStyleBackColor = true;
            this.checkByte2.CheckStateChanged += new System.EventHandler(this.checkByte2_CheckStateChanged);
            // 
            // checkByte3
            // 
            this.checkByte3.AutoSize = true;
            this.checkByte3.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkByte3.Location = new System.Drawing.Point(577, 221);
            this.checkByte3.Name = "checkByte3";
            this.checkByte3.Size = new System.Drawing.Size(219, 57);
            this.checkByte3.TabIndex = 3;
            this.checkByte3.Text = "Byte #3";
            this.checkByte3.UseVisualStyleBackColor = true;
            this.checkByte3.CheckStateChanged += new System.EventHandler(this.checkByte3_CheckStateChanged);
            // 
            // checkByte4
            // 
            this.checkByte4.AutoSize = true;
            this.checkByte4.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkByte4.Location = new System.Drawing.Point(848, 221);
            this.checkByte4.Name = "checkByte4";
            this.checkByte4.Size = new System.Drawing.Size(219, 57);
            this.checkByte4.TabIndex = 4;
            this.checkByte4.Text = "Byte #4";
            this.checkByte4.UseVisualStyleBackColor = true;
            this.checkByte4.CheckStateChanged += new System.EventHandler(this.checkByte4_CheckStateChanged);
            // 
            // checkByte5
            // 
            this.checkByte5.AutoSize = true;
            this.checkByte5.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkByte5.Location = new System.Drawing.Point(1112, 221);
            this.checkByte5.Name = "checkByte5";
            this.checkByte5.Size = new System.Drawing.Size(219, 57);
            this.checkByte5.TabIndex = 5;
            this.checkByte5.Text = "Byte #5";
            this.checkByte5.UseVisualStyleBackColor = true;
            this.checkByte5.CheckStateChanged += new System.EventHandler(this.checkByte5_CheckStateChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(34, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(393, 61);
            this.comboBox1.TabIndex = 8;
            // 
            // txtByte1
            // 
            this.txtByte1.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtByte1.Location = new System.Drawing.Point(34, 293);
            this.txtByte1.Name = "txtByte1";
            this.txtByte1.Size = new System.Drawing.Size(219, 62);
            this.txtByte1.TabIndex = 10;
            // 
            // txtByte2
            // 
            this.txtByte2.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtByte2.Location = new System.Drawing.Point(301, 293);
            this.txtByte2.Name = "txtByte2";
            this.txtByte2.Size = new System.Drawing.Size(219, 62);
            this.txtByte2.TabIndex = 11;
            // 
            // txtByte3
            // 
            this.txtByte3.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtByte3.Location = new System.Drawing.Point(577, 293);
            this.txtByte3.Name = "txtByte3";
            this.txtByte3.Size = new System.Drawing.Size(219, 62);
            this.txtByte3.TabIndex = 12;
            // 
            // txtByte4
            // 
            this.txtByte4.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtByte4.Location = new System.Drawing.Point(848, 293);
            this.txtByte4.Name = "txtByte4";
            this.txtByte4.Size = new System.Drawing.Size(219, 62);
            this.txtByte4.TabIndex = 13;
            // 
            // txtByte5
            // 
            this.txtByte5.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtByte5.Location = new System.Drawing.Point(1112, 293);
            this.txtByte5.Name = "txtByte5";
            this.txtByte5.Size = new System.Drawing.Size(219, 62);
            this.txtByte5.TabIndex = 14;
            // 
            // CheckuseSlider
            // 
            this.CheckuseSlider.AutoSize = true;
            this.CheckuseSlider.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckuseSlider.Location = new System.Drawing.Point(47, 425);
            this.CheckuseSlider.Name = "CheckuseSlider";
            this.CheckuseSlider.Size = new System.Drawing.Size(277, 57);
            this.CheckuseSlider.TabIndex = 17;
            this.CheckuseSlider.Text = "Use Slider";
            this.CheckuseSlider.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtCommand
            // 
            this.txtCommand.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommand.Location = new System.Drawing.Point(460, 649);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(254, 62);
            this.txtCommand.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 637);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(343, 53);
            this.label2.TabIndex = 20;
            this.label2.Text = "Command Byte";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(34, 514);
            this.trackBar1.Maximum = 65535;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(1228, 114);
            this.trackBar1.TabIndex = 22;
            this.trackBar1.Value = 5000;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Location = new System.Drawing.Point(528, 787);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(549, 283);
            this.textBox1.TabIndex = 23;
            // 
            // transmit
            // 
            this.transmit.Location = new System.Drawing.Point(96, 134);
            this.transmit.Name = "transmit";
            this.transmit.Size = new System.Drawing.Size(558, 69);
            this.transmit.TabIndex = 24;
            this.transmit.Text = "Transmit to MCU";
            this.transmit.UseVisualStyleBackColor = true;
            this.transmit.Click += new System.EventHandler(this.transmit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(877, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 25;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Disconnect.Location = new System.Drawing.Point(724, 12);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(322, 61);
            this.button_Disconnect.TabIndex = 26;
            this.button_Disconnect.Text = "Disconnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(62, 718);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(268, 36);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Text = "Half Step Control";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(62, 778);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 105);
            this.button2.TabIndex = 28;
            this.button2.Text = "CCW";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(237, 778);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 105);
            this.button3.TabIndex = 29;
            this.button3.Text = "CW";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 1129);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button_Disconnect);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.transmit);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.CheckuseSlider);
            this.Controls.Add(this.txtByte5);
            this.Controls.Add(this.txtByte4);
            this.Controls.Add(this.txtByte3);
            this.Controls.Add(this.txtByte2);
            this.Controls.Add(this.txtByte1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.checkByte5);
            this.Controls.Add(this.checkByte4);
            this.Controls.Add(this.checkByte3);
            this.Controls.Add(this.checkByte2);
            this.Controls.Add(this.checkByte1);
            this.Controls.Add(this.buttonConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort MCUSerial;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.CheckBox checkByte1;
        private System.Windows.Forms.CheckBox checkByte2;
        private System.Windows.Forms.CheckBox checkByte3;
        private System.Windows.Forms.CheckBox checkByte4;
        private System.Windows.Forms.CheckBox checkByte5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtByte1;
        private System.Windows.Forms.TextBox txtByte2;
        private System.Windows.Forms.TextBox txtByte3;
        private System.Windows.Forms.TextBox txtByte4;
        private System.Windows.Forms.TextBox txtByte5;
        private System.Windows.Forms.CheckBox CheckuseSlider;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button transmit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

