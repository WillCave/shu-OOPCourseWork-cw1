using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOPCourseWorkAPI;
using OOPCourseWorkApp;

namespace OOPCourseWork
{
    public partial class frmLogin : Form
    {
        protected IUserService _userService;
        
        public frmLogin()
        {
            // Create required services
            _userService = new UserService(Program.DBConnectionString);

            InitializeComponent();
            pnlLogin.Visible = false;        
            
        }
        
        private void btnRegister_Click(object sender, EventArgs e)
        {
            //Checking to see if someone has already got the same username
            //as what this person wanted theirs to be in database
            if (_userService.IsUsernameAvailable(txtRUser.Text) == false)
            {
                // if username already taken error message will show
                MessageBox.Show("Username has already been taken");
                    return;
            }

            if (ValidRegisterForm() == true)
            {
                var user = _userService.RegisterUser(txtRUser.Text, txtRPassword.Text,
                    UserRoleType.Voter, txtFirstName.Text, txtLastName.Text);

                ShowMainForm(user);
            }
        }

        /// <summary>
        /// Validate the register form
        /// </summary>
        /// <returns>true if registeration form is valid otherwise false</returns>
        private bool ValidRegisterForm()
        {
            string errorMessage = null;

            // Check Fields have values
            if (String.IsNullOrEmpty(txtRUser.Text))
                errorMessage = "Username is blank";
            else if (String.IsNullOrEmpty(txtRPassword.Text))
                errorMessage = "Password is blank";
            else if (string.IsNullOrEmpty(txtFirstName.Text))
                errorMessage = "Please enter your first name";
            else if (string.IsNullOrEmpty(txtLastName.Text))
                errorMessage = "Please enter your last name";

            if ( errorMessage != null)
            {
                MessageBox.Show(errorMessage);
                return false;
            }

            return true;
        }

        // Allowing users to be able to login 
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //going into the UserService to see if the username and password match in the database
            var user = _userService.LoginUser(txtUserName.Text, txtPassword.Text);
            //if username or password is wrong/ doesn't match up a error message will appear
            if(user == null)
            {
                MessageBox.Show("Username or password wrong please try again, or register if you haven't alredy.");
                return;
            }

            ShowMainForm(user); 
           
        }

        private void ShowMainForm(User user)
        {
            //This will hide the login form and take the user to the main form where they can place their votes 
            // and also if admin will take them to their allocated roles
            frmMain Main = new frmMain(user);
            Main.Show();
            Visible = false;
        }

        //If the register label is clicked on the log in pannel then the Register pannel will show and log in will be hidden
        private void lblLRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlLogin.Visible = false;
            pnlRegister.Visible = true;
        }

        //if the login label is clicken then the login panel will show and the register panel will be hidden
        private void lblLLongin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlLogin.Visible = true;
            pnlRegister.Visible = false;
        }
    }
}
