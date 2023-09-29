using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using final_gui_Template.BL.AdminBL;
using final_gui_Template.DL.ADMINDL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace final_gui_Template
{
    public partial class users : Form
    {
        private static AdminBL user = new AdminBL("", "", "", "");
        public users()
        {
            InitializeComponent();
            LoadDataIntoDataGridView();
        }

        private bool UsernameExists()
        {
            string constring = Configuration.connectionString;
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Users WHERE username = @username", con);
            command.Parameters.AddWithValue("@username", user.Username);
            int count = (int)command.ExecuteScalar();
            con.Close();
            return count > 0;
        }

        private void clear_data()
        {
            txt_username.Clear();
            txt_email.Clear();
            txt_pswd.Clear();
            combo_role.Text = "";

        }
        private void update_user_grid()
        {
            usergridview.Rows.Clear();
            List<AdminBL> admins = AdminDL.retrieve_user();
            foreach (AdminBL a in admins)
            {

                int n = usergridview.Rows.Add();
                usergridview.Rows[n].Cells[0].Value = a.Id;
                usergridview.Rows[n].Cells[1].Value = a.Username;
                usergridview.Rows[n].Cells[2].Value = a.Email;
                usergridview.Rows[n].Cells[3].Value = a.Password;
                usergridview.Rows[n].Cells[4].Value = a.Role;
            }
        }
        private void LoadDataIntoDataGridView()
        {
            string constring = Configuration.connectionString;
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "SELECT * FROM Users";
            SqlCommand cmd = new SqlCommand(q, con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                usergridview.Rows.Add(reader["ID"], reader["username"], reader["email"], reader["pswd"], reader["role"], "Edit/Delete");

            }
            con.Close();
        }

        private void usergridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 5)
            {
                user.Id = Convert.ToInt32(usergridview.Rows[e.RowIndex].Cells["Column1"].Value);
                user.Username = usergridview.Rows[e.RowIndex].Cells["Column2"].FormattedValue.ToString();
                user.Email = usergridview.Rows[e.RowIndex].Cells["Column3"].FormattedValue.ToString();
                user.Password = usergridview.Rows[e.RowIndex].Cells["Column4"].FormattedValue.ToString();
                user.Role = usergridview.Rows[e.RowIndex].Cells["Column5"].FormattedValue.ToString();

                load_user();
            }
        }

        private void load_user()
        {
            txt_username.Text = user.Username;
            txt_email.Text = user.Email;
            txt_pswd.Text = user.Password;
            combo_role.Text = user.Role;
        }

        private void load_user_data()
        {
            user.Username = txt_username.Text;
            user.Email = txt_email.Text;
            user.Password = txt_pswd.Text;
            user.Role = combo_role.Text;
        }

        private void Checkvalidation()
        {
            string usernamePattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[!@#$%^&*()_+=\[{\]};:<>|./?,-])[A-Za-z\d!@#$%^&*()_+=\[{\]};:<>|./?,-]{8,}$";
            string passwordPattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()_+=\[{\]};:<>|./?,-])(?!.*\s).{8,}$";

            if (string.IsNullOrEmpty(txt_username.Text))
            {
                lbl1.Text = "Username, empty";
                lbl1.ForeColor = Color.Red;
            }
            else if (!Regex.IsMatch(txt_username.Text, usernamePattern))
            {
                lbl1.Text = "Username weak";
                lbl1.ForeColor = Color.Red;
            }
            else
            {
                lbl1.Text = "Valid";
                lbl1.ForeColor = Color.Green;
            }

            if (string.IsNullOrEmpty(txt_pswd.Text))
            {
                lbl2.Text = "Password, empty";
                lbl2.ForeColor = Color.Red;
            }
            else if (!Regex.IsMatch(txt_pswd.Text, passwordPattern))
            {
                lbl2.Text = "Password is weak.";
            }
            else
            {
                lbl2.Text = "Password is strong";
                lbl2.ForeColor = Color.Green;
            }

            if (string.IsNullOrEmpty(txt_email.Text))
            {
                lbl3.Text = "Email, empty";
                lbl3.ForeColor = Color.Red;
            }
            else if (!Regex.IsMatch(txt_email.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lbl3.Text = "Invalid email format";
                lbl3.ForeColor = Color.Red;
            }
            else
            {
                lbl3.Text = "Valid";
                lbl3.ForeColor = Color.Green;
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                user.Id = -1;
                user.Username = txt_username.Text;
                user.Email = txt_email.Text;
                user.Password = txt_pswd.Text;
                user.Role = combo_role.Text;
                if (UsernameExists())
                {
                    MessageBox.Show("Username Exists");
                }
                else if (string.IsNullOrEmpty(combo_role.Text))
                {
                    MessageBox.Show("Select Option");
                }
                else
                {
                    if (AdminDL.Add_update_user(user) == 1)
                    {
                        MessageBox.Show("Added Successfully");
                    }
                }

                update_user_grid();
                clear_data();
                user.Id = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                {
                    MessageBox.Show("Please enter valid user data.");
                    return;
                }
              
                load_user_data();

                int result = AdminDL.Add_update_user(user);

                if (result == 0)
                {
                    MessageBox.Show("Update unsuccessful.");
                }
                else if (result == 1)
                {
                    MessageBox.Show("Added successfully.");
                }
                else if (result == 2)
                {
                    MessageBox.Show("Updated successfully.");
                }
                update_user_grid();
                clear_data();
                user.Id = -1;
            }
            catch(Exception EX)
            {
                MessageBox.Show("", EX.Message);
            }


        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (user == null || user.Id == -1)
                {
                    MessageBox.Show("Please select a user to delete.");
                    return;
                }

                if (MessageBox.Show("Are you sure you want to delete this user?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                if (AdminDL.delete_Id(user.Id))
                {
                    MessageBox.Show("User deleted successfully.");
                    update_user_grid();
                    clear_data();
                    user.Id = -1;
                }
                else
                {
                    MessageBox.Show("Not delete User.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("", ex.Message);
            }
        }

        private void txt_username_TextChanged_1(object sender, EventArgs e)
        {
            Checkvalidation();
        }

        private void txt_email_TextChanged_1(object sender, EventArgs e)
        {
            Checkvalidation();
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {
            Checkvalidation();
        }
    }
}
