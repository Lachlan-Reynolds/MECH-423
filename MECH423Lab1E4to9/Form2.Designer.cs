namespace MECH423Lab1E4to9
{
    partial class Form2
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
            this.txtQueueItems = new System.Windows.Forms.TextBox();
            this.DataStream = new System.Windows.Forms.TextBox();
            this.SerialPort = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Ax = new System.Windows.Forms.Label();
            this.Ay = new System.Windows.Forms.Label();
            this.Az = new System.Windows.Forms.Label();
            this.txtAx = new System.Windows.Forms.TextBox();
            this.txtAy = new System.Windows.Forms.TextBox();
            this.txtAz = new System.Windows.Forms.TextBox();
            this.txtOrientation = new System.Windows.Forms.TextBox();
            this.Orientation = new System.Windows.Forms.Label();
            this.SaveToFile = new System.Windows.Forms.CheckBox();
            this.SelectFile = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtDeltaAy = new System.Windows.Forms.TextBox();
            this.txtDeltaAz = new System.Windows.Forms.TextBox();
            this.txtDeltaAx = new System.Windows.Forms.TextBox();
            this.deltaAx = new System.Windows.Forms.Label();
            this.deltaAy = new System.Windows.Forms.Label();
            this.deltaAz = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DisconnectSerial
            // 
            this.DisconnectSerial.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisconnectSerial.Location = new System.Drawing.Point(516, 12);
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
            this.BytesToRead.Location = new System.Drawing.Point(20, 205);
            this.BytesToRead.Name = "BytesToRead";
            this.BytesToRead.Size = new System.Drawing.Size(449, 53);
            this.BytesToRead.TabIndex = 2;
            this.BytesToRead.Text = "Serial Bytes to Read";
            // 
            // StrLen
            // 
            this.StrLen.AutoSize = true;
            this.StrLen.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StrLen.Location = new System.Drawing.Point(20, 278);
            this.StrLen.Name = "StrLen";
            this.StrLen.Size = new System.Drawing.Size(427, 53);
            this.StrLen.TabIndex = 3;
            this.StrLen.Text = "Temp String Length";
            // 
            // QueueItems
            // 
            this.QueueItems.AutoSize = true;
            this.QueueItems.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QueueItems.Location = new System.Drawing.Point(20, 341);
            this.QueueItems.Name = "QueueItems";
            this.QueueItems.Size = new System.Drawing.Size(341, 53);
            this.QueueItems.TabIndex = 4;
            this.QueueItems.Text = "Items In Queue";
            // 
            // LabelDataStream
            // 
            this.LabelDataStream.AutoSize = true;
            this.LabelDataStream.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDataStream.Location = new System.Drawing.Point(11, 498);
            this.LabelDataStream.Name = "LabelDataStream";
            this.LabelDataStream.Size = new System.Drawing.Size(417, 53);
            this.LabelDataStream.TabIndex = 5;
            this.LabelDataStream.Text = "Serial Data Stream";
            // 
            // txtBytesToRead
            // 
            this.txtBytesToRead.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBytesToRead.Location = new System.Drawing.Point(514, 202);
            this.txtBytesToRead.Name = "txtBytesToRead";
            this.txtBytesToRead.Size = new System.Drawing.Size(430, 62);
            this.txtBytesToRead.TabIndex = 6;
            // 
            // txtStrLen
            // 
            this.txtStrLen.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStrLen.Location = new System.Drawing.Point(514, 278);
            this.txtStrLen.Name = "txtStrLen";
            this.txtStrLen.Size = new System.Drawing.Size(430, 62);
            this.txtStrLen.TabIndex = 7;
            // 
            // txtQueueItems
            // 
            this.txtQueueItems.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQueueItems.Location = new System.Drawing.Point(514, 346);
            this.txtQueueItems.Name = "txtQueueItems";
            this.txtQueueItems.Size = new System.Drawing.Size(430, 62);
            this.txtQueueItems.TabIndex = 8;
            // 
            // DataStream
            // 
            this.DataStream.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DataStream.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataStream.Location = new System.Drawing.Point(12, 573);
            this.DataStream.Multiline = true;
            this.DataStream.Name = "DataStream";
            this.DataStream.ReadOnly = true;
            this.DataStream.Size = new System.Drawing.Size(2029, 484);
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
            // Ax
            // 
            this.Ax.AutoSize = true;
            this.Ax.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ax.Location = new System.Drawing.Point(1010, 202);
            this.Ax.Name = "Ax";
            this.Ax.Size = new System.Drawing.Size(78, 53);
            this.Ax.TabIndex = 13;
            this.Ax.Text = "Ax";
            // 
            // Ay
            // 
            this.Ay.AutoSize = true;
            this.Ay.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ay.Location = new System.Drawing.Point(1012, 287);
            this.Ay.Name = "Ay";
            this.Ay.Size = new System.Drawing.Size(76, 53);
            this.Ay.TabIndex = 14;
            this.Ay.Text = "Ay";
            // 
            // Az
            // 
            this.Az.AutoSize = true;
            this.Az.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Az.Location = new System.Drawing.Point(1012, 362);
            this.Az.Name = "Az";
            this.Az.Size = new System.Drawing.Size(77, 53);
            this.Az.TabIndex = 15;
            this.Az.Text = "Az";
            // 
            // txtAx
            // 
            this.txtAx.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAx.Location = new System.Drawing.Point(1132, 199);
            this.txtAx.Name = "txtAx";
            this.txtAx.Size = new System.Drawing.Size(220, 62);
            this.txtAx.TabIndex = 16;
            // 
            // txtAy
            // 
            this.txtAy.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAy.Location = new System.Drawing.Point(1132, 278);
            this.txtAy.Name = "txtAy";
            this.txtAy.Size = new System.Drawing.Size(220, 62);
            this.txtAy.TabIndex = 17;
            // 
            // txtAz
            // 
            this.txtAz.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAz.Location = new System.Drawing.Point(1132, 362);
            this.txtAz.Name = "txtAz";
            this.txtAz.Size = new System.Drawing.Size(220, 62);
            this.txtAz.TabIndex = 18;
            // 
            // txtOrientation
            // 
            this.txtOrientation.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrientation.Location = new System.Drawing.Point(1132, 118);
            this.txtOrientation.Name = "txtOrientation";
            this.txtOrientation.Size = new System.Drawing.Size(220, 62);
            this.txtOrientation.TabIndex = 21;
            // 
            // Orientation
            // 
            this.Orientation.AutoSize = true;
            this.Orientation.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Orientation.Location = new System.Drawing.Point(874, 121);
            this.Orientation.Name = "Orientation";
            this.Orientation.Size = new System.Drawing.Size(252, 53);
            this.Orientation.TabIndex = 20;
            this.Orientation.Text = "Orientation";
            // 
            // SaveToFile
            // 
            this.SaveToFile.AutoSize = true;
            this.SaveToFile.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveToFile.Location = new System.Drawing.Point(491, 488);
            this.SaveToFile.Name = "SaveToFile";
            this.SaveToFile.Size = new System.Drawing.Size(309, 57);
            this.SaveToFile.TabIndex = 22;
            this.SaveToFile.Text = "Save to File";
            this.SaveToFile.UseVisualStyleBackColor = true;
            this.SaveToFile.CheckedChanged += new System.EventHandler(this.SaveToFile_CheckedChanged);
            // 
            // SelectFile
            // 
            this.SelectFile.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectFile.Location = new System.Drawing.Point(832, 483);
            this.SelectFile.Name = "SelectFile";
            this.SelectFile.Size = new System.Drawing.Size(309, 71);
            this.SelectFile.TabIndex = 23;
            this.SelectFile.Text = "Select File";
            this.SelectFile.UseVisualStyleBackColor = true;
            this.SelectFile.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(1173, 483);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(868, 62);
            this.txtFileName.TabIndex = 24;
            // 
            // txtDeltaAy
            // 
            this.txtDeltaAy.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeltaAy.Location = new System.Drawing.Point(1584, 275);
            this.txtDeltaAy.Name = "txtDeltaAy";
            this.txtDeltaAy.Size = new System.Drawing.Size(318, 62);
            this.txtDeltaAy.TabIndex = 25;
            // 
            // txtDeltaAz
            // 
            this.txtDeltaAz.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeltaAz.Location = new System.Drawing.Point(1586, 356);
            this.txtDeltaAz.Name = "txtDeltaAz";
            this.txtDeltaAz.Size = new System.Drawing.Size(316, 62);
            this.txtDeltaAz.TabIndex = 26;
            // 
            // txtDeltaAx
            // 
            this.txtDeltaAx.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeltaAx.Location = new System.Drawing.Point(1586, 190);
            this.txtDeltaAx.Name = "txtDeltaAx";
            this.txtDeltaAx.Size = new System.Drawing.Size(316, 62);
            this.txtDeltaAx.TabIndex = 27;
            // 
            // deltaAx
            // 
            this.deltaAx.AutoSize = true;
            this.deltaAx.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deltaAx.Location = new System.Drawing.Point(1391, 199);
            this.deltaAx.Name = "deltaAx";
            this.deltaAx.Size = new System.Drawing.Size(189, 53);
            this.deltaAx.TabIndex = 28;
            this.deltaAx.Text = "delta Ax";
            // 
            // deltaAy
            // 
            this.deltaAy.AutoSize = true;
            this.deltaAy.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deltaAy.Location = new System.Drawing.Point(1391, 275);
            this.deltaAy.Name = "deltaAy";
            this.deltaAy.Size = new System.Drawing.Size(187, 53);
            this.deltaAy.TabIndex = 29;
            this.deltaAy.Text = "delta Ay";
            // 
            // deltaAz
            // 
            this.deltaAz.AutoSize = true;
            this.deltaAz.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deltaAz.Location = new System.Drawing.Point(1392, 365);
            this.deltaAz.Name = "deltaAz";
            this.deltaAz.Size = new System.Drawing.Size(188, 53);
            this.deltaAz.TabIndex = 30;
            this.deltaAz.Text = "delta Az";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2053, 1069);
            this.Controls.Add(this.deltaAz);
            this.Controls.Add(this.deltaAy);
            this.Controls.Add(this.deltaAx);
            this.Controls.Add(this.txtDeltaAx);
            this.Controls.Add(this.txtDeltaAz);
            this.Controls.Add(this.txtDeltaAy);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.SelectFile);
            this.Controls.Add(this.SaveToFile);
            this.Controls.Add(this.txtOrientation);
            this.Controls.Add(this.Orientation);
            this.Controls.Add(this.txtAz);
            this.Controls.Add(this.txtAy);
            this.Controls.Add(this.txtAx);
            this.Controls.Add(this.Az);
            this.Controls.Add(this.Ay);
            this.Controls.Add(this.Ax);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.DataStream);
            this.Controls.Add(this.txtQueueItems);
            this.Controls.Add(this.txtStrLen);
            this.Controls.Add(this.txtBytesToRead);
            this.Controls.Add(this.LabelDataStream);
            this.Controls.Add(this.QueueItems);
            this.Controls.Add(this.StrLen);
            this.Controls.Add(this.BytesToRead);
            this.Controls.Add(this.DisconnectSerial);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
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
        private System.Windows.Forms.TextBox txtQueueItems;
        private System.Windows.Forms.TextBox DataStream;
        private System.IO.Ports.SerialPort SerialPort;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label Ax;
        private System.Windows.Forms.Label Ay;
        private System.Windows.Forms.Label Az;
        private System.Windows.Forms.TextBox txtAx;
        private System.Windows.Forms.TextBox txtAy;
        private System.Windows.Forms.TextBox txtAz;
        private System.Windows.Forms.TextBox txtOrientation;
        private System.Windows.Forms.Label Orientation;
        private System.Windows.Forms.CheckBox SaveToFile;
        private System.Windows.Forms.Button SelectFile;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtDeltaAy;
        private System.Windows.Forms.TextBox txtDeltaAz;
        private System.Windows.Forms.TextBox txtDeltaAx;
        private System.Windows.Forms.Label deltaAx;
        private System.Windows.Forms.Label deltaAy;
        private System.Windows.Forms.Label deltaAz;
    }
}

