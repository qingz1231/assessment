using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;
using System.Web.Services;
using System.Data.SqlClient;

namespace assessment
{
    public partial class assessment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static int MyCSharpFunction(string inputParameter)
        {
           string databasePath = "|DataDirectory|\\Database.mdf";

   
        int row = 0;
            string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={databasePath};Integrated Security=True"; ;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Database operations go here
            }

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


    }
}