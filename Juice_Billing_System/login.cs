using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Juice_Billing_System
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="vaibhav" && textBox2.Text == "12345")
            {
                MessageBox.Show("Login Successful");
                this.Hide();
                MDI_Main m = new MDI_Main();
                m.Show();
            }
            else
            {
                MessageBox.Show("Wrong Login Details");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
