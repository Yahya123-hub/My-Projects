using Lab2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace final_gui_Template
{


    public partial class submit_application : Form
    {
        int sup_id, idx;
        Supplier supplier;
        public submit_application()
        {
            InitializeComponent();
        }
        //string username = s;

        private void label2_Click(object sender, EventArgs e)
        {

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

        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool matchname(string username)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd33 = new SqlCommand("select count(*) from Users where username=@username", con);
            cmd33.Parameters.AddWithValue("@username", username);
            int count = (int)cmd33.ExecuteScalar();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(name_txtbox.Text) && string.IsNullOrEmpty(email_txtbox.Text) && string.IsNullOrEmpty(contact_txtbox.Text))
                {
                    name_ind_lbl.Text = "Name cannot be empty";
                    name_ind_lbl.ForeColor = Color.Red;
                    email_ind_lbl.Text = "Email cannot be empty";
                    email_ind_lbl.ForeColor = Color.Red;
                    contact_ind_lbl.Text = "Contact cannot be empty";
                    contact_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(name_txtbox.Text))
                {
                    name_ind_lbl.Text = "Name cannot be empty";
                    name_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(email_txtbox.Text))
                {
                    email_ind_lbl.Text = "Email cannot be empty";
                    email_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(contact_txtbox.Text))
                {
                    contact_ind_lbl.Text = "Contact cannot be empty";
                    contact_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsAllLetters(name_txtbox.Text))
                {
                    name_ind_lbl.Text = "Name must only contain letters";
                    name_ind_lbl.ForeColor = Color.Red;
                }
                else if (name_txtbox.Text.Length > 10)
                {
                    name_ind_lbl.Text = "Name cannot be greater than 10 characters";
                    name_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsValidEmail(email_txtbox.Text))
                {
                    email_ind_lbl.Text = "Invalid Email Format";
                    email_ind_lbl.ForeColor = Color.Red;
                }
                else if (contact_txtbox.Text.Substring(0, 2) != "03")
                {
                    contact_ind_lbl.Text = "Must start with 03";
                    contact_ind_lbl.ForeColor = Color.Red;
                }
                else if(!matchname(name_txtbox.Text))
                {
                    name_ind_lbl.Text = "Name should be the same as the login name";
                    name_ind_lbl.ForeColor = Color.Red;
                }
                else if (contact_txtbox.TextLength != 11 || double.Parse(contact_txtbox.Text) < 0 || double.Parse(contact_txtbox.Text) == 0)
                {
                    contact_ind_lbl.Text = "Invalid Contact number Format";
                    contact_ind_lbl.ForeColor = Color.Red;
                }
                else
                {


                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert into Suppliers values (@name,@contact,@email,@region,@isapproved,@report_eligible)", con);
                    cmd.Parameters.AddWithValue("@name", name_txtbox.Text);
                    cmd.Parameters.AddWithValue("@contact", contact_txtbox.Text);
                    cmd.Parameters.AddWithValue("@email", email_txtbox.Text);
                    cmd.Parameters.AddWithValue("@region", region_combox.Text);
                    cmd.Parameters.AddWithValue("@isapproved", 0);
                    cmd.Parameters.AddWithValue("@report_eligible", 0);
                    cmd.ExecuteNonQuery();
                    supplier = new Supplier(name_txtbox.Text, contact_txtbox.Text, email_txtbox.Text, region_combox.Text);
                    Supplier.add(supplier);
                    MessageBox.Show("Application Submitted, approval pending from admin");
                    button1.Enabled = false;

                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(name_txtbox.Text) && string.IsNullOrEmpty(email_txtbox.Text) && string.IsNullOrEmpty(contact_txtbox.Text))
                {
                    name_ind_lbl.Text = "Name cannot be empty";
                    name_ind_lbl.ForeColor = Color.Red;
                    email_ind_lbl.Text = "Email cannot be empty";
                    email_ind_lbl.ForeColor = Color.Red;
                    contact_ind_lbl.Text = "Contact cannot be empty";
                    contact_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(name_txtbox.Text))
                {
                    name_ind_lbl.Text = "Name cannot be empty";
                    name_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(email_txtbox.Text))
                {
                    email_ind_lbl.Text = "Email cannot be empty";
                    email_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(contact_txtbox.Text))
                {
                    contact_ind_lbl.Text = "Contact cannot be empty";
                    contact_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsAllLetters(name_txtbox.Text))
                {
                    name_ind_lbl.Text = "Name must only contain letters";
                    name_ind_lbl.ForeColor = Color.Red;
                }
                else if (name_txtbox.Text.Length > 10)
                {
                    name_ind_lbl.Text = "Name cannot be greater than 10 characters";
                    name_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsValidEmail(email_txtbox.Text))
                {
                    email_ind_lbl.Text = "Invalid Email Format";
                    email_ind_lbl.ForeColor = Color.Red;
                }
                else if (contact_txtbox.Text.Substring(0, 2) != "03")
                {
                    contact_ind_lbl.Text = "Must start with 03";
                    contact_ind_lbl.ForeColor = Color.Red;
                }
                else if (contact_txtbox.TextLength != 11 || double.Parse(contact_txtbox.Text) < 0 || double.Parse(contact_txtbox.Text) == 0)
                {
                    contact_ind_lbl.Text = "Invalid Contact number Format";
                    contact_ind_lbl.ForeColor = Color.Red;
                }
                else
                {
                    
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Update Suppliers set name=@name,contact=@contact,email=@email,region=@region,isapproved=@isapproved,report_eligible=@report_eligible where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", sup_id);
                    cmd.Parameters.AddWithValue("@name", name_txtbox.Text);
                    cmd.Parameters.AddWithValue("@contact", contact_txtbox.Text);
                    cmd.Parameters.AddWithValue("@email", email_txtbox.Text);
                    cmd.Parameters.AddWithValue("@region", region_combox.Text);
                    cmd.Parameters.AddWithValue("@isapproved", 0);
                    cmd.Parameters.AddWithValue("@report_eligible", 0);
                    cmd.ExecuteNonQuery();

                    /*DataGridViewRow newitem = supgridview.Rows[idx];
                    newitem.Cells[0].Value = name_txtbox.Text;
                    newitem.Cells[1].Value = contact_txtbox.Text;
                    newitem.Cells[2].Value = email_txtbox.Text;
                    newitem.Cells[3].Value = region_combox.Text;
                    Supplier updatedsupplier = new Supplier(name_txtbox.Text, contact_txtbox.Text, email_txtbox.Text, region_combox.Text);
                    Supplier.update(supplier, updatedsupplier);*/




                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Something went wrong", ex.Message);
            }
        }

        private void delfromlist()
        {
            

        }



        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(name_txtbox.Text))
                {
                    MessageBox.Show("Select application to delete");
                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Delete Suppliers where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", sup_id);
                    cmd.ExecuteNonQuery();
                    //delfromlist();
                    MessageBox.Show("Application Deleted");
                    button1.Enabled = true;
                    SqlCommand cmd2 = new SqlCommand("Select * from Suppliers", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //supgridview.DataSource = dt;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
            }
        }

        private void supgridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void supgridview_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


        }

        private void supgridview_MouseEnter(object sender, EventArgs e)
        {

        }


        private bool Applicationfilled(string username)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd33 = new SqlCommand("select count(*) from Suppliers where name=@name", con);
            cmd33.Parameters.AddWithValue("@name", username);
            int supcount = (int)cmd33.ExecuteScalar();
            if (supcount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void submit_application_Load(object sender, EventArgs e)
        {
           // MessageBox.Show(username);

            //passed username
            string username = "";
            region_combox.SelectedIndex = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select * from Suppliers", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //supgridview.DataSource = dt;

           /* if(Applicationfilled(username))
            {
                button1.Enabled = false;
                MessageBox.Show("Application already filled");
            }
            else
            {
                button1.Enabled = true;
            }*/

        
        }

        private void supgridview_Click(object sender, EventArgs e)
        {

        }

        private void supgridview_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
