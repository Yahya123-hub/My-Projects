using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_gui_Template.BL
{
    internal class customers
    {
        private string name;
        private string pswd;
        private string phone;
        private string email;
        private string address;
        public customers(string name, string pswd, string phone, string email, string address)
        {
            this.Name = name;
            this.Pswd = pswd;
            this.Phone = phone;
            this.Email = email;
            Address = address;
        }

        public string Name { get => name; set => name = value; }
        public string Pswd { get => pswd; set => pswd = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => Address; set => Address = value; }
    }
}
