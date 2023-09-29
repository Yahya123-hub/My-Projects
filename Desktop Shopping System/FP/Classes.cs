using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace final_gui_Template
{
    class Supplier : CRUD
    {
        int id;
        string name;
        string contact;
        string email;
        string region;
        bool is_approved, report_eligible;
        private static List<Supplier> suplist = new List<Supplier>();

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Email { get => email; set => email = value; }
        public string Region { get => region; set => region = value; }
        public bool Is_approved { get => is_approved; set => is_approved = value; }
        public bool Report_eligible { get => report_eligible; set => report_eligible = value; }
        public static List<Supplier> Suplist { get => suplist; set => suplist = value; }

        public Supplier()
        {


        }

        public Supplier(string name,string contact,string email,string region)
        {
            this.name = name;
            this.contact = contact;
            this.email = email;
            this.region = region;
        }

        public static void add(Supplier supplier)
        {
            Suplist.Add(supplier);
        }

        public static Supplier retrieve(int id)
        {
            foreach (Supplier supplier in suplist.ToList())
            {
                if (id == supplier.id)
                {
                    return supplier;
                }
            }
            return null;
        }

        public static bool remove(String name)
        {

            foreach (Supplier supplier in Suplist.ToList())
            {
                if (name == supplier.name)
                {
                    Suplist.Remove(supplier);
                    return true;
                }
            }
            return false;
        }

        public static void update(Supplier oldsupplier, Supplier newsupplier)
        {

            foreach (Supplier supplier1 in suplist.ToList())
            {

                if (supplier1 == oldsupplier)
                {
                    oldsupplier.name = newsupplier.name;
                    oldsupplier.contact = newsupplier.contact;
                    oldsupplier.email = newsupplier.email;
                    oldsupplier.region = newsupplier.region;
                }
            }
        }

        public void add()
        {

        }

        public void remove()
        {

        }
        public void update()
        {

        }

        public void retrieve()
        {

        }


    }

    class Product : CRUD
    {
        int ID;
        string ProductName;
        int Pprice;
        int available_quantity;
        string category;
        int supid;
        Image Product_img;
        private static List<Product> plist = new List<Product>();

        public int ID1 { get => ID; set => ID = value; }
        public string ProductName1 { get => ProductName; set => ProductName = value; }
        public int Pprice1 { get => Pprice; set => Pprice = value; }
        public int Available_quantity { get => available_quantity; set => available_quantity = value; }
        public string Category { get => category; set => category = value; }
        public int Supid { get => supid; set => supid = value; }
        public Image Product_img1 { get => Product_img; set => Product_img = value; }
        public static List<Product> Plist { get => plist; set => plist = value; }

        public Product(string ProductName, int Pprice, int available_quantity, string category,Image Product_img)
        {
            this.ProductName1 = ProductName;
            this.Pprice1 = Pprice;
            this.Available_quantity = available_quantity;
            this.Category = category;
            this.Product_img1 = Product_img;
        }
        public Product()
        {

        }

        public static void add(Product product)
        {
            Plist.Add(product);
        }

        public void add()
        {

        }
        public void remove()
        {

        }
        public void update()
        {

        }
        public void retrieve()
        {

        }
    }

    class user : CRUD
    {
        int id;
        string username;
        string email;
        string pswd;
        string role;
        private static List<user> users = new List<user>();

        public user()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public string Pswd { get => pswd; set => pswd = value; }
        public string Role { get => role; set => role = value; }
        public static List<user> Users { get => users; set => users = value; }

        public void add()
        {

        }
        public void remove()
        {

        }
        public void update()
        {

        }
        public void retrieve()
        {

        }
    }

    class feedback : CRUD
    {
        int id;
        int custid;
        int supid;
        string comment;
        int rating;
        private static List<feedback> reviews = new List<feedback>();

        public int Id { get => id; set => id = value; }
        public int Custid { get => custid; set => custid = value; }
        public int Supid { get => supid; set => supid = value; }
        public string Comment { get => comment; set => comment = value; }
        public int Rating { get => rating; set => rating = value; }
        public static List<feedback> Reviews { get => reviews; set => reviews = value; }
        
        public feedback()
        {

        }

        public feedback(int supid,string comment,int rating)
        {
            this.supid = supid;
            this.comment = comment;
            this.rating = rating;

        }

        public void add()
        {

        }
        public void remove()
        {

        }
        public void update()
        {

        }
        public void retrieve()
        {

        }


    }



}
