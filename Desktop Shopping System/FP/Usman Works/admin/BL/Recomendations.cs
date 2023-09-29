using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_gui_Template.BL
{
    internal class Recomendations
    {
        private int customer_id;
        private int product_id;
        private string review;
        public Recomendations(int customer_id, int product_id, string review)
        {
            this.Customer_id = customer_id;
            this.Product_id = product_id;
            this.Review = review;
        }

        public int Customer_id { get => customer_id; set => customer_id = value; }
        public int Product_id { get => product_id; set => product_id = value; }
        public string Review { get => review; set => review = value; }
    }
}
