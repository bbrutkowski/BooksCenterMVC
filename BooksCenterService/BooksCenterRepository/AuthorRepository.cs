using BooksCenterService.Interfaces;
using BooksCenterService.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BooksCenterRepository
{
   
    public class AuthorRepository : IAuthorRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["BookCenterConnectionString"].ConnectionString;

        public bool AddAuthor(Author author)
        {
            bool success;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.OpenAsync();

                    string commandText = $"INSERT INTO [Authors] ([Name],[Surname],[YearOfBirth]) VALUES (@Name, @Surname, @YearOfBirth)";
                    SqlCommand command = new SqlCommand(commandText, connection);
                    command.Parameters.Add("@Name", SqlDbType.NVarChar, 255).Value = author.Name;
                    command.Parameters.Add("@Surname", SqlDbType.NVarChar, 255).Value = author.Surname;
                    command.Parameters.Add("@YearOfBirth", SqlDbType.Int, 8).Value = author.YearOfBirth;
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

        public bool DeleteAuthor(int id)
        {
            bool success;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string commandText = $"DELETE FROM [Authors] WHERE ID = @Id";
                    SqlCommand command = new SqlCommand(commandText, connection);
                    command.Parameters.Add("@Id", SqlDbType.Int, 8).Value = id;
                    int rowsAffected = command.ExecuteNonQuery();

                    success = rowsAffected == 1;
                    if (!success)
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                success = false;
            }

            return success;
        }
    }
}
