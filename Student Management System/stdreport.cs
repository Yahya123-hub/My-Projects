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
using DGVPrinterHelper;

namespace Student_Management_System
{
    public partial class stdreport : Form
    {
        public stdreport()
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
                if (ind_lbl.Text == "Assessment-Wise-Report")
                {
                    DGVPrinter printer = new DGVPrinter();
                    printer.Title = "Assessment Wise Class Result";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now);
                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = false;
                    printer.PorportionalColumns = true;
                    printer.HeaderCellAlignment = StringAlignment.Near;
                    printer.Footer = "Student Assessment Evaluation";
                    printer.FooterSpacing = 15;
                    printer.PrintDataGridView(repgridview);

                }
                else if (ind_lbl.Text == "Attendance-Report")
                {
                    DGVPrinter printer = new DGVPrinter();
                    printer.Title = "Class Attendance Report";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now);
                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = false;
                    printer.PorportionalColumns = true;
                    printer.HeaderCellAlignment = StringAlignment.Near;
                    printer.Footer = "Student Attendance";
                    printer.FooterSpacing = 15;
                    printer.PrintDataGridView(repgridview);

                }
                else if (ind_lbl.Text == "CLO-Report")
                {
                    DGVPrinter printer = new DGVPrinter();
                    printer.Title = "CLO Wise Class Result";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now);
                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = false;
                    printer.PorportionalColumns = true;
                    printer.HeaderCellAlignment = StringAlignment.Near;
                    printer.Footer = "Student CLO Evaluation";
                    printer.FooterSpacing = 15;
                    printer.PrintDataGridView(repgridview);

                }
                else if (ind_lbl.Text == "Student-Report")
                {
                    DGVPrinter printer = new DGVPrinter();
                    printer.Title = "All Enrolled Students";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now);
                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = false;
                    printer.PorportionalColumns = true;
                    printer.HeaderCellAlignment = StringAlignment.Near;
                    printer.Footer = "Students Details";
                    printer.FooterSpacing = 15;
                    printer.PrintDataGridView(repgridview);

                }
                else if (ind_lbl.Text == "AC-Report")
                {
                    DGVPrinter printer = new DGVPrinter();
                    printer.Title = "Assessment Components Details";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now);
                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = false;
                    printer.PorportionalColumns = true;
                    printer.HeaderCellAlignment = StringAlignment.Near;
                    printer.Footer = "Assessment Components";
                    printer.FooterSpacing = 15;
                    printer.PrintDataGridView(repgridview);

                }
            }
            catch(Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }

        }

        private void stdreport_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select cl.Id as \"CLO Id\",cl.Name,cl.DateCreated,cl.DateUpdated,r.Id as \"Rubric ID\",r.Details,rl.Id as \"Rubric Measurement level ID\",rl.Details as \"Rubric Level Details\",rl.MeasurementLevel,sr.StudentId,sr.AssessmentComponentId,sr.EvaluationDate from Clo cl join Rubric r on cl.id=r.CloId join RubricLevel rl on r.id=rl.RubricId join StudentResult sr on rl.id=sr.RubricMeasurementId", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            repgridview.DataSource = dt;
            MessageBox.Show("CLO Wise Report Preview");
            ind_lbl.Text = "CLO-Report";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select a.id as \"Assessment ID\",a.Title,a.DateCreated,a.TotalMarks, a.TotalWeightage, ac.Id as \"Assessment Component ID\",ac.Name,ac.RubricId,ac.TotalMarks as \"Assessment Component Total Marks\",ac.DateCreated as \"Assessment Component Creation\",ac.DateUpdated as \"Assessment Component Updation\",sr.StudentId, sr.RubricMeasurementId,sr.EvaluationDate from Assessment a join AssessmentComponent ac on a.id=ac.AssessmentId join StudentResult sr on ac.id=sr.AssessmentComponentId\r\n", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            repgridview.DataSource = dt;
            MessageBox.Show("Assessment Wise Report Preview");
            ind_lbl.Text = "Assessment-Wise-Report";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select s.id as \"Student ID\",s.FirstName,s.LastName,s.Contact,s.Email,s.RegistrationNumber,s.Status, sa.AttendanceId,sa.AttendanceStatus,ca.AttendanceDate from Student s join StudentAttendance sa on s.Id=sa.StudentId join ClassAttendance ca on sa.AttendanceId=ca.Id where s.Status=5", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            repgridview.DataSource = dt;
            MessageBox.Show("Attendance Report Preview");
            ind_lbl.Text = "Attendance-Report";
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
  
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select * from student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            repgridview.DataSource = dt;
            MessageBox.Show("All Students Enrolled");
            ind_lbl.Text = "Student-Report";

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select * from Assessment Component", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            repgridview.DataSource = dt;
            MessageBox.Show("Assessment Component Report");
            ind_lbl.Text = "AC-Report";
        }
    }
}
