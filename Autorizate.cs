using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iSpyApplication
{
    public partial class Autorizate : Form
    {
        public Autorizate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login, pass;
            login = textBox1.Text;
            pass = textBox2.Text;
            if(login == "Admin" && pass == "Admin")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Dont correctic login or password", "Dont logining!");
            }
        }

        private void Autorizate_Load(object sender, EventArgs e)
        {

        }
    }
}
