using information;
using Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace final_gui_Template
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Feedback());
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

        private void Customer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new customer_crediential());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new browse_products());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new cart());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new orders());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new payment_history());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Refund());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Recommendations());
           // Recommendations.SetList(products_cat_r_list);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new chat());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new customer_info());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            login form = new login();
            form.Show();
        }
    }
}
