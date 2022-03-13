using System;
using System.Collections.Generic;
using System.Text;

namespace OOPCourseWorkAPI
{
 
    /// <summary>
    /// IUserService provides a interface for the userApi in the voting system
    /// </summary>
    public  interface IUserService
    {
        /// <summary>
        /// Register the user with the specified parameters 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="userRole"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>        
        /// <returns>The newly registered user or a error if can not register</returns>
        User RegisterUser(string userName, string password, UserRoleType userRole, string firstName, string lastName);

        /// <summary>
        /// Checks if the Username is available
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>true if available otherwise false</returns>
        bool IsUsernameAvailable(string userName);

        /// <summary>
        ///Login the user with specified parameters 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>User if succesful otherwise Null</returns>
        User LoginUser(string userName, string password);

        /// <summary>
        /// Manual Register only for the auditor
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        ///  <param name="Dob"></param>
        /// <returns>A newly registered voter otherwise a error</returns>
        User ManualRegister(string firstName, string lastName, DateTime Dob);

        /// <summary>
        /// Check to see if the auditor is able to register user manually
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        ///  <param name="Dob"></param>
        /// <returns>true if available otherwise false</returns>
        bool IsManualUserAvailable(string firstName, string lastName, DateTime Dob);

        /// <summary>
        /// Gets the manual user
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        ///  <param name="Dob"></param>
        /// <returns>Logs in otherwise a error</returns>
        User GetManualUser(string firstName, string lastName, DateTime Dob);

    }
}
