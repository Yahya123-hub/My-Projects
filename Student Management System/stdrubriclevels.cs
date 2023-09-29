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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Student_Management_System
{
    public partial class stdrubriclevels : Form
    {
        int rl_id,rub_id;
        public stdrubriclevels()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
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
            for (int i = 0; i < rlevelgridview.Rows.Count; i++)
            {
                if (entry == rlevelgridview.Rows[i].Cells[cellnum].Value.ToString())
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
                
                if (string.IsNullOrEmpty(det_txtbox.Text) && string.IsNullOrEmpty(m_txtbox.Text) && string.IsNullOrEmpty(rid_txtbox.Text))
                {
                    det_ind_lbl.Text = "Details cannot be empty";
                    det_ind_lbl.ForeColor = Color.Red;
                    m_ind_lbl.Text = "Measurement level cannot be empty";
                    m_ind_lbl.ForeColor = Color.Red;
                    rid_ind_lbl.Text = "Rubric ID cannot be empty";
                    rid_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(det_txtbox.Text))
                {
                    det_ind_lbl.Text = "Details cannot be empty";
                    det_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(m_txtbox.Text))
                {
                    m_ind_lbl.Text = "Measurement level cannot be empty";
                    m_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(rid_txtbox.Text))
                {
                    rid_ind_lbl.Text = "Rubric ID cannot be empty";
                    rid_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsDigitsOnly(rid_txtbox.Text))
                {
                    rid_ind_lbl.Text = "Must only contain digits";
                    rid_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsDigitsOnly(m_txtbox.Text))
                {
                    m_ind_lbl.Text = "Must only contain digits";
                    m_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsAllLetters(det_txtbox.Text))
                {
                    det_ind_lbl.Text = "Details must only contain letters";
                    det_ind_lbl.ForeColor = Color.Red;
                }
                else if (EntryAlreadyExists(rid_txtbox.Text,1))
                {
                    MessageBox.Show("Rubric ID already exists, try again");
                }
                else
                {

                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert into RubricLevel values (@RubricId,@Details,@MeasurementLevel)", con);
                    cmd.Parameters.AddWithValue("@RubricId", int.Parse(rid_txtbox.Text));
                    cmd.Parameters.AddWithValue("@Details", det_txtbox.Text);
                    cmd.Parameters.AddWithValue("@MeasurementLevel", int.Parse(m_txtbox.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rubric Level Added");
                    SqlCommand cmd2 = new SqlCommand("Select * from RubricLevel", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    rlevelgridview.DataSource = dt;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
        }

        private void stdrubriclevels_Load(object sender, EventArgs e)
        {
            search_combox.SelectedIndex = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select * from RubricLevel", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rlevelgridview.DataSource = dt;

            SqlCommand cmd3 = new SqlCommand("Select Id as RubricId from Rubric", con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd3);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            rubidgridview.DataSource = dt2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(det_txtbox.Text) && string.IsNullOrEmpty(m_txtbox.Text) && string.IsNullOrEmpty(rid_txtbox.Text))
                {
                    det_ind_lbl.Text = "Details cannot be empty";
                    det_ind_lbl.ForeColor = Color.Red;
                    m_ind_lbl.Text = "Measurement level cannot be empty";
                    m_ind_lbl.ForeColor = Color.Red;
                    rid_ind_lbl.Text = "Rubric ID cannot be empty";
                    rid_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(det_txtbox.Text))
                {
                    det_ind_lbl.Text = "Details cannot be empty";
                    det_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(m_txtbox.Text))
                {
                    m_ind_lbl.Text = "Measurement level cannot be empty";
                    m_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(rid_txtbox.Text))
                {
                    rid_ind_lbl.Text = "Rubric ID cannot be empty";
                    rid_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsDigitsOnly(rid_txtbox.Text))
                {
                    rid_ind_lbl.Text = "Must only contain digits";
                    rid_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsDigitsOnly(m_txtbox.Text))
                {
                    m_ind_lbl.Text = "Must only contain digits";
                    m_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsAllLetters(det_txtbox.Text))
                {
                    det_ind_lbl.Text = "Details must only contain letters";
                    det_ind_lbl.ForeColor = Color.Red;
                }
                else
                {

                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Update RubricLevel set RubricId=@RubricId,Details=@Details, MeasurementLevel=@MeasurementLevel  where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", rl_id);
                    cmd.Parameters.AddWithValue("@RubricId", int.Parse(rid_txtbox.Text));
                    cmd.Parameters.AddWithValue("@Details", det_txtbox.Text);
                    cmd.Parameters.AddWithValue("@MeasurementLevel", int.Parse(m_txtbox.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rubric Level Updated");
                    SqlCommand cmd2 = new SqlCommand("Select * from RubricLevel", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    rlevelgridview.DataSource = dt;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(det_txtbox.Text) || string.IsNullOrEmpty(m_txtbox.Text) || string.IsNullOrEmpty(rid_txtbox.Text))
                {
                    MessageBox.Show("Select a Rubric Level to delete");
                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Delete RubricLevel where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", rl_id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rubric Level Deleted");
                    SqlCommand cmd2 = new SqlCommand("Select * from RubricLevel", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    rlevelgridview.DataSource = dt;
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
            rlevelgridview.ClearSelection();
            foreach (DataGridViewRow row in rlevelgridview.Rows)
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
                if (search_combox.SelectedItem.ToString() == "Details")
                {
                    searchtxt = det_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");
                    }
                    else
                    {
                        searchdgv(searchtxt);
                    }

                }
                else if (search_combox.SelectedItem.ToString() == "Measurement-level")
                {
                    searchtxt = m_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");

                    }
                    else
                    {
                        searchdgvint(int.Parse(m_txtbox.Text), rlevelgridview, "MeasurementLevel");
                    }
                }
                else if (search_combox.SelectedItem.ToString() == "Rubric-ID")
                {
                    searchtxt = rid_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");

                    }
                    else
                    {
                        searchdgvint(int.Parse(rid_txtbox.Text), rlevelgridview, "RubricId");
                    }
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
            }
        }

        private void rlevelgridview_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                rl_id = Convert.ToInt32(rlevelgridview.SelectedRows[0].Cells[0].Value);
                rid_txtbox.Text = rlevelgridview.SelectedRows[0].Cells[1].Value.ToString();
                det_txtbox.Text = rlevelgridview.SelectedRows[0].Cells[2].Value.ToString();
                m_txtbox.Text = rlevelgridview.SelectedRows[0].Cells[3].Value.ToString();
                rid_txtbox.Enabled = false;
            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
        }

        private void rubidgridview_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                rub_id = Convert.ToInt32(rubidgridview.SelectedRows[0].Cells[0].Value);
                rid_txtbox.Text = rubidgridview.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
        }
    }
}
