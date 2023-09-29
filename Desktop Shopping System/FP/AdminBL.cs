using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_gui_Template.BL.AdminBL
{
    internal class AdminBL
    {
        int id;
        string username;
        string email;
        string password;
        string role;

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }

        public AdminBL(string username, string email, string password, string role)
        {
            this.username = username;
            this.email = email;
            this.password = password;
            this.role = role;
        }
        public AdminBL()
        {
        }
        public AdminBL(string username)
        {
            this.username = username;
        }
    }
}
