namespace DVLD
{
    partial class ReplacmentForDamagedLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplacmentForDamagedLicense));
            this.ctrFilterLicneseAndShowDetails1 = new DVLD.Applications.ctrFilterLicneseAndShowDetails();
            this.lbShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btClose = new System.Windows.Forms.Button();
            this.btReplacmentLicense = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblLReplacmentLicenseID = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblOldLicenseid = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblApplicarionFees = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblLApplicationDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAddNewApplication = new System.Windows.Forms.Label();
            this.lblL_R_ApplicationID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdLost = new System.Windows.Forms.RadioButton();
            this.rdDamaged = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrFilterLicneseAndShowDetails1
            // 
            this.ctrFilterLicneseAndShowDetails1.BackColor = System.Drawing.Color.White;
            this.ctrFilterLicneseAndShowDetails1.LicenseID = -1;
            this.ctrFilterLicneseAndShowDetails1.Location = new System.Drawing.Point(49, 74);
            this.ctrFilterLicneseAndShowDetails1.Name = "ctrFilterLicneseAndShowDetails1";
            this.ctrFilterLicneseAndShowDetails1.Size = new System.Drawing.Size(1121, 621);
            this.ctrFilterLicneseAndShowDetails1.TabIndex = 72;
            this.ctrFilterLicneseAndShowDetails1.OnLicenseSelected += new System.Action<int>(this.ctrFilterLicneseAndShowDetails1_OnLicenseSelected);
            // 
            // lbShowNewLicenseInfo
            // 
            this.lbShowNewLicenseInfo.AutoSize = true;
            this.lbShowNewLicenseInfo.Enabled = false;
            this.lbShowNewLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lbShowNewLicenseInfo.Location = new System.Drawing.Point(343, 912);
            this.lbShowNewLicenseInfo.Name = "lbShowNewLicenseInfo";
            this.lbShowNewLicenseInfo.Size = new System.Drawing.Size(218, 22);
            this.lbShowNewLicenseInfo.TabIndex = 71;
            this.lbShowNewLicenseInfo.TabStop = true;
            this.lbShowNewLicenseInfo.Text = "Show New License Info";
            this.lbShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbShowNewLicenseInfo_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.linkLabel1.Location = new System.Drawing.Point(54, 912);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(203, 22);
            this.linkLabel1.TabIndex = 70;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Show License History";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btClose
            // 
            this.btClose.BackColor = System.Drawing.Color.White;
            this.btClose.FlatAppearance.BorderSize = 2;
            this.btClose.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btClose.Image = ((System.Drawing.Image)(resources.GetObject("btClose.Image")));
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(765, 912);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(153, 45);
            this.btClose.TabIndex = 69;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btReplacmentLicense
            // 
            this.btReplacmentLicense.BackColor = System.Drawing.Color.White;
            this.btReplacmentLicense.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btReplacmentLicense.FlatAppearance.BorderSize = 2;
            this.btReplacmentLicense.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btReplacmentLicense.Image = global::DVLD.Properties.Resources.icons8_driver_license_327;
            this.btReplacmentLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btReplacmentLicense.Location = new System.Drawing.Point(944, 912);
            this.btReplacmentLicense.Name = "btReplacmentLicense";
            this.btReplacmentLicense.Size = new System.Drawing.Size(211, 45);
            this.btReplacmentLicense.TabIndex = 68;
            this.btReplacmentLicense.Text = "Issue Replacment";
            this.btReplacmentLicense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btReplacmentLicense.UseVisualStyleBackColor = false;
            this.btReplacmentLicense.Click += new System.EventHandler(this.btRbtReplacmentLicense_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.Image = global::DVLD.Properties.Resources.icons8_driver_license_326;
            this.label4.Location = new System.Drawing.Point(292, 905);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 33);
            this.label4.TabIndex = 67;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.lblLReplacmentLicenseID);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lblOldLicenseid);
            this.groupBox1.Controls.Add(this.lblCreatedBy);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.lblApplicarionFees);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblLApplicationDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblAddNewApplication);
            this.groupBox1.Controls.Add(this.lblL_R_ApplicationID);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(36, 701);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1119, 188);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Info";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label18.Location = new System.Drawing.Point(610, 39);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(227, 24);
            this.label18.TabIndex = 64;
            this.label18.Text = "Replacment License ID :";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label19.Image = global::DVLD.Properties.Resources.field_number1;
            this.label19.Location = new System.Drawing.Point(849, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 33);
            this.label19.TabIndex = 65;
            // 
            // lblLReplacmentLicenseID
            // 
            this.lblLReplacmentLicenseID.AutoSize = true;
            this.lblLReplacmentLicenseID.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblLReplacmentLicenseID.Location = new System.Drawing.Point(906, 44);
            this.lblLReplacmentLicenseID.Name = "lblLReplacmentLicenseID";
            this.lblLReplacmentLicenseID.Size = new System.Drawing.Size(51, 23);
            this.lblLReplacmentLicenseID.TabIndex = 66;
            this.lblLReplacmentLicenseID.Text = "[???]";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label13.Location = new System.Drawing.Point(610, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(152, 24);
            this.label13.TabIndex = 61;
            this.label13.Text = "Old License ID :";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label16.Image = global::DVLD.Properties.Resources.icons8_driver_license_3251;
            this.label16.Location = new System.Drawing.Point(849, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 33);
            this.label16.TabIndex = 62;
            // 
            // lblOldLicenseid
            // 
            this.lblOldLicenseid.AutoSize = true;
            this.lblOldLicenseid.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblOldLicenseid.Location = new System.Drawing.Point(906, 88);
            this.lblOldLicenseid.Name = "lblOldLicenseid";
            this.lblOldLicenseid.Size = new System.Drawing.Size(51, 23);
            this.lblOldLicenseid.TabIndex = 63;
            this.lblOldLicenseid.Text = "[???]";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblCreatedBy.Location = new System.Drawing.Point(904, 141);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(51, 23);
            this.lblCreatedBy.TabIndex = 60;
            this.lblCreatedBy.Text = "[???]";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label14.Image = global::DVLD.Properties.Resources.person_boy13;
            this.label14.Location = new System.Drawing.Point(847, 127);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 33);
            this.label14.TabIndex = 59;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label15.Location = new System.Drawing.Point(610, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(127, 24);
            this.label15.TabIndex = 58;
            this.label15.Text = "Created By : ";
            // 
            // lblApplicarionFees
            // 
            this.lblApplicarionFees.AutoSize = true;
            this.lblApplicarionFees.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblApplicarionFees.Location = new System.Drawing.Point(289, 136);
            this.lblApplicarionFees.Name = "lblApplicarionFees";
            this.lblApplicarionFees.Size = new System.Drawing.Size(54, 23);
            this.lblApplicarionFees.TabIndex = 57;
            this.lblApplicarionFees.Text = "[$$$]";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label9.Image = global::DVLD.Properties.Resources.icons8_expensive_price_322;
            this.label9.Location = new System.Drawing.Point(232, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 33);
            this.label9.TabIndex = 56;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label12.Location = new System.Drawing.Point(18, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(174, 24);
            this.label12.TabIndex = 55;
            this.label12.Text = "Application Fees : ";
            // 
            // lblLApplicationDate
            // 
            this.lblLApplicationDate.AutoSize = true;
            this.lblLApplicationDate.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblLApplicationDate.Location = new System.Drawing.Point(289, 84);
            this.lblLApplicationDate.Name = "lblLApplicationDate";
            this.lblLApplicationDate.Size = new System.Drawing.Size(51, 23);
            this.lblLApplicationDate.TabIndex = 51;
            this.lblLApplicationDate.Text = "[???]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label1.Location = new System.Drawing.Point(18, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 24);
            this.label1.TabIndex = 43;
            this.label1.Text = "L.R.Application ID :";
            // 
            // lblAddNewApplication
            // 
            this.lblAddNewApplication.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblAddNewApplication.Image = global::DVLD.Properties.Resources.field_number1;
            this.lblAddNewApplication.Location = new System.Drawing.Point(232, 30);
            this.lblAddNewApplication.Name = "lblAddNewApplication";
            this.lblAddNewApplication.Size = new System.Drawing.Size(35, 33);
            this.lblAddNewApplication.TabIndex = 44;
            // 
            // lblL_R_ApplicationID
            // 
            this.lblL_R_ApplicationID.AutoSize = true;
            this.lblL_R_ApplicationID.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblL_R_ApplicationID.Location = new System.Drawing.Point(289, 44);
            this.lblL_R_ApplicationID.Name = "lblL_R_ApplicationID";
            this.lblL_R_ApplicationID.Size = new System.Drawing.Size(51, 23);
            this.lblL_R_ApplicationID.TabIndex = 45;
            this.lblL_R_ApplicationID.Text = "[???]";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label6.Image = global::DVLD.Properties.Resources.date5;
            this.label6.Location = new System.Drawing.Point(232, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 33);
            this.label6.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label7.Location = new System.Drawing.Point(18, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 24);
            this.label7.TabIndex = 46;
            this.label7.Text = "Application Date : ";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 25.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(276, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(603, 41);
            this.lblTitle.TabIndex = 65;
            this.lblTitle.Text = "Replacment For Damaged License ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdLost);
            this.groupBox2.Controls.Add(this.rdDamaged);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.groupBox2.Location = new System.Drawing.Point(767, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 98);
            this.groupBox2.TabIndex = 74;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Replacment For : ";
            // 
            // rdLost
            // 
            this.rdLost.AutoSize = true;
            this.rdLost.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdLost.Location = new System.Drawing.Point(231, 39);
            this.rdLost.Name = "rdLost";
            this.rdLost.Size = new System.Drawing.Size(126, 23);
            this.rdLost.TabIndex = 1;
            this.rdLost.Text = "Lost License";
            this.rdLost.UseVisualStyleBackColor = true;
            this.rdLost.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rdDamaged
            // 
            this.rdDamaged.AutoSize = true;
            this.rdDamaged.Checked = true;
            this.rdDamaged.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdDamaged.Location = new System.Drawing.Point(23, 39);
            this.rdDamaged.Name = "rdDamaged";
            this.rdDamaged.Size = new System.Drawing.Size(169, 23);
            this.rdDamaged.TabIndex = 0;
            this.rdDamaged.TabStop = true;
            this.rdDamaged.Text = "Damaged License";
            this.rdDamaged.UseVisualStyleBackColor = true;
            // 
            // ReplacmentForDamagedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1229, 984);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ctrFilterLicneseAndShowDetails1);
            this.Controls.Add(this.lbShowNewLicenseInfo);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btReplacmentLicense);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.Name = "ReplacmentForDamagedLicense";
            this.ShowIcon = false;
            this.Text = "Replacment For Damaged License";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Applications.ctrFilterLicneseAndShowDetails ctrFilterLicneseAndShowDetails1;
        private System.Windows.Forms.LinkLabel lbShowNewLicenseInfo;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btReplacmentLicense;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblLReplacmentLicenseID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblOldLicenseid;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblApplicarionFees;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblLApplicationDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAddNewApplication;
        private System.Windows.Forms.Label lblL_R_ApplicationID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdLost;
        private System.Windows.Forms.RadioButton rdDamaged;
    }
}