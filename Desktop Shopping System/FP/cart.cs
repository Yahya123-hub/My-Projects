using DevExpress.XtraExport.Helpers;
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
using DevExpress.UIAutomation;
using System.Collections;

namespace final_gui_Template
{
    public partial class cart : Form
    {
        DateTime created = DateTime.Now;
        int pid,cid,ordered_quantity,available_quantity,updated_quantity,amount,updated_amount
       ,c_avail_quant,c_ordered_quant,c_updated_quant,c_count,c_amount,c_updatedamount,cartamount,sum=0;
        bool disablecart;
        List<int> cartIds = new List<int>();
        List<int> cart_ids2 = new List<int>();
        List<int> products_Ids = new List<int>();
        List<int> cart_amount = new List<int>();
        public cart()
        {
            InitializeComponent();
        }

        private bool IDexistence(int cid)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd3 = new SqlCommand("Select ID from cart", con);
            SqlDataReader reader = cmd3.ExecuteReader();
            while (reader.Read())
            {
                int cart_Id = Convert.ToInt32(reader["ID"]);
                cartIds.Add(cart_Id);
            }
            reader.Close();

            if (cartIds.Contains(cid))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        private void updatecart()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd4 = new SqlCommand("Update cart set quantity_ordered=@quantity_ordered where ID=@ID", con);
            cmd4.Parameters.AddWithValue("@ID", cid);
            cmd4.Parameters.AddWithValue("@quantity_ordered", ordered_quantity);
            cmd4.ExecuteNonQuery();
            MessageBox.Show("Cart Updated");
            SqlCommand cmd5 = new SqlCommand("Select * from cart", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd5);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cart_gridview.DataSource = dt;
        }


        private void dec_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (TableExists("cart"))
                {
                    if (!IDexistence(cid))
                    {
                        MessageBox.Show("Select an item to decrement quantity");
                    }
                    else
                    {
                        prelim();
                        if (ordered_quantity > 1)
                        {
                            ordered_quantity -= 1;
                            updatecart();
                        }
                        else
                        {
                            MessageBox.Show("Ordered Quantity cannot be smaller than 1");
                        }

                    }
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
            }
        }

        private void cart_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select * from cart", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cart_gridview.DataSource = dt;

            if(!TableExists("cart"))
            {
                MessageBox.Show("Cart is empty");
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


        private void cnfrm_btn_Click(object sender, EventArgs e)
        {
            //lock the cart 
            try
            {
                if (TableExists("cart"))
                {

                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Select count(*) from cart", con);
                    c_count = Convert.ToInt32(cmd.ExecuteScalar());

                    SqlCommand cmd0 = new SqlCommand("Select ID from cart", con);
                    SqlDataReader reader0 = cmd0.ExecuteReader();
                    while (reader0.Read())
                    {
                        int cart_id = Convert.ToInt32(reader0["ID"]);
                        cart_ids2.Add(cart_id);
                    }
                    reader0.Close();

                    SqlCommand cmd1 = new SqlCommand("Select ProductID from cart", con);
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    while (reader1.Read())
                    {
                        int p_id = Convert.ToInt32(reader1["ProductID"]);
                        products_Ids.Add(p_id);
                    }
                    reader1.Close();

                  



                    //List<int> combinedList = cart_ids2.Zip(products_Ids, (a, b) => a + b).ToList();
                    for (int i = 0; i < c_count; i++)
                    {
                        SqlCommand cmd3 = new SqlCommand("Select quantity_ordered from cart where ID=@ID", con);
                        cmd3.Parameters.AddWithValue("@ID", cart_ids2[i]);
                        c_ordered_quant = Convert.ToInt32(cmd3.ExecuteScalar());

                        SqlCommand cmd2 = new SqlCommand("Select available_quantity from products where ID=@ID", con);
                        cmd2.Parameters.AddWithValue("@ID", products_Ids[i]);
                        c_avail_quant = Convert.ToInt32(cmd2.ExecuteScalar());

                        SqlCommand cmd5 = new SqlCommand("Select Amount from Cart where ID=@ID", con);
                        cmd5.Parameters.AddWithValue("@ID", cart_ids2[i]);
                        c_amount = Convert.ToInt32(cmd5.ExecuteScalar());

                        //insert in payment record
                        SqlCommand cmd03 = new SqlCommand("EXEC stpGetLatestCustID", con);
                        int custid = (int)cmd03.ExecuteScalar();
                        SqlCommand cmd77 = new SqlCommand("Insert into Payment_Record values (@Amount_payed,@date,@CustomerID,@ProductID)", con);
                        cmd77.Parameters.AddWithValue("@Amount_payed", c_amount); 
                        cmd77.Parameters.AddWithValue("@date", created);
                        cmd77.Parameters.AddWithValue("@CustomerID", custid);
                        cmd77.Parameters.AddWithValue("@ProductID", products_Ids[i]);
                        cmd77.ExecuteNonQuery();


                        if (c_avail_quant - c_ordered_quant > 0)
                        {
                            c_updated_quant = c_avail_quant - c_ordered_quant;
                        }

                        //multiply amount by ordered quant
                        c_updatedamount = c_amount * c_ordered_quant;
                        //update in products table
                        SqlCommand cmd4 = new SqlCommand("Update products set available_quantity=@available_quantity where ID=@ID", con);
                        cmd4.Parameters.AddWithValue("@ID", products_Ids[i]);
                        cmd4.Parameters.AddWithValue("@available_quantity", c_updated_quant);
                        cmd4.ExecuteNonQuery();
                        //update cart price according to ordered quantity
                        SqlCommand cmd6 = new SqlCommand("Update cart set amount=@amount where ID=@ID", con);
                        cmd6.Parameters.AddWithValue("@ID", cart_ids2[i]);
                        cmd6.Parameters.AddWithValue("@amount", c_updatedamount);
                        cmd6.ExecuteNonQuery();

                    }
                    //cartstate(false);

                    SqlCommand cmd9 = new SqlCommand("Select * from cart", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd9);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cart_gridview.DataSource = dt;

                    //calculate grandtotal for order
                    SqlCommand cmd10 = new SqlCommand("Select amount from cart", con);
                    SqlDataReader reader10 = cmd10.ExecuteReader();
                    while (reader10.Read())
                    {
                        int amount = Convert.ToInt32(reader10["Amount"]);
                        cart_amount.Add(amount);
                    }
                    reader10.Close();

                    for (int i = 0; i < cart_amount.Count; i++)
                    {
                        sum += cart_amount[i];
                    }
                    orderinsert();
                    MessageBox.Show("Order added, the Cart will be disabled until you confirm the order by heading over to the order section");
                    
                    
                    SqlCommand cmd11= new SqlCommand("delete cart", con);
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd11);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    cart_gridview.DataSource = dt;
                }

            }
            catch(Exception err)
            {

                MessageBox.Show( err.Message);
            }
        }


        private void orderinsert()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into orders values (@date,@customerID,@totalamount,@status,@shipping_address,@payment_method)", con);
            cmd.Parameters.AddWithValue("@date", created); 

            SqlCommand cmd3 = new SqlCommand("Select top 1 ID from Customers order by ID desc", con);
            int custid = (int)cmd3.ExecuteScalar(); //get current cust id from info page

            SqlCommand cmd4 = new SqlCommand("Select address from Customers where ID=@ID", con);
            cmd4.Parameters.AddWithValue("@ID", custid);
            string ship_address = (string)cmd4.ExecuteScalar(); //get current address from info page

            cmd.Parameters.AddWithValue("@customerID", custid);
            cmd.Parameters.AddWithValue("@totalamount", sum);
            cmd.Parameters.AddWithValue("@status", "pending");
            cmd.Parameters.AddWithValue("@shipping_address", ship_address); 
            cmd.Parameters.AddWithValue("@payment_method", "Cash"); //default cash
            cmd.ExecuteNonQuery();
            MessageBox.Show("Order Added");

        }

        private void cart_gridview_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                cid = Convert.ToInt32(cart_gridview.SelectedRows[0].Cells[0].Value);

            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TableExists("cart"))
                {
                    if (!IDexistence(cid))
                    {
                        MessageBox.Show("Select an item to remove");

                    }
                    else
                    {
                        var con = Configuration.getInstance().getConnection();
                        SqlCommand cmd = new SqlCommand("Delete cart where ID=@ID", con);
                        cmd.Parameters.AddWithValue("@ID", cid);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Item Removed");
                        SqlCommand cmd2 = new SqlCommand("Select * from cart", con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cart_gridview.DataSource = dt;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
            }
        }

        private void prelim()
        {
            //get current ordered quant
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select quantity_ordered from cart where ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", cid);
            ordered_quantity = Convert.ToInt32(cmd.ExecuteScalar());

            //get corresponding productid
            SqlCommand cmd2 = new SqlCommand("Select ProductID from cart where ID = @ID", con);
            cmd2.Parameters.AddWithValue("@ID", cid);
            pid = Convert.ToInt32(cmd2.ExecuteScalar());

            //get avail quant based on the productid
            SqlCommand cmd3 = new SqlCommand("Select available_quantity from Products where ID = @ID", con);
            cmd3.Parameters.AddWithValue("@ID", pid);
            available_quantity = Convert.ToInt32(cmd3.ExecuteScalar());
        }



        private void inc_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (TableExists("cart"))
                {
                    if (!IDexistence(cid))
                    {
                        MessageBox.Show("Select an item to increment quantity");
                    }
                    else
                    {
                        prelim();
                        if (ordered_quantity < available_quantity)
                        {
                            ordered_quantity += 1;
                            updatecart();
                        }
                        else
                        {
                            MessageBox.Show("Max " + ordered_quantity + " Units available for this item");
                        }

                    }
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
            }


        }
    }
}
