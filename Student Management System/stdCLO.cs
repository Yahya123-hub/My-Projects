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
    public partial class stdCLO : Form
    {
        public int clo_id;
        DateTime crt_date = DateTime.Now;
        public stdCLO()
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

        private bool EntryAlreadyExists(string entry, int cellnum)
        {
            for (int i = 0; i < clogridview.Rows.Count; i++)
            {
                if (entry == clogridview.Rows[i].Cells[cellnum].Value.ToString())
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
                if(string.IsNullOrEmpty(cloname_txtbox.Text))
                {
                    cloname_ind_lbl.Text = "CLO Name cannot be empty";
                    cloname_ind_lbl.ForeColor = Color.Red;
                }
                else if(!IsAllLetters(cloname_txtbox.Text))
                {
                    cloname_ind_lbl.Text = "CLO Name should only contain letters";
                    cloname_ind_lbl.ForeColor = Color.Red;
                }
                else if(EntryAlreadyExists(cloname_txtbox.Text,1))
                {
                    MessageBox.Show("Clo already exists");
                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert into Clo values (@Name,@DateCreated,@DateUpdated)", con);
                    cmd.Parameters.AddWithValue("@Name", cloname_txtbox.Text);
                    cmd.Parameters.AddWithValue("@DateCreated", crt_date);
                    cmd.Parameters.AddWithValue("@DateUpdated", crt_date);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("CLO Added");
                    SqlCommand cmd2 = new SqlCommand("Select * from Clo", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    clogridview.DataSource = dt;

                }
                
            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
            }
}

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cloname_txtbox.Text))
                {
                    cloname_ind_lbl.Text = "CLO Name cannot be empty";
                    cloname_ind_lbl.ForeColor = Color.Red;
                }
                else if (!IsAllLetters(cloname_txtbox.Text))
                {
                    cloname_ind_lbl.Text = "CLO Name should only contain letters";
                    cloname_ind_lbl.ForeColor = Color.Red;
                }
                else if (updaterepetition(cloname_txtbox.Text,clogridview, 1))
                {
                    MessageBox.Show("Clo already exists");
                }
                else
                {
                    DateTime up_date = DateTime.Now;
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Update Clo set Name=@Name,DateCreated=@DateCreated,DateUpdated=@DateUpdated where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", clo_id);
                    cmd.Parameters.AddWithValue("@Name", cloname_txtbox.Text);
                    cmd.Parameters.AddWithValue("@DateCreated", crt_date);
                    cmd.Parameters.AddWithValue("@DateUpdated", up_date);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("CLO Updated");
                    SqlCommand cmd2 = new SqlCommand("Select * from Clo", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    clogridview.DataSource = dt;
                }


            }
            catch (Exception error)
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


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cloname_txtbox.Text))
                {
                    MessageBox.Show("Select a CLO to delete");
                }
                else
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Delete Clo where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", clo_id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("CLO Deleted");
                    SqlCommand cmd2 = new SqlCommand("Select * from Clo", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    clogridview.DataSource = dt;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Something went wrong", error.Message);
            }
        }

        private void stdgridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void stdgridview_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                clo_id = Convert.ToInt32(clogridview.SelectedRows[0].Cells[0].Value);
                cloname_txtbox.Text = clogridview.SelectedRows[0].Cells[1].Value.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        private void searchdgv(string searchtxt)
        {
            bool found = false;
            clogridview.ClearSelection();
            foreach (DataGridViewRow row in clogridview.Rows)
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


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string searchtxt = closearch_txtbox.Text;
                if (string.IsNullOrEmpty(searchtxt))
                {
                    MessageBox.Show("Nothing to Search");

                }
                else
                {
                    searchdgv(searchtxt);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
        }

        private void stdCLO_Load(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select * from Clo", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            clogridview.DataSource = dt;
        }

        private void closearch_txtbox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clogridview_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
