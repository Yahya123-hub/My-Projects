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
        public Supplier_page()
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
            string message = "Are you sure you want to log out?";
            string title = "Confirm";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {

            }
            else
            {
                this.Close();
            }
        }
    }
}
