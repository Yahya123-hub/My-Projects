using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_gui_Template.BL
{
    internal class Cart_products

    {
        private int customer_id;
        private int product_id;
        public Cart_products(int customer_id, int product_id)
        {
            this.Customer_id = customer_id;
            this.Product_id = product_id;
        }

        public int Customer_id { get => customer_id; set => customer_id = value; }
        public int Product_id { get => product_id; set => product_id = value; }
    }
}
