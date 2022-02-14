
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
            this.btnVote = new System.Windows.Forms.Button();
            this.lblCandidates = new System.Windows.Forms.Label();
            this.cboVoteCandidate = new System.Windows.Forms.ComboBox();
            this.tabAdmin = new System.Windows.Forms.TabPage();
            this.tabAuditor = new System.Windows.Forms.TabPage();
            this.lstCandidates = new System.Windows.Forms.ListView();
            this.colCandidateName = new System.Windows.Forms.ColumnHeader();
            this.lblUserName = new System.Windows.Forms.Label();
            this.cboVoteEvents = new System.Windows.Forms.ComboBox();
            this.btnAddVoteEvent = new System.Windows.Forms.Button();
            this.lblLogOut = new System.Windows.Forms.LinkLabel();
            this.tabUserRole.SuspendLayout();
            this.tabVoter.SuspendLayout();
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
            this.tabUserRole.Size = new System.Drawing.Size(491, 238);
            this.tabUserRole.TabIndex = 0;
            // 
            // tabVoter
            // 
            this.tabVoter.Controls.Add(this.btnVote);
            this.tabVoter.Controls.Add(this.lblCandidates);
            this.tabVoter.Controls.Add(this.cboVoteCandidate);
            this.tabVoter.Location = new System.Drawing.Point(4, 24);
            this.tabVoter.Name = "tabVoter";
            this.tabVoter.Padding = new System.Windows.Forms.Padding(3);
            this.tabVoter.Size = new System.Drawing.Size(483, 210);
            this.tabVoter.TabIndex = 0;
            this.tabVoter.Text = "Voter";
            this.tabVoter.UseVisualStyleBackColor = true;
            // 
            // btnVote
            // 
            this.btnVote.Location = new System.Drawing.Point(124, 50);
            this.btnVote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVote.Name = "btnVote";
            this.btnVote.Size = new System.Drawing.Size(206, 47);
            this.btnVote.TabIndex = 2;
            this.btnVote.Text = "Vote";
            this.btnVote.UseVisualStyleBackColor = true;
            this.btnVote.Click += new System.EventHandler(this.btnVote_Click);
            // 
            // lblCandidates
            // 
            this.lblCandidates.AutoSize = true;
            this.lblCandidates.Location = new System.Drawing.Point(13, 15);
            this.lblCandidates.Name = "lblCandidates";
            this.lblCandidates.Size = new System.Drawing.Size(95, 15);
            this.lblCandidates.TabIndex = 1;
            this.lblCandidates.Text = "Select Candidate";
            // 
            // cboVoteCandidate
            // 
            this.cboVoteCandidate.FormattingEnabled = true;
            this.cboVoteCandidate.Location = new System.Drawing.Point(124, 15);
            this.cboVoteCandidate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboVoteCandidate.Name = "cboVoteCandidate";
            this.cboVoteCandidate.Size = new System.Drawing.Size(206, 23);
            this.cboVoteCandidate.TabIndex = 0;
            // 
            // tabAdmin
            // 
            this.tabAdmin.Location = new System.Drawing.Point(4, 24);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdmin.Size = new System.Drawing.Size(483, 210);
            this.tabAdmin.TabIndex = 1;
            this.tabAdmin.Text = "Admin";
            this.tabAdmin.UseVisualStyleBackColor = true;
            // 
            // tabAuditor
            // 
            this.tabAuditor.Controls.Add(this.lstCandidates);
            this.tabAuditor.Location = new System.Drawing.Point(4, 24);
            this.tabAuditor.Name = "tabAuditor";
            this.tabAuditor.Padding = new System.Windows.Forms.Padding(3);
            this.tabAuditor.Size = new System.Drawing.Size(483, 210);
            this.tabAuditor.TabIndex = 2;
            this.tabAuditor.Text = "Auditor";
            this.tabAuditor.UseVisualStyleBackColor = true;
            // 
            // lstCandidates
            // 
            this.lstCandidates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCandidateName});
            this.lstCandidates.HideSelection = false;
            this.lstCandidates.Location = new System.Drawing.Point(3, 6);
            this.lstCandidates.Name = "lstCandidates";
            this.lstCandidates.Size = new System.Drawing.Size(474, 198);
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
            this.lblUserName.Location = new System.Drawing.Point(345, 15);
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
            // 
            // btnAddVoteEvent
            // 
            this.btnAddVoteEvent.Location = new System.Drawing.Point(261, 10);
            this.btnAddVoteEvent.Name = "btnAddVoteEvent";
            this.btnAddVoteEvent.Size = new System.Drawing.Size(31, 24);
            this.btnAddVoteEvent.TabIndex = 3;
            this.btnAddVoteEvent.Text = "+";
            this.btnAddVoteEvent.UseVisualStyleBackColor = true;
            // 
            // lblLogOut
            // 
            this.lblLogOut.AutoSize = true;
            this.lblLogOut.Location = new System.Drawing.Point(437, 40);
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
            this.ClientSize = new System.Drawing.Size(517, 287);
            this.Controls.Add(this.lblLogOut);
            this.Controls.Add(this.btnAddVoteEvent);
            this.Controls.Add(this.cboVoteEvents);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.tabUserRole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Voting System";
            this.tabUserRole.ResumeLayout(false);
            this.tabVoter.ResumeLayout(false);
            this.tabVoter.PerformLayout();
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
        private System.Windows.Forms.Button btnVote;
        private System.Windows.Forms.Label lblCandidates;
        private System.Windows.Forms.ComboBox cboVoteCandidate;
        private System.Windows.Forms.ListView lstCandidates;
        private System.Windows.Forms.ColumnHeader colCandidateName;
        private System.Windows.Forms.LinkLabel lblLogOut;
    }
}