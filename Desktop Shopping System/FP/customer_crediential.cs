using information;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{


    public partial class customer_crediential : Form
    {
        public static List<int> userids = new List<int>();
        int uid;
        public customer_crediential()
        {
            InitializeComponent();
        }
        private void CheckPasswordStrength()
        {
            string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()_+=\[{\]};:<>|./?,-])(?!.*\s).{8,}$";

            if (string.IsNullOrEmpty(txt_old.Text) && string.IsNullOrEmpty(txt_new.Text))
            {
                lbl_1.Text = "Old Password cannot be empty";
                lbl_1.ForeColor = Color.Red;
                lbl_2.Text = "New Password cannot be empty";
                lbl_2.ForeColor = Color.Red;
            }
            else if (string.IsNullOrEmpty(txt_old.Text))
            {
                lbl_1.Text = "Old Password cannot be empty";
                lbl_1.ForeColor = Color.Red;
            }
            else if (string.IsNullOrEmpty(txt_new.Text))
            {
                lbl_2.Text = "New Password cannot be empty";
                lbl_2.ForeColor = Color.Red;
            }
            else if (txt_old.Text == txt_new.Text)
            {
                lbl_2.Text = "New Password cannot be the same as Old Password";
                lbl_2.ForeColor = Color.Red;
            }
            else if (!Regex.IsMatch(txt_new.Text, pattern))
            {
                lbl_2.Text = "Password is weak";
                lbl_2.ForeColor = Color.Red;
            }
            else
            {
                lbl_2.Text = "Password is strong";
                lbl_2.ForeColor = Color.Green;
            }
        }

        private bool IDexistence(int uid)
        {
            string constring = Configuration1.connectionString;
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd3 = new SqlCommand("Select ID from Users", con);
            con.Open();
            SqlDataReader reader = cmd3.ExecuteReader();
            while (reader.Read())
            {
                int userId = Convert.ToInt32(reader["ID"]);
                userids.Add(userId);
            }
            reader.Close();
            con.Close();
            if (userids.Contains(uid))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btn_confirm_Click(object sender, EventArgs e)
        {

        }

        private void txt_old_TextChanged(object sender, EventArgs e)
        {
            CheckPasswordStrength();
        }

        private void txt_new_TextChanged(object sender, EventArgs e)
        {
            CheckPasswordStrength();
        }

        private void customer_crediential_Load(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
