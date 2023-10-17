using System.Windows.Forms;

namespace Juice_Billing_System
{
    public partial class MDI_Main : Form
    {
        public MDI_Main()
        {
            InitializeComponent();
        }

        private void addJuicePriceToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Add_Juice_Price a1 = new Add_Juice_Price();
            a1.Show();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Add_Employee a2 = new Add_Employee();
            a2.Show();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Add_Customer a3 = new Add_Customer();
            a3.Show();
        }

        private void ordersToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Order a4 = new Order();
            a4.Show();
        }

        private void showToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            view_Orders a5 = new view_Orders();
            a5.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void MDI_Main_Load(object sender, System.EventArgs e)
        {

        }
    }
}
