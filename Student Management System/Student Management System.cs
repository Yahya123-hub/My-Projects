using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            hideSubMenu();
            //this.ControlBox = false;
        }

        private void l1_Click(object sender, EventArgs e)
        {

        }

        private void hideSubMenu()
        {
            std_subpnl.Visible = false;
            
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private Form activeForm = null;
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            mainpanel.Controls.Add(childForm);
            mainpanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


      

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(std_subpnl);

            openChildFormInPanel(new stdcrud());
            main_lbl.Text = "Student";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            main_lbl.Text = "CLO";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            main_lbl.Text = "Rubrics";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            main_lbl.Text = "Assessment";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            main_lbl.Text = "Rubric Levels";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            main_lbl.Text = "Evaluations";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            main_lbl.Text = "Reports";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {

            openChildFormInPanel(new stdattendance());
            main_lbl.Text = "Student Attendance";



            hideSubMenu();


        }

        private void button9_Click_1(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            openChildFormInPanel(new stdqueries());
            main_lbl.Text = "Student Queries";


            hideSubMenu();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            openChildFormInPanel(new stdattendance());
            main_lbl.Text = "Class Attendance";

            hideSubMenu();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            openChildFormInPanel(new stdCLO());
            main_lbl.Text = "CLO's";

            hideSubMenu();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            openChildFormInPanel(new stdrubric());
            main_lbl.Text = "Rubric";

            hideSubMenu();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            openChildFormInPanel(new stdrubriclevels());
            main_lbl.Text = "Rubric Levels";

            hideSubMenu();

        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            openChildFormInPanel(new stdassessment());
            main_lbl.Text = "Assessments";

            hideSubMenu();


        }

        private void button15_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new stdac());
            main_lbl.Text = "Assessment Components";

            hideSubMenu();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new stdresult());
            main_lbl.Text = "Student Evaluation";

            hideSubMenu();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            openChildFormInPanel(new stdreport());
            main_lbl.Text = "Reports";

            hideSubMenu();
        }
    }
}
