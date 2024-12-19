using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace CookingSystem
{

    public static class Validator
    {

        public static string GetValidatedUser()
        {
            string input = "";
            bool isValid = false;

            while (!isValid)
            {
                try
                {
                    input = Console.ReadLine();

                    if (input.Length >= 3 && input.Length <= 20 && Regex.IsMatch(input, @"^[a-zA-Z0-9]+$"))
                    {
                        if (IsUsernameTaken(input))
                        {
                            Console.WriteLine("Username is already taken. Please choose a different one.");
                        }
                        else
                        {
                            isValid = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a username with 3-20 characters, only letters and numbers, and no spaces.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    Console.WriteLine("Please try again.");
                }
            }
            return input;
        }

        public static bool IsUsernameTaken(string username)
        {
            string connectionString =@"Data Source = (LocalDB)\MSSQLLocalDB;Initial Catalog=""D:\School\source\repos\CookingSystem\Database1.mdf"";Integrated Security = True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM CompleteCustomizations WHERE CharacName = @CharacName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CharacName", username);

                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Database error occurred: " + sqlEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                return false;
            }
        }


        public static int GetValidatedInput(int min, int max)
        {
            int choice;

            while (true)
            {
                try
                {
                    string userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out choice))
                    {
                        if (choice >= min && choice <= max)
                        {
                            return choice;
                        }
                        else
                        {
                            Console.WriteLine($"Please enter a valid number between {min} and {max}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    Console.WriteLine("Please try again.");
                }
            }
        }
    }
}
