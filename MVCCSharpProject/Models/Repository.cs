using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVCCSharpProject.ViewModels;

namespace MVCCSharpProject.Models
{
    public class Repository
    {

        public string _connectionString =
            System.Configuration.ConfigurationManager.ConnectionStrings["mvcCsharp"].ConnectionString;


        public void Create(Customers customerForm)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"INSERT INTO CustomersTable
                                                 (CustomerName,CustomerAddress,CustomerPhone)
                                         VALUES  (@CustomerName,@CustomerAddress,@CustomerPhone)";
                command.Parameters.AddWithValue("@CustomerName", customerForm.CustomerName);
                command.Parameters.AddWithValue("@CustomerAddress", customerForm.CustomerAddress);
                command.Parameters.AddWithValue("@CustomerPhone", customerForm.CustomerPhone);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        internal List<Customers> GetCustomerReport()
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT *
                                    FROM CustomersTable";
                connection.Open();
                var reader = command.ExecuteReader();
                var customers = new List<Customers>();
                while (reader.Read())
                {
                    Customers customersList = new Customers();
                    customersList.Id = (int)reader["Id"];
                    customersList.CustomerName = reader["CustomerName"] as string;
                    customersList.CustomerAddress = reader["CustomerAddress"] as string;
                    customersList.CustomerPhone = reader["CustomerPhone"] as string;
                    customers.Add(customersList);
                }
                return customers;
            }
        }

        internal List<Customers> GetCustomers()
        {

            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM CustomersTable";

                connection.Open();

                var reader = command.ExecuteReader();
                var customers = new List<Customers>();

                while (reader.Read())
                {
                    var customerList = new Customers();
                    customerList.Id = (int)reader["Id"];
                    customerList.CustomerName = reader["CustomerName"] as string;
                    customerList.CustomerAddress = reader["CustomerAddress"] as string;
                    customerList.CustomerPhone = reader["CustomerPhone"] as string;
                    customers.Add(customerList);

                }
                return customers;
            }

        }
    }
}