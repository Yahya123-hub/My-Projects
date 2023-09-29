using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management_System
{
    public partial class stdattendance : Form
    {
        int rng, std_id, attendanceId;
        Random rand = new Random();
        public stdattendance()
        {
            InitializeComponent();
        }

        private void stdattendance_Load(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select * from ClassAttendance", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                classattendance_gridview.DataSource = dt;

                SqlCommand cmd2 = new SqlCommand("Select Id from Student where status=5", con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                stdid_gridview.DataSource = dt2;


                SqlCommand cmd3 = new SqlCommand("Select * from StudentAttendance", con);
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                attendancegridview.DataSource = dt3;



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

        private bool Isattendancemarked(int std_id)
        {

            attendancegridview.ClearSelection();
            foreach (DataGridViewRow row in attendancegridview.Rows)
            {
                if (row.Cells["StudentId"].Value != null && Convert.ToInt32(row.Cells["StudentId"].Value) == std_id) 
                {
                    row.Selected = true;
                    return true;
                }
            }
            return false;

        }

        private void updateattendancestate(int attendance_Status)
        {
            var con = Configuration.getInstance().getConnection();
            //del stdattendance
            //del corresponding clattendance
            //insert same as before

            SqlCommand cmd2 = new SqlCommand("delete from StudentAttendance output deleted.attendanceid where StudentId=@StudentId", con);
            cmd2.Parameters.AddWithValue("@StudentId", std_id);
            int delId = (int)cmd2.ExecuteScalar();


            SqlCommand cmd3 = new SqlCommand("delete from ClassAttendance where Id=@Id", con);
            cmd3.Parameters.AddWithValue("@Id", delId);
            cmd3.ExecuteNonQuery();

            SqlCommand cmd4 = new SqlCommand("Insert into ClassAttendance (AttendanceDate) values (@AttendanceDate); SELECT SCOPE_IDENTITY();", con);
            cmd4.Parameters.AddWithValue("@AttendanceDate", atd_date.Text);
            attendanceId = Convert.ToInt32(cmd4.ExecuteScalar());

            SqlCommand cmd5 = new SqlCommand("Insert into StudentAttendance (AttendanceId, StudentId, AttendanceStatus) VALUES (@AttendanceId, @StudentId, @AttendanceStatus)", con);
            cmd5.Parameters.AddWithValue("@AttendanceId", attendanceId);
            cmd5.Parameters.AddWithValue("@StudentId", stdid_txtbox.Text);
            cmd5.Parameters.AddWithValue("@AttendanceStatus",attendance_Status);
            cmd5.ExecuteNonQuery();
            MessageBox.Show("Marked");

            SqlCommand cmd6 = new SqlCommand("Select * from ClassAttendance", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd6);
            DataTable dt = new DataTable();
            da.Fill(dt);
            classattendance_gridview.DataSource = dt;

            SqlCommand cmd7 = new SqlCommand("Select * from StudentAttendance", con);
            SqlDataAdapter da4 = new SqlDataAdapter(cmd7);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            attendancegridview.DataSource = dt4;
        }

        private void markattendance(int attendance_status)
        {
            try
            {


                if (Isattendancemarked(int.Parse(stdid_txtbox.Text)))
                {
                    string message = "Would you like to Remark this Student's Attendance?";
                    string title = "Attendance Already marked";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        updateattendancestate(attendance_status);
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else if (string.IsNullOrEmpty(stdid_txtbox.Text))
                {
                    MessageBox.Show("Student not selected");
                }
                else
                {

                    var con = Configuration.getInstance().getConnection();

                    SqlCommand cmd2 = new SqlCommand("Insert into ClassAttendance (AttendanceDate) values (@AttendanceDate); SELECT SCOPE_IDENTITY();", con);
                    cmd2.Parameters.AddWithValue("@AttendanceDate", atd_date.Text);
                    attendanceId = Convert.ToInt32(cmd2.ExecuteScalar());

                    SqlCommand cmd = new SqlCommand("Insert into StudentAttendance (AttendanceId, StudentId, AttendanceStatus) VALUES (@AttendanceId, @StudentId, @AttendanceStatus)", con);
                    cmd.Parameters.AddWithValue("@AttendanceId", attendanceId);
                    cmd.Parameters.AddWithValue("@StudentId", stdid_txtbox.Text);
                    cmd.Parameters.AddWithValue("@AttendanceStatus", attendance_status);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Marked");

                    SqlCommand cmd3 = new SqlCommand("Select * from ClassAttendance", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd3);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    classattendance_gridview.DataSource = dt;

                    SqlCommand cmd4 = new SqlCommand("Select * from StudentAttendance", con);
                    SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
                    DataTable dt4 = new DataTable();
                    da4.Fill(dt4);
                    attendancegridview.DataSource = dt4;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            markattendance(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            markattendance(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            markattendance(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            markattendance(4);
        }

        private void attendancegridview_MouseClick(object sender, MouseEventArgs e)
        {
            //stud_id = Convert.ToInt32(attendancegridview.SelectedRows[0].Cells[1].Value);
            
        }

        private void atd_date_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string message = "Changing the Date will clear the Attendance entered so far(if any), continue?";
                string title = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    var con = Configuration.getInstance().getConnection();

                    SqlCommand cmd2 = new SqlCommand("delete from StudentAttendance", con);
                    cmd2.ExecuteNonQuery();
                    SqlCommand cmd3 = new SqlCommand("delete from ClassAttendance", con);
                    cmd3.ExecuteNonQuery();

                    SqlCommand cmd4 = new SqlCommand("Select * from ClassAttendance", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd4);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    classattendance_gridview.DataSource = dt;

                    SqlCommand cmd5 = new SqlCommand("Select * from StudentAttendance", con);
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd5);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    attendancegridview.DataSource = dt3;
                }
                else 
                {
                    this.Close();
                }
            }
            catch(Exception err) 
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
        }

        private void stdid_gridview_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                std_id = Convert.ToInt32(stdid_gridview.SelectedRows[0].Cells[0].Value);
                stdid_txtbox.Text = stdid_gridview.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
        }
    }
}
