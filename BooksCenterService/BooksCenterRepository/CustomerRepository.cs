using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BooksCenterService.Models;
using BooksCenterService.Interfaces;

namespace BooksCenterRepository
{
    
    public class CustomerRepository : ICustomerRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["BookCenterConnectionString"].ConnectionString;

        public bool AddCustomer(Customer user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string commandSql = "INSERT INTO [Users] ([Name], [Email], [Password]) " +
                        "VALUES (@Name, @Email, @Password)";
                    SqlCommand command = new SqlCommand(commandSql, connection);
                    command.Parameters.Add("@Name", SqlDbType.NVarChar, 255).Value = user.Name;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar, 255).Value = user.Email;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar, 255).Value = user.Password;

                    if (command.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        public bool DeleteCustomer(string userName)
        {
            bool success;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string commandText = $"DELETE FROM [Users] WHERE Name = '{userName}'";
                    SqlCommand command = new SqlCommand(commandText, connection);
                    int rowsAffected = command.ExecuteNonQuery();

                    success = rowsAffected == 1;

                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                success = false;
            }

            return success;
        }

        public Customer GetCustomer(string username)
        {
            Customer user = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string commandText = $"SELECT * FROM [Users] WHERE [Name] = @Name";

                    SqlCommand command = new SqlCommand(commandText, connection);
                    command.Parameters.Add("@Name", SqlDbType.NVarChar, 255).Value = username;

                    SqlDataReader dataReader = command.ExecuteReader();

                    dataReader.Read();

                    user = new Customer
                    {
                        Name = dataReader["Name"].ToString(),
                        Password = dataReader["Password"].ToString(),
                        Email = dataReader["Email"].ToString(),
                    };

                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                user = null;
            }

            return user;
        }
    }
}
