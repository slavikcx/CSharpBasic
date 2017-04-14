using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace DBSources
{
    public class SQLDBSource
    {
        private int[,] array;

        private string connectionString;

        public int[,] GetArray(string serverName, string databaseName)
        {
            //creating connection string for SQL DB connection
            connectionString = "Data Source=" + serverName + ";Initial Catalog=" + databaseName + ";Integrated Security=True";
            
            // creating SQL connection instance
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not open connection ! ");
                }

                GetTableToArray(sqlConnection);
            }
            
            return array;
        }

        
        public int [,] GetArray(string serverName, string databaseName, string userName, string password)
        {
            //creating connection string for SQL DB connection
            string connectionString = "Data Source=" + serverName +";Initial Catalog=" + databaseName + ";User ID=" + userName + ";Password=" + password;
            
            // creating SQL connection instance
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not open connection ! ");
                }

                GetTableToArray(sqlConnection);

            }
            return array;
        }


        private void GetTableToArray (SqlConnection sqlConnection)
        {
            string sqlExpression = "select * from ArrayForSorting"; //creating sql query

            SqlCommand command = new SqlCommand(sqlExpression, sqlConnection); //creating sqlcommand instance for sending query to DB
            
            SqlDataReader reader = command.ExecuteReader(); //creting reader for reading data from DB

            int amountOfRows = 10; // need to get somehow amount of rows
            int amountOFCoulumns = reader.FieldCount;

            array = new int[amountOfRows, amountOFCoulumns];

            if (reader.HasRows)
            {
                int i = 0;
                while (reader.Read()) //if string exist in tabel - starting get values in fields
                {
                    for (int j = 0; j < amountOFCoulumns; j++)
                    {
                        array[i, j] = (int)reader.GetValue(j); //getting values fom fields as object and converting them to int
                    }
                    i++;
                }
            }
            reader.Close(); //closing reader
            sqlConnection.Close(); //closing connection
        }

    }
    
}
