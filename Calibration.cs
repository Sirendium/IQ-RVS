using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace iSpyApplication
{
    public partial class Calibration : Form
    {
        public Calibration()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader f1 = new StreamReader("InfoBOX.txt");
            string info_box = f1.ReadToEnd();
            f1.Close();
            text_location.Text = info_box;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Data base updated!", "Ready.");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Variables changed!", "Ready.");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Now internet-cloud dont connecction", "Please add acces in settings menu");
        }
    }
}
