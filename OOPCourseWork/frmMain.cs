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
            var voteEvents = _voteService.GetVoteEvents();
            foreach (var voteEvent in voteEvents)
                cboVoteEvents.Items.Add(voteEvent);

            if (voteEvents.Count > 0)
                cboVoteEvents.SelectedIndex = 0;

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
        private void SetUpAdminUser()
        {
            tabUserRole.TabPages.Remove(tabVoter);
            tabUserRole.TabPages.Remove(tabAuditor);
            btnAddVoteEvent.Visible = true;
        }
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
    }
}
