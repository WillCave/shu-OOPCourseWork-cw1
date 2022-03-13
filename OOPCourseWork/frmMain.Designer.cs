
namespace OOPCourseWorkApp
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabUserRole = new System.Windows.Forms.TabControl();
            this.tabVoter = new System.Windows.Forms.TabPage();
            this.ctlVoteControl = new OOPCourseWorkApp.VoteControl();
            this.tabAdmin = new System.Windows.Forms.TabPage();
            this.btnAddCandidate = new System.Windows.Forms.Button();
            this.btnDeleteCandidate = new System.Windows.Forms.Button();
            this.lstAdminCandidates = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.tabAuditor = new System.Windows.Forms.TabPage();
            this.btnAddVote = new System.Windows.Forms.Button();
            this.lstCandidates = new System.Windows.Forms.ListView();
            this.colCandidateName = new System.Windows.Forms.ColumnHeader();
            this.lblUserName = new System.Windows.Forms.Label();
            this.cboVoteEvents = new System.Windows.Forms.ComboBox();
            this.btnAddVoteEvent = new System.Windows.Forms.Button();
            this.lblLogOut = new System.Windows.Forms.LinkLabel();
            this.tabUserRole.SuspendLayout();
            this.tabVoter.SuspendLayout();
            this.tabAdmin.SuspendLayout();
            this.tabAuditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabUserRole
            // 
            this.tabUserRole.Controls.Add(this.tabVoter);
            this.tabUserRole.Controls.Add(this.tabAdmin);
            this.tabUserRole.Controls.Add(this.tabAuditor);
            this.tabUserRole.Location = new System.Drawing.Point(10, 40);
            this.tabUserRole.Name = "tabUserRole";
            this.tabUserRole.SelectedIndex = 0;
            this.tabUserRole.Size = new System.Drawing.Size(521, 259);
            this.tabUserRole.TabIndex = 0;
            // 
            // tabVoter
            // 
            this.tabVoter.Controls.Add(this.ctlVoteControl);
            this.tabVoter.Location = new System.Drawing.Point(4, 24);
            this.tabVoter.Name = "tabVoter";
            this.tabVoter.Padding = new System.Windows.Forms.Padding(3);
            this.tabVoter.Size = new System.Drawing.Size(513, 231);
            this.tabVoter.TabIndex = 0;
            this.tabVoter.Text = "Voter";
            this.tabVoter.UseVisualStyleBackColor = true;
            // 
            // ctlVoteControl
            // 
            this.ctlVoteControl.Location = new System.Drawing.Point(4, 7);
            this.ctlVoteControl.Name = "ctlVoteControl";
            this.ctlVoteControl.Size = new System.Drawing.Size(444, 218);
            this.ctlVoteControl.TabIndex = 0;
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.btnAddCandidate);
            this.tabAdmin.Controls.Add(this.btnDeleteCandidate);
            this.tabAdmin.Controls.Add(this.lstAdminCandidates);
            this.tabAdmin.Location = new System.Drawing.Point(4, 24);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdmin.Size = new System.Drawing.Size(513, 231);
            this.tabAdmin.TabIndex = 1;
            this.tabAdmin.Text = "Admin";
            this.tabAdmin.UseVisualStyleBackColor = true;
            // 
            // btnAddCandidate
            // 
            this.btnAddCandidate.Location = new System.Drawing.Point(426, 193);
            this.btnAddCandidate.Name = "btnAddCandidate";
            this.btnAddCandidate.Size = new System.Drawing.Size(81, 23);
            this.btnAddCandidate.TabIndex = 3;
            this.btnAddCandidate.Text = "Add";
            this.btnAddCandidate.UseVisualStyleBackColor = true;
            this.btnAddCandidate.Click += new System.EventHandler(this.btnAddCandidate_Click);
            // 
            // btnDeleteCandidate
            // 
            this.btnDeleteCandidate.Location = new System.Drawing.Point(350, 193);
            this.btnDeleteCandidate.Name = "btnDeleteCandidate";
            this.btnDeleteCandidate.Size = new System.Drawing.Size(70, 23);
            this.btnDeleteCandidate.TabIndex = 2;
            this.btnDeleteCandidate.Text = "Delete";
            this.btnDeleteCandidate.UseVisualStyleBackColor = true;
            this.btnDeleteCandidate.Click += new System.EventHandler(this.btnDeleteCandidate_Click);
            // 
            // lstAdminCandidates
            // 
            this.lstAdminCandidates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstAdminCandidates.HideSelection = false;
            this.lstAdminCandidates.Location = new System.Drawing.Point(0, 3);
            this.lstAdminCandidates.MultiSelect = false;
            this.lstAdminCandidates.Name = "lstAdminCandidates";
            this.lstAdminCandidates.Size = new System.Drawing.Size(507, 184);
            this.lstAdminCandidates.TabIndex = 1;
            this.lstAdminCandidates.UseCompatibleStateImageBehavior = false;
            this.lstAdminCandidates.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "CandidateName";
            this.columnHeader1.Text = "Candidate";
            this.columnHeader1.Width = 200;
            // 
            // tabAuditor
            // 
            this.tabAuditor.Controls.Add(this.btnAddVote);
            this.tabAuditor.Controls.Add(this.lstCandidates);
            this.tabAuditor.Location = new System.Drawing.Point(4, 24);
            this.tabAuditor.Name = "tabAuditor";
            this.tabAuditor.Padding = new System.Windows.Forms.Padding(3);
            this.tabAuditor.Size = new System.Drawing.Size(513, 231);
            this.tabAuditor.TabIndex = 2;
            this.tabAuditor.Text = "Auditor";
            this.tabAuditor.UseVisualStyleBackColor = true;
            // 
            // btnAddVote
            // 
            this.btnAddVote.Location = new System.Drawing.Point(339, 205);
            this.btnAddVote.Name = "btnAddVote";
            this.btnAddVote.Size = new System.Drawing.Size(168, 26);
            this.btnAddVote.TabIndex = 1;
            this.btnAddVote.Text = "Add Manual Vote";
            this.btnAddVote.UseVisualStyleBackColor = true;
            this.btnAddVote.Click += new System.EventHandler(this.btnAddVote_Click);
            // 
            // lstCandidates
            // 
            this.lstCandidates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCandidateName});
            this.lstCandidates.HideSelection = false;
            this.lstCandidates.Location = new System.Drawing.Point(3, 6);
            this.lstCandidates.Name = "lstCandidates";
            this.lstCandidates.Size = new System.Drawing.Size(504, 198);
            this.lstCandidates.TabIndex = 0;
            this.lstCandidates.UseCompatibleStateImageBehavior = false;
            this.lstCandidates.View = System.Windows.Forms.View.Details;
            // 
            // colCandidateName
            // 
            this.colCandidateName.Tag = "CandidateName";
            this.colCandidateName.Text = "Candidate";
            this.colCandidateName.Width = 200;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(417, 18);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(38, 15);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "label1";
            // 
            // cboVoteEvents
            // 
            this.cboVoteEvents.FormattingEnabled = true;
            this.cboVoteEvents.Location = new System.Drawing.Point(10, 10);
            this.cboVoteEvents.Name = "cboVoteEvents";
            this.cboVoteEvents.Size = new System.Drawing.Size(246, 23);
            this.cboVoteEvents.TabIndex = 2;
            this.cboVoteEvents.SelectedIndexChanged += new System.EventHandler(this.cboVoteEvents_SelectedIndexChanged);
            // 
            // btnAddVoteEvent
            // 
            this.btnAddVoteEvent.Location = new System.Drawing.Point(261, 10);
            this.btnAddVoteEvent.Name = "btnAddVoteEvent";
            this.btnAddVoteEvent.Size = new System.Drawing.Size(31, 24);
            this.btnAddVoteEvent.TabIndex = 3;
            this.btnAddVoteEvent.Text = "+";
            this.btnAddVoteEvent.UseVisualStyleBackColor = true;
            this.btnAddVoteEvent.Click += new System.EventHandler(this.btnAddVoteEvent_Click);
            // 
            // lblLogOut
            // 
            this.lblLogOut.AutoSize = true;
            this.lblLogOut.Location = new System.Drawing.Point(476, 40);
            this.lblLogOut.Name = "lblLogOut";
            this.lblLogOut.Size = new System.Drawing.Size(50, 15);
            this.lblLogOut.TabIndex = 4;
            this.lblLogOut.TabStop = true;
            this.lblLogOut.Text = "Log Out";
            this.lblLogOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 311);
            this.Controls.Add(this.lblLogOut);
            this.Controls.Add(this.btnAddVoteEvent);
            this.Controls.Add(this.cboVoteEvents);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.tabUserRole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voting System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.tabUserRole.ResumeLayout(false);
            this.tabVoter.ResumeLayout(false);
            this.tabAdmin.ResumeLayout(false);
            this.tabAuditor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabUserRole;
        private System.Windows.Forms.TabPage tabVoter;
        private System.Windows.Forms.TabPage tabAdmin;
        private System.Windows.Forms.TabPage tabAuditor;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.ComboBox cboVoteEvents;
        private System.Windows.Forms.Button btnAddVoteEvent;
        private System.Windows.Forms.ListView lstCandidates;
        private System.Windows.Forms.ColumnHeader colCandidateName;
        private System.Windows.Forms.LinkLabel lblLogOut;
        private System.Windows.Forms.ListView lstAdminCandidates;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnAddCandidate;
        private System.Windows.Forms.Button btnDeleteCandidate;
        private VoteControl ctlVoteControl;
        private System.Windows.Forms.Button btnAddVote;
    }
}