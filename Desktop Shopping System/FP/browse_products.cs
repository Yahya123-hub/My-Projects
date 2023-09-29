using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms.Helpers.Transitions;
using Lab2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace final_gui_Template
{
    public partial class browse_products : Form
    {
        int pcount,pprice,avail_quant;
        string pname,category;
        Image pimg;
        string searchitem;
        List<int> products_price_list = new List<int>();
        List<int> products_quant_list = new List<int>();
        List<int> products_id_list = new List<int>();
        List<string> products_name_list = new List<string>();
        List<string> products_cat_list = new List<string>();
        List<byte[]> products_img_list = new List<byte[]>();

        private void products_section_Paint(object sender, PaintEventArgs e)
        {

        }

        private void loadforsearchorsort(SqlDataReader reader)
        {
            while (reader.Read())
            {
                int product_id = Convert.ToInt32(reader["ID"]);
                string product_name = (string)reader["Pname"];
                int product_price = Convert.ToInt32(reader["Pprice"]);
                int product_quantity = Convert.ToInt32(reader["available_quantity"]);
                string product_category = (string)reader["category"];
                byte[] product_image = (byte[])reader["Product_Image"];


                item Item = new item();
                products_section.Controls.Add(Item);
                Item.BackColor = Color.Gainsboro;

                Item.id = product_id;
                Item.name = product_name;
                Item.price = product_price;
                Item.quantity = product_quantity;
                if (Item.quantity <= 0)
                {
                    Item.quantity = 0;
                    Item.status = "out of stock";
                }
                Item.cat = product_category;
                using (MemoryStream ms = new MemoryStream(product_image))
                {
                    Image image = Image.FromStream(ms);
                    Item.img = image;
                }
                products_section.Controls.Add(Item);
            }
            reader.Close();
        }

        private void search_txtbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                products_section.Controls.Clear();
                string searchKeyword = search_txtbox.Text;
                if (string.IsNullOrEmpty(searchKeyword))
                {
                    loadproducts();
                    return;
                }
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select * from products where Pname like @searchKeyword OR category like @searchKeyword OR Pprice like @searchKeyword", con);
                cmd.Parameters.AddWithValue("@searchKeyword", "%" + searchKeyword + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                loadforsearchorsort(reader);

            }
            catch(Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }

        }

        private void loadproducts()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select count(*) from products", con);
            pcount = Convert.ToInt32(cmd.ExecuteScalar());

            //id
            SqlCommand cmd0 = new SqlCommand("Select ID from Products", con);
            SqlDataReader reader0 = cmd0.ExecuteReader();
            while (reader0.Read())
            {
                int product_id = Convert.ToInt32(reader0["ID"]);
                products_id_list.Add(product_id);
            }
            reader0.Close();

            //pnames
            SqlCommand cmd1 = new SqlCommand("Select pname from Products", con);
            SqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                string product_name = (string)reader["Pname"];
                products_name_list.Add(product_name);
            }
            reader.Close();

            //pprices
            SqlCommand cmd2 = new SqlCommand("Select Pprice from Products", con);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                int product_price = Convert.ToInt32(reader2["Pprice"]);
                products_price_list.Add(product_price);
            }
            reader2.Close();

            //quantities
            SqlCommand cmd3 = new SqlCommand("Select available_quantity from Products", con);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                int product_quantity = Convert.ToInt32(reader3["available_quantity"]);
                products_quant_list.Add(product_quantity);
            }
            reader3.Close();

            //category
            SqlCommand cmd4 = new SqlCommand("Select category from Products", con);
            SqlDataReader reader4 = cmd4.ExecuteReader();
            while (reader4.Read())
            {
                string product_category = (string)reader4["category"];
                products_cat_list.Add(product_category);
            }
            reader4.Close();

            //image
            SqlCommand cmd5 = new SqlCommand("Select Product_Image from Products", con);
            SqlDataReader reader5 = cmd5.ExecuteReader();
            while (reader5.Read())
            {
                byte[] product_image = (byte[])reader5["Product_Image"];
                products_img_list.Add(product_image);
            }
            reader5.Close();

            for (int i = 0; i < pcount; i++)
            {
                item Item = new item();
                products_section.Controls.Add(Item);
                Item.BackColor = Color.Gainsboro;

                Item.id = products_id_list[i];
                Item.name = products_name_list[i];
                Item.price = products_price_list[i];
                Item.quantity = products_quant_list[i];
                if (Item.quantity <= 0)
                {
                    Item.quantity = 0;
                    Item.status = "out of stock";
                }
                Item.cat = products_cat_list[i];
                using (MemoryStream ms = new MemoryStream(products_img_list[i]))
                {
                    Image image = Image.FromStream(ms);
                    Item.img = image;
                }
            }
        }

        private void search_txtbox_Enter(object sender, EventArgs e)
        {
     
            if (search_txtbox.Text == "Search by Name,Price or Category")
            {
                search_txtbox.Text = "";
                search_txtbox.ForeColor = SystemColors.WindowText;
            }
        }

        private void search_txtbox_Leave(object sender, EventArgs e)
        {
            if (search_txtbox.Text == "")
            {
                search_txtbox.Text = "Search by Name,Price or Category";
                search_txtbox.ForeColor = SystemColors.GrayText;
            }

        }

        private void search_combox_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                products_section.Controls.Clear();
                string sortKeyword = sort_combox.Text;

                if (string.IsNullOrEmpty(sortKeyword))
                {
                    return;
                }
                else if (sortKeyword=="Name")
                {
                    sortKeyword = "Pname";
                }
                else if (sortKeyword=="Price")
                {
                    sortKeyword = "Pprice";
                }
                else if (sortKeyword=="Category")
                {
                    sortKeyword = "category";
                }
                else if (sortKeyword == "Quantity")
                {
                    sortKeyword = "available_quantity";
                }

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand($"Select * from products order by {sortKeyword} asc", con);
                SqlDataReader reader = cmd.ExecuteReader();
                loadforsearchorsort(reader);
            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }






        }

        public browse_products()
        {
            InitializeComponent();
        }

        private void browse_products_Load(object sender, EventArgs e)
        {
            try
            {
                loadproducts();
            }
            catch(Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }

        }

        private void item12_Load(object sender, EventArgs e)
        {
                    
        
        }
    }
}
