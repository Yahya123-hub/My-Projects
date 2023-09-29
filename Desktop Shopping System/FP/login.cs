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
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;

namespace final_gui_Template
{
    public partial class login : Form
    {
        string role, username;
        public login()
        {
            InitializeComponent();
        }

        //select role,username from users where username n pwsd =inputted
        //login according to role
        //pass dat username on the application form to see if supplier has filled application

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(username_txtbox.Text) && string.IsNullOrEmpty(pswd_txtbox.Text))
                {
                    username_ind_lbl.Text = "User Name cannot be empty";
                    username_ind_lbl.ForeColor = Color.Red;
                    pswd_ind_lbl.Text = "Password cannot be empty";
                    pswd_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(username_txtbox.Text))
                {
                    username_ind_lbl.Text = "User Name cannot be empty";
                    username_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(pswd_txtbox.Text))
                {
                    pswd_ind_lbl.Text = "Password cannot be empty";
                    pswd_ind_lbl.ForeColor = Color.Red;
                }
             
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("select role,username from users where username=@username and pswd=@pswd", con);
                    cmd.Parameters.AddWithValue("@username", username_txtbox.Text); //get current cust id from login page
                    cmd.Parameters.AddWithValue("@pswd", pswd_txtbox.Text);
                    role = (String)cmd.ExecuteScalar();
                    username= (String)cmd.ExecuteScalar();

                    if(role==null)
                    {
                        MessageBox.Show("Invalid Credentials");
                    }
                    else if (role=="Supplier")
                    {
                        this.Hide();
                        Supplier_page form = new Supplier_page(username);
                        form.Show();
                       // this.Close();

                    }
                    else if (role == "Customer")
                    {
                        this.Hide();
                        Customer form = new Customer();
                        form.Show();
                       
                    }
                    else if (role == "Admin")
                    {
                        this.Hide();
                        admin_page form = new admin_page();
                        form.Show();
                       // this.Close();
                    }

                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
                //MessageBox.Show(error.Message);
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            pswd_txtbox.UseSystemPasswordChar = true;

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pswd_txtbox.UseSystemPasswordChar = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pswd_txtbox.UseSystemPasswordChar = true;
        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
