using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace assessment
{
    public class ApplicationController
    {
        private static string databasePath = "|DataDirectory|\\Database.mdf";
        private static string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={databasePath};Integrated Security=True";

        public static int getRecordTotal(string inputParameter)
        {
            int row = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = $"SELECT * FROM Application WHERE firstChoice='{inputParameter}'";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Access data using reader["ColumnName"]
                            row++;
                        }
                    }
                }

            }


            return row;
        }


        public static Boolean addRecord(string name, string ic, string phone, string email, byte[] fileBytes)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "INSERT INTO Application (applicantName, applicantIC, phone, email, firstChoice,resultSlip,applicationStatus) " +
                      "VALUES (@name, @ic, @phone, @email, @test,@resultImage,@status)";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@ic", ic);
                        command.Parameters.AddWithValue("@phone", phone);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@test", "test");
                        command.Parameters.AddWithValue("@resultImage", fileBytes);
                        command.Parameters.AddWithValue("@status", "pending");
                        // Execute the SQL command
                        int rowsAffected = command.ExecuteNonQuery();
                        

                    }
                    connection.Close();
                    return true;
                }
            }catch(Exception ex)
            {
                return false;
            }
        }

        public static Boolean isRecordExist(string ic)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = $"SELECT * FROM Application WHERE applicantIC='{ic}'";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return true;
                            }
                        }
                    }
                    connection.Close();
                }
            } catch(Exception ex)
            {
                throw ex;
            }

            return false;
        }


        public static string getEmailByIc(string ic)
        {
            string email;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT email FROM Application WHERE applicantIC = @ic";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ic", ic);
                        // Execute the SQL command
                        email = command.ExecuteScalar() as string;

                    }
                    connection.Close();
                    
                }
                return email;
            
        }

        public static Application getApplicationByIc(string ic)
        {
            Application application;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a SqlCommand with the SQL query
                string sqlQuery = "SELECT * FROM Application WHERE applicantIC = @ic";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Add the parameter
                    command.Parameters.AddWithValue("@ic", ic);

                    // Execute the query and retrieve the results as a SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Create an Application object and populate it with data from the reader
                             application = new Application
                            {
                                ApplicationID = (int)reader["applicationID"],
                                ApplicantName = reader["applicantName"].ToString(),
                                ApplicantIC = reader["applicantIC"].ToString(),
                                Phone = reader["phone"].ToString(),
                                Email = reader["email"].ToString(),
                                status = reader["applicationStatus"].ToString(),
                                result = (byte[])reader["resultSlip"]
                                // Set other properties as needed...
                            };

                            // Add the Application object to the list
                            return application;
                        }
                    }
                }

            }

            return application = new Application();
        }
    }

    
}