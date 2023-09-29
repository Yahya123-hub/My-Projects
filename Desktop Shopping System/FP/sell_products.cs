using Lab2;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Emgu.CV;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;

namespace final_gui_Template
{
    public partial class sell_products : Form
    {
        int pid;
        string img_url = null;
        Product product;
        public sell_products()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }

        private bool EntryAlreadyExists(string entry1, string entry2, string entry3, int cellnum1, int cellnum2, int cellnum3)
        {
            for (int i = 0; i < pgridview.Rows.Count; i++)
            {
                if (entry1 == pgridview.Rows[i].Cells[cellnum1].Value.ToString() && entry2 == pgridview.Rows[i].Cells[cellnum2].Value.ToString() && entry3 == pgridview.Rows[i].Cells[cellnum3].Value.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        
        private bool IsProductNameValid(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetterOrDigit(c) && !Char.IsWhiteSpace(c))
                    return false;
            }

            bool containsNonDigits = s.Any(c => !Char.IsDigit(c));
            if (!containsNonDigits)
                return false;

            return true;
        }



        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(pname_txtbox.Text) && string.IsNullOrEmpty(pprice_txtbox.Text) && string.IsNullOrEmpty(avail_quant_txtbox.Text))
                {
                    pname_ind_lbl.Text = "Product Name cannot be empty";
                    pname_ind_lbl.ForeColor = Color.Red;
                    pprice_ind_lbl.Text = "Product Price cannot be empty";
                    pprice_ind_lbl.ForeColor = Color.Red;
                    avail_quant_ind_lbl.Text = "Available Quantity cannot be empty";
                    avail_quant_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(pname_txtbox.Text))
                {
                    pname_ind_lbl.Text = "Product Name cannot be empty";
                    pname_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(pprice_txtbox.Text))
                {
                    pprice_ind_lbl.Text = "Product Price cannot be empty";
                    pprice_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(avail_quant_txtbox.Text))
                {
                    avail_quant_ind_lbl.Text = "Quantity cannot be empty";
                    avail_quant_ind_lbl.ForeColor = Color.Red;
                }
                else if (!(pprice_txtbox.Text.ToString().All(char.IsDigit)))
                {
                    pprice_ind_lbl.Text = "Price must only contain numbers";
                    pprice_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(pprice_txtbox.Text) < 0 || int.Parse(pprice_txtbox.Text) == 0)
                {
                    pprice_ind_lbl.Text = "Invalid Price";
                    pprice_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(pprice_txtbox.Text) > 10000)
                {
                    pprice_ind_lbl.Text = "Price cannnot be greater than 10000";
                    pprice_ind_lbl.ForeColor = Color.Red;
                }
                else if (!(avail_quant_txtbox.Text.ToString().All(char.IsDigit)))
                {
                    avail_quant_ind_lbl.Text = "Quantity must only contain numbers";
                    avail_quant_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(avail_quant_txtbox.Text) < 0 || int.Parse(avail_quant_txtbox.Text) == 0)
                {
                    avail_quant_ind_lbl.Text = "Invalid Quantity";
                    avail_quant_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(avail_quant_txtbox.Text) > 10000)
                {
                    avail_quant_ind_lbl.Text = "Quantity cannnot be greater than 10000";
                    avail_quant_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsProductNameValid(pname_txtbox.Text))
                {
                    pname_ind_lbl.Text = "Invalid Comment";
                    pname_ind_lbl.ForeColor = Color.Red;
                }
                else if (pname_txtbox.Text.Length > 30)
                {
                    pname_ind_lbl.Text = "Product Name must be less than 30 characters";
                    pname_ind_lbl.ForeColor = Color.Red;
                }
                else if(product_pic.Image==null)
                {
                    img_ind_lbl.Text = "Product must have an image";
                    img_ind_lbl.ForeColor = Color.Red;
                }

                else
                {
                    //image input
                    Image img = product_pic.Image;
                    byte[] arr;
                    ImageConverter converter = new ImageConverter();
                    arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

                   
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert into Products values (@Pname,@Pprice,@available_quantity,@category,@SupplierID,@Product_Image,@Image_url)", con);
                    cmd.Parameters.AddWithValue("@Pname", pname_txtbox.Text);
                    cmd.Parameters.AddWithValue("@Pprice", pprice_txtbox.Text);
                    cmd.Parameters.AddWithValue("@available_quantity", avail_quant_txtbox.Text);
                    cmd.Parameters.AddWithValue("@category", cat_combox.Text);
                    //insert in cat
                    /*SqlCommand cmd88 = new SqlCommand("Insert into Category values (@Product_category)", con);
                    cmd88.Parameters.AddWithValue("@Product_category",cat_combox.Text);
                    cmd88.ExecuteNonQuery();*/ //done through trigger
                    //get supid
                    SqlCommand cmd3 = new SqlCommand("EXEC stpGetLatestSupid", con);
                    int supid = (int)cmd3.ExecuteScalar();
                    cmd.Parameters.AddWithValue("@SupplierID", supid);
                    cmd.Parameters.AddWithValue("@Product_Image", arr);
                    if (!string.IsNullOrEmpty(img_url_txtbox.Text))
                    {
                        cmd.Parameters.AddWithValue("@Image_url", img_url_txtbox.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Image_url", img_url);
                    }
                    cmd.ExecuteNonQuery();
                    product = new Product(pname_txtbox.Text,int.Parse(pprice_txtbox.Text),int.Parse(avail_quant_txtbox.Text),cat_combox.Text,img);
                    Product.add(product);
                    MessageBox.Show("Product Added");
                    SqlCommand cmd2 = new SqlCommand("Select * from Products", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    pgridview.DataSource = dt;


                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
              // MessageBox.Show(error.Message);
            }

        }

        private bool updaterepetition(string s,string s2,string s3, DataGridView dg, int cellnum, int cellnum2, int cellnum3)
        {
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                if ((s == dg.Rows[i].Cells[cellnum].Value.ToString() && s != dg.CurrentRow.Cells[cellnum].Value.ToString()) && (s2 == dg.Rows[i].Cells[cellnum2].Value.ToString() && s2 != dg.CurrentRow.Cells[cellnum2].Value.ToString()) && (s3 == dg.Rows[i].Cells[cellnum3].Value.ToString() && s3 != dg.CurrentRow.Cells[cellnum3].Value.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(pname_txtbox.Text) && string.IsNullOrEmpty(pprice_txtbox.Text) && string.IsNullOrEmpty(avail_quant_txtbox.Text))
                {
                    pname_ind_lbl.Text = "Product Name cannot be empty";
                    pname_ind_lbl.ForeColor = Color.Red;
                    pprice_ind_lbl.Text = "Product Price cannot be empty";
                    pprice_ind_lbl.ForeColor = Color.Red;
                    avail_quant_ind_lbl.Text = "Available Quantity cannot be empty";
                    avail_quant_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(pname_txtbox.Text))
                {
                    pname_ind_lbl.Text = "Product Name cannot be empty";
                    pname_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(pprice_txtbox.Text))
                {
                    pprice_ind_lbl.Text = "Product Price cannot be empty";
                    pprice_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(avail_quant_txtbox.Text))
                {
                    avail_quant_ind_lbl.Text = "Quantity cannot be empty";
                    avail_quant_ind_lbl.ForeColor = Color.Red;
                }
                else if (!(pprice_txtbox.Text.ToString().All(char.IsDigit)))
                {
                    pprice_ind_lbl.Text = "Price must only contain numbers";
                    pprice_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(pprice_txtbox.Text) < 0 || int.Parse(pprice_txtbox.Text) == 0)
                {
                    pprice_ind_lbl.Text = "Invalid Price";
                    pprice_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(pprice_txtbox.Text) > 10000)
                {
                    pprice_ind_lbl.Text = "Price cannnot be greater than 10000";
                    pprice_ind_lbl.ForeColor = Color.Red;
                }
                else if (!(avail_quant_txtbox.Text.ToString().All(char.IsDigit)))
                {
                    avail_quant_ind_lbl.Text = "Quantity must only contain numbers";
                    avail_quant_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(avail_quant_txtbox.Text) < 0 || int.Parse(avail_quant_txtbox.Text) == 0)
                {
                    avail_quant_ind_lbl.Text = "Invalid Quantity";
                    avail_quant_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(avail_quant_txtbox.Text) > 10000)
                {
                    pprice_ind_lbl.Text = "Quantity cannnot be greater than 10000";
                    pprice_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsProductNameValid(pname_txtbox.Text))
                {
                    pname_ind_lbl.Text = "Invalid Comment";
                    pname_ind_lbl.ForeColor = Color.Red;
                }
                else if (pname_txtbox.Text.Length > 30)
                {
                    pname_ind_lbl.Text = "Product Name must be less than 30 characters";
                    pname_ind_lbl.ForeColor = Color.Red;
                }
                else if (product_pic.Image == null)
                {
                    img_ind_lbl.Text = "Product must have an image";
                    img_ind_lbl.ForeColor = Color.Red;
                }
                else
                {
                    //image input
                    Image img = product_pic.Image;
                    byte[] arr;
                    ImageConverter converter = new ImageConverter();
                    arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

                    var con = Configuration.getInstance().getConnection();
                    //update in cat
                    SqlCommand cmd88 = new SqlCommand("Update Category set Product_category=@Product_category where Id=@Id", con);
                    cmd88.Parameters.AddWithValue("@Id", pid);
                    cmd88.Parameters.AddWithValue("@Product_category", cat_combox.Text);
                    cmd88.ExecuteNonQuery();
                    //update in p
                    SqlCommand cmd = new SqlCommand("Update Products set Pname=@Pname,Pprice=@Pprice,available_quantity=@available_quantity,category=@category,Product_Image=@Product_Image,Image_url=@Image_url where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", pid);
                    cmd.Parameters.AddWithValue("@Pname", pname_txtbox.Text);
                    cmd.Parameters.AddWithValue("@Pprice", pprice_txtbox.Text);
                    cmd.Parameters.AddWithValue("@available_quantity", avail_quant_txtbox.Text);
                    cmd.Parameters.AddWithValue("@category", cat_combox.Text);
                    cmd.Parameters.AddWithValue("@Product_Image", arr);
                    if (!string.IsNullOrEmpty(img_url_txtbox.Text))
                    {
                        cmd.Parameters.AddWithValue("@Image_url", img_url_txtbox.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Image_url", img_url);
                    }
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Updated");
                    SqlCommand cmd2 = new SqlCommand("Select * from Products", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    pgridview.DataSource = dt;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(pname_txtbox.Text))
                {
                    MessageBox.Show("Select a Product to delete");
                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Delete Products where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", pid);
                    cmd.ExecuteNonQuery();

                    //del in cat
                    SqlCommand cmd88 = new SqlCommand("Delete Category where Id=@Id", con);
                    cmd88.Parameters.AddWithValue("@Id", pid);
                    cmd88.ExecuteNonQuery();


                    MessageBox.Show("Product Deleted");
                    SqlCommand cmd2 = new SqlCommand("Select * from Products", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    pgridview.DataSource = dt;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
            }
        }



        private void searchdgv(string searchtxt)
        {
            bool found = false;
            pgridview.ClearSelection();
            foreach (DataGridViewRow row in pgridview.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value.ToString().Contains(searchtxt))
                    {
                        row.Selected = true;
                        found = true;
                    }
                }
            }
            if (!found)
            {
                MessageBox.Show("Item not found");
            }
        }

        private void searchdgvint(int s, DataGridView dg, string colname)
        {
            bool found = false;
            dg.ClearSelection();
            foreach (DataGridViewRow row in dg.Rows)
            {
                if (row.Cells[colname].Value != null && Convert.ToInt32(row.Cells[colname].Value) == s)
                {
                    row.Selected = true;
                    found = true;
                }
            }
            if (!found)
            {
                MessageBox.Show("Item not found");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string searchtxt;
                if (search_combox.SelectedItem.ToString() == "Name")
                {
                    searchtxt = pname_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");
                    }
                    else
                    {
                        searchdgv(searchtxt);
                    }

                }
                else if (search_combox.SelectedItem.ToString() == "Price")
                {
                    searchtxt = pprice_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");

                    }
                    else
                    {
                        searchdgvint(int.Parse(pprice_txtbox.Text), pgridview, "Pprice");
                    }
                }
                else if (search_combox.SelectedItem.ToString() == "Quantity")
                {
                    searchtxt = avail_quant_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");

                    }
                    else
                    {
                        searchdgvint(int.Parse(avail_quant_txtbox.Text), pgridview, "available_quantity");
                    }

                }
                else if (search_combox.SelectedItem.ToString() == "Category")
                {
                    searchtxt = cat_combox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");

                    }
                    else
                    {
                        searchdgv(searchtxt);
                    }

                }
                else if (search_combox.SelectedItem.ToString() == "Image")
                {
                    
                    if (product_pic.Image!=null)
                    {
                        Image img = product_pic.Image;
                        Bitmap bmp = new Bitmap(img);
                        dgvImgsearch(bmp, pgridview);
                                              
                    }
                    else
                    {
                        MessageBox.Show("Nothing to Search");
                    }

                }

            }
            catch (Exception error)
            {
                // MessageBox.Show("Something went wrong", error.Message);
                MessageBox.Show(error.Message);
            }
        }

        public void dgvImgsearch(Bitmap bmpImage1, DataGridView dgvImages)
        {
            int correct = 0;
            int totalPixels = 0;
            bool found=false;

            foreach (DataGridViewRow row in dgvImages.Rows)
            {
                if (!row.IsNewRow && row.Cells["Product_Image"].Value != null)
                {
                    Bitmap bmpImage2 = (Bitmap)row.Cells["Product_Image"].Value;
                    for (int i = 0; i < bmpImage1.Width; i++)
                    {
                        for (int j = 0; j < bmpImage1.Height; j++)
                        {
                            Color c1 = bmpImage1.GetPixel(i, j);
                            Color c2 = bmpImage2.GetPixel(i, j);
                            if (c1.ToArgb() == c2.ToArgb())
                                correct++;
                            totalPixels++;
                            
                            if ((100.0 * correct) / totalPixels >= 90)
                            {
                                row.Selected = true;
                                found = true;
                            }
                        }
                    }
                }
            }
            if (!found)
            {
                MessageBox.Show("Item not found");
            }
            
        }


        private bool Applicationfilled(string username)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd33 = new SqlCommand("select count(*) from Suppliers where name=@name", con);
            cmd33.Parameters.AddWithValue("@name", username);
            int supcount = (int)cmd33.ExecuteScalar();
            if(supcount>0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void sell_products_Load(object sender, EventArgs e)
        {
            //check eligibility to sell
            //if application filled
            try
            {
                //get current username, passed through forms
                //string username="";
                //if (Applicationfilled(username))
                //{
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd3 = new SqlCommand("EXEC stpGetLatestSupid", con);
                    int supid = (int)cmd3.ExecuteScalar();

                    SqlCommand cmd4 = new SqlCommand("Select isapproved from Suppliers where ID=@ID", con);
                    cmd4.Parameters.AddWithValue("@ID", supid);
                    bool isapproved = (bool)cmd4.ExecuteScalar();

                    //if (isapproved)
                    //{
                        button1.Enabled = true;
                        button2.Enabled = true;
                        button3.Enabled = true;
                        button4.Enabled = true;
                        button5.Enabled = true;
                        pgridview.Enabled = true;
                        search_combox.SelectedIndex = 1;
                        cat_combox.SelectedIndex = 1;

                        SqlCommand cmd2 = new SqlCommand("EXEC stpGetProducts", con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        pgridview.DataSource = dt;
                    //}
                    /*else
                    {
                        MessageBox.Show("Not approved for selling items yet");
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                        pgridview.Enabled = false;
                    }*/
                /*}
                else
                {
                    MessageBox.Show("Fill the Application by going over to the Submit Application Section");
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    pgridview.Enabled = false;
                }*/
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void pgridview_Enter(object sender, EventArgs e)
        {

        }

        private void pgridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cat_combox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void search_combox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pgridview_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                pid = Convert.ToInt32(pgridview.SelectedRows[0].Cells[0].Value);
                pname_txtbox.Text = pgridview.SelectedRows[0].Cells[1].Value.ToString();
                pprice_txtbox.Text = pgridview.SelectedRows[0].Cells[2].Value.ToString();
                avail_quant_txtbox.Text = pgridview.SelectedRows[0].Cells[3].Value.ToString();
                cat_combox.Text = pgridview.SelectedRows[0].Cells[4].Value.ToString();
                //show updated img
                if (pgridview.SelectedRows.Count > 0)
                {
                    byte[] imageData = (byte[])pgridview.SelectedRows[0].Cells[6].Value;
                    if (imageData != null)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            product_pic.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        product_pic.Image = null;
                    }
                }
                img_url_txtbox.Text = pgridview.SelectedRows[0].Cells[7].Value.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd=new OpenFileDialog())
            {
                if(ofd.ShowDialog() == DialogResult.OK) 
                {
                    img_url=ofd.FileName;
                    product_pic.Image = Image.FromFile(ofd.FileName);
                
                }

            }
        }

        private void pgridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
