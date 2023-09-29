//using Student_Management_System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net.Mail;
using System.Linq.Expressions;

namespace Student_Management_System
{
    public partial class stdcrud : Form
    {
        int std_id,std_status;
        public stdcrud()
        {
            InitializeComponent();
        }

        private void stdcrud_Load(object sender, EventArgs e)
        {
            search_combox.SelectedIndex = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select * from Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            stdgridview.DataSource = dt;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
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

        private bool EntryAlreadyExists(string entry, int cellnum)
        {
            for (int i = 0; i < stdgridview.Rows.Count; i++)
            {
                if (entry == stdgridview.Rows[i].Cells[cellnum].Value.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private bool Isvalidregnum(string s)
        {
            if (s[0]=='2' && s[1] == '0' && s[2] == '2' && s[3] == '1' && s[4] == '-' && s[5] == 'C' && s[6] == 'S' && s[7] == '-' && IsDigitsOnly(s.Substring(8)))
            {
                return true;
            }
            else
            {
                return false;
            }
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



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(stdfname_txtbox.Text) && string.IsNullOrEmpty(stdlname_txtbox.Text) && string.IsNullOrEmpty(stdcontact_txtbox.Text) && string.IsNullOrEmpty(stdemail_txtbox.Text) && string.IsNullOrEmpty(stdregnum_txtbox.Text))
                {
                    stdfname_ind_lbl.Text = "First Name cannot be empty";
                    stdfname_ind_lbl.ForeColor = Color.Red;
                    stdlname_ind_lbl.Text = "Last Name cannot be empty";
                    stdlname_ind_lbl.ForeColor = Color.Red;
                    stdcontact_ind_lbl.Text = "Contact cannot be empty";
                    stdcontact_ind_lbl.ForeColor = Color.Red;
                    stdemail_ind_lbl.Text = "Email cannot be empty";
                    stdemail_ind_lbl.ForeColor = Color.Red;
                    stdregnum_ind_lbl.Text = "Registration Number cannot be empty";
                    stdregnum_ind_lbl.ForeColor = Color.Red;

                }
                else if (string.IsNullOrEmpty(stdfname_txtbox.Text))
                {
                    stdfname_ind_lbl.Text = "First Name cannot be empty";
                    stdfname_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(stdlname_txtbox.Text))
                {
                    stdlname_ind_lbl.Text = "Last Name cannot be empty";
                    stdlname_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsAllLetters(stdfname_txtbox.Text))
                {
                    stdfname_ind_lbl.Text = "First Name must only contain letters";
                    stdfname_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsAllLetters(stdlname_txtbox.Text))
                {
                    stdlname_ind_lbl.Text = "Last Name must only contain letters";
                    stdlname_ind_lbl.ForeColor = Color.Red;
                }
                else if (stdfname_txtbox.Text.Length > 10)
                {
                    stdfname_ind_lbl.Text = "First Name cannot be greater than 10 characters";
                    stdfname_ind_lbl.ForeColor = Color.Red;
                }
                else if (stdlname_txtbox.Text.Length > 10)
                {
                    stdlname_ind_lbl.Text = "Last Name cannot be greater than 10 characters";
                    stdlname_ind_lbl.ForeColor = Color.Red;
                }
                else if (stdcontact_txtbox.Text.Substring(0, 2) != "03")
                {
                    stdcontact_ind_lbl.Text = "Phone number must start with 03";
                    stdcontact_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(stdcontact_txtbox.Text))
                {
                    stdcontact_ind_lbl.Text = "Phone number cannot be empty";
                    stdcontact_ind_lbl.ForeColor = Color.Red;
                }
                else if (stdcontact_txtbox.TextLength != 11 || double.Parse(stdcontact_txtbox.Text) < 0 || double.Parse(stdcontact_txtbox.Text) == 0)
                {
                    stdcontact_ind_lbl.Text = "Invalid Phone number Format";
                    stdcontact_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(stdemail_txtbox.Text))
                {
                    stdemail_ind_lbl.Text = "Email cannot be empty";
                    stdemail_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsValidEmail(stdemail_txtbox.Text))
                {
                    stdemail_ind_lbl.Text = "Invalid Email Format";
                    stdemail_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(stdregnum_txtbox.Text))
                {
                    stdregnum_ind_lbl.Text = "Registration number cannot be empty";
                    stdregnum_ind_lbl.ForeColor = Color.Red;
                }
                else if (!Isvalidregnum(stdregnum_txtbox.Text))
                {
                    stdregnum_ind_lbl.Text = "Invalid format";
                    stdregnum_ind_lbl.ForeColor = Color.Red;
                }
                else if (EntryAlreadyExists(stdregnum_txtbox.Text, 5))
                {
                    MessageBox.Show("Registration Number already Exists");
                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert into Student values (@Firstname,@Lastname,@Contact,@Email,@RegistrationNumber,@Status)", con);
                    cmd.Parameters.AddWithValue("@Firstname", stdfname_txtbox.Text);
                    cmd.Parameters.AddWithValue("@Lastname", stdlname_txtbox.Text);
                    cmd.Parameters.AddWithValue("@Contact", stdcontact_txtbox.Text);
                    cmd.Parameters.AddWithValue("@Email", stdemail_txtbox.Text);
                    cmd.Parameters.AddWithValue("@RegistrationNumber", stdregnum_txtbox.Text);
                    if(stdactive_chkbox.Checked)
                    {
                        cmd.Parameters.AddWithValue("@Status", 5);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Status", 6);
                    }
               
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Added");
                    SqlCommand cmd2 = new SqlCommand("Select * from Student", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    stdgridview.DataSource = dt;


                }
                
            }
            catch(Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
            }

        }

        private bool updaterepetition(string s, DataGridView dg, int cellnum)
        {
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                if (s == dg.Rows[i].Cells[cellnum].Value.ToString() && s != dg.CurrentRow.Cells[cellnum].Value.ToString())
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


                if (string.IsNullOrEmpty(stdfname_txtbox.Text) && string.IsNullOrEmpty(stdlname_txtbox.Text) && string.IsNullOrEmpty(stdcontact_txtbox.Text) && string.IsNullOrEmpty(stdemail_txtbox.Text) && string.IsNullOrEmpty(stdregnum_txtbox.Text))
                {
                    stdfname_ind_lbl.Text = "First Name cannot be empty";
                    stdfname_ind_lbl.ForeColor = Color.Red;
                    stdlname_ind_lbl.Text = "Last Name cannot be empty";
                    stdlname_ind_lbl.ForeColor = Color.Red;
                    stdcontact_ind_lbl.Text = "Contact cannot be empty";
                    stdcontact_ind_lbl.ForeColor = Color.Red;
                    stdemail_ind_lbl.Text = "Email cannot be empty";
                    stdemail_ind_lbl.ForeColor = Color.Red;
                    stdregnum_ind_lbl.Text = "Registration Number cannot be empty";
                    stdregnum_ind_lbl.ForeColor = Color.Red;

                }
                else if (string.IsNullOrEmpty(stdfname_txtbox.Text))
                {
                    stdfname_ind_lbl.Text = "First Name cannot be empty";
                    stdfname_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(stdlname_txtbox.Text))
                {
                    stdlname_ind_lbl.Text = "Last Name cannot be empty";
                    stdlname_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsAllLetters(stdfname_txtbox.Text))
                {
                    stdfname_ind_lbl.Text = "First Name must only contain letters";
                    stdfname_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsAllLetters(stdlname_txtbox.Text))
                {
                    stdlname_ind_lbl.Text = "Last Name must only contain letters";
                    stdlname_ind_lbl.ForeColor = Color.Red;
                }
                else if (stdfname_txtbox.Text.Length > 10)
                {
                    stdfname_ind_lbl.Text = "First Name cannot be greater than 10 characters";
                    stdfname_ind_lbl.ForeColor = Color.Red;
                }
                else if (stdlname_txtbox.Text.Length > 10)
                {
                    stdlname_ind_lbl.Text = "Last Name cannot be greater than 10 characters";
                    stdlname_ind_lbl.ForeColor = Color.Red;
                }
                else if (stdcontact_txtbox.Text.Substring(0, 2) != "03")
                {
                    stdcontact_ind_lbl.Text = "Phone number must start with 03";
                    stdcontact_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(stdcontact_txtbox.Text))
                {
                    stdcontact_ind_lbl.Text = "Phone number cannot be empty";
                    stdcontact_ind_lbl.ForeColor = Color.Red;
                }
                else if (stdcontact_txtbox.TextLength != 11 || double.Parse(stdcontact_txtbox.Text) < 0 || double.Parse(stdcontact_txtbox.Text) == 0)
                {
                    stdcontact_ind_lbl.Text = "Invalid Phone number Format";
                    stdcontact_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(stdemail_txtbox.Text))
                {
                    stdemail_ind_lbl.Text = "Email cannot be empty";
                    stdemail_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsValidEmail(stdemail_txtbox.Text))
                {
                    stdemail_ind_lbl.Text = "Invalid Email Format";
                    stdemail_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(stdregnum_txtbox.Text))
                {
                    stdregnum_ind_lbl.Text = "Registration number cannot be empty";
                    stdregnum_ind_lbl.ForeColor = Color.Red;
                }
                else if (!Isvalidregnum(stdregnum_txtbox.Text))
                {
                    stdregnum_ind_lbl.Text = "Invalid format";
                    stdregnum_ind_lbl.ForeColor = Color.Red;
                }
                else if (updaterepetition(stdregnum_txtbox.Text, stdgridview, 5))
                {
                    MessageBox.Show("Registration Number already exists");
                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Update Student set Firstname=@Firstname,Lastname=@Lastname,Email=@Email,Contact=@Contact, Status=@Status, RegistrationNumber=@RegistrationNumber where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", std_id);
                    cmd.Parameters.AddWithValue("@Firstname", stdfname_txtbox.Text);
                    cmd.Parameters.AddWithValue("@Lastname", stdlname_txtbox.Text);
                    cmd.Parameters.AddWithValue("@Contact", stdcontact_txtbox.Text);
                    cmd.Parameters.AddWithValue("@Email", stdemail_txtbox.Text);
                    cmd.Parameters.AddWithValue("@RegistrationNumber", stdregnum_txtbox.Text);
                    if (stdactive_chkbox.Checked)
                    {
                        cmd.Parameters.AddWithValue("@Status", 5);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Status", 6);
                    }
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Updated");
                    SqlCommand cmd2 = new SqlCommand("Select * from Student", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    stdgridview.DataSource = dt;
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
                if (string.IsNullOrEmpty(stdfname_txtbox.Text) || string.IsNullOrEmpty(stdlname_txtbox.Text) || string.IsNullOrEmpty(stdcontact_txtbox.Text) || string.IsNullOrEmpty(stdemail_txtbox.Text) || string.IsNullOrEmpty(stdregnum_txtbox.Text))
                {
                    MessageBox.Show("Select a student to delete");

                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Delete Student where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", std_id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Deleted");
                    SqlCommand cmd2 = new SqlCommand("Select * from Student", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    stdgridview.DataSource = dt;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
  
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchdgv(string searchtxt)
        {
            bool found = false;
            stdgridview.ClearSelection();
            foreach (DataGridViewRow row in stdgridview.Rows)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                string searchtxt;
                if (search_combox.SelectedItem.ToString() == "First-Name")
                {
                    searchtxt = stdfname_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");

                    }
                    else
                    {
                        searchdgv(searchtxt);
                    }

                }
                else if (search_combox.SelectedItem.ToString() == "Last-Name")
                {
                    searchtxt = stdlname_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");

                    }
                    else
                    {
                        searchdgv(searchtxt);
                    }
                }
                else if (search_combox.SelectedItem.ToString() == "Contact")
                {
                    searchtxt = stdcontact_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");

                    }
                    else
                    {
                        searchdgv(searchtxt);
                    }

                }
                else if (search_combox.SelectedItem.ToString() == "Registration-Number")
                {
                    searchtxt = stdregnum_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");

                    }
                    else
                    {
                        searchdgv(searchtxt);
                    }

                }
                else if (search_combox.SelectedItem.ToString() == "Email")
                {
                    searchtxt = stdemail_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");

                    }
                    else
                    {
                        searchdgv(searchtxt);
                    }
                }




            }
            catch(Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
        }

        private void stdactive_chkbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void stdgridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void stdgridview_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                std_id = Convert.ToInt32(stdgridview.SelectedRows[0].Cells[0].Value);
                stdfname_txtbox.Text = stdgridview.SelectedRows[0].Cells[1].Value.ToString();
                stdlname_txtbox.Text = stdgridview.SelectedRows[0].Cells[2].Value.ToString();
                stdcontact_txtbox.Text = stdgridview.SelectedRows[0].Cells[3].Value.ToString();
                stdemail_txtbox.Text = stdgridview.SelectedRows[0].Cells[4].Value.ToString();
                stdregnum_txtbox.Text = stdgridview.SelectedRows[0].Cells[5].Value.ToString();
                std_status = Convert.ToInt32(stdgridview.SelectedRows[0].Cells[6].Value);
            }
            catch(Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
            

        }
    }
}
