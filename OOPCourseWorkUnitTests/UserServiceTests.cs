using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPCourseWorkAPI;
using System;

namespace OOPCourseWorkUnitTests
{
    [TestClass]
    public class UserServiceTests
    {

        [TestInitialize]
        public void TestInit()
        {
            // Need to clean up Test Database user table between tests
            DatabaseTestHelpers.DeleteTableContent("Users");
        }

        [TestMethod]
        public void RegisterUserTest()
        {
            //SetUp
            var userService = new UserService(DatabaseTestHelpers.TestConnectionString);

            //Test
            var user = userService.RegisterUser("wcave", "Password123", UserRoleType.Voter, "Will", "Cave");

            //Check
            Assert.IsNotNull(user, "No user Registered");
            Assert.IsTrue(user.UserId > 0 , "No userID assigned");
            Assert.AreEqual("wcave", user.UserName, "Incorrect Username");
            Assert.AreEqual(UserRoleType.Voter, user.UserRole, "Incorrect UserRole");
            Assert.AreEqual("Will", user.FirstName, "Incorrect Firstname");
            Assert.AreEqual("Cave", user.LastName, "Incorrect Lastname");
        }

        [TestMethod]
        public void RegisterUserWithSameUsernameTest()
        {
            //Set Up register initial user
            var userService = new UserService(DatabaseTestHelpers.TestConnectionString);
            userService.RegisterUser("wcave", "Password123", UserRoleType.Voter, "Will", "Cave");

            //Test  
            var registerAction = new Action( () => { userService.RegisterUser("wcave", "Password1234", UserRoleType.Voter, "Will2", "Cave2"); });

            //Check
            Assert.ThrowsException<Exception>( registerAction, "Username already Exists");
        }

        [TestMethod]
        public void IsUsernameAvailableTest()
        {
            //Set Up
            var userService = new UserService(DatabaseTestHelpers.TestConnectionString);
            userService.RegisterUser("wcave", "Password123", UserRoleType.Voter, "Will", "Cave");
            userService.RegisterUser("pcave", "Password1234", UserRoleType.Voter, "Phil", "Cave");

            //Test
            var wcaveAvailable = userService.IsUsernameAvailable("wcave");
            var pcaveAvailable = userService.IsUsernameAvailable("pcave");
            var lcaveAvailable = userService.IsUsernameAvailable("lcave");
            var scaveAvailable = userService.IsUsernameAvailable("scave");

            //Check
            Assert.AreEqual(false, wcaveAvailable ,"wcave should not be available");
            Assert.AreEqual(false, pcaveAvailable, "pcave should not be available");
            Assert.AreEqual(true, lcaveAvailable, "lcave should be available");
            Assert.AreEqual(true, scaveAvailable, "scave should not be available");
        }

        [TestMethod]
        public void LoginUserTest()
        {
            //Set Up register initial user
            var userService = new UserService(DatabaseTestHelpers.TestConnectionString);
            userService.RegisterUser("wcave", "Password123", UserRoleType.Voter, "Will", "Cave");

            //Test  
            var user = userService.LoginUser("wcave", "Password123");

            //Check
            Assert.IsNotNull(user, "user login incorrect");
            Assert.AreEqual("wcave", user.UserName, "Incorrect Username");
            Assert.AreEqual(UserRoleType.Voter, user.UserRole, "Incorrect UserRole");
            Assert.AreEqual("Will", user.FirstName, "Incorrect Firstname");
            Assert.AreEqual("Cave", user.LastName, "Incorrect Lastname");
        }
        [TestMethod]
        public void LoginUserIncorrectPasswordTest()
        {
            //Set Up register initial user
            var userService = new UserService(DatabaseTestHelpers.TestConnectionString);
            userService.RegisterUser("wcave", "Password123", UserRoleType.Voter, "Will", "Cave");

            //Test  
            var user = userService.LoginUser("wcave", "IncorrectPassword");

            //Check
            Assert.IsNull(user, "user should be null");
        }
        [TestMethod]
        public void LoginUserIncorrectUserNameTest()
        {
            //Set Up register initial user
            var userService = new UserService(DatabaseTestHelpers.TestConnectionString);
            userService.RegisterUser("wcave", "Password123", UserRoleType.Voter, "Will", "Cave");

            //Test  
            var user = userService.LoginUser("wcaveIncorrect", "Password123");

            //Check
            Assert.IsNull(user, "user should be null");
        }
    }
}
