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
using DevExpress.ClipboardSource.SpreadsheetML;
using Lab2;


namespace final_gui_Template
{
    public partial class Refund : Form
    {
        int pid,ID,totalamount_payed,CustomerID;
        DateTime date;
        List<int> l = new List<int>();
        List<int> l2 = new List<int>();
        public Refund()
        {
            InitializeComponent();
        }


        private bool IDexistence(int cid)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd3 = new SqlCommand("Select ID from payment", con);
            SqlDataReader reader = cmd3.ExecuteReader();
            while (reader.Read())
            {
                int p_Id = Convert.ToInt32(reader["ID"]);
                l.Add(p_Id);
            }
            reader.Close();

            if (l.Contains(cid))
            {
                return true;
            }
            else
            {
                return false;
            }

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


        private void Refund_Load(object sender, EventArgs e)
        {


            try
            {

                if (!TableExists("payment"))
                {
                    MessageBox.Show("No payments to refund");
                }
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd2 = new SqlCommand("Select * from payment", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                paymentsgridview.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
        }

        private void paymentsgridview_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                pid = Convert.ToInt32(paymentsgridview.SelectedRows[0].Cells[0].Value);

            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
                //MessageBox.Show(err.Message);
            }
        }

        private bool RefundEligible()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd4 = new SqlCommand("Select date from Payment where ID=@ID", con);
            cmd4.Parameters.AddWithValue("@ID", pid);
            var foundDate = (DateTime?)cmd4.ExecuteScalar();
            
            if (foundDate != null && foundDate.Value >= DateTime.Now.AddDays(-1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool AlreadyRefunded(int cid)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd3 = new SqlCommand("Select PaymentID from refund", con);
            SqlDataReader reader = cmd3.ExecuteReader();
            while (reader.Read())
            {
                int p_Id = Convert.ToInt32(reader["PaymentID"]);
                l2.Add(p_Id);
            }
            reader.Close();

            if (l2.Contains(cid))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (IDexistence(pid) && TableExists("Payment"))
                {
                    if (RefundEligible())
                    {
                        if (!AlreadyRefunded(pid))
                        {
                            //get from payments
                            var con = Configuration.getInstance().getConnection();
                            SqlCommand cmd4 = new SqlCommand("Select * from Payment where ID=@ID", con);
                            cmd4.Parameters.AddWithValue("@ID", pid);
                            SqlDataReader reader4 = cmd4.ExecuteReader();
                            while (reader4.Read())
                            {
                                ID = Convert.ToInt32(reader4["ID"]);
                                totalamount_payed = Convert.ToInt32(reader4["totalamount_payed"]);
                                date = (DateTime)reader4["date"];
                                CustomerID = Convert.ToInt32(reader4["CustomerID"]);
                            }
                            reader4.Close();

                            //insert in refund
                            SqlCommand cmd = new SqlCommand("Insert into refund values (@CustomerID,@Amount_Refunded,@Date,@PaymentID)", con);
                            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                            cmd.Parameters.AddWithValue("@Amount_Refunded", totalamount_payed);
                            cmd.Parameters.AddWithValue("@Date", date);
                            cmd.Parameters.AddWithValue("@PaymentID", ID);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Payment Refunded, check the Refunds in the history section");

                            //update payments
                            SqlCommand cmd5 = new SqlCommand("Update Payment set Refunded=@Refunded where ID=@ID", con);
                            cmd5.Parameters.AddWithValue("@ID", pid);
                            cmd5.Parameters.AddWithValue("@Refunded", 1);
                            SqlDataAdapter da = new SqlDataAdapter(cmd5);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            paymentsgridview.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Item Already Refunded");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Refunds can only be made on the same day of payment");
                    }
                }
                else
                {
                    MessageBox.Show("Select Item to refund");
                }

            }
            catch(Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
        }
    }
}
