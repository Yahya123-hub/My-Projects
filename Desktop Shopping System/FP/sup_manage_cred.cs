using Lab2;
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
using System.Text.RegularExpressions;
using System.Drawing.Text;

namespace final_gui_Template
{
    public partial class sup_manage_cred : Form
    {
        List<int> userIds = new List<int>();
        List<string> pswds = new List<string>();
        int uid;
        public sup_manage_cred()
        {
            InitializeComponent();
        }

        private bool IDexistence(int uid)
        {
            var con = Configuration.getInstance().getConnection();
            //compare uid with all users id to see if the pswd actually exists
            SqlCommand cmd3 = new SqlCommand("Select ID from Users", con);
            SqlDataReader reader = cmd3.ExecuteReader();
            while (reader.Read())
            {
                int userId = Convert.ToInt32(reader["ID"]);
                userIds.Add(userId);
            }
            reader.Close();
            
            if (userIds.Contains(uid))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool pswdexists(string pswd)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd3 = new SqlCommand("Select pswd from Users", con);
            SqlDataReader reader = cmd3.ExecuteReader();
            
            while (reader.Read())
            {
                string dbPswd = (string)(reader["pswd"]); 
                pswds.Add(dbPswd); 
            }
            reader.Close();

            if (pswds.Contains(pswd))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool oldpswdexistence(string oldpswd)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select ID from Users where pswd=@pswd", con);
            cmd.Parameters.AddWithValue("@pswd", oldpswd);
            uid = Convert.ToInt32(cmd.ExecuteScalar());
            if (!IDexistence(uid))
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {           

            try
            {
                string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()_+=\[{\]};:<>|./?,-])(?!.*\s).{8,}$";

                if (string.IsNullOrEmpty(oldpswd_txtbox.Text) && string.IsNullOrEmpty(newpswd_txtbox.Text))
                {
                    oldpswd_ind_lbl.Text = "Old Password cannot be empty";
                    oldpswd_ind_lbl.ForeColor = Color.Red;
                    newpswd_ind_lbl.Text = "New Password cannot be empty";
                    newpswd_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(oldpswd_txtbox.Text))
                {
                    oldpswd_ind_lbl.Text = "Old Password cannot be empty";
                    oldpswd_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(newpswd_txtbox.Text))
                {
                    newpswd_ind_lbl.Text = "New Password cannot be empty";
                    newpswd_ind_lbl.ForeColor = Color.Red;
                }
                else if(oldpswd_txtbox.Text==newpswd_txtbox.Text)
                {
                    MessageBox.Show("New Password cannot be the same as Old Password");
                }
                else if(!Regex.IsMatch(newpswd_txtbox.Text, pattern))
                {
                    newpswd_ind_lbl.Text = "Password is weak, requirements:\r\n\r\nAt least one uppercase letter\r\nAt least one lowercase letter\r\nAt least one digit\r\nAt least one special character\r\nNo whitespace characters\r\nMinimum length of 8 characters";
                    newpswd_ind_lbl.ForeColor = Color.Red;
                }
                else if(pswdexists(newpswd_txtbox.Text))
                {
                    //all must have different passwords
                    newpswd_ind_lbl.Text = "Password similarity detected, try a different combination";
                    newpswd_ind_lbl.ForeColor = Color.Red;
                }
                else if(!oldpswdexistence(oldpswd_txtbox.Text))
                {
                    oldpswd_ind_lbl.Text = "No such password exists";
                    oldpswd_ind_lbl.ForeColor = Color.Red;
                }
                else
                {
                   
                    newpswd_ind_lbl.Text = "Password is strong";
                    newpswd_ind_lbl.ForeColor = Color.Green;
                    var con = Configuration.getInstance().getConnection();
                    //get id based on old pswd then update using that id 
                    /*SqlCommand cmd = new SqlCommand("Select ID from Users where pswd=@pswd", con);
                    cmd.Parameters.AddWithValue("@pswd", oldpswd_txtbox.Text);
                    uid = Convert.ToInt32(cmd.ExecuteScalar());
                    if (!IDexistence(uid))
                    {
                        oldpswd_ind_lbl.Text = "No such password exists";
                        oldpswd_ind_lbl.ForeColor = Color.Red;
                    }*/
                    SqlCommand cmd2 = new SqlCommand("Update Users set pswd=@pswd where ID=@ID", con);
                    cmd2.Parameters.AddWithValue("@ID", uid);
                    cmd2.Parameters.AddWithValue("@pswd", newpswd_txtbox.Text);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Password updated, use the new password to login next time");
                        // or just log the user out
                    
                    
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

        private void label1_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("You have been assigned the default password 123, you can use this to log in next time");
        
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void sup_manage_cred_Load(object sender, EventArgs e)
        {

        }
    }
}
