using OOPCourseWorkAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OOPCourseWorkApp
{
    public partial class frmManualVote : Form
    {
        protected IUserService _userService;
        protected IVoteService _voteService;
        protected VoteEvent _voteEvent;
        protected List<Candidate> _currentCandidates;
        protected User _manualUser;

        public frmManualVote(IUserService userService, IVoteService voteService, VoteEvent voteEvent, List<Candidate> currentCandidates)
        {
            _userService = userService;
            _voteService = voteService;
            _voteEvent = voteEvent;
            _currentCandidates = currentCandidates;
            InitializeComponent();

            pnlManualRegister.Visible = true;
            ctlManualVoteControl.Visible = false;
            ctlManualVoteControl.OnCompleted += CtlManualVoteControl_OnCompleted;
        }

       

        private void btnNext_Click(object sender, EventArgs e)
        {
            var firstName = txtFirstName.Text;
            var lastName = txtLastName.Text;
            var DOB = dtpDob.Value;

            //Checking we have values
            if(string.IsNullOrEmpty(firstName)||string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Please enter first name and last name");
                return;
            }

            //Check to see if username is available
            if (_userService.IsManualUserAvailable(firstName, lastName, DOB) == false)
            {
                MessageBox.Show("A user with first name,last name and DOB already exists");
                return;
            }

            //Create the manual user
            _manualUser = _userService.ManualRegister(firstName, lastName, DOB);

            //Switch to log the manual user to vote
            pnlManualRegister.Visible = false;
            ctlManualVoteControl.Init(_voteService, _voteEvent, _manualUser.UserId, _currentCandidates);
            ctlManualVoteControl.Location = pnlManualRegister.Location;
            ctlManualVoteControl.Visible = true;
            ctlManualVoteControl.BringToFront();
            this.Refresh();            
        }

        /// <summary>
        /// Called when the vote control is completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CtlManualVoteControl_OnCompleted(object sender, EventArgs e)
        {
            // Close the Form when vote is complete
            this.Close();
        }
    }
}
