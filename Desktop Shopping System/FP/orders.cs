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
using GoogleMaps.LocationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Emgu.CV.ML;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Net;

namespace final_gui_Template
{
    public partial class orders : Form
    {
        int oid;
        int remainingSeconds = 15;
        int sum = 0;
        List<int> orders_totalamount_list = new List<int>();
        DateTime order_date = DateTime.Now;

        public orders()
        {
            InitializeComponent();
        }

        private void orders_Load(object sender, EventArgs e)
        {
            if(!TableExists("orders"))
            {
                MessageBox.Show("No orders yet");
            }
        
            button2.Enabled = true;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select * from orders", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ordersgridview.DataSource = dt;
        }

        private void ordersgridview_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                oid = Convert.ToInt32(ordersgridview.SelectedRows[0].Cells[0].Value);
                shipping_adr_txtbox.Text = ordersgridview.SelectedRows[0].Cells[5].Value.ToString();
                payment_combox.Text = ordersgridview.SelectedRows[0].Cells[6].Value.ToString();

            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
        }


        private bool IsAddressValid(string adr)
        {
            /*var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(address);
            if (point != null)
            {
                return true;
            }
            else
            {
                return false;
            }*/

            string pattern = @"^\d+\s+([a-zA-Z]+\s)*[a-zA-Z]+,\s*[a-zA-Z]+(\s+[a-zA-Z]+)*\s+\d{5}(?:-\d{4})?$";
            return Regex.IsMatch(adr,pattern);

        }


    private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TableExists("orders"))
                {
                    if (string.IsNullOrEmpty(shipping_adr_txtbox.Text) && string.IsNullOrEmpty(payment_combox.Text))
                    {
                        shipadr_ind_lbl.Text = "Shipping Address cannot be empty";
                        shipadr_ind_lbl.ForeColor = Color.Red;
                        payment_ind_lbl.Text = "Payment Method cannot be empty";
                        payment_ind_lbl.ForeColor = Color.Red;
                    }
                    else if (string.IsNullOrEmpty(shipping_adr_txtbox.Text))
                    {
                        shipadr_ind_lbl.Text = "Shipping Address cannot be empty";
                        shipadr_ind_lbl.ForeColor = Color.Red;
                    }
                    else if (string.IsNullOrEmpty(payment_combox.Text))
                    {
                        payment_ind_lbl.Text = "Payment Method cannot be empty";
                        payment_ind_lbl.ForeColor = Color.Red;
                    }
                    else if (!IsAddressValid(shipping_adr_txtbox.Text))
                    {
                        shipadr_ind_lbl.Text = "Invalid Format";
                        shipadr_ind_lbl.ForeColor = Color.Red;
                        MessageBox.Show("Address Requirements : Starts with one or more digits\r\nFollowed by one or more whitespace characters\r\nFollowed by the street name, which must consist of one or more groups of alphabetical characters followed by whitespace, and end with one or more alphabetical characters\r\nFollowed by a comma\r\nFollowed by zero or more whitespace characters\r\nFollowed by the city name, which must consist of one or more alphabetical characters, and can be followed by zero or more groups of whitespace characters and one or more alphabetical characters (this allows for multi-word city names like \"New York\")\r\nFollowed by one or more whitespace characters\r\nFollowed by the ZIP code, which must consist of five digits, and can be followed by an optional group consisting of a hyphen and four more digits (this allows for ZIP+4 codes)");
                    }
                    else if (shipping_adr_txtbox.TextLength > 70)
                    {
                        shipadr_ind_lbl.Text = "Shipping Address cannot be greater than 70 characters";
                        shipadr_ind_lbl.ForeColor = Color.Red;
                    }
                    else
                    {
                        var con = Configuration.getInstance().getConnection();
                        SqlCommand cmd = new SqlCommand("Update orders set shipping_address=@shipping_address,payment_method=@payment_method where ID=@ID", con);
                        cmd.Parameters.AddWithValue("@ID", oid);
                        cmd.Parameters.AddWithValue("@shipping_address", shipping_adr_txtbox.Text);
                        cmd.Parameters.AddWithValue("@payment_method", payment_combox.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Order Updated");
                        SqlCommand cmd2 = new SqlCommand("Select * from Orders", con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ordersgridview.DataSource = dt;
                    }
                }

            }
            catch (Exception error)
            {
                //MessageBox.Show("Something went wrong", error.Message);
                 MessageBox.Show(error.Message);
            }
        }

        private bool TableExists(string table)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd3 = new SqlCommand("Select count(*) from " + table, con);
            int count = (int)cmd3.ExecuteScalar();

            if(count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //sum all orders, insert in payment, start timer n update order status accordingly
            //disable orders temporarily until the timer runs out, then clear the cart n orders
            //transaction info will be saved in payments
            try 
            {
                if (TableExists("orders"))
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd0 = new SqlCommand("Select totalamount from Orders", con);
                    SqlDataReader reader0 = cmd0.ExecuteReader();
                    while (reader0.Read())
                    {
                        int totalamount = Convert.ToInt32(reader0["totalamount"]);
                        orders_totalamount_list.Add(totalamount);
                    }
                    reader0.Close();

                    for (int i = 0; i < orders_totalamount_list.Count; i++)
                    {
                        sum += orders_totalamount_list[i];
                    }

                    MessageBox.Show("Your Grand Total is Rs." + sum.ToString() + " , Payment added.");

                    SqlCommand cmd3 = new SqlCommand("EXEC stpGetLatestCustID", con);
                    int custid = (int)cmd3.ExecuteScalar();
                    SqlCommand cmd = new SqlCommand("Insert into payment values (@totalamount_payed,@date,@CustomerID,@Refunded)", con);
                    cmd.Parameters.AddWithValue("@totalamount_payed", sum);
                    cmd.Parameters.AddWithValue("@CustomerID", custid);
                    cmd.Parameters.AddWithValue("@date", order_date);
                    cmd.Parameters.AddWithValue("@Refunded", 0);
                    cmd.ExecuteNonQuery();
                    //timer here

                    SqlCommand cmd2 = new SqlCommand("delete orders", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ordersgridview.DataSource = dt;

                    button2.Enabled = false;
                }

            }
            catch (Exception error)
            {
                //MessageBox.Show("Something went wrong", error.Message);
                 MessageBox.Show(error.Message);

            }



        }


        private void UpdateTimerLabel()
        {
            timer_lbl.Text = "Time remaining: " + remainingSeconds + " seconds";
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            remainingSeconds--;

            if (remainingSeconds <0)
            {
                remainingSeconds = 0;
                timer1.Stop();
            }

            UpdateTimerLabel();
        }
    }
}
