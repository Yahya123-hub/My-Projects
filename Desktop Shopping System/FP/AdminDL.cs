using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using final_gui_Template.BL.AdminBL;
using information;

namespace final_gui_Template.DL.ADMINDL
{
    internal class AdminDL
    {
        public static int Add_update_user(AdminBL user)
        {
            int status = 0;
            string conString = Configuration1.connectionString;
            bool found = false;
            AdminBL tempuser = new AdminBL("", "", "", "");
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Users WHERE ID = '" + user.Id + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    tempuser.Id = result.GetInt32(0);
                    tempuser.Username = result.GetString(1);
                    tempuser.Email = result.GetString(2);
                    tempuser.Password = result.GetString(3);
                    tempuser.Role = result.GetString(4);
                    found = true;
                    break;
                }
                result.Close();
            }
            if (found)
            {
                if (shouldUpdate(tempuser, user))
                {
                    UpdateUser(user);
                    status = 2;
                }
            }
            else
            {
                if (shouldInsert(user, tempuser))
                {
                    insertUser(user);
                    status = 1;
                }
            }
            con.Close();
            return status;
        }

        private static bool shouldUpdate(AdminBL olduser, AdminBL newuser)
        {
            // Check if any of the user fields have changed
            bool hasChanged = (
                (!olduser.Username.Equals(newuser.Username)) ||
                (!olduser.Email.Equals(newuser.Email)) ||
                (!olduser.Password.Equals(newuser.Password)) ||
                (!olduser.Role.Equals(newuser.Role))
            );

            // Check if the new email is not already in use
            bool emailAvailable = (getuserByEmail(newuser.Email).Id == -1 || getuserByEmail(newuser.Email).Id == newuser.Id);

            // Check if the new email is the same as the old email or if it is available
            bool canUpdateEmail = (newuser.Email == olduser.Email || emailAvailable);

            if (hasChanged && canUpdateEmail)
            {
                string constring = Configuration1.connectionString;
                using (var connection = new SqlConnection(constring))
                {
                    connection.Open();
                    var query = "UPDATE Users SET username=@Username, email=@Email, pswd=@Password, role=@Role WHERE ID=@Id";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", olduser.Id);
                    command.Parameters.AddWithValue("@Username", newuser.Username);
                    command.Parameters.AddWithValue("@Email", newuser.Email);
                    command.Parameters.AddWithValue("@Password", newuser.Password);
                    command.Parameters.AddWithValue("@Role", newuser.Role);
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }




        private static void UpdateUser(AdminBL user)
        {
            string conString = Configuration1.connectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "UPDATE Users SET username = @username, email = @email, pswd = @pswd, role = @role WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@pswd", user.Password);
                cmd.Parameters.AddWithValue("@role", user.Role);
                cmd.Parameters.AddWithValue("@ID", user.Id);
                cmd.ExecuteNonQuery();
            }
        }

        private static bool shouldInsert(AdminBL user, AdminBL tempuser)
        {
            if (!tempuser.Username.Equals("") && !tempuser.Email.Equals("") && !tempuser.Password.Equals("") && !tempuser.Role.Equals(""))
            {
                if (tempuser.Username.Equals(user.Username) && tempuser.Email.Equals(user.Email) && tempuser.Password.Equals(user.Password) && tempuser.Role.Equals(user.Role))
                {
                    return false;
                }

                if (getuserByEmail(user.Email).Id == -1)
                {
                    return true;
                }

                if (GetUser(user.Email).Id == tempuser.Id)
                {
                    return false;
                }
            }

            return true;
        }


        private static void insertUser(AdminBL user)
        {
            Configuration1.Execute("INSERT INTO Users(username, email, pswd, role) values ('" + user.Username + "', '" + user.Email + "', '" + user.Password + "', '" + user.Role + "')");
        }


        public static AdminBL getuserByEmail(string email)
        {
            string conString = Configuration1.connectionString;
            AdminBL user = new AdminBL("", "", "", "");
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Users WHERE email = '" + email + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    user.Id = result.GetInt32(0);
                    user.Username = result.GetString(1);
                    user.Email = result.GetString(2);
                    user.Password = result.GetString(3);
                    user.Role = result.GetString(4);
                    break;
                }
            }
            con.Close();
            if (user.Id == 0)
            {
                user.Id = -1;
            }
            return user;
        }

        public static AdminBL GetUser(string email)
        {
            string constring = Configuration1.connectionString;
            var query = "SELECT * FROM Users WHERE  email = @email";
            var parameters = new { email = email };

            using (var connection = new SqlConnection(constring))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", email);
                var result = command.ExecuteReader();

                if (result.Read())
                {
                    var u_l = new AdminBL
                    {
                        Id = result.GetInt32(0),
                        Username = result.GetString(1),
                        Email = result.GetString(2),
                        Password = result.GetString(3),
                        Role = result.GetString(4),
                    };

                    return u_l;
                }
                else
                {
                    return null;
                }
            }
        }

        public static List<AdminBL> retrieve_user()
        {
            string conString = Configuration1.connectionString;
            List<AdminBL> ulist = new List<AdminBL>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {


                string q = "SELECT * FROM Users";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    AdminBL u_s = new AdminBL(result.GetString(1), result.GetString(2), result.GetString(3), result.GetString(4));
                    u_s.Id = result.GetInt32(0);
                    ulist.Add(u_s);

                }

            }
            con.Close();
            return ulist;

        }
        public static bool delete_Id(int id)
        {
            string query = "DELETE FROM Users WHERE ID = '" + id + "'";
            if (Configuration1.Execute(query) > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}

