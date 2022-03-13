
namespace OOPCourseWorkApp
{
    partial class frmManualVote
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
            this.pnlManualRegister = new System.Windows.Forms.Panel();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.ctlManualVoteControl = new OOPCourseWorkApp.VoteControl();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlManualRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlManualRegister
            // 
            this.pnlManualRegister.Controls.Add(this.dtpDob);
            this.pnlManualRegister.Controls.Add(this.label4);
            this.pnlManualRegister.Controls.Add(this.txtLastName);
            this.pnlManualRegister.Controls.Add(this.txtFirstName);
            this.pnlManualRegister.Controls.Add(this.label3);
            this.pnlManualRegister.Controls.Add(this.label2);
            this.pnlManualRegister.Controls.Add(this.label1);
            this.pnlManualRegister.Controls.Add(this.btnNext);
            this.pnlManualRegister.Location = new System.Drawing.Point(7, 9);
            this.pnlManualRegister.Name = "pnlManualRegister";
            this.pnlManualRegister.Size = new System.Drawing.Size(269, 172);
            this.pnlManualRegister.TabIndex = 0;
            // 
            // dtpDob
            // 
            this.dtpDob.Location = new System.Drawing.Point(98, 114);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(141, 23);
            this.dtpDob.TabIndex = 9;
            this.dtpDob.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            // 
            // ctlManualVoteControl
            // 
            this.ctlManualVoteControl.Location = new System.Drawing.Point(282, 12);
            this.ctlManualVoteControl.Name = "ctlManualVoteControl";
            this.ctlManualVoteControl.Size = new System.Drawing.Size(359, 172);
            this.ctlManualVoteControl.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date Of Birth";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(98, 79);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 23);
            this.txtLastName.TabIndex = 5;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(98, 43);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 23);
            this.txtFirstName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Last Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "First Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Manual Vote";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(191, 146);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // frmManualVote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 197);
            this.Controls.Add(this.pnlManualRegister);
            this.Controls.Add(this.ctlManualVoteControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManualVote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Manual Vote";
            this.pnlManualRegister.ResumeLayout(false);
            this.pnlManualRegister.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlManualRegister;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNext;
        private VoteControl ctlManualVoteControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDob;
    }
}