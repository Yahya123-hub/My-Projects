using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.ML;
using Lab2;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;

namespace final_gui_Template
{
    public partial class item : UserControl
    {
        DateTime cart_date = DateTime.Now;
        DateTime order_date = DateTime.Now;
      

        //myform.Show();
        public item()
        {
            InitializeComponent();
        }

        public Image img
        {

            get 
            {
                return p_image.Image;   
            }
            set 
            {
                p_image.Image = value;
            }
        }

        public string name
        {

            get
            {
                return pname_lbl.Text;
            }
            set
            {
                pname_lbl.Text = value;
            }
        }

        public string status
        {
            get
            {
                return status_lbl.Text;
            }
            set
            {
                status_lbl.Text = value;
            }
        }

        public int price
        {
            get
            {
                int price;
                if (int.TryParse(Pprice_lbl.Text, out price))
                {
                    return price;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                Pprice_lbl.Text = value.ToString();
            }
        }

        public int id
        {
            get
            {
                int id;
                if (int.TryParse(id_lbl.Text, out id))
                {
                    return id;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                id_lbl.Text = value.ToString();
            }
        }



        public string cat
        {

            get
            {
                return pcat_lbl.Text;
            }
            set
            {
                pcat_lbl.Text = value;
            }
        }

        public int quantity
        {
            get
            {
                int quantity;
                if (int.TryParse(avail_quant_lbl.Text, out quantity))
                {
                    return quantity;
                }
                else
                {
                    return 0; 
                }
            }
            set
            {
                avail_quant_lbl.Text = value.ToString();
            }
        }






        private void item_Load(object sender, EventArgs e)
        {


        }

        private void avail_quant_lbl_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                var con = Configuration.getInstance().getConnection();
                //getting data for recommendation
                SqlCommand cmd000 = new SqlCommand("Insert into User_Interactions values (@UserID,@ProductID)", con);
                SqlCommand cmd33 = new SqlCommand("Select top 1 ID from Customers order by ID desc", con);
                int uid = (int)cmd33.ExecuteScalar();
                cmd000.Parameters.AddWithValue("@UserID", uid); //get current cust id from login page
                cmd000.Parameters.AddWithValue("@ProductID", id_lbl.Text);
                cmd000.ExecuteNonQuery();


                SqlCommand cmd = new SqlCommand("Select count(*) from cart where ProductID = @ProductID", con);
                cmd.Parameters.AddWithValue("@ProductID", id_lbl.Text);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Product already exists in cart, please choose a different product.");
                }
                else if(status_lbl.Text=="out of stock")
                {
                    MessageBox.Show("Product is not in stock");
                }
                else
                {
                    SqlCommand cmd1 = new SqlCommand("Insert into cart values (@ProductID,@Amount,@date,@quantity_ordered)", con);
                    cmd1.Parameters.AddWithValue("@ProductID", id_lbl.Text);
                    cmd1.Parameters.AddWithValue("@Amount", Pprice_lbl.Text);
                    cmd1.Parameters.AddWithValue("@date", cart_date);
                    cmd1.Parameters.AddWithValue("@quantity_ordered", 1);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Added to cart");
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                var con = Configuration.getInstance().getConnection();

                //getting data for recommendation
                SqlCommand cmd000 = new SqlCommand("Insert into User_Interactions values (@UserID,@ProductID)", con);
                SqlCommand cmd33 = new SqlCommand("Select top 1 ID from Customers order by ID desc", con);
                int uid = (int)cmd33.ExecuteScalar();
                cmd000.Parameters.AddWithValue("@UserID", uid); //get current cust id from login page
                cmd000.Parameters.AddWithValue("@ProductID", id_lbl.Text);
                cmd000.ExecuteNonQuery();



                SqlCommand cmd1 = new SqlCommand("Select count(*) from cart where ProductID = @ProductID", con);
                cmd1.Parameters.AddWithValue("@ProductID", id_lbl.Text);
                int count = Convert.ToInt32(cmd1.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("Product already exists in cart, please choose a different product.");
                }
                else if(status_lbl.Text == "out of stock")
                {
                    MessageBox.Show("Product out of stock");
                }
                else
                {
                    //insert in payment record
                    SqlCommand cmd03 = new SqlCommand("EXEC stpGetLatestCustID", con);
                    int cid = (int)cmd03.ExecuteScalar();
                    SqlCommand cmd77 = new SqlCommand("Insert into Payment_Record values (@Amount_payed,@date,@CustomerID,@ProductID)", con);
                    cmd77.Parameters.AddWithValue("@Amount_payed", Pprice_lbl.Text);
                    cmd77.Parameters.AddWithValue("@date", order_date);
                    cmd77.Parameters.AddWithValue("@CustomerID", cid);
                    cmd77.Parameters.AddWithValue("@ProductID", id_lbl.Text);
                    cmd77.ExecuteNonQuery();


                    SqlCommand cmd = new SqlCommand("Insert into orders values (@date,@customerID,@totalamount,@status,@shipping_address,@payment_method)", con);
                    cmd.Parameters.AddWithValue("@date", order_date);

                    SqlCommand cmd3 = new SqlCommand("Select top 1 ID from Customers order by ID desc", con);
                    int custid = (int)cmd3.ExecuteScalar(); //get current cust id from info page

                    SqlCommand cmd4 = new SqlCommand("Select address from Customers where ID=@ID", con);
                    cmd4.Parameters.AddWithValue("@ID", custid);
                    string ship_address = (string)cmd4.ExecuteScalar(); //get current address from info page

                    cmd.Parameters.AddWithValue("@customerID", custid);
                    cmd.Parameters.AddWithValue("@totalamount", Pprice_lbl.Text);
                    cmd.Parameters.AddWithValue("@status", "pending");
                    cmd.Parameters.AddWithValue("@shipping_address", ship_address);
                    cmd.Parameters.AddWithValue("@payment_method", "Cash"); //default cash
                    cmd.ExecuteNonQuery();

                    //update quantity 
                    int avail_quant = Convert.ToInt32(avail_quant_lbl.Text);
                    if (avail_quant > 0)
                    {
                        avail_quant -= 1;
                        if(avail_quant==0)
                        {
                            status_lbl.Text = "out of stock";
                        }
                        avail_quant_lbl.Text = avail_quant.ToString();
                        //update in products table
                        SqlCommand cmd6 = new SqlCommand("Update products set available_quantity=@available_quantity where ID=@ID", con);
                        cmd6.Parameters.AddWithValue("@ID", id_lbl.Text);
                        cmd6.Parameters.AddWithValue("@available_quantity", avail_quant);
                        cmd6.ExecuteNonQuery();

                        MessageBox.Show("Order Added");
                    }
                    else
                    {
                        MessageBox.Show("Product is not in stock");
                    }
                }


            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            //getting data for recommendation
            SqlCommand cmd000 = new SqlCommand("Insert into User_Interactions values (@UserID,@ProductID)", con);
            SqlCommand cmd33 = new SqlCommand("Select top 1 ID from Customers order by ID desc", con);
            int uid = (int)cmd33.ExecuteScalar();
            cmd000.Parameters.AddWithValue("@UserID", uid); //get current cust id from login page
            cmd000.Parameters.AddWithValue("@ProductID", id_lbl.Text);
            cmd000.ExecuteNonQuery();

        }
    }
}
