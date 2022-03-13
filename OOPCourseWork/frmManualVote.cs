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

            //Check if the manual user exists as they may want to change their vote
            _manualUser = _userService.GetManualUser(firstName, lastName, DOB);

            //No manual user exists so cretae one
            if (_manualUser == null)
            {
                //Create the manual user
                _manualUser = _userService.ManualRegister(firstName, lastName, DOB);
            }

            //Switch to log the manual user to vote
            pnlManualRegister.Visible = false;
            ctlManualVoteControl.Init(_voteService, _voteEvent, _manualUser.UserId, _currentCandidates);
            ctlManualVoteControl.Location = pnlManualRegister.Location;
            ctlManualVoteControl.Visible = true;
            ctlManualVoteControl.BringToFront();
            this.Refresh();            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
