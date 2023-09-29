using information;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Contact { get; set; }
    public string Email { get; set; }
    public string Country { get; set; }
    public string Address { get; set; }
    public DateTime DateUpdated { get; set; }
    public DateTime DateCreated { get; set; }

    public static List<Customer> Customers { get; set; } = new List<Customer>();

    public Customer(string firstName, string lastName, string contact, string email, string country, string address)
    {
        this.Id = -1;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Contact = contact;
        this.Email = email;
        this.Country = country;
        this.Address = address;
        this.DateCreated = DateTime.Now;
        this.DateUpdated = DateTime.Now;
    }

    public bool AddCustomer()
    {
        string constring = Configuration1.connectionString;
        SqlConnection con = new SqlConnection(constring);
        string query = "INSERT INTO Customers (Fname, Lname, mobile, email, country, address, datecreated, dateupdated) " +
                           "VALUES (@FirstName, @LastName, @Contact, @Email, @Country, @Address, @DateCreated, @DateUpdated)";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@Contact", Contact);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Country", Country);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@DateCreated", DateCreated);
                command.Parameters.AddWithValue("@DateUpdated", DateUpdated);

                con.Open();
                command.ExecuteNonQuery();
            }
        

        Customers.Add(this);
        return true;
    }

    public static List<Customer> GetAllCustomers()
    {
        List<Customer> customers = new List<Customer>();

        string constring = Configuration1.connectionString;       
        using (SqlConnection connection = new SqlConnection(constring))
        {
            string query = "SELECT Fname, Lname, contact, email, country, address FROM Customers";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer(
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5)
                        );
                        customer.DateCreated = reader.GetDateTime(6);
                        customer.DateUpdated = reader.GetDateTime(7);
                        customers.Add(customer);
                    }
                }
            }
        }

        Customers = customers;
        return customers;
    }
}

