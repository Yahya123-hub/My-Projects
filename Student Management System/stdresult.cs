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
    public partial class stdresult : Form
    {
        int currentRowIndex, stdid, acid, rubmid, totalMarks, rubricLevel;
        float res;
        public stdresult()
        {
            InitializeComponent();
        }

        private bool Isresultmarked(int std_id)
        {
            stdresultgridview.ClearSelection();
            foreach (DataGridViewRow row in stdresultgridview.Rows)
            {
                if (row.Cells["StudentId"].Value != null && Convert.ToInt32(row.Cells["StudentId"].Value) == std_id)
                {
                    row.Selected = true;
                    return true;
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd6 = new SqlCommand("delete from StudentResult", con);
            SqlDataAdapter da4 = new SqlDataAdapter(cmd6);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            stdresultgridview.DataSource = dt4;

            SqlCommand cmd2 = new SqlCommand("Select ac.name as Component , ac.totalmarks as TotalMarks, rl.details as Rubric, rl.measurementlevel as RubricLevel from AssessmentComponent ac join studentresult sr on ac.Id=sr.AssessmentComponentId join RubricLevel rl on sr.RubricMeasurementId = rl.Id", con);
            SqlDataAdapter da5 = new SqlDataAdapter(cmd2);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            resGridView.DataSource = dt5;


        }

        private bool samerows()
        {

            if (stdidgridview.RowCount == acidgridview.RowCount && stdidgridview.RowCount == rubmidgridview.RowCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {

                if (Isresultmarked(stdid))
                {
                    MessageBox.Show("Result already finalized");
                }
                else if(!samerows())
                {
                    MessageBox.Show("Insufficient Assessment Components or Rubric Levels");
                }
                else
                {

                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert into StudentResult values (@StudentId,@AssessmentComponentId,@RubricMeasurementId,@EvaluationDate)", con);
                    cmd.Parameters.AddWithValue("@StudentId", stdid);
                    cmd.Parameters.AddWithValue("@AssessmentComponentId",acid);
                    cmd.Parameters.AddWithValue("@RubricMeasurementId", rubmid);
                    cmd.Parameters.AddWithValue("@EvaluationDate", res_date.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Evaluated");

                    SqlCommand cmd3 = new SqlCommand("Select * from StudentResult", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd3);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    stdresultgridview.DataSource = dt;

                    SqlCommand cmd1 = new SqlCommand("Select totalmarks from AssessmentComponent where Id=@Id", con);
                    cmd1.Parameters.AddWithValue("@Id", acid);
                    totalMarks = (int)cmd1.ExecuteScalar(); 
                    SqlCommand cmd4 = new SqlCommand("Select measurementlevel from RubricLevel where Id=@Id", con);
                    cmd4.Parameters.AddWithValue("@Id", rubmid);
                    rubricLevel = (int)cmd4.ExecuteScalar();
                    res = (((float)rubricLevel / (float)totalMarks) * (float)totalMarks);

                    SqlCommand cmd2 = new SqlCommand("Select ac.name as Component , ac.totalmarks as TotalMarks, rl.details as Rubric, rl.measurementlevel as RubricLevel from AssessmentComponent ac join studentresult sr on ac.Id=sr.AssessmentComponentId join RubricLevel rl on sr.RubricMeasurementId = rl.Id", con);
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    resGridView.DataSource = dt2;

                    int obtainedColumnIndex = resGridView.Columns["Column1"].Index;
                    foreach (DataGridViewRow row in resGridView.Rows)
                    {
                        row.Cells[obtainedColumnIndex].Value = res;
                    }
                    MessageBox.Show(res.ToString());
                    //save result when application is closed
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void stdresult_Load(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd3 = new SqlCommand("Select Id as SId from student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            DataTable dt = new DataTable();
            da.Fill(dt);
            stdidgridview.DataSource = dt;

            SqlCommand cmd4 = new SqlCommand("Select Id as ACId from AssessmentComponent", con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd4);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            acidgridview.DataSource = dt2;

            SqlCommand cmd5 = new SqlCommand("Select Id as RMId from RubricLevel", con);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd5);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            rubmidgridview.DataSource = dt3;

            SqlCommand cmd6 = new SqlCommand("Select * from StudentResult", con);
            SqlDataAdapter da4 = new SqlDataAdapter(cmd6);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            stdresultgridview.DataSource = dt4;


            SqlCommand cmd2 = new SqlCommand("Select ac.name as Component , ac.totalmarks as TotalMarks, rl.details as Rubric, rl.measurementlevel as RubricLevel from AssessmentComponent ac join studentresult sr on ac.Id=sr.AssessmentComponentId join RubricLevel rl on sr.RubricMeasurementId = rl.Id", con);
            SqlDataAdapter da5 = new SqlDataAdapter(cmd2);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            resGridView.DataSource = dt5;


        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void stdidgridview_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                currentRowIndex = stdidgridview.CurrentRow.Index;
                if (currentRowIndex >= 0 && currentRowIndex < stdidgridview.Rows.Count)
                {
                    DataGridViewRow currentRow = stdidgridview.Rows[currentRowIndex];
                    foreach (DataGridView dataGridView in new[] { acidgridview, rubmidgridview,resGridView })
                    {
                        if (currentRowIndex < dataGridView.Rows.Count)
                        {
                            dataGridView.Rows[currentRowIndex].Selected = true;
                            dataGridView.CurrentCell = dataGridView.Rows[currentRowIndex].Cells[0];
                        }
                    }

                }
                stdid = Convert.ToInt32(stdidgridview.SelectedRows[0].Cells[0].Value);
                acid = Convert.ToInt32(acidgridview.SelectedRows[0].Cells[0].Value);
                rubmid = Convert.ToInt32(rubmidgridview.SelectedRows[0].Cells[0].Value);

            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }

        }
    }
}
