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
    public partial class stdrubric : Form
    {
        int rub_id,clo_id,rng;
        Random rand = new Random();

        
        public stdrubric()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                rng = rand.Next(100);

                if (string.IsNullOrEmpty(rubricdet_txtbox.Text) && string.IsNullOrEmpty(cloid_txtbox.Text))
                {
                    rubricdet_ind_lbl.Text = "Details cannot be empty";
                    rubricdet_ind_lbl.ForeColor = Color.Red;
                    cloid_ind_lbl.Text = "CLO ID cannot be empty";
                    cloid_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(rubricdet_txtbox.Text))
                {
                    rubricdet_ind_lbl.Text = "Details cannot be empty";
                    rubricdet_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(cloid_txtbox.Text))
                {
                    cloid_ind_lbl.Text = "CLO ID cannot be empty";
                    cloid_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsDigitsOnly(cloid_txtbox.Text))
                {
                    cloid_ind_lbl.Text = "CLO ID must only contain digits";
                    cloid_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsAllLetters(rubricdet_txtbox.Text))
                {
                    rubricdet_ind_lbl.Text = "Rubric Details must only contain letters";
                    rubricdet_ind_lbl.ForeColor = Color.Red;
                }
                else if (EntryAlreadyExists(cloid_txtbox.Text, 2))
                {
                    MessageBox.Show("Rubric already exists, try again");
                }
                else if(EntryAlreadyExists(rng.ToString(),0))
                {
                    MessageBox.Show("Rubric ID already exists, try again");
                }
                else
                {
                    
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert into Rubric values (@Id,@Details,@CloId)", con);
                    cmd.Parameters.AddWithValue("@Id", rng);
                    cmd.Parameters.AddWithValue("@Details", rubricdet_txtbox.Text);
                    cmd.Parameters.AddWithValue("@CloId", int.Parse(cloid_txtbox.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rubric Added");
                    SqlCommand cmd2 = new SqlCommand("Select * from Rubric", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    rubricgridview.DataSource = dt;
                }
                
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
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
            for (int i = 0; i < rubricgridview.Rows.Count; i++)
            {
                if (entry == rubricgridview.Rows[i].Cells[cellnum].Value.ToString())
                {
                    return true;
                }
            }
            return false;
        }


        private void searchdgv(string searchtxt, DataGridView dg)
        {
            bool found = false;
            dg.ClearSelection();
            foreach (DataGridViewRow row in dg.Rows)
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



        private void stdrubric_Load(object sender, EventArgs e)
        {
            search_combox.SelectedIndex = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select * from Rubric", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rubricgridview.DataSource = dt;

            SqlCommand cmd3 = new SqlCommand("Select Id as CloId from Clo", con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd3);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            cloidgridview.DataSource = dt2;

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

                if (string.IsNullOrEmpty(rubricdet_txtbox.Text) && string.IsNullOrEmpty(cloid_txtbox.Text))
                {
                    rubricdet_ind_lbl.Text = "Details cannot be empty";
                    rubricdet_ind_lbl.ForeColor = Color.Red;
                    cloid_ind_lbl.Text = "CLO ID cannot be empty";
                    cloid_ind_lbl.ForeColor = Color.Red;


                }
                else if (string.IsNullOrEmpty(rubricdet_txtbox.Text))
                {
                    rubricdet_ind_lbl.Text = "Details cannot be empty";
                    rubricdet_ind_lbl.ForeColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(cloid_txtbox.Text))
                {
                    cloid_ind_lbl.Text = "CLO ID cannot be empty";
                    cloid_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsDigitsOnly(cloid_txtbox.Text))
                {
                    cloid_ind_lbl.Text = "CLO ID must only contain digits";
                    cloid_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsAllLetters(rubricdet_txtbox.Text))
                {
                    rubricdet_ind_lbl.Text = "Rubric Details must only contain letters";
                    rubricdet_ind_lbl.ForeColor = Color.Red;
                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Update Rubric set Details=@Details,CloId=@CloId  where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", rub_id);
                    cmd.Parameters.AddWithValue("@Details", rubricdet_txtbox.Text);
                    cmd.Parameters.AddWithValue("@CloId", int.Parse(cloid_txtbox.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rubric Updated");
                    SqlCommand cmd2 = new SqlCommand("Select * from Rubric", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    rubricgridview.DataSource = dt;

                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
        }

        private void rubricgridview_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                rub_id = Convert.ToInt32(rubricgridview.SelectedRows[0].Cells[0].Value);
                rubricdet_txtbox.Text = rubricgridview.SelectedRows[0].Cells[1].Value.ToString();
                cloid_txtbox.Text = rubricgridview.SelectedRows[0].Cells[2].Value.ToString();
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
                if (string.IsNullOrEmpty(rubricdet_txtbox.Text) || string.IsNullOrEmpty(cloid_txtbox.Text))
                {
                    MessageBox.Show("Select a rubric to delete");
                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Delete Rubric where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", rub_id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rubric Deleted");
                    SqlCommand cmd2 = new SqlCommand("Select * from Rubric", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    rubricgridview.DataSource = dt;
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

        private void cloidgridview_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                clo_id = Convert.ToInt32(cloidgridview.SelectedRows[0].Cells[0].Value);
                cloid_txtbox.Text = cloidgridview.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                string searchtxt;
                if (search_combox.SelectedItem.ToString() == "Details")
                {
                    searchtxt = rubricdet_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");
                    }
                    else
                    {
                        searchdgv(searchtxt, rubricgridview);
                    }

                }
                else if (search_combox.SelectedItem.ToString() == "Clo-Id")
                {
                    searchtxt = cloid_txtbox.Text;
                    if (string.IsNullOrEmpty(searchtxt))
                    {
                        MessageBox.Show("Nothing to Search");

                    }
                    else
                    {
                        searchdgvint(int.Parse(cloid_txtbox.Text), rubricgridview, "CloId");
                    }
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
            }
        }
    }
    
}
