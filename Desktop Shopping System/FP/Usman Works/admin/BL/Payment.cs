using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_gui_Template.BL
{
    internal class Payment
    {
        private int order_id;
        private string payment_method;
        private string amount;
        private string delivery_date;
        public Payment(int order_id, string payment_method, string amount, string delivery_date)
        {
            this.Order_id = order_id;
            this.Payment_method = payment_method;
            this.Amount = amount;
            this.Delivery_date = delivery_date;
        }

        public int Order_id { get => order_id; set => order_id = value; }
        public string Payment_method { get => payment_method; set => payment_method = value; }
        public string Amount { get => amount; set => amount = value; }
        public string Delivery_date { get => delivery_date; set => delivery_date = value; }
    }
}
