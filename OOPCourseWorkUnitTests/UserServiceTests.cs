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
            // Need to clean up Test Database delete tables in order to not break forign key links           
            DatabaseTestHelpers.DeleteTableContent("Votes");
            DatabaseTestHelpers.DeleteTableContent("Candidates");
            DatabaseTestHelpers.DeleteTableContent("VoteEvents");
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
        [TestMethod]
        public void ManuallyRegisterUser()
        {
            //Set Up
            var userService = new UserService(DatabaseTestHelpers.TestConnectionString);

            //Test
            var user = userService.ManualRegister("Will", "Cave", new DateTime(2002, 2, 8));

            //Check
            Assert.AreEqual("Will", user.FirstName, "Incorrect Firstname");
            Assert.AreEqual("Cave", user.LastName, "Incorrect Lastname");
            Assert.AreEqual("WillCave08/02/2002", user.UserName, "Incorrect Username");
        }
        [TestMethod]
        public void ManualRegisterExistingUser()
        {
            //Set Up register initial user
            var userService = new UserService(DatabaseTestHelpers.TestConnectionString);
            userService.ManualRegister("Will", "Cave", new DateTime(2002, 2, 8));

            //Test  
            var registerAction = new Action(() => { var user = userService.ManualRegister("Will", "Cave", new DateTime(2002, 2, 8)); });

            //Check
            Assert.ThrowsException<Exception>(registerAction, "A person with this first name, last name and DOB already exists");
        }
        [TestMethod]
        public void IsManualUserNameAvailable()
        {
            //Set Up
            var userService = new UserService(DatabaseTestHelpers.TestConnectionString);
            userService.ManualRegister("Will", "Cave", new DateTime(2002,2,8));
            userService.ManualRegister("Phil", "Cave",new DateTime(1972, 3, 15));

            //Test
            var wcaveAvailable = userService.IsManualUserAvailable("Will", "Cave", new DateTime(2002, 2, 8));
            var pcaveAvailable = userService.IsManualUserAvailable("Phil", "Cave", new DateTime(1972, 3, 15));
            var lcaveAvailable = userService.IsManualUserAvailable("Lee", "Cave", new DateTime(1975, 6, 20));
            var scaveAvailable = userService.IsManualUserAvailable("Ste", "Cave", new DateTime(1969, 6, 12));

            //Check
            Assert.AreEqual(false, wcaveAvailable, "Will Cave should not be available");
            Assert.AreEqual(false, pcaveAvailable, "Phil Cave should not be available");
            Assert.AreEqual(true, lcaveAvailable, "Lee Cave should be available");
            Assert.AreEqual(true, scaveAvailable, "Ste Cave should not be available");
        }
    }
}
