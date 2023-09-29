using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_gui_Template
{
    public partial class Supplier_page : Form
    {
        public Supplier_page(string f_username)
        {
            InitializeComponent();
           
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

        private void button12_Click(object sender, EventArgs e)
        {
            //if application approved then lock this section and show a msg saying application has already been approved
            openChildFormInPanel(new submit_application());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new sell_products());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new reports());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new sup_manage_cred());
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void Supplier_page_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            login form = new login();
            form.Show();
        }
    }
}
