
namespace OOPCourseWork
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLogIn = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.llbLastName = new System.Windows.Forms.Label();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.lblLRegister = new System.Windows.Forms.LinkLabel();
            this.pnlRegister = new System.Windows.Forms.Panel();
            this.lblLLongin = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRUser = new System.Windows.Forms.TextBox();
            this.txtRPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLogin.SuspendLayout();
            this.pnlRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLogIn
            // 
            this.lblLogIn.AutoSize = true;
            this.lblLogIn.Location = new System.Drawing.Point(16, 19);
            this.lblLogIn.Name = "lblLogIn";
            this.lblLogIn.Size = new System.Drawing.Size(40, 15);
            this.lblLogIn.TabIndex = 0;
            this.lblLogIn.Text = "Log In";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(19, 143);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(64, 15);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "First Name";
            // 
            // llbLastName
            // 
            this.llbLastName.AutoSize = true;
            this.llbLastName.Location = new System.Drawing.Point(19, 180);
            this.llbLastName.Name = "llbLastName";
            this.llbLastName.Size = new System.Drawing.Size(63, 15);
            this.llbLastName.TabIndex = 2;
            this.llbLastName.Text = "Last Name";
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(80, 143);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(100, 40);
            this.btnLogIn.TabIndex = 3;
            this.btnLogIn.Text = "Log In";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(99, 208);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(100, 41);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(16, 69);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(65, 15);
            this.lblUserName.TabIndex = 5;
            this.lblUserName.Text = "User Name";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(16, 106);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(57, 15);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(99, 143);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 23);
            this.txtFirstName.TabIndex = 8;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(99, 177);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 23);
            this.txtLastName.TabIndex = 9;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(80, 69);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 23);
            this.txtUserName.TabIndex = 10;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(80, 103);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 23);
            this.txtPassword.TabIndex = 11;
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.lblLRegister);
            this.pnlLogin.Controls.Add(this.lblLogIn);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.txtUserName);
            this.pnlLogin.Controls.Add(this.lblPassword);
            this.pnlLogin.Controls.Add(this.btnLogIn);
            this.pnlLogin.Controls.Add(this.lblUserName);
            this.pnlLogin.Location = new System.Drawing.Point(12, 12);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(274, 304);
            this.pnlLogin.TabIndex = 12;
            // 
            // lblLRegister
            // 
            this.lblLRegister.AutoSize = true;
            this.lblLRegister.Location = new System.Drawing.Point(107, 186);
            this.lblLRegister.Name = "lblLRegister";
            this.lblLRegister.Size = new System.Drawing.Size(49, 15);
            this.lblLRegister.TabIndex = 12;
            this.lblLRegister.TabStop = true;
            this.lblLRegister.Text = "Register";
            this.lblLRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLRegister_LinkClicked);
            // 
            // pnlRegister
            // 
            this.pnlRegister.Controls.Add(this.lblLLongin);
            this.pnlRegister.Controls.Add(this.label3);
            this.pnlRegister.Controls.Add(this.label2);
            this.pnlRegister.Controls.Add(this.txtRUser);
            this.pnlRegister.Controls.Add(this.txtRPassword);
            this.pnlRegister.Controls.Add(this.label1);
            this.pnlRegister.Controls.Add(this.lblFirstName);
            this.pnlRegister.Controls.Add(this.btnRegister);
            this.pnlRegister.Controls.Add(this.txtLastName);
            this.pnlRegister.Controls.Add(this.llbLastName);
            this.pnlRegister.Controls.Add(this.txtFirstName);
            this.pnlRegister.Location = new System.Drawing.Point(12, 12);
            this.pnlRegister.Name = "pnlRegister";
            this.pnlRegister.Size = new System.Drawing.Size(274, 304);
            this.pnlRegister.TabIndex = 13;
            // 
            // lblLLongin
            // 
            this.lblLLongin.AutoSize = true;
            this.lblLLongin.Location = new System.Drawing.Point(121, 252);
            this.lblLLongin.Name = "lblLLongin";
            this.lblLLongin.Size = new System.Drawing.Size(40, 15);
            this.lblLLongin.TabIndex = 14;
            this.lblLLongin.TabStop = true;
            this.lblLLongin.Text = "Log In";
            this.lblLLongin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLLongin_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Password";
            // 
            // txtRUser
            // 
            this.txtRUser.Location = new System.Drawing.Point(99, 85);
            this.txtRUser.Name = "txtRUser";
            this.txtRUser.Size = new System.Drawing.Size(100, 23);
            this.txtRUser.TabIndex = 11;
            // 
            // txtRPassword
            // 
            this.txtRPassword.Location = new System.Drawing.Point(99, 114);
            this.txtRPassword.Name = "txtRPassword";
            this.txtRPassword.PasswordChar = '*';
            this.txtRPassword.Size = new System.Drawing.Size(100, 23);
            this.txtRPassword.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Register";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 330);
            this.Controls.Add(this.pnlRegister);
            this.Controls.Add(this.pnlLogin);
            this.Name = "frmLogin";
            this.Text = "VotingSystem";
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlRegister.ResumeLayout(false);
            this.pnlRegister.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLogIn;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label llbLastName;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Panel pnlRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRUser;
        private System.Windows.Forms.TextBox txtRPassword;
        private System.Windows.Forms.LinkLabel lblLRegister;
        private System.Windows.Forms.LinkLabel lblLLongin;
    }
}

