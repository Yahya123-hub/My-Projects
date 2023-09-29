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

namespace Student_Management_System
{
    public partial class stdassessment : Form
    {
        int a_id;
        DateTime ascrt_date = DateTime.Now;
        public stdassessment()
        {
            InitializeComponent();
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

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private bool EntryAlreadyExists(string entry, int cellnum)
        {
            for (int i = 0; i < asgridview.Rows.Count; i++)
            {
                if (entry == asgridview.Rows[i].Cells[cellnum].Value.ToString())
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
                if (string.IsNullOrEmpty(astitle_txtbox.Text) && string.IsNullOrEmpty(astotmrk_txtbox.Text) && string.IsNullOrEmpty(astotmrk_txtbox.Text))
                {
                    astitle_ind_lbl.Text = "Title cannot be empty";
                    astitle_ind_lbl.ForeColor = Color.Red;
                    astotmrk_ind_lbl.Text = "Total Marks cannot be empty";
                    astotmrk_ind_lbl.ForeColor = Color.Red;
                    asw_ind_lbl.Text = "Weightage cannot be empty";
                    asw_ind_lbl.ForeColor = Color.Red;

                }
                else if (string.IsNullOrEmpty(astitle_txtbox.Text))
                {
                    astitle_ind_lbl.Text = "Title cannot be empty";
                    astitle_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(astotmrk_txtbox.Text))
                {
                    astotmrk_ind_lbl.Text = "Total Marks cannot be empty";
                    astotmrk_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(astotmrk_txtbox.Text))
                {
                    asw_ind_lbl.Text = "Weightage cannot be empty";
                    asw_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsAllLetters(astitle_txtbox.Text))
                {
                    astitle_ind_lbl.Text = "Title must only contain letters";
                    astitle_ind_lbl.ForeColor = Color.Red;
                }
                else if (!(astotmrk_txtbox.Text.ToString().All(char.IsDigit)))
                {
                    astotmrk_ind_lbl.Text = "Total Marks must only contain numbers";
                    astotmrk_ind_lbl.ForeColor = Color.Red;
                }
                else if (!(asw_txtbox.Text.ToString().All(char.IsDigit)))
                {
                    asw_ind_lbl.Text = "Must only contain numbers";
                    asw_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(astotmrk_txtbox.Text) < 0 || int.Parse(astotmrk_txtbox.Text) == 0)
                {
                    astotmrk_ind_lbl.Text = "Invalid Total Marks";
                    astotmrk_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(asw_txtbox.Text) < 0 || int.Parse(asw_txtbox.Text) == 0)
                {
                    asw_ind_lbl.Text = "Invalid";
                    asw_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(asw_txtbox.Text) > 40)
                {
                    asw_ind_lbl.Text = "Max 40";
                    asw_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(astotmrk_txtbox.Text) > 40)
                {
                    astotmrk_ind_lbl.Text = "Max 40";
                    astotmrk_ind_lbl.ForeColor = Color.Red;
                }
                else if(EntryAlreadyExists(astitle_txtbox.Text,1))
                {
                    MessageBox.Show("Assessment already exists");
                    
                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert into Assessment values (@Title,@DateCreated,@TotalMarks,@TotalWeightage)", con);
                    cmd.Parameters.AddWithValue("@Title", astitle_txtbox.Text);
                    cmd.Parameters.AddWithValue("@DateCreated", ascrt_date);
                    cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(astotmrk_txtbox.Text));
                    cmd.Parameters.AddWithValue("@TotalWeightage", int.Parse(asw_txtbox.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Assessment Added");
                    SqlCommand cmd2 = new SqlCommand("Select * from Assessment", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    asgridview.DataSource = dt;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
            }
        }

        private void stdassessment_Load(object sender, EventArgs e)
        {
            search_combox.SelectedIndex = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select * from Assessment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            asgridview.DataSource = dt;
        }

        private void asgridview_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                a_id = Convert.ToInt32(asgridview.SelectedRows[0].Cells[0].Value);
                astitle_txtbox.Text = asgridview.SelectedRows[0].Cells[1].Value.ToString();
                astotmrk_txtbox.Text = asgridview.SelectedRows[0].Cells[3].Value.ToString();
                asw_txtbox.Text = asgridview.SelectedRows[0].Cells[4].Value.ToString();

            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
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
                if (string.IsNullOrEmpty(astitle_txtbox.Text) && string.IsNullOrEmpty(astotmrk_txtbox.Text) && string.IsNullOrEmpty(astotmrk_txtbox.Text))
                {
                    astitle_ind_lbl.Text = "Title cannot be empty";
                    astitle_ind_lbl.ForeColor = Color.Red;
                    astotmrk_ind_lbl.Text = "Total Marks cannot be empty";
                    astotmrk_ind_lbl.ForeColor = Color.Red;
                    asw_ind_lbl.Text = "Weightage cannot be empty";
                    asw_ind_lbl.ForeColor = Color.Red;

                }
                else if (string.IsNullOrEmpty(astitle_txtbox.Text))
                {
                    astitle_ind_lbl.Text = "Title cannot be empty";
                    astitle_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(astotmrk_txtbox.Text))
                {
                    astotmrk_ind_lbl.Text = "Total Marks cannot be empty";
                    astotmrk_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(astotmrk_txtbox.Text))
                {
                    asw_ind_lbl.Text = "Weightage cannot be empty";
                    asw_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsAllLetters(astitle_txtbox.Text))
                {
                    astitle_ind_lbl.Text = "Title must only contain letters";
                    astitle_ind_lbl.ForeColor = Color.Red;
                }
                else if (!(astotmrk_txtbox.Text.ToString().All(char.IsDigit)))
                {
                    astotmrk_ind_lbl.Text = "Total Marks must only contain numbers";
                    astotmrk_ind_lbl.ForeColor = Color.Red;
                }
                else if (!(asw_txtbox.Text.ToString().All(char.IsDigit)))
                {
                    asw_ind_lbl.Text = "Must only contain numbers";
                    asw_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(astotmrk_txtbox.Text) < 0 || int.Parse(astotmrk_txtbox.Text) == 0)
                {
                    astotmrk_ind_lbl.Text = "Invalid Total Marks";
                    astotmrk_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(asw_txtbox.Text) < 0 || int.Parse(asw_txtbox.Text) == 0)
                {
                    asw_ind_lbl.Text = "Invalid";
                    asw_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(asw_txtbox.Text) > 40)
                {
                    asw_ind_lbl.Text = "Max 40";
                    asw_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(astotmrk_txtbox.Text) > 40)
                {
                    astotmrk_ind_lbl.Text = "Max 40";
                    astotmrk_ind_lbl.ForeColor = Color.Red;
                }
                else if (updaterepetition(astitle_txtbox.Text,asgridview, 1))
                {
                    MessageBox.Show("Assessment already exists");
                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Update Assessment set Title=@Title,DateCreated=@DateCreated,TotalMarks=@TotalMarks,TotalWeightage=@TotalWeightage where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", a_id);
                    cmd.Parameters.AddWithValue("@Title", astitle_txtbox.Text);
                    cmd.Parameters.AddWithValue("@DateCreated", ascrt_date);
                    cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(astotmrk_txtbox.Text));
                    cmd.Parameters.AddWithValue("@TotalWeightage", int.Parse(asw_txtbox.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Assessment Updated");
                    SqlCommand cmd2 = new SqlCommand("Select * from Assessment", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    asgridview.DataSource = dt;
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
                if (string.IsNullOrEmpty(astitle_txtbox.Text))
                {
                    MessageBox.Show("Select an Assessment to delete");
                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Delete Assessment where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", a_id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Assessment Deleted");
                    SqlCommand cmd2 = new SqlCommand("Select * from Assessment", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    asgridview.DataSource = dt;
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
            asgridview.ClearSelection();
            foreach (DataGridViewRow row in asgridview.Rows)
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
                if (search_combox.SelectedItem.ToString() == "Title")
                {
                    searchtxt = astitle_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");
                    }
                    else
                    {
                        searchdgv(searchtxt);
                    }

                }
                else if (search_combox.SelectedItem.ToString() == "Total-Marks")
                {
                    searchtxt = astotmrk_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");

                    }
                    else
                    {
                        searchdgvint(int.Parse(astotmrk_txtbox.Text),asgridview, "TotalMarks");
                    }
                }
                else if (search_combox.SelectedItem.ToString() == "Weightage")
                {
                    searchtxt = asw_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");

                    }
                    else
                    {
                        searchdgvint(int.Parse(asw_txtbox.Text), asgridview, "TotalWeightage");
                    }

                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
    


