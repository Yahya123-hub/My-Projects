using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management_System
{
    public partial class stdqueries : Form
    {
        public stdqueries()
        {
            InitializeComponent();
        }

        private void stdqueries_Load(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select * from Student", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                qgridview.DataSource = dt;
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

        private void button5_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select Firstname from Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            qgridview.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select Lastname from Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            qgridview.DataSource = dt;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select id,title from Assessment where year(datecreated)='2023' and TotalMarks>=10 and TotalWeightage>=12", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            qgridview.DataSource = dt;

            MessageBox.Show("Assessments created in 2023 having totalmarks greater than 10 and totalweightage greater than 12");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select * from RubricLevel where Measurementlevel<4", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            qgridview.DataSource = dt;

            MessageBox.Show("Rubric Levels with measurement level smaller than 4");



        }

        private void button16_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select id,name from AssessmentComponent where day(datecreated)='6' and totalmarks<5", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            qgridview.DataSource = dt;

            MessageBox.Show("Assessment Components created on 6th of march,2023 and having totalmarks smaller than 5");


        }

        private void button15_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select * from Clo where name like '%a%' and year(DateCreated)='2023'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            qgridview.DataSource = dt;

            MessageBox.Show("CLO's created in 2023 and containing a's");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select a.Id,name from AssessmentComponent ac join Assessment a on ac.AssessmentId=a.Id where year(a.DateCreated)=year(ac.DateCreated)", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            qgridview.DataSource = dt;

            MessageBox.Show("Assessment Id's and component names created in the same year");


        }

        private void button4_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select * from AssessmentComponent ac join Rubric r on ac.RubricId=r.Id join clo on r.CloId=Clo.Id where ac.TotalMarks>4", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            qgridview.DataSource = dt;

            MessageBox.Show("Joins the Rubric,CLO and Assessment Component Table with totalmarks greater than 4");


        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                string query = q_txtbox.Text;
                SqlCommand cmd2 = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                qgridview.DataSource = dt;
            }
            catch(Exception err)
            {
                MessageBox.Show("Invalid Query",err.Message);
            }
            

        }

        private void button8_Click(object sender, EventArgs e)
        {

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd2 = new SqlCommand(" Select * from  ClassAttendance c join StudentAttendance s on c.Id=s.AttendanceId where AttendanceStatus=2", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                qgridview.DataSource = dt;
                MessageBox.Show("Absent Students");



        }

        private void button7_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select count(s.AttendanceStatus) from ClassAttendance c join StudentAttendance s on c.Id=s.AttendanceId group by s.AttendanceStatus having s.AttendanceStatus=2", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            qgridview.DataSource = dt;
            MessageBox.Show("Number of Absent Students");

        }

        private void button13_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select * from StudentResult where day(EvaluationDate)=11", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            qgridview.DataSource = dt;
            MessageBox.Show("Students Evaluated on 11th March");

        }
    }
}
