
namespace OOPCourseWorkApp
{
    partial class VoteControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlVote = new System.Windows.Forms.Panel();
            this.btnVote = new System.Windows.Forms.Button();
            this.lblCandidates = new System.Windows.Forms.Label();
            this.cboVoteCandidate = new System.Windows.Forms.ComboBox();
            this.pnlRevoke = new System.Windows.Forms.Panel();
            this.btnRevokeVote = new System.Windows.Forms.Button();
            this.lblVotedCandidate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlVote.SuspendLayout();
            this.pnlRevoke.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlVote
            // 
            this.pnlVote.Controls.Add(this.btnVote);
            this.pnlVote.Controls.Add(this.lblCandidates);
            this.pnlVote.Controls.Add(this.cboVoteCandidate);
            this.pnlVote.Location = new System.Drawing.Point(4, 4);
            this.pnlVote.Name = "pnlVote";
            this.pnlVote.Size = new System.Drawing.Size(350, 159);
            this.pnlVote.TabIndex = 0;
            // 
            // btnVote
            // 
            this.btnVote.Location = new System.Drawing.Point(114, 76);
            this.btnVote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVote.Name = "btnVote";
            this.btnVote.Size = new System.Drawing.Size(206, 47);
            this.btnVote.TabIndex = 5;
            this.btnVote.Text = "Vote";
            this.btnVote.UseVisualStyleBackColor = true;
            this.btnVote.Click += new System.EventHandler(this.btnVote_Click);
            // 
            // lblCandidates
            // 
            this.lblCandidates.AutoSize = true;
            this.lblCandidates.Location = new System.Drawing.Point(3, 37);
            this.lblCandidates.Name = "lblCandidates";
            this.lblCandidates.Size = new System.Drawing.Size(95, 15);
            this.lblCandidates.TabIndex = 4;
            this.lblCandidates.Text = "Select Candidate";
            // 
            // cboVoteCandidate
            // 
            this.cboVoteCandidate.FormattingEnabled = true;
            this.cboVoteCandidate.Location = new System.Drawing.Point(114, 37);
            this.cboVoteCandidate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboVoteCandidate.Name = "cboVoteCandidate";
            this.cboVoteCandidate.Size = new System.Drawing.Size(206, 23);
            this.cboVoteCandidate.TabIndex = 3;
            // 
            // pnlRevoke
            // 
            this.pnlRevoke.Controls.Add(this.btnRevokeVote);
            this.pnlRevoke.Controls.Add(this.lblVotedCandidate);
            this.pnlRevoke.Controls.Add(this.label1);
            this.pnlRevoke.Location = new System.Drawing.Point(3, 3);
            this.pnlRevoke.Name = "pnlRevoke";
            this.pnlRevoke.Size = new System.Drawing.Size(350, 159);
            this.pnlRevoke.TabIndex = 1;
            // 
            // btnRevokeVote
            // 
            this.btnRevokeVote.Location = new System.Drawing.Point(111, 63);
            this.btnRevokeVote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRevokeVote.Name = "btnRevokeVote";
            this.btnRevokeVote.Size = new System.Drawing.Size(206, 47);
            this.btnRevokeVote.TabIndex = 10;
            this.btnRevokeVote.Text = "Revoke Vote";
            this.btnRevokeVote.UseVisualStyleBackColor = true;
            this.btnRevokeVote.Click += new System.EventHandler(this.btnRevokeVote_Click);
            // 
            // lblVotedCandidate
            // 
            this.lblVotedCandidate.AutoSize = true;
            this.lblVotedCandidate.Location = new System.Drawing.Point(151, 19);
            this.lblVotedCandidate.Name = "lblVotedCandidate";
            this.lblVotedCandidate.Size = new System.Drawing.Size(107, 15);
            this.lblVotedCandidate.TabIndex = 9;
            this.lblVotedCandidate.Text = "CANDIDATE NAME";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Voted Candidate";
            // 
            // VoteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlRevoke);
            this.Controls.Add(this.pnlVote);
            this.Name = "VoteControl";
            this.Size = new System.Drawing.Size(359, 172);
            this.pnlVote.ResumeLayout(false);
            this.pnlVote.PerformLayout();
            this.pnlRevoke.ResumeLayout(false);
            this.pnlRevoke.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlVote;
        private System.Windows.Forms.Panel pnlRevoke;
        private System.Windows.Forms.Button btnVote;
        private System.Windows.Forms.Label lblCandidates;
        private System.Windows.Forms.ComboBox cboVoteCandidate;
        private System.Windows.Forms.Button btnRevokeVote;
        private System.Windows.Forms.Label lblVotedCandidate;
        private System.Windows.Forms.Label label1;
    }
}
