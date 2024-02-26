using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CsGettingStarted
{
    public partial class frmMainWindow : Form
    {



        public frmMainWindow()
        {
            InitializeComponent();
        }



        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            txtXPosition.Text = e.X.ToString();
            txtYPosition.Text = e.Y.ToString();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            string coordintates = $"({txtXPosition.Text}, {txtYPosition.Text})\n";
            textBox1.AppendText(coordintates);

        }


    }


}
