namespace MECH423Lab1E4to9
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
            this.DisconnectSerial = new System.Windows.Forms.Button();
            this.BytesToRead = new System.Windows.Forms.Label();
            this.StrLen = new System.Windows.Forms.Label();
            this.QueueItems = new System.Windows.Forms.Label();
            this.LabelDataStream = new System.Windows.Forms.Label();
            this.txtBytesToRead = new System.Windows.Forms.TextBox();
            this.txtStrLen = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.DataStream = new System.Windows.Forms.TextBox();
            this.SerialPort = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // DisconnectSerial
            // 
            this.DisconnectSerial.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisconnectSerial.Location = new System.Drawing.Point(564, 12);
            this.DisconnectSerial.Name = "DisconnectSerial";
            this.DisconnectSerial.Size = new System.Drawing.Size(447, 78);
            this.DisconnectSerial.TabIndex = 0;
            this.DisconnectSerial.Text = "Disconnect Serial";
            this.DisconnectSerial.UseVisualStyleBackColor = true;
            this.DisconnectSerial.Click += new System.EventHandler(this.DisconnectSerial_Click);
            // 
            // BytesToRead
            // 
            this.BytesToRead.AutoSize = true;
            this.BytesToRead.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BytesToRead.Location = new System.Drawing.Point(22, 174);
            this.BytesToRead.Name = "BytesToRead";
            this.BytesToRead.Size = new System.Drawing.Size(449, 53);
            this.BytesToRead.TabIndex = 2;
            this.BytesToRead.Text = "Serial Bytes to Read";
            // 
            // StrLen
            // 
            this.StrLen.AutoSize = true;
            this.StrLen.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StrLen.Location = new System.Drawing.Point(22, 247);
            this.StrLen.Name = "StrLen";
            this.StrLen.Size = new System.Drawing.Size(427, 53);
            this.StrLen.TabIndex = 3;
            this.StrLen.Text = "Temp String Length";
            // 
            // QueueItems
            // 
            this.QueueItems.AutoSize = true;
            this.QueueItems.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QueueItems.Location = new System.Drawing.Point(22, 310);
            this.QueueItems.Name = "QueueItems";
            this.QueueItems.Size = new System.Drawing.Size(341, 53);
            this.QueueItems.TabIndex = 4;
            this.QueueItems.Text = "Items In Queue";
            // 
            // LabelDataStream
            // 
            this.LabelDataStream.AutoSize = true;
            this.LabelDataStream.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDataStream.Location = new System.Drawing.Point(22, 456);
            this.LabelDataStream.Name = "LabelDataStream";
            this.LabelDataStream.Size = new System.Drawing.Size(417, 53);
            this.LabelDataStream.TabIndex = 5;
            this.LabelDataStream.Text = "Serial Data Stream";
            // 
            // txtBytesToRead
            // 
            this.txtBytesToRead.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBytesToRead.Location = new System.Drawing.Point(516, 171);
            this.txtBytesToRead.Name = "txtBytesToRead";
            this.txtBytesToRead.Size = new System.Drawing.Size(430, 62);
            this.txtBytesToRead.TabIndex = 6;
            // 
            // txtStrLen
            // 
            this.txtStrLen.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStrLen.Location = new System.Drawing.Point(516, 247);
            this.txtStrLen.Name = "txtStrLen";
            this.txtStrLen.Size = new System.Drawing.Size(430, 62);
            this.txtStrLen.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(516, 315);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(430, 62);
            this.textBox3.TabIndex = 8;
            // 
            // DataStream
            // 
            this.DataStream.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DataStream.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataStream.Location = new System.Drawing.Point(12, 512);
            this.DataStream.Multiline = true;
            this.DataStream.Name = "DataStream";
            this.DataStream.ReadOnly = true;
            this.DataStream.Size = new System.Drawing.Size(2029, 1058);
            this.DataStream.TabIndex = 9;
            // 
            // SerialPort
            // 
            this.SerialPort.DtrEnable = true;
            this.SerialPort.PortName = "COM3";
            this.SerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Serial_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(20, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(451, 61);
            this.comboBox1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2053, 1594);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.DataStream);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txtStrLen);
            this.Controls.Add(this.txtBytesToRead);
            this.Controls.Add(this.LabelDataStream);
            this.Controls.Add(this.QueueItems);
            this.Controls.Add(this.StrLen);
            this.Controls.Add(this.BytesToRead);
            this.Controls.Add(this.DisconnectSerial);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DisconnectSerial;
        private System.Windows.Forms.Label BytesToRead;
        private System.Windows.Forms.Label StrLen;
        private System.Windows.Forms.Label QueueItems;
        private System.Windows.Forms.Label LabelDataStream;
        private System.Windows.Forms.TextBox txtBytesToRead;
        private System.Windows.Forms.TextBox txtStrLen;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox DataStream;
        private System.IO.Ports.SerialPort SerialPort;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

