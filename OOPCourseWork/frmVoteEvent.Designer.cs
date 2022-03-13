
namespace OOPCourseWorkApp
{
    partial class frmVoteEvent
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtVoteEvent = new System.Windows.Forms.TextBox();
            this.btnAddVoteEvent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Vote Event Name";
            // 
            // txtVoteEvent
            // 
            this.txtVoteEvent.Location = new System.Drawing.Point(145, 15);
            this.txtVoteEvent.Name = "txtVoteEvent";
            this.txtVoteEvent.Size = new System.Drawing.Size(165, 23);
            this.txtVoteEvent.TabIndex = 1;
            // 
            // btnAddVoteEvent
            // 
            this.btnAddVoteEvent.Location = new System.Drawing.Point(145, 56);
            this.btnAddVoteEvent.Name = "btnAddVoteEvent";
            this.btnAddVoteEvent.Size = new System.Drawing.Size(165, 35);
            this.btnAddVoteEvent.TabIndex = 2;
            this.btnAddVoteEvent.Text = "Add Vote Event";
            this.btnAddVoteEvent.UseVisualStyleBackColor = true;
            this.btnAddVoteEvent.Click += new System.EventHandler(this.btnAddVoteEvent_Click);
            // 
            // frmVoteEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 107);
            this.Controls.Add(this.btnAddVoteEvent);
            this.Controls.Add(this.txtVoteEvent);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmVoteEvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmVoteEvent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVoteEvent;
        private System.Windows.Forms.Button btnAddVoteEvent;
    }
}