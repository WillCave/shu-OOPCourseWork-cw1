﻿using System;
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
        private VoteEvent _currentVoteEvent;
        private List<Candidate> _currentCandidates;        

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

        /// <summary>
        /// inits candidates
        /// </summary>
        private void initCandidates()
        {
            //Get the candidates for specific vote event            
            _currentCandidates = _voteService.GetCandidates(_currentVoteEvent.VoteEventId);

            //add the vote event candidates
            cboVoteCandidate.Items.Clear();
            foreach (var candidate in _currentCandidates)
                cboVoteCandidate.Items.Add(candidate);

            //init candidate votes for auditor
            lstCandidates.Items.Clear();
            List<CandidateVotes> candidateVotes = _voteService.GetCandidateVotes(_currentVoteEvent.VoteEventId);
            foreach (var candidateVote in candidateVotes)
                lstCandidates.Items.Add(candidateVote.ToString());

            //init candidates for admin
           lstAdminCandidates.Items.Clear();
            foreach (var candidate in _currentCandidates)
                lstAdminCandidates.Items.Add(candidate.ToString());
        }

        /// <summary>
        /// sets up voting user
        /// </summary>
        private void SetUpVoteUser()
        {
            tabUserRole.TabPages.Remove(tabAdmin);
            tabUserRole.TabPages.Remove(tabAuditor);
            btnAddVoteEvent.Visible = false;

            if (cboVoteEvents.SelectedItem == null)
                return;

            initCandidates();
        }

        /// <summary>
        /// sets up admin user
        /// </summary>
        private void SetUpAdminUser()
        {
            tabUserRole.TabPages.Remove(tabVoter);
            tabUserRole.TabPages.Remove(tabAuditor);
            btnAddVoteEvent.Visible = true;
            VoteEvent voteEvent = (VoteEvent)cboVoteEvents.SelectedItem;
            List<CandidateVotes> candidateVotes = _voteService.GetCandidateVotes(voteEvent.VoteEventId);
        }

        /// <summary>
        /// sets up aditor user
        /// </summary>
        private void SetUpAuditorUser()
        {
            tabUserRole.TabPages.Remove(tabVoter);
            tabUserRole.TabPages.Remove(tabAdmin);
            btnAddVoteEvent.Visible = false;

            initCandidates();
        }

        /// <summary>
        /// Called when user wants to vote
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

       /// <summary>
       /// Called when user wants to log out
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin Login = new frmLogin();
            Login.Show();
            Visible = false;
             
        }

        /// <summary>
        /// Called when revoke vote is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Called when vote events is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboVoteEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Store the current vote event
            _currentVoteEvent = (VoteEvent)cboVoteEvents.SelectedItem;

            //Init new candidates for the changed vote event
            initCandidates();
        }

        /// <summary>
        /// called when add vote event is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddVoteEvent_Click(object sender, EventArgs e)
        {
            //Add vote event form
            frmVoteEvent VoteEvent = new frmVoteEvent(_voteService);
            VoteEvent.ShowDialog();

            //Refeshing vote events
            initVoteEvents();
        }

        private void btnAddCandidate_Click(object sender, EventArgs e)
        {
            //Add candidates form
            frmAddCandidates addCandidates = new frmAddCandidates(_voteService, _currentVoteEvent, _currentCandidates);
            addCandidates.ShowDialog();

            //Refresh Candidates list
            initCandidates();
        }
    }
}
