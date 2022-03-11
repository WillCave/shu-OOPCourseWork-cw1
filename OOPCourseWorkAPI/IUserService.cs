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
     
    }
}
