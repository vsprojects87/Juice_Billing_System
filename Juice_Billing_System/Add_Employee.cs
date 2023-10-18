using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Juice_Billing_System
{
    public partial class Add_Employee : Form
    {
        static string s = "server=DESKTOP-DCR9VIS;database=Juice_Shop;integrated security=true";
        SqlConnection con = new SqlConnection(s);
        public Add_Employee()
        {
            InitializeComponent();
        }

        private void Add_Employee_Load(object sender, EventArgs e)
        {
            autoincreament();
            data();
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
            cmd.CommandText = "insert into employee values(@p1,@p2,@p3,@p4,@p5,@p6)";
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", textBox3.Text);
            cmd.Parameters.AddWithValue("@p4", gender);
            cmd.Parameters.AddWithValue("@p5", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@p6", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Product added Successfuly");
            clear();
            autoincreament();
            data();
        }

        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
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
        public void data()
        {
            SqlDataAdapter adp = new SqlDataAdapter("Select * from employee", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
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
            cmd.CommandText = "update employee set emp_name=@p2, emp_contact=@p3, emp_gender=@p4, emp_dob=@p5, emp_sal=@p6 where emp_id=@p1";
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", textBox3.Text);
            cmd.Parameters.AddWithValue("@p4", gender);
            cmd.Parameters.AddWithValue("@p5", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@p6", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            clear();
            autoincreament();
            data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.CommandText = "delete from employee where emp_id = @p1";
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            clear();
            autoincreament();
            data();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].ToString() == "Female")
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
                dateTimePicker1.Text = row.Cells[4].Value.ToString();
                textBox3.Text = row.Cells[5].Value.ToString();
            }
        }
    }
}
