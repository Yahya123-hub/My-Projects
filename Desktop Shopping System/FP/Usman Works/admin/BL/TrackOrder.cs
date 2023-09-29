using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_gui_Template.BL
{
    internal class TrackOrder
    {
        private int order_id;
        private int customer_id;
        private string order_date;
        private string delivery_date;
        private string status;
        private string ship_address;
        public TrackOrder(int order_id, int customer_id, string order_date, string delivery_date, string status, string ship_address)
        {
            this.Order_id = order_id;
            this.Customer_id = customer_id;
            this.Order_date = order_date;
            this.Delivery_date = delivery_date;
            this.Status = status;
            this.Ship_address = ship_address;
        }

        public int Order_id { get => order_id; set => order_id = value; }
        public int Customer_id { get => customer_id; set => customer_id = value; }
        public string Order_date { get => order_date; set => order_date = value; }
        public string Delivery_date { get => delivery_date; set => delivery_date = value; }
        public string Status { get => status; set => status = value; }
        public string Ship_address { get => ship_address; set => ship_address = value; }
    }
}
