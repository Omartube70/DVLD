namespace DVLDBussiensTier
{
    partial class AddEditUserInfo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditUserInfo));
            this.tabUserDetails = new System.Windows.Forms.TabControl();
            this.PersonalInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.personDetailsControl = new DVLDBussiensTier.ctrPersonCardWithFilters();
            this.LoginInfo = new System.Windows.Forms.TabPage();
            this.chbIsActive = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCurrentUserID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfirmUserPassword = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblAddNewPerson = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FormMode = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabUserDetails.SuspendLayout();
            this.PersonalInfo.SuspendLayout();
            this.LoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabUserDetails
            // 
            this.tabUserDetails.Controls.Add(this.PersonalInfo);
            this.tabUserDetails.Controls.Add(this.LoginInfo);
            this.tabUserDetails.Location = new System.Drawing.Point(12, 112);
            this.tabUserDetails.Name = "tabUserDetails";
            this.tabUserDetails.SelectedIndex = 0;
            this.tabUserDetails.Size = new System.Drawing.Size(1172, 632);
            this.tabUserDetails.TabIndex = 0;
            // 
            // PersonalInfo
            // 
            this.PersonalInfo.Controls.Add(this.btnNext);
            this.PersonalInfo.Controls.Add(this.personDetailsControl);
            this.PersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.PersonalInfo.Name = "PersonalInfo";
            this.PersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.PersonalInfo.Size = new System.Drawing.Size(1164, 606);
            this.PersonalInfo.TabIndex = 0;
            this.PersonalInfo.Text = "Personal Info";
            this.PersonalInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.FlatAppearance.BorderSize = 2;
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnNext.Image = global::DVLDBussiensTier.Properties.Resources.user__2_2;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(1005, 546);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(153, 45);
            this.btnNext.TabIndex = 27;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // personDetailsControl
            // 
            this.personDetailsControl.Location = new System.Drawing.Point(6, 6);
            this.personDetailsControl.Name = "personDetailsControl";
            this.personDetailsControl.PersonID = -1;
            this.personDetailsControl.Size = new System.Drawing.Size(1166, 540);
            this.personDetailsControl.TabIndex = 0;
            this.personDetailsControl.OnPersonSelected += new System.Action<int>(this.personDetailsControl_OnPersonSelected);
            // 
            // LoginInfo
            // 
            this.LoginInfo.Controls.Add(this.chbIsActive);
            this.LoginInfo.Controls.Add(this.label2);
            this.LoginInfo.Controls.Add(this.lblCurrentUserID);
            this.LoginInfo.Controls.Add(this.label1);
            this.LoginInfo.Controls.Add(this.txtConfirmUserPassword);
            this.LoginInfo.Controls.Add(this.label10);
            this.LoginInfo.Controls.Add(this.label11);
            this.LoginInfo.Controls.Add(this.txtUserPassword);
            this.LoginInfo.Controls.Add(this.label4);
            this.LoginInfo.Controls.Add(this.label9);
            this.LoginInfo.Controls.Add(this.txtUsername);
            this.LoginInfo.Controls.Add(this.lblAddNewPerson);
            this.LoginInfo.Controls.Add(this.label3);
            this.LoginInfo.Location = new System.Drawing.Point(4, 22);
            this.LoginInfo.Name = "LoginInfo";
            this.LoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.LoginInfo.Size = new System.Drawing.Size(1164, 606);
            this.LoginInfo.TabIndex = 1;
            this.LoginInfo.Text = "Login Info";
            this.LoginInfo.UseVisualStyleBackColor = true;
            // 
            // chbIsActive
            // 
            this.chbIsActive.AutoSize = true;
            this.chbIsActive.Font = new System.Drawing.Font("Tahoma", 14F);
            this.chbIsActive.Location = new System.Drawing.Point(307, 341);
            this.chbIsActive.Name = "chbIsActive";
            this.chbIsActive.Size = new System.Drawing.Size(99, 27);
            this.chbIsActive.TabIndex = 72;
            this.chbIsActive.Text = "Is Active";
            this.chbIsActive.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Image = global::DVLDBussiensTier.Properties.Resources.person_boy1;
            this.label2.Location = new System.Drawing.Point(231, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 49);
            this.label2.TabIndex = 81;
            // 
            // lblCurrentUserID
            // 
            this.lblCurrentUserID.AutoSize = true;
            this.lblCurrentUserID.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblCurrentUserID.Location = new System.Drawing.Point(303, 61);
            this.lblCurrentUserID.Name = "lblCurrentUserID";
            this.lblCurrentUserID.Size = new System.Drawing.Size(41, 23);
            this.lblCurrentUserID.TabIndex = 80;
            this.lblCurrentUserID.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label1.Location = new System.Drawing.Point(133, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 23);
            this.label1.TabIndex = 79;
            this.label1.Text = "User ID : ";
            // 
            // txtConfirmUserPassword
            // 
            this.txtConfirmUserPassword.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtConfirmUserPassword.Location = new System.Drawing.Point(307, 282);
            this.txtConfirmUserPassword.MaxLength = 20;
            this.txtConfirmUserPassword.Name = "txtConfirmUserPassword";
            this.txtConfirmUserPassword.PasswordChar = '*';
            this.txtConfirmUserPassword.Size = new System.Drawing.Size(177, 27);
            this.txtConfirmUserPassword.TabIndex = 71;
            this.txtConfirmUserPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label10.Image = global::DVLDBussiensTier.Properties.Resources.password4;
            this.label10.Location = new System.Drawing.Point(231, 260);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 49);
            this.label10.TabIndex = 78;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label11.Location = new System.Drawing.Point(47, 282);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(178, 23);
            this.label11.TabIndex = 77;
            this.label11.Text = "Confirm Password : ";
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtUserPassword.Location = new System.Drawing.Point(307, 215);
            this.txtUserPassword.MaxLength = 20;
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = '*';
            this.txtUserPassword.Size = new System.Drawing.Size(177, 27);
            this.txtUserPassword.TabIndex = 70;
            this.txtUserPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.Image = global::DVLDBussiensTier.Properties.Resources.password2;
            this.label4.Location = new System.Drawing.Point(231, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 49);
            this.label4.TabIndex = 76;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label9.Location = new System.Drawing.Point(116, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 23);
            this.label9.TabIndex = 75;
            this.label9.Text = "Password : ";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtUsername.Location = new System.Drawing.Point(307, 138);
            this.txtUsername.MaxLength = 20;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(177, 27);
            this.txtUsername.TabIndex = 69;
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // lblAddNewPerson
            // 
            this.lblAddNewPerson.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblAddNewPerson.Image = ((System.Drawing.Image)(resources.GetObject("lblAddNewPerson.Image")));
            this.lblAddNewPerson.Location = new System.Drawing.Point(231, 112);
            this.lblAddNewPerson.Name = "lblAddNewPerson";
            this.lblAddNewPerson.Size = new System.Drawing.Size(70, 49);
            this.lblAddNewPerson.TabIndex = 74;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label3.Location = new System.Drawing.Point(116, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 23);
            this.label3.TabIndex = 73;
            this.label3.Text = "UserName : ";
            // 
            // FormMode
            // 
            this.FormMode.AutoSize = true;
            this.FormMode.Font = new System.Drawing.Font("Tahoma", 25.25F, System.Drawing.FontStyle.Bold);
            this.FormMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FormMode.Location = new System.Drawing.Point(475, 39);
            this.FormMode.Name = "FormMode";
            this.FormMode.Size = new System.Drawing.Size(257, 41);
            this.FormMode.TabIndex = 25;
            this.FormMode.Text = "Add New User";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(848, 769);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(153, 45);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1031, 769);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(153, 45);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddEditUserInfo
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1196, 832);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.FormMode);
            this.Controls.Add(this.tabUserDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddEditUserInfo";
            this.Text = "AddEditUserInfo";
            this.Load += new System.EventHandler(this.AddEditUserInfo_Load);
            this.tabUserDetails.ResumeLayout(false);
            this.PersonalInfo.ResumeLayout(false);
            this.LoginInfo.ResumeLayout(false);
            this.LoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabUserDetails;
        private System.Windows.Forms.TabPage PersonalInfo;
        private System.Windows.Forms.TabPage LoginInfo;
        private ctrPersonCardWithFilters personDetailsControl;
        private System.Windows.Forms.Label FormMode;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox chbIsActive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCurrentUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConfirmUserPassword;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblAddNewPerson;
        private System.Windows.Forms.Label label3;
    }
}