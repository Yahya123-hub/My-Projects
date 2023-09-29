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
using Lab2;

namespace final_gui_Template
{
    public partial class payment_history : Form
    {
        public payment_history()
        {
            InitializeComponent();
        }

        private bool TableExists(string table)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd3 = new SqlCommand("Select count(*) from " + table, con);
            int count = (int)cmd3.ExecuteScalar();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void payment_history_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TableExists("payment"))
                {
                    MessageBox.Show("No payments added yet");
                }
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd2 = new SqlCommand("EXEC stpGetPayments", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                paymentgridview.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TableExists("Refund"))
                {
                    MessageBox.Show("No Refunds made yet");
                }
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd2 = new SqlCommand("EXEC stpGetRefunds", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                paymentgridview.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
        }
    }
}
