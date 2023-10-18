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
    public partial class Add_Juice_Price : Form
    {
        static string s = "server=DESKTOP-DCR9VIS;database=Juice_Shop;integrated security=true";
        SqlConnection con = new SqlConnection(s);
        public Add_Juice_Price()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            autoincreament();
            data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into juice_prices values(@p1,@p2,@p3)";
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", textBox3.Text);
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
        }
        public void autoincreament()
        {
            int r;
            con.Open();
            SqlCommand cmd = new SqlCommand("select max(juice_id) from juice_prices", con);
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
            SqlDataAdapter adp = new SqlDataAdapter("Select * from juice_prices", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update juice_prices set juice_name=@p2, juice_price=@p3 where juice_id=@p1";
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", textBox3.Text);
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
            cmd.CommandText = "delete from juice_prices where juice_id = @p1";
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
            }
         }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
