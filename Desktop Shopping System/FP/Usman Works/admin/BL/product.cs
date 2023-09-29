using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_gui_Template.BL
{
    internal class product
    {
        private int category_id;
        private int brand_id;
        private string name;
        private string description;
        private float price;
        private int quantity;
        private string image_url;
        public product(int category_id, int brand_id, string name, string description, float price, int quantity, string image_url)
        {
            this.Category_id = category_id;
            this.Brand_id = brand_id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Quantity = quantity;
            this.Image_url = image_url;
        }

        public int Category_id { get => category_id; set => category_id = value; }
        public int Brand_id { get => brand_id; set => brand_id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public float Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string Image_url { get => image_url; set => image_url = value; }
    }
}
