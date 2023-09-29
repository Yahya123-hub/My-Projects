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
    public partial class supplier_info : Form
    {
        public supplier_info()
        {
            InitializeComponent();
            LoadSuppliers();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void LoadSuppliers()
        {
            string constring = Configuration.connectionString;
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand command = new SqlCommand("SELECT ID, name, contact, email, region FROM Suppliers", con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                suppliergridview.Rows.Add(reader["ID"], reader["Name"], reader["Contact"], reader["Email"], reader["Region"]);
            }
            reader.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (suppliergridview.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a supplier to approve.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int rowIndex = suppliergridview.CurrentCell.RowIndex;
            int supplierID = int.Parse(suppliergridview.Rows[rowIndex].Cells["Column1"].Value.ToString());
            string constring = Configuration.connectionString;
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand command = new SqlCommand("UPDATE Suppliers SET isApproved = 1 WHERE ID = @SupplierID", con);
            command.Parameters.AddWithValue("@SupplierID", supplierID);
            int rowsAffected = command.ExecuteNonQuery();
            con.Close();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Supplier application approved successfully.");
              
            }
            else
            {
                MessageBox.Show("Application is not Approved.");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (suppliergridview.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a supplier to approve.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int rowIndex = suppliergridview.CurrentCell.RowIndex;
            int supplierID = int.Parse(suppliergridview.Rows[rowIndex].Cells["Column1"].Value.ToString());
            string constring = Configuration.connectionString;
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand command = new SqlCommand("UPDATE Suppliers SET report_eligible = 1 WHERE ID = @SupplierID", con);
            command.Parameters.AddWithValue("@SupplierID", supplierID);
            int rowsAffected = command.ExecuteNonQuery();
            con.Close();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Supplier Report Generation approved successfully.");

            }
            else
            {
                MessageBox.Show("Report Generation is not Approved.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
