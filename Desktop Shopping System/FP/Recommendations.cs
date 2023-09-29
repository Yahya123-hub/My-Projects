using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab2;

namespace final_gui_Template
{
    public partial class Recommendations : Form
    {
        int rcount;
        List<int> r_list = new List<int>();
        string cat;
        public Recommendations()
        {
            InitializeComponent();
        }

        private void Recommendations_Load(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd3 = new SqlCommand("Select top 1 ID from Customers order by ID desc", con);
                int custid = (int)cmd3.ExecuteScalar();
                SqlCommand cmd0 = new SqlCommand("select ProductID\r\nfrom User_Interactions\r\nwhere UserID = @UserID\r\ngroup by ProductID\r\nhaving count(*) = (\r\n    select top 1 count(*) as max_count\r\n    from User_Interactions\r\n    where UserID =@UserID\r\n    group by ProductID\r\n    order by max_count desc\r\n)\r\n", con);
                cmd0.Parameters.AddWithValue("@UserID", custid);
                SqlDataReader reader0 = cmd0.ExecuteReader();
                while (reader0.Read())
                {
                    int product_id = Convert.ToInt32(reader0["ProductID"]);
                    r_list.Add(product_id);
                }
                reader0.Close();

                List<string> recommendedCategories = new List<string>();

                for (int i = 0; i < r_list.Count; i++)
                {
                    SqlCommand cmd1 = new SqlCommand("select category from products where ID=@ID", con);
                    cmd1.Parameters.AddWithValue("@ID", r_list[i]);
                    string cat = (string)cmd1.ExecuteScalar();
                    //load products of each category once
                    if (!recommendedCategories.Contains(cat))
                    {
                        recommendedCategories.Add(cat);
                        SqlCommand cmd4 = new SqlCommand("Select * from Products where category=@category", con);
                        cmd4.Parameters.AddWithValue("@category", cat);
                        SqlDataReader reader = cmd4.ExecuteReader();
                        while (reader.Read())
                        {
                            int product_id = Convert.ToInt32(reader["ID"]);
                            string product_name = (string)reader["Pname"];
                            int product_price = Convert.ToInt32(reader["Pprice"]);
                            int product_quantity = Convert.ToInt32(reader["available_quantity"]);
                            string product_category = (string)reader["category"];
                            byte[] product_image = (byte[])reader["Product_Image"];

                            item Item = new item();
                            recommended_section.Controls.Add(Item);
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
                            recommended_section.Controls.Add(Item);
                        }
                        reader.Close();
                    }
                }

                string message = string.Join(Environment.NewLine, recommendedCategories);
                MessageBox.Show(message, "Recommendations based on your earlier interactions:");

            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }



        }
    }
}
