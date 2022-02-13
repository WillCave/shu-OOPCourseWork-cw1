using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Text;

namespace OOPCourseWorkUnitTests
{
    /// <summary>
    /// Database Test Helpers provides functionality to help whilst testing the database
    /// </summary>
    public class DatabaseTestHelpers
    {

        /// <summary>
        /// Test Connection String of unit testing database
        /// </summary>
        public static string TestConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security = True; Database=VotingSystemTestDatabase";


        /// <summary>
        /// Delete Table Contents is a helper method that deletes the conntent of the tables
        /// </summary>
        /// <param name="tableName"></param>
        public static void DeleteTableContent(string tableName)
        {
            using (var connection = new SqlConnection(DatabaseTestHelpers.TestConnectionString))
            {
                connection.Execute($"Delete FROM {tableName}");
            }
        }
    }
}
