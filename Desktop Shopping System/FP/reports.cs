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
using Lab2;
using LiveCharts;
using LiveCharts.Wpf;

namespace final_gui_Template
{
    public partial class reports : Form
    {
        Func<ChartPoint, string> label = chartpoint => string.Format("{0} ({1:P)", chartpoint.Y, chartpoint.Participation);
        public reports()
        {
            InitializeComponent();
        }

        private void rlevelgridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("  Select p.category,sum(pr.Amount_payed) as \"Sales\" from products p\r\n  join Payment_Record pr \r\n  on p.ID=pr.ProductID\r\n  group by p.category", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rgridview.DataSource = dt;
            MessageBox.Show("Category Wise Sales Report Preview");
            ind_lbl.Text = "CS";
        }




        private void button2_Click(object sender, EventArgs e)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd3 = new SqlCommand("EXEC stpGetLatestSupid", con);
            int supid = (int)cmd3.ExecuteScalar();
            SqlCommand cmd2 = new SqlCommand("Select pname,pprice,available_quantity,category,SupplierID from Products where SupplierID=@SupplierID", con);
            cmd2.Parameters.AddWithValue("@SupplierID", supid);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rgridview.DataSource = dt;
            MessageBox.Show("Supplier Wise Inventory Report Preview");
            ind_lbl.Text = "SPI";
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("Report Preview");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (ind_lbl.Text == "SPI")
                {
                    DGVPrinter printer = new DGVPrinter();
                    printer.Title = "Supplier Wise Inventory Report";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now);
                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = false;
                    printer.PorportionalColumns = true;
                    printer.HeaderCellAlignment = StringAlignment.Near;
                    printer.Footer = "Stock Information";
                    printer.FooterSpacing = 15;
                    printer.PrintDataGridView(rgridview);

                }
                else if (ind_lbl.Text == "CS")
                {
                    DGVPrinter printer = new DGVPrinter();
                    printer.Title = "Category Wise Sales Report";
                    printer.SubTitle = string.Format("Date: {0}", DateTime.Now);
                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = false;
                    printer.PorportionalColumns = true;
                    printer.HeaderCellAlignment = StringAlignment.Near;
                    printer.Footer = "Sale Information";
                    printer.FooterSpacing = 15;
                    printer.PrintDataGridView(rgridview);

                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Something went wrong", err.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Applicationfilled(string username)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd33 = new SqlCommand("select count(*) from Suppliers where name=@name", con);
            cmd33.Parameters.AddWithValue("@name", username);
            int supcount = (int)cmd33.ExecuteScalar();
            if (supcount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void reports_Load(object sender, EventArgs e)
        {
            //get current username, passed through forms
            //string username = "";
            /*if (Applicationfilled(username))
            {*/

                //check if application filled
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd3 = new SqlCommand("EXEC stpGetLatestSupid", con);
                int supid = (int)cmd3.ExecuteScalar();

                SqlCommand cmd4 = new SqlCommand("Select report_eligible from Suppliers where ID=@ID", con);
                cmd4.Parameters.AddWithValue("@ID", supid);
                bool reporteligible = (bool)cmd4.ExecuteScalar();

               // if (reporteligible)
               //{
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    rgridview.Enabled = true;

               /* }
                else
                {
                    MessageBox.Show("Not approved for report generation yet");
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    rgridview.Enabled = false;

                }*/
            /*}
            else
            {
                MessageBox.Show("Fill the Application by going over to the Submit Application Section");
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                rgridview.Enabled = false;
            }*/

        }
    }
}
