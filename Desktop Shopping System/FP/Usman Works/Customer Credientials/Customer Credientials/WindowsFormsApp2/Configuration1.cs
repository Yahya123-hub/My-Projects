using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class Configuration1
    {
        //________CONNECTION OF SERVER______________
        public static string connectionString = "Data Source=(local);Initial Catalog=FP;Integrated Security=True";
        public static int Execute(string query)
        {
            string conString = Configuration1.connectionString;
            int result = 0;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = query;
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteNonQuery();
            }
            con.Close();
            return result;
        }
    }

}
