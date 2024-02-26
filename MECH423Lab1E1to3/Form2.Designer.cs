using System.Drawing;
using System.Windows.Forms;

namespace CsGettingStarted
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
            components = new System.ComponentModel.Container();
            Button Enqueue;
            Dequeue = new Button();
            ItemsInQueue = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            AverageQueue = new Button();
            txtN = new TextBox();
            txtAverage = new TextBox();
            Contents = new TextBox();
            txtEnqueue = new TextBox();
            txtDequeue = new TextBox();
            txtNumItems = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            Enqueue = new Button();
            SuspendLayout();
            // 
            // Enqueue
            // 
            Enqueue.Font = new Font("Arial", 14.1F);
            Enqueue.Location = new Point(5, 16);
            Enqueue.Margin = new Padding(5, 4, 5, 4);
            Enqueue.Name = "Enqueue";
            Enqueue.Size = new Size(299, 75);
            Enqueue.TabIndex = 0;
            Enqueue.Text = "Enqueue";
            Enqueue.UseVisualStyleBackColor = true;
            Enqueue.Click += Enqueue_Click;
            // 
            // Dequeue
            // 
            Dequeue.Font = new Font("Arial", 14.1F);
            Dequeue.Location = new Point(5, 115);
            Dequeue.Margin = new Padding(5, 4, 5, 4);
            Dequeue.Name = "Dequeue";
            Dequeue.Size = new Size(299, 75);
            Dequeue.TabIndex = 1;
            Dequeue.Text = "Dequeue";
            Dequeue.UseVisualStyleBackColor = true;
            Dequeue.Click += Dequeue_Click;
            // 
            // ItemsInQueue
            // 
            ItemsInQueue.AutoSize = true;
            ItemsInQueue.Font = new Font("Arial", 14.1F);
            ItemsInQueue.Location = new Point(5, 212);
            ItemsInQueue.Margin = new Padding(5, 0, 5, 0);
            ItemsInQueue.Name = "ItemsInQueue";
            ItemsInQueue.Size = new Size(339, 53);
            ItemsInQueue.TabIndex = 2;
            ItemsInQueue.Text = "Items in Queue";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 376);
            label1.Name = "label1";
            label1.Size = new Size(70, 53);
            label1.TabIndex = 3;
            label1.Text = "N:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(557, 376);
            label2.Name = "label2";
            label2.Size = new Size(211, 53);
            label2.TabIndex = 4;
            label2.Text = "Average:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 462);
            label3.Name = "label3";
            label3.Size = new Size(365, 53);
            label3.TabIndex = 5;
            label3.Text = "Queue Contents";
            // 
            // AverageQueue
            // 
            AverageQueue.Location = new Point(76, 285);
            AverageQueue.Name = "AverageQueue";
            AverageQueue.Size = new Size(909, 58);
            AverageQueue.TabIndex = 6;
            AverageQueue.Text = "Dequeue and Average First N Data Points";
            AverageQueue.UseVisualStyleBackColor = true;
            AverageQueue.Click += AverageQueue_Click;
            // 
            // txtN
            // 
            txtN.Location = new Point(76, 373);
            txtN.Name = "txtN";
            txtN.Size = new Size(250, 62);
            txtN.TabIndex = 7;
            txtN.TextChanged += txtN_TextChanged;
            // 
            // txtAverage
            // 
            txtAverage.Location = new Point(774, 373);
            txtAverage.Name = "txtAverage";
            txtAverage.Size = new Size(261, 62);
            txtAverage.TabIndex = 8;
            // 
            // Contents
            // 
            Contents.BackColor = SystemColors.ControlLightLight;
            Contents.Location = new Point(0, 518);
            Contents.Multiline = true;
            Contents.Name = "Contents";
            Contents.ReadOnly = true;
            Contents.Size = new Size(1032, 321);
            Contents.TabIndex = 9;
            Contents.TextChanged += textBox1_TextChanged;
            // 
            // txtEnqueue
            // 
            txtEnqueue.Location = new Point(360, 16);
            txtEnqueue.Name = "txtEnqueue";
            txtEnqueue.Size = new Size(672, 62);
            txtEnqueue.TabIndex = 10;
            // 
            // txtDequeue
            // 
            txtDequeue.Location = new Point(360, 128);
            txtDequeue.Name = "txtDequeue";
            txtDequeue.Size = new Size(672, 62);
            txtDequeue.TabIndex = 11;
            txtDequeue.TextChanged += txtDequeue_TextChanged;
            // 
            // txtNumItems
            // 
            txtNumItems.Location = new Point(360, 209);
            txtNumItems.Name = "txtNumItems";
            txtNumItems.Size = new Size(672, 62);
            txtNumItems.TabIndex = 12;
            txtNumItems.TextChanged += txtNumItems_TextChanged;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(27F, 53F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1602, 851);
            Controls.Add(txtNumItems);
            Controls.Add(txtDequeue);
            Controls.Add(txtEnqueue);
            Controls.Add(Contents);
            Controls.Add(txtAverage);
            Controls.Add(txtN);
            Controls.Add(AverageQueue);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ItemsInQueue);
            Controls.Add(Dequeue);
            Controls.Add(Enqueue);
            Font = new Font("Arial", 14.1F);
            Margin = new Padding(5, 4, 5, 4);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Dequeue;
        private Label ItemsInQueue;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button AverageQueue;
        private TextBox txtN;
        private TextBox txtAverage;
        private TextBox Contents;
        private TextBox txtEnqueue;
        private TextBox txtDequeue;
        private TextBox txtNumItems;
        private System.Windows.Forms.Timer timer1;
    }
}