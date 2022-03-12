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
    public partial class frmVoteEvent : Form
    {
        protected IVoteService _voteService;

        public frmVoteEvent(IVoteService voteService)
        {
            _voteService = voteService;
            InitializeComponent();
        }

        private void btnAddVoteEvent_Click(object sender, EventArgs e)
        {
            //Making sure that there is something in the text box
            if (string.IsNullOrEmpty(txtVoteEvent.Text))
                MessageBox.Show("please enter a name for this vote event");

            //Adding vote event name to database            
           var voteEvent = _voteService.CreateVoteEvent(txtVoteEvent.Text);

            //Checking the result
            if (voteEvent != null)
            {
                MessageBox.Show("Successfully added vote event");
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Failed to add vote event please try again");
                txtVoteEvent.Text = string.Empty;
            }
            
        }
    }
}
