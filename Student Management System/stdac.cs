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
    public partial class stdac : Form
    {
        int ac_id,a_id,rub_id;
        DateTime accrt_date = DateTime.Now;
        public stdac()
        {
            InitializeComponent();
        }

        private void acgridview_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                ac_id = Convert.ToInt32(acgridview.SelectedRows[0].Cells[0].Value);
                acname_txtbox.Text = acgridview.SelectedRows[0].Cells[1].Value.ToString();
                rubid_txtbox.Text = acgridview.SelectedRows[0].Cells[2].Value.ToString();
                actotmrk_txtbox.Text = acgridview.SelectedRows[0].Cells[3].Value.ToString();
                aid_txtbox.Text = acgridview.SelectedRows[0].Cells[6].Value.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
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
            for (int i = 0; i < acgridview.Rows.Count; i++)
            {
                if (entry == acgridview.Rows[i].Cells[cellnum].Value.ToString())
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
                if (string.IsNullOrEmpty(acname_txtbox.Text) && string.IsNullOrEmpty(rubid_txtbox.Text) && string.IsNullOrEmpty(actotmrk_txtbox.Text) && string.IsNullOrEmpty(aid_txtbox.Text))
                {
                    acname_ind_lbl.Text = "Name cannot be empty";
                    acname_ind_lbl.ForeColor = Color.Red;
                    rubid_ind_lbl.Text = "Rubric ID cannot be empty";
                    rubid_ind_lbl.ForeColor = Color.Red;
                    actotmrk_ind_lbl.Text = "Total Marks cannot be empty";
                    actotmrk_ind_lbl.ForeColor = Color.Red;
                    aid_ind_lbl.Text = "Assessment ID cannot be empty";
                    aid_ind_lbl.ForeColor = Color.Red;
                    

                }
                else if (string.IsNullOrEmpty(acname_txtbox.Text))
                {
                    acname_ind_lbl.Text = "Name cannot be empty";
                    acname_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(rubid_txtbox.Text))
                {
                    rubid_ind_lbl.Text = "Total Marks cannot be empty";
                    rubid_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(actotmrk_txtbox.Text))
                {
                    actotmrk_ind_lbl.Text = "Total Marks cannot be empty";
                    actotmrk_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(aid_txtbox.Text))
                {
                    aid_ind_lbl.Text = "Assessment ID cannot be empty";
                    aid_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsAllLetters(acname_txtbox.Text))
                {
                    acname_ind_lbl.Text = "Name must only contain letters";
                    acname_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsDigitsOnly(rubid_txtbox.Text))
                {
                    rubid_ind_lbl.Text = "Rubric ID must only contain numbers";
                    rubid_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsDigitsOnly(actotmrk_txtbox.Text))
                {
                    actotmrk_ind_lbl.Text = "Total Marks must only contain numbers";
                    actotmrk_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsDigitsOnly(aid_txtbox.Text))
                {
                    aid_ind_lbl.Text = "Assessment ID must only contain numbers";
                    aid_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(actotmrk_txtbox.Text) < 0 ||int.Parse(actotmrk_txtbox.Text) == 0)
                {
                    actotmrk_ind_lbl.Text = "Invalid Total Marks";
                    actotmrk_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(actotmrk_txtbox.Text) > 40)
                {
                    actotmrk_ind_lbl.Text = "Max 40";
                    actotmrk_ind_lbl.ForeColor = Color.Red;
                }
                else if(EntryAlreadyExists(rubid_txtbox.Text, 2) || EntryAlreadyExists(aid_txtbox.Text, 6))
                {
                    MessageBox.Show("Corresponding Rubric ID or Assessment ID already exists");

                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert into AssessmentComponent values (@Name,@RubricId,@TotalMarks,@DateCreated,@DateUpdated,@AssessmentId)", con);
                    cmd.Parameters.AddWithValue("@Name", acname_txtbox.Text);
                    cmd.Parameters.AddWithValue("@RubricId", int.Parse(rubid_txtbox.Text));
                    cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(actotmrk_txtbox.Text));
                    cmd.Parameters.AddWithValue("@DateCreated", accrt_date);
                    cmd.Parameters.AddWithValue("@DateUpdated", accrt_date);
                    cmd.Parameters.AddWithValue("@AssessmentId", int.Parse(aid_txtbox.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Assessment Component Added");
                    SqlCommand cmd2 = new SqlCommand("Select * from AssessmentComponent", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    acgridview.DataSource = dt;
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
                if (string.IsNullOrEmpty(acname_txtbox.Text) && string.IsNullOrEmpty(rubid_txtbox.Text) && string.IsNullOrEmpty(actotmrk_txtbox.Text) && string.IsNullOrEmpty(aid_txtbox.Text))
                {
                    acname_ind_lbl.Text = "Name cannot be empty";
                    acname_ind_lbl.ForeColor = Color.Red;
                    rubid_ind_lbl.Text = "Rubric ID cannot be empty";
                    rubid_ind_lbl.ForeColor = Color.Red;
                    actotmrk_ind_lbl.Text = "Total Marks cannot be empty";
                    actotmrk_ind_lbl.ForeColor = Color.Red;
                    aid_ind_lbl.Text = "Assessment ID cannot be empty";
                    aid_ind_lbl.ForeColor = Color.Red;


                }
                else if (string.IsNullOrEmpty(acname_txtbox.Text))
                {
                    acname_ind_lbl.Text = "Name cannot be empty";
                    acname_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(rubid_txtbox.Text))
                {
                    rubid_ind_lbl.Text = "Total Marks cannot be empty";
                    rubid_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(actotmrk_txtbox.Text))
                {
                    actotmrk_ind_lbl.Text = "Total Marks cannot be empty";
                    actotmrk_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(aid_txtbox.Text))
                {
                    aid_ind_lbl.Text = "Assessment ID cannot be empty";
                    aid_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsAllLetters(acname_txtbox.Text))
                {
                    acname_ind_lbl.Text = "Name must only contain letters";
                    acname_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsDigitsOnly(rubid_txtbox.Text))
                {
                    rubid_ind_lbl.Text = "Rubric ID must only contain numbers";
                    rubid_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsDigitsOnly(actotmrk_txtbox.Text))
                {
                    actotmrk_ind_lbl.Text = "Total Marks must only contain numbers";
                    actotmrk_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsDigitsOnly(aid_txtbox.Text))
                {
                    aid_ind_lbl.Text = "Assessment ID must only contain numbers";
                    aid_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(actotmrk_txtbox.Text) < 0 || int.Parse(actotmrk_txtbox.Text) == 0)
                {
                    actotmrk_ind_lbl.Text = "Invalid Total Marks";
                    actotmrk_ind_lbl.ForeColor = Color.Red;
                }
                else if (int.Parse(actotmrk_txtbox.Text) > 40)
                {
                    actotmrk_ind_lbl.Text = "Max 40";
                    actotmrk_ind_lbl.ForeColor = Color.Red;
                }
                else
                {
                    DateTime up_date = DateTime.Now;
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Update AssessmentComponent set Name=@Name,RubricId=@RubricId,TotalMarks=@TotalMarks, DateCreated=@DateCreated, DateUpdated=@DateUpdated, AssessmentId=@AssessmentId where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", ac_id);
                    cmd.Parameters.AddWithValue("@Name", acname_txtbox.Text);
                    cmd.Parameters.AddWithValue("@RubricId", int.Parse(rubid_txtbox.Text));
                    cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(actotmrk_txtbox.Text));
                    cmd.Parameters.AddWithValue("@DateCreated", accrt_date);
                    cmd.Parameters.AddWithValue("@DateUpdated", up_date);
                    cmd.Parameters.AddWithValue("@AssessmentId", int.Parse(aid_txtbox.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Assessment Component Updated");
                    SqlCommand cmd2 = new SqlCommand("Select * from AssessmentComponent", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    acgridview.DataSource = dt;
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
            }
        }

        private void stdac_Load(object sender, EventArgs e)
        {
            search_combox.SelectedIndex = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select * from AssessmentComponent", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            acgridview.DataSource = dt;

            SqlCommand cmd3 = new SqlCommand("Select Id as AssessmentId from Assessment", con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd3);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            aidGridView.DataSource = dt2;

            SqlCommand cmd4 = new SqlCommand("Select Id as RubricId from Rubric", con);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd4);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            rubidGridView.DataSource = dt3;

        }

        private void acgridview_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(acname_txtbox.Text) || string.IsNullOrEmpty(rubid_txtbox.Text) || string.IsNullOrEmpty(actotmrk_txtbox.Text) || string.IsNullOrEmpty(aid_txtbox.Text))
                {
                    MessageBox.Show("Select an Assessment Component to delete");
                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Delete AssessmentComponent where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", ac_id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("AssessmentComponent Deleted");
                    SqlCommand cmd2 = new SqlCommand("Select * from AssessmentComponent", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    acgridview.DataSource = dt;
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
            acgridview.ClearSelection();
            foreach (DataGridViewRow row in acgridview.Rows)
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

        private void searchdgvint(int s,DataGridView dg,string colname)
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
                    searchtxt = acname_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");
                    }
                    else
                    {
                        searchdgv(searchtxt);
                    }

                }
                else if (search_combox.SelectedItem.ToString() == "Rubric-ID")
                {
                    searchtxt = rubid_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");

                    }
                    else
                    {
                        searchdgvint(int.Parse(rubid_txtbox.Text),acgridview,"RubricId");
                    }
                }
                else if (search_combox.SelectedItem.ToString() == "Total-Marks")
                {
                    searchtxt = actotmrk_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");

                    }
                    else
                    {
                        searchdgvint(int.Parse(actotmrk_txtbox.Text), acgridview, "TotalMarks");
                    }

                }
                else if (search_combox.SelectedItem.ToString() == "Assessment-ID")
                {
                    searchtxt = aid_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");

                    }
                    else
                    {
                        searchdgvint(int.Parse(aid_txtbox.Text), acgridview, "AssessmentId");
                    }

                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
            }
        }

        private void rubidGridView_MouseClick_1(object sender, MouseEventArgs e)
        {
            try
            {
                rub_id = Convert.ToInt32(rubidGridView.SelectedRows[0].Cells[0].Value);
                rubid_txtbox.Text = rubidGridView.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
        }

        private void rubidgridview_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void aidGridView_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                a_id = Convert.ToInt32(aidGridView.SelectedRows[0].Cells[0].Value);
                aid_txtbox.Text = aidGridView.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
        }
    }
}
