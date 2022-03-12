using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OOPCourseWorkApp;
using OOPCourseWorkAPI;
using OOPCourseWork;

namespace OOPCourseWorkApp
{
    public partial class frmMain : Form
    {

        
        private User _user;
        private IVoteService _voteService;
        

        /// <summary>
        ///  Create the main form wuth the user
        /// </summary>
        /// <param name="user"></param>
        public frmMain(User user)
        {
            _user = user;

            // Create required services
            _voteService = new VoteService(Program.DBConnectionString);

            InitializeComponent();

            InitForm();
        }

        /// <summary>
        /// Initialise the form
        /// </summary>
        protected void InitForm()
        {

            //Sets up the vote events
            initVoteEvents();

            // Authorize the views of the main form based on the user role
            if ( _user.UserRole == UserRoleType.Admin)
            {
                SetUpAdminUser();
            }
            if (_user.UserRole == UserRoleType.Voter)
            {
                SetUpVoteUser();
            }
            if (_user.UserRole == UserRoleType.Audit)
            {
                SetUpAuditorUser();
            }

            lblUserName.Text = $"Welcome {_user.FirstName} {_user.LastName}";        
        }

        /// <summary>
        /// Init vote events
        /// </summary>
        protected void initVoteEvents()
        {
            //Clears any previous items
            cboVoteEvents.Items.Clear();

            //Sets up the vote events
            var voteEvents = _voteService.GetVoteEvents();
            foreach (var voteEvent in voteEvents)
                cboVoteEvents.Items.Add(voteEvent);

            if (voteEvents.Count > 0)
                cboVoteEvents.SelectedIndex = 0;
        }

        //Sets up the main form if the a voter is logged in, by getting rid of the admin and auditor pages.
        // Also adds the first voting events and populates the candidates in the select candidate combobox
        private void SetUpVoteUser()
        {
            tabUserRole.TabPages.Remove(tabAdmin);
            tabUserRole.TabPages.Remove(tabAuditor);
            btnAddVoteEvent.Visible = false;

            if (cboVoteEvents.SelectedItem == null)
                return;

            VoteEvent voteEvent = (VoteEvent)cboVoteEvents.SelectedItem;
            var candidates = _voteService.GetCandidates(voteEvent.VoteEventId);

            foreach (var candidate in candidates)
                cboVoteCandidate.Items.Add(candidate);

        }

        //Sets up the admin user by getting rid of the voting and auditor tabs and also adds the add event button
        //TODO: make the admin able to use the add event button.
        private void SetUpAdminUser()
        {
            tabUserRole.TabPages.Remove(tabVoter);
            tabUserRole.TabPages.Remove(tabAuditor);
            btnAddVoteEvent.Visible = true;
            VoteEvent voteEvent = (VoteEvent)cboVoteEvents.SelectedItem;
            List<CandidateVotes> candidateVotes = _voteService.GetCandidateVotes(voteEvent.VoteEventId);
        }

        //Sets up the auditor by removing the voting and admin tabs
        //added grid to display the amount of votes for each candidate depending on what vote event in which you have decided to count votes for
        private void SetUpAuditorUser()
        {
            tabUserRole.TabPages.Remove(tabVoter);
            tabUserRole.TabPages.Remove(tabAdmin);
            btnAddVoteEvent.Visible = false;

            //Get the votes for each candidate for the vote event
            VoteEvent voteEvent = (VoteEvent)cboVoteEvents.SelectedItem;
            List<CandidateVotes> candidateVotes = _voteService.GetCandidateVotes(voteEvent.VoteEventId);
            
            foreach (var candidateVote in candidateVotes)
                lstCandidates.Items.Add(candidateVote.ToString());
        }

        //When this button is clicked it will check to see if the person logged in has already voted and if there is something in the voting combobox
        //if they haven't voted and selected someone the system will log their vote into the database table
        private void btnVote_Click(object sender, EventArgs e)
        {
            VoteEvent voteEvent = (VoteEvent)cboVoteEvents.SelectedItem;
            if (_voteService.CanVote(voteEvent.VoteEventId, _user.UserId) == false)
            {
                MessageBox.Show("Already Voted");
                return;
            }

            if (cboVoteCandidate.SelectedItem == null)
            {
                MessageBox.Show("Please select a candidate");
                return;
            }

            Candidate candidate = (Candidate)cboVoteCandidate.SelectedItem;
            _voteService.LogVote(voteEvent.VoteEventId, _user.UserId, candidate.CandidateId);

            MessageBox.Show("Thank you for Voting");

            cboVoteCandidate.SelectedItem = null ;
        }

        //If Log out label clicked then it will take you back to the Login page
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin Login = new frmLogin();
            Login.Show();
            Visible = false;
             
        }

        //This will make it so a user who has already voted 
        private void btnRevokeVote_Click(object sender, EventArgs e)
        {
            VoteEvent voteEvent = (VoteEvent)cboVoteEvents.SelectedItem;
            if (_voteService.CanVote(voteEvent.VoteEventId, _user.UserId) == true)
            {
                MessageBox.Show("You have not Voted for anybody yet.");
                return;
            }

            _voteService.RevokeVote(voteEvent.VoteEventId, _user.UserId);
            MessageBox.Show("Vote successfully cancelled");
        }

        private void btnAddVoteEvent_Click(object sender, EventArgs e)
        {
            //Add vote event form
            frmVoteEvent VoteEvent = new frmVoteEvent(_voteService);
            VoteEvent.ShowDialog();

            //Refeshing vote events
            initVoteEvents();
        }
    }
}
