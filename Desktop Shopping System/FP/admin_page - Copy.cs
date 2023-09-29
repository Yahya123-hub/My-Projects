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

namespace final_gui_Template
{
    public partial class admin_page : Form
    {
        public admin_page()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new supplier_info());
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


        private void admin_page_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
           
            openChildFormInPanel(new users());
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new admin_cred());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login form = new login();
            form.Show();
        }
    }
}
