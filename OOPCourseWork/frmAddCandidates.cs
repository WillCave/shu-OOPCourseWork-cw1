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
    public partial class frmAddCandidates : Form
    {
        protected IVoteService _voteService;
        protected VoteEvent _voteEvent;
        protected List<Candidate> _currentCandidates;

        public frmAddCandidates(IVoteService voteService, VoteEvent voteEvent, List<Candidate> currentCandidates)
        {
            _voteService = voteService;
            _voteEvent = voteEvent;
            _currentCandidates = currentCandidates;
            InitializeComponent();
        }

        private void btnAddCandidate_Click(object sender, EventArgs e)
        {
            //Making sure that something has been entered into the textbox
            if (String.IsNullOrEmpty(txtAddCandidates.Text))
            {
                MessageBox.Show("Please enter a name for this candidate");
                return;
            }

            //Make sure that candidate does not exist
            bool alreadyExists = _currentCandidates.Any(c => c.CandidateName.CompareTo(txtAddCandidates.Text) == 0 );
            if (alreadyExists == true)
            {
                MessageBox.Show("Candidate name has already been entered");
                return;
            }

            //add candidate
            var addCandidate = _voteService.AddCandidate(_voteEvent.VoteEventId, txtAddCandidates.Text);
            if(addCandidate != null)
            {
                MessageBox.Show("Successfully added candidate");
                this.Close();
            }
            else
            {
                MessageBox.Show("There has been a error please try again");
                txtAddCandidates.Text = string.Empty;
            }
        }
    }
}
