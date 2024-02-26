namespace MECH423Lab1E4to9
{
    partial class Form3
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
            this.Ax = new System.Windows.Forms.Label();
            this.Ay = new System.Windows.Forms.Label();
            this.Az = new System.Windows.Forms.Label();
            this.CurrentState = new System.Windows.Forms.Label();
            this.DataHistory = new System.Windows.Forms.Label();
            this.txtAx = new System.Windows.Forms.TextBox();
            this.txtAz = new System.Windows.Forms.TextBox();
            this.txtAy = new System.Windows.Forms.TextBox();
            this.txtCurrentState = new System.Windows.Forms.TextBox();
            this.txtHistory = new System.Windows.Forms.TextBox();
            this.processNew = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Ax
            // 
            this.Ax.AutoSize = true;
            this.Ax.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ax.Location = new System.Drawing.Point(12, 9);
            this.Ax.Name = "Ax";
            this.Ax.Size = new System.Drawing.Size(78, 53);
            this.Ax.TabIndex = 0;
            this.Ax.Text = "Ax";
            // 
            // Ay
            // 
            this.Ay.AutoSize = true;
            this.Ay.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ay.Location = new System.Drawing.Point(319, 9);
            this.Ay.Name = "Ay";
            this.Ay.Size = new System.Drawing.Size(76, 53);
            this.Ay.TabIndex = 1;
            this.Ay.Text = "Ay";
            // 
            // Az
            // 
            this.Az.AutoSize = true;
            this.Az.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Az.Location = new System.Drawing.Point(629, 12);
            this.Az.Name = "Az";
            this.Az.Size = new System.Drawing.Size(77, 53);
            this.Az.TabIndex = 2;
            this.Az.Text = "Az";
            // 
            // CurrentState
            // 
            this.CurrentState.AutoSize = true;
            this.CurrentState.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentState.Location = new System.Drawing.Point(121, 228);
            this.CurrentState.Name = "CurrentState";
            this.CurrentState.Size = new System.Drawing.Size(302, 53);
            this.CurrentState.TabIndex = 3;
            this.CurrentState.Text = "Current State";
            // 
            // DataHistory
            // 
            this.DataHistory.AutoSize = true;
            this.DataHistory.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataHistory.Location = new System.Drawing.Point(21, 307);
            this.DataHistory.Name = "DataHistory";
            this.DataHistory.Size = new System.Drawing.Size(281, 53);
            this.DataHistory.TabIndex = 4;
            this.DataHistory.Text = "Data History";
            // 
            // txtAx
            // 
            this.txtAx.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtAx.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAx.Location = new System.Drawing.Point(111, 9);
            this.txtAx.Name = "txtAx";
            this.txtAx.ReadOnly = true;
            this.txtAx.Size = new System.Drawing.Size(191, 62);
            this.txtAx.TabIndex = 5;
            // 
            // txtAz
            // 
            this.txtAz.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtAz.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAz.Location = new System.Drawing.Point(712, 12);
            this.txtAz.Name = "txtAz";
            this.txtAz.ReadOnly = true;
            this.txtAz.Size = new System.Drawing.Size(191, 62);
            this.txtAz.TabIndex = 6;
            // 
            // txtAy
            // 
            this.txtAy.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtAy.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAy.Location = new System.Drawing.Point(410, 6);
            this.txtAy.Name = "txtAy";
            this.txtAy.ReadOnly = true;
            this.txtAy.Size = new System.Drawing.Size(191, 62);
            this.txtAy.TabIndex = 7;
            // 
            // txtCurrentState
            // 
            this.txtCurrentState.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentState.Location = new System.Drawing.Point(429, 225);
            this.txtCurrentState.Name = "txtCurrentState";
            this.txtCurrentState.Size = new System.Drawing.Size(172, 62);
            this.txtCurrentState.TabIndex = 8;
            // 
            // txtHistory
            // 
            this.txtHistory.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtHistory.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHistory.Location = new System.Drawing.Point(21, 363);
            this.txtHistory.Multiline = true;
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.ReadOnly = true;
            this.txtHistory.Size = new System.Drawing.Size(1219, 479);
            this.txtHistory.TabIndex = 9;
            // 
            // processNew
            // 
            this.processNew.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processNew.Location = new System.Drawing.Point(111, 105);
            this.processNew.Name = "processNew";
            this.processNew.Size = new System.Drawing.Size(708, 97);
            this.processNew.TabIndex = 11;
            this.processNew.Text = "Process New Data Point";
            this.processNew.UseVisualStyleBackColor = true;
            this.processNew.Click += new System.EventHandler(this.processNew_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DtrEnable = true;
            this.serialPort1.PortName = "COM3";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 860);
            this.Controls.Add(this.processNew);
            this.Controls.Add(this.txtHistory);
            this.Controls.Add(this.txtCurrentState);
            this.Controls.Add(this.txtAy);
            this.Controls.Add(this.txtAz);
            this.Controls.Add(this.txtAx);
            this.Controls.Add(this.DataHistory);
            this.Controls.Add(this.CurrentState);
            this.Controls.Add(this.Az);
            this.Controls.Add(this.Ay);
            this.Controls.Add(this.Ax);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Ax;
        private System.Windows.Forms.Label Ay;
        private System.Windows.Forms.Label Az;
        private System.Windows.Forms.Label CurrentState;
        private System.Windows.Forms.Label DataHistory;
        private System.Windows.Forms.TextBox txtAx;
        private System.Windows.Forms.TextBox txtAz;
        private System.Windows.Forms.TextBox txtAy;
        private System.Windows.Forms.TextBox txtCurrentState;
        private System.Windows.Forms.TextBox txtHistory;
        private System.Windows.Forms.Button processNew;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
    }
}