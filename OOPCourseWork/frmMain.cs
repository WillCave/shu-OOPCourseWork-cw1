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
using System.Linq;

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
            // Check we have vote events
            if (_currentVoteEvent == null)
                return;

            //Get the candidates for specific vote event            
            _currentCandidates = _voteService.GetCandidates(_currentVoteEvent.VoteEventId);

            //init candidate votes for auditor
            lstCandidates.Items.Clear();
            List<CandidateVotes> candidateVotes = _voteService.GetCandidateVotes(_currentVoteEvent.VoteEventId);
            foreach (var candidateVote in candidateVotes)
                lstCandidates.Items.Add(candidateVote.ToString());

            //init candidates for admin
           lstAdminCandidates.Items.Clear();
            foreach (var candidate in _currentCandidates)
                lstAdminCandidates.Items.Add(candidate.ToString());

            //init the vote control for voters
            ctlVoteControl.Init(_voteService, _currentVoteEvent, _user.UserId, _currentCandidates);
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

        /// <summary>
        /// Called when Adding candidate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCandidate_Click(object sender, EventArgs e)
        {
            //Add candidates form
            frmAddCandidates addCandidates = new frmAddCandidates(_voteService, _currentVoteEvent, _currentCandidates);
            addCandidates.ShowDialog();

            //Refresh Candidates list
            initCandidates();
        }

        /// <summary>
        /// Clled when deleting candidate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteCandidate_Click(object sender, EventArgs e)
        {
            // Check we have a vote event
            if (_currentVoteEvent == null)
            {
                MessageBox.Show("Please select a vote event");
                return;
            }

            //Find the candidate name selected
            var candidateName = lstAdminCandidates.SelectedItems.Count > 0 ? lstAdminCandidates.SelectedItems[0].Text : null;
            if(candidateName == null)
            {
                MessageBox.Show("Please select a candidate to delete");
                return;
            }

            //Get the candidate object from the name
            var candidate = _currentCandidates.Where(c => c.CandidateName == candidateName).FirstOrDefault();
            if(candidate == null)
            {
                MessageBox.Show("Could not find candidate to delete");
                return;
            }

            //check if we can delete
            if(_voteService.CanDeleteCandidate(_currentVoteEvent.VoteEventId, candidate.CandidateId) == false)
            {
                MessageBox.Show("Candidate has exising votes. Can not delete");
                return;
            }

            //Delete Candidate
            if (_voteService.DeleteCandidate(_currentVoteEvent.VoteEventId, candidate.CandidateId) == true)
            {
                MessageBox.Show("Deleted candidate");
                initCandidates();
                return;
            }
            else
            {
                MessageBox.Show("Failed to delete candidate");
                return;
            }
        }

        /// <summary>
        /// Close the application on closing this form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // TODO: Add are you sure you want to exit
            Application.Exit();
        }
    }
}
