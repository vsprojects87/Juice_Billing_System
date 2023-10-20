using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Juice_Billing_System
{
    public partial class login : Form
    {
        static string s = "server=DESKTOP-DCR9VIS;database=Juice_Shop;integrated security=true";
        SqlConnection con = new SqlConnection(s);

        public login()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select password from user where username = '"+textBox1.Text+"'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string password = dr[0].ToString();

                if (textBox2.Text == password)
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
            else{
                MessageBox.Show("Wrong Login Details");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
            con.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into user values(@p1,@p2,@p3)";
            cmd.Parameters.AddWithValue("@p1", textBox3.Text);
            cmd.Parameters.AddWithValue("@p2", textBox4.Text);
            cmd.Parameters.AddWithValue("@p3", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sign Up Successfully");

            clear();
        }

        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
