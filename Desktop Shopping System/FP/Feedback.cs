using Emgu.CV.OCR;
using Lab2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace final_gui_Template
{
    public partial class Feedback : Form
    {
        int fid;
        List<int> SIDs = new List<int>();
        public Feedback()
        {
            InitializeComponent();
        }

        private void Feedback_Load(object sender, EventArgs e)
        {
            search_combox.SelectedIndex = 1;
            supid_combox.SelectedIndex = 1;

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select ID from Suppliers", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["ID"]);
                SIDs.Add(id);
            }
            reader.Close();
            supid_combox.Items.Clear();
            foreach (int item in SIDs)
            {
                supid_combox.Items.Add(item);
            }

            SqlCommand cmd3 = new SqlCommand("Select * from Feedback", con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd3);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            feedbackgridview.DataSource = dt2;
        }

        private void supgridview_Click(object sender, EventArgs e)
        {

        }

        private void supgridview_MouseClick(object sender, MouseEventArgs e)
        {

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


        private bool IsCommentValid(string s)
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

        private bool EntryAlreadyExists(string entry, int cellnum)
        {
            for (int i = 0; i < feedbackgridview.Rows.Count; i++)
            {
                if (entry == feedbackgridview.Rows[i].Cells[cellnum].Value.ToString())
                {
                    return true;
                }
            }
            return false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(supid_combox.Text) && string.IsNullOrEmpty(comment_txtbox.Text) && string.IsNullOrEmpty(rating_txtbox.Text))
                {
                    supid_ind_lbl.Text = "Supplier ID cannot be empty";
                    supid_ind_lbl.ForeColor = Color.Red;
                    comment_ind_lbl.Text = "Comment cannot be empty";
                    comment_ind_lbl.ForeColor = Color.Red;
                    rating_ind_lbl.Text = "Rating cannot be empty";
                    rating_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(supid_combox.Text))
                {
                    supid_ind_lbl.Text = "Supplier ID cannot be empty";
                    supid_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(comment_txtbox.Text))
                {
                    comment_ind_lbl.Text = "Comment cannot be empty";
                    comment_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(rating_txtbox.Text))
                {
                    rating_ind_lbl.Text = "Rating cannot be empty";
                    rating_ind_lbl.ForeColor = Color.Red;
                }
                else if (!(rating_txtbox.Text.ToString().All(char.IsDigit)))
                {
                    rating_ind_lbl.Text = "Must only contain numbers";
                    rating_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(rating_txtbox.Text) < 0)
                {
                    comment_ind_lbl.Text = "Invalid Rating";
                    comment_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(rating_txtbox.Text) > 5)
                {
                    rating_ind_lbl.Text = "Cannot be greater than 5";
                    rating_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsCommentValid(comment_txtbox.Text))
                {
                    comment_ind_lbl.Text = "Invalid Comment";
                    comment_ind_lbl.ForeColor = Color.Red;
                }
                else if (comment_txtbox.Text.Length > 200)
                {
                    comment_ind_lbl.Text = "Comment cannot be greater than 200 characters";
                    comment_ind_lbl.ForeColor = Color.Red;
                }
                else if (EntryAlreadyExists(supid_combox.Text, 2))
                {
                    MessageBox.Show("Feedback already Exists");
                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert into Feedback values (@CustomerID,@SupplierID,@Comment,@Rating)", con);
                    cmd.Parameters.AddWithValue("@CustomerID", 1); //get current cust id from login page
                    cmd.Parameters.AddWithValue("@SupplierID", supid_combox.Text);
                    cmd.Parameters.AddWithValue("@Comment", comment_txtbox.Text);
                    cmd.Parameters.AddWithValue("@Rating", rating_txtbox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Feedback Added");
                    SqlCommand cmd2 = new SqlCommand("Select * from Feedback", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    feedbackgridview.DataSource = dt;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
                //MessageBox.Show(error.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(supid_combox.Text))
                {
                    MessageBox.Show("Select a feedback to delete");

                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Delete Feedback where ID=@ID", con);
                    cmd.Parameters.AddWithValue("@ID", fid);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Feedback Deleted");
                    SqlCommand cmd2 = new SqlCommand("Select * from Feedback", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    feedbackgridview.DataSource = dt;
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
            feedbackgridview.ClearSelection();
            foreach (DataGridViewRow row in feedbackgridview.Rows)
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
                if (search_combox.SelectedItem.ToString() == "Supplier ID")
                {
                    searchtxt = supid_combox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");
                    }
                    else
                    {
                        searchdgv(searchtxt);
                    }

                }
                else if (search_combox.SelectedItem.ToString() == "Comment")
                {
                    searchtxt = comment_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");
                    }
                    else
                    {
                        searchdgv(searchtxt);
                    }
                }
                else if (search_combox.SelectedItem.ToString() == "Rating")
                {
                    searchtxt = rating_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");

                    }
                    else
                    {
                        searchdgvint(int.Parse(rating_txtbox.Text), feedbackgridview, "Rating");
                    }

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

        private void feedbackgridview_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                fid = Convert.ToInt32(feedbackgridview.SelectedRows[0].Cells[0].Value);
                supid_combox.Text= feedbackgridview.SelectedRows[0].Cells[2].Value.ToString();
                comment_txtbox.Text = feedbackgridview.SelectedRows[0].Cells[3].Value.ToString();
                rating_txtbox.Text = feedbackgridview.SelectedRows[0].Cells[4].Value.ToString();

            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
                //MessageBox.Show(err.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(supid_combox.Text) && string.IsNullOrEmpty(comment_txtbox.Text) && string.IsNullOrEmpty(rating_txtbox.Text))
                {
                    supid_ind_lbl.Text = "Supplier ID cannot be empty";
                    supid_ind_lbl.ForeColor = Color.Red;
                    comment_ind_lbl.Text = "Comment cannot be empty";
                    comment_ind_lbl.ForeColor = Color.Red;
                    rating_ind_lbl.Text = "Rating cannot be empty";
                    rating_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(supid_combox.Text))
                {
                    supid_ind_lbl.Text = "Supplier ID cannot be empty";
                    supid_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(comment_txtbox.Text))
                {
                    comment_ind_lbl.Text = "Comment cannot be empty";
                    comment_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(rating_txtbox.Text))
                {
                    rating_ind_lbl.Text = "Rating cannot be empty";
                    rating_ind_lbl.ForeColor = Color.Red;
                }
                else if (!(rating_txtbox.Text.ToString().All(char.IsDigit)))
                {
                    rating_ind_lbl.Text = "Must only contain numbers";
                    rating_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(rating_txtbox.Text) < 0)
                {
                    comment_ind_lbl.Text = "Invalid Rating";
                    comment_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(rating_txtbox.Text) > 5)
                {
                    rating_ind_lbl.Text = "Cannot be greater than 5";
                    rating_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsCommentValid(comment_txtbox.Text))
                {
                    comment_ind_lbl.Text = "Invalid Comment";
                    comment_ind_lbl.ForeColor = Color.Red;
                }
                else if (comment_txtbox.Text.Length > 200)
                {
                    comment_ind_lbl.Text = "Comment cannot be greater than 200 characters";
                    comment_ind_lbl.ForeColor = Color.Red;
                }
                else if (updaterepetition(supid_combox.Text,feedbackgridview,1))
                {
                    MessageBox.Show("Feedback already Exists");
                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Update Feedback set SupplierID=@SupplierID,Comment=@Comment,Rating=@Rating where ID=@ID", con);
                    cmd.Parameters.AddWithValue("@ID", fid);
                    cmd.Parameters.AddWithValue("@SupplierID", supid_combox.Text);
                    cmd.Parameters.AddWithValue("@Comment", comment_txtbox.Text);
                    cmd.Parameters.AddWithValue("@Rating", rating_txtbox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Feedback Updated");
                    SqlCommand cmd2 = new SqlCommand("Select * from Feedback", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    feedbackgridview.DataSource = dt;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
            }
        }
    }
}
