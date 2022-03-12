using OOPCourseWorkAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OOPCourseWorkApp
{
    public partial class VoteControl : UserControl
    {
        private  IVoteService _voteService;
        private VoteEvent _currentVoteEvent;
        private long _currentUserId;
        private List<Candidate> _currentCandidates;

        public VoteControl()
        {

            InitializeComponent();
            pnlVote.Visible = false;
            pnlRevoke.Visible = false;
        }

        public void Init(IVoteService voteService, VoteEvent currentVoteEvent, long currentUserId, List<Candidate> currentCandidates)
        {
            _voteService = voteService;
            _currentVoteEvent = currentVoteEvent;
            _currentUserId = currentUserId;
            _currentCandidates = currentCandidates;
            InitView();
        }
        protected void InitView()
        { 
            // Make sure UI update on the correct thread
            if( this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(InitView));
                return;
            }

            if (_voteService.CanVote(_currentVoteEvent.VoteEventId, _currentUserId) == true)
            {
                pnlVote.Visible = true;
                pnlRevoke.Visible = false;

                //add the vote event candidates
                cboVoteCandidate.Items.Clear();                           
                foreach (var candidate in _currentCandidates)
                    cboVoteCandidate.Items.Add(candidate);
            }
            else
            {
                pnlVote.Visible = false;
                pnlRevoke.Visible = true;

                // set the voted candidate name
                var voted = _voteService.GetVote(_currentVoteEvent.VoteEventId, _currentUserId);
                if (voted != null)
                    lblVotedCandidate.Text = _currentCandidates.Where(c => c.CandidateId == voted.CandidateId).FirstOrDefault().CandidateName;

                else
                    lblVotedCandidate.Text = "Unknown";            
            }

            this.Refresh();
        }


        private void btnVote_Click(object sender, EventArgs e)
        {

            if (cboVoteCandidate.SelectedItem == null)
            {
                    MessageBox.Show("Please select a candidate");
                    return;
            }

            Candidate candidate = (Candidate)cboVoteCandidate.SelectedItem;
            _voteService.LogVote(_currentVoteEvent.VoteEventId, _currentUserId, candidate.CandidateId);

            MessageBox.Show("Thank you for Voting");

            InitView();
            
        }

        private void btnRevokeVote_Click(object sender, EventArgs e)
        {
            //check voted
            if (_voteService.CanVote(_currentVoteEvent.VoteEventId, _currentUserId) == true)
            {
                MessageBox.Show("You have not Voted for anybody yet.");
                return;
            }

            //Revoking the vote
            _voteService.RevokeVote(_currentVoteEvent.VoteEventId, _currentUserId);
            MessageBox.Show("Vote successfully cancelled");
            InitView();
        }
    }
}
