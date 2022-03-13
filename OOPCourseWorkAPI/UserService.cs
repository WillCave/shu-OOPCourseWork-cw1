using System;
using System.Data;
using System.IO;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;

namespace OOPCourseWorkAPI
{
    /// <summary>
    /// Implmentation of the IUserService using Dapper
    /// </summary>
    public class UserService : IUserService
    {

        private string _connectionString;

        public UserService(string connectionString )
        {
            _connectionString = connectionString;
        }

        /// <inheritdoc/>
       public User RegisterUser(string userName, string password, UserRoleType userRole, string firstName, string lastName)
       {
            // Check Username is available
            if (IsUsernameAvailable(userName) == false)
                throw new Exception("Username already exists");

            // Insert New User
            using ( var connection = new SqliteConnection( _connectionString ))
            {
                var newUser = new User() { UserName = userName, PasswordHash = password, UserRole = userRole, FirstName = firstName, LastName = lastName, EntryDateTime = DateTime.Now, UpdateDateTime = DateTime.Now };
                connection.Insert(newUser);

                return newUser;    
            }
        }

        /// <inheritdoc/>
        public bool IsUsernameAvailable(string userName)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {            
                return connection.Query($"SELECT * FROM Users WHERE Username = '{userName}'").ToList().Count == 0;
            }
        }

        /// <inheritdoc/>
        public User LoginUser(string userName, string password)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                return connection.Query<User>($"SELECT * FROM Users WHERE Username = '{userName}' AND PasswordHash ='{password}'").FirstOrDefault();
            }
        }
      
    }
}
