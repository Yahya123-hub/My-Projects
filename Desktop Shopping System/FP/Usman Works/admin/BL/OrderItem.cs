using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_gui_Template.BL
{
    internal class OrderItem
    {
        private int order_id;
        private int product_id;
        private int quantity;
        private int price;
        public OrderItem(int order_id, int product_id, int quantity, int price)
        {
            this.Order_id = order_id;
            this.Product_id = product_id;
            this.Quantity = quantity;
            this.Price = price;
        }

        public int Order_id { get => order_id; set => order_id = value; }
        public int Product_id { get => product_id; set => product_id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int Price { get => price; set => price = value; }
    }
}
