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
    public partial class frmAddCandidates : Form
    {
        protected IVoteService _voteService;
        protected VoteEvent _voteEvent;

        public frmAddCandidates(IVoteService voteService, VoteEvent voteEvent)
        {
            _voteService = voteService;
            _voteEvent = voteEvent;
            InitializeComponent();
        }

        private void btnAddCandidate_Click(object sender, EventArgs e)
        {
            //Making sure that something has been entered into the textbox
            if (String.IsNullOrEmpty(txtAddCandidates.Text))
                MessageBox.Show("Please enter a name for this candidate");

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
