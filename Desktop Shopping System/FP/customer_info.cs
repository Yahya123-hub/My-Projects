using final_gui_Template;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace information
{
    public partial class customer_info : Form
    {
        private static Customer c = new Customer("", "", "", "", "", "");
        public customer_info()
        {
            InitializeComponent();
        }
        private void VaidateCustomer()
        {
            string namePattern = @"^[A-Za-z]+$";
            string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
            string contactPattern = @"^03\d{9}$";

            if (string.IsNullOrEmpty(txt_FirstName.Text))
            {
                lbl_Validation1.Text = "First name cannot be empty";
                lbl_Validation1.ForeColor = Color.Red;
            }
            else if (!Regex.IsMatch(txt_FirstName.Text, namePattern))
            {
                lbl_Validation1.Text = "First name can only contain letters";
                lbl_Validation1.ForeColor = Color.Red;
            }
            else
            {
                lbl_Validation1.Text = "Valid";
                lbl_Validation1.ForeColor = Color.Green;
            }

            if (string.IsNullOrEmpty(txt_LastName.Text))
            {
                lbl_Validation2.Text = "Last name cannot be empty";
                lbl_Validation2.ForeColor = Color.Red;
            }
            else if (!Regex.IsMatch(txt_LastName.Text, namePattern))
            {
                lbl_Validation2.Text = "Last name can only contain letters";
                lbl_Validation2.ForeColor = Color.Red;
            }
            else
            {
                lbl_Validation2.Text = "Valid";
                lbl_Validation2.ForeColor = Color.Green;
            }

            if (string.IsNullOrEmpty(txt_Contact.Text))
            {
                lbl_Validation3.Text = "Contact cannot be empty";
                lbl_Validation3.ForeColor = Color.Red;
            }
            else if (!Regex.IsMatch(txt_Contact.Text, contactPattern))
            {
                lbl_Validation3.Text = "Invalid contact number";
                lbl_Validation3.ForeColor = Color.Red;
            }
            else
            {
                lbl_Validation3.Text = "Valid";
                lbl_Validation3.ForeColor = Color.Green;
            }

            if (string.IsNullOrEmpty(txt_Email.Text))
            {
                lbl_Validation4.Text = "Email cannot be empty";
                lbl_Validation4.ForeColor = Color.Red;
            }
            else if (!Regex.IsMatch(txt_Email.Text, emailPattern))
            {
                lbl_Validation4.Text = "Invalid email format";
                lbl_Validation4.ForeColor = Color.Red;
            }
            else
            {
                lbl_Validation4.Text = "Valid";
                lbl_Validation4.ForeColor = Color.Green;
            }

            if (string.IsNullOrEmpty(txt_address.Text))
            {
                lbl_Validation5.Text = "Address cannot be empty";
                lbl_Validation5.ForeColor = Color.Red;
            }
            else
            {
                lbl_Validation5.Text = "Valid";
                lbl_Validation5.ForeColor = Color.Green;
            }
        }
        private bool IsExistingCustomer()
        {

            string constring = Configuration1.connectionString;
            string query = "SELECT COUNT(*) FROM Customers WHERE Fname = @FirstName AND Lname = @LastName AND mobile =@Mobile AND email =@Email AND address = @Address AND country = @Country";
            using (SqlConnection connection = new SqlConnection(constring))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", c.FirstName);
                command.Parameters.AddWithValue("@LastName", c.LastName);
                command.Parameters.AddWithValue("@Mobile", c.Contact);
                command.Parameters.AddWithValue("@Email", c.Email);
                command.Parameters.AddWithValue("@Address", c.Address);
                command.Parameters.AddWithValue("@Country", c.Country);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
        private void CheckAddButtonStatus()
        {
            if (IsExistingCustomer())
            {
                btn_Add.Enabled = false;
            }
            else
            {
                btn_Add.Enabled = true;
            }
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                c.Id = -1;
                c.FirstName = txt_FirstName.Text;
                c.LastName = txt_LastName.Text;
                c.Contact = txt_Contact.Text;
                c.Country = combo_country.Text;
                c.Email = txt_Email.Text;
                c.Address = txt_address.Text;

                if (IsExistingCustomer())
                {
                    MessageBox.Show("This is an existing customer");
                }
                else
                {
                    if (combo_country.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please select an Country");
                    }
                    else if (c.AddCustomer())
                    {
                        MessageBox.Show("Customer added successfully!");
                        btn_Add.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Failed to add customer");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Went Wrong", ex.Message);
            }


        }

        private void txt_FirstName_TextChanged(object sender, EventArgs e)
        {
            VaidateCustomer();
            // CheckAddButtonStatus();
        }

        private void txt_LastName_TextChanged(object sender, EventArgs e)
        {
            VaidateCustomer();
            //CheckAddButtonStatus();
        }

        private void txt_Contact_TextChanged(object sender, EventArgs e)
        {
            VaidateCustomer();
            //CheckAddButtonStatus();
        }

        private void txt_Email_TextChanged(object sender, EventArgs e)
        {
            VaidateCustomer();
            //CheckAddButtonStatus();
        }

        private void txt_address_TextChanged(object sender, EventArgs e)
        {
            VaidateCustomer();
            ///CheckAddButtonStatus();
        }

        private void customer_info_Load(object sender, EventArgs e)
        {

        }
    }
}
