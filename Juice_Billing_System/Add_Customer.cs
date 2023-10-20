using System;
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
    public partial class Add_Customer : Form
    {
        static string s = "server=DESKTOP-DCR9VIS;database=Juice_Shop;integrated security=true";
        SqlConnection con = new SqlConnection(s);
        public Add_Customer()
        {
            InitializeComponent();
        }

        private void Add_Customer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gender;
            if (radioButton1.Checked == true)
                gender = "Female";
            else if (radioButton2.Checked == true)
                gender = "Male";
            else gender = "other";

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into employee values(@p1,@p2,@p3,@p4)";
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", textBox3.Text);
            cmd.Parameters.AddWithValue("@p4", gender);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Product added Successfuly");
            clear();
            autoincreament();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void autoincreament()
        {
            int r;
            con.Open();
            SqlCommand cmd = new SqlCommand("select max(emp_id) from employee", con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string d = dr[0].ToString();
                if (d == "")
                {
                    textBox1.Text = "1";
                }
                else
                {
                    r = Convert.ToInt16(d[0].ToString());
                    r = r + 1;
                    textBox1.Text = r.ToString();
                }
            }
            dr.Close();
            con.Close();
        }

        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

    }
}
