using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_gui_Template.BL
{
    internal class Order
    {
        private int user_id;
        private string order_date;
        private string ship_address;
        private int total_price;
        public Order(int user_id, string order_date, string ship_address, int total_price)
        {
            User_id = user_id;
            Order_date = order_date;
            Ship_address = ship_address;
            Total_price = total_price;
        }

        public int User_id { get => user_id; set => user_id = value; }
        public string Order_date { get => order_date; set => order_date = value; }
        public string Ship_address { get => ship_address; set => ship_address = value; }
        public int Total_price { get => total_price; set => total_price = value; }
       
    }
}
