namespace DVLD.Detain
{
    partial class DetainLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetainLicense));
            this.ctrFilterLicneseAndShowDetails1 = new DVLD.Applications.ctrFilterLicneseAndShowDetails();
            this.label2 = new System.Windows.Forms.Label();
            this.lbShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btClose = new System.Windows.Forms.Button();
            this.btDetain = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudFineFees = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblLcenseID = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblLDetainDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAddNewApplication = new System.Windows.Forms.Label();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFineFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrFilterLicneseAndShowDetails1
            // 
            this.ctrFilterLicneseAndShowDetails1.BackColor = System.Drawing.Color.White;
            this.ctrFilterLicneseAndShowDetails1.LicenseID = -1;
            this.ctrFilterLicneseAndShowDetails1.Location = new System.Drawing.Point(9, 67);
            this.ctrFilterLicneseAndShowDetails1.Name = "ctrFilterLicneseAndShowDetails1";
            this.ctrFilterLicneseAndShowDetails1.Size = new System.Drawing.Size(1121, 621);
            this.ctrFilterLicneseAndShowDetails1.TabIndex = 0;
            this.ctrFilterLicneseAndShowDetails1.OnLicenseSelected += new System.Action<int>(this.ctrFilterLicneseAndShowDetails1_OnLicenseSelected);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 25.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(412, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 41);
            this.label2.TabIndex = 59;
            this.label2.Text = "Detain License";
            // 
            // lbShowLicenseInfo
            // 
            this.lbShowLicenseInfo.AutoSize = true;
            this.lbShowLicenseInfo.Enabled = false;
            this.lbShowLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lbShowLicenseInfo.Location = new System.Drawing.Point(300, 896);
            this.lbShowLicenseInfo.Name = "lbShowLicenseInfo";
            this.lbShowLicenseInfo.Size = new System.Drawing.Size(173, 22);
            this.lbShowLicenseInfo.TabIndex = 65;
            this.lbShowLicenseInfo.TabStop = true;
            this.lbShowLicenseInfo.Text = "Show License Info";
            this.lbShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbShowLicenseInfo_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.linkLabel1.Location = new System.Drawing.Point(11, 896);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(203, 22);
            this.linkLabel1.TabIndex = 64;
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
            this.btClose.Location = new System.Drawing.Point(794, 896);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(153, 45);
            this.btClose.TabIndex = 63;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btDetain
            // 
            this.btDetain.BackColor = System.Drawing.Color.White;
            this.btDetain.FlatAppearance.BorderSize = 2;
            this.btDetain.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btDetain.Image = global::DVLD.Properties.Resources.world_north_america11;
            this.btDetain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDetain.Location = new System.Drawing.Point(977, 896);
            this.btDetain.Name = "btDetain";
            this.btDetain.Size = new System.Drawing.Size(153, 45);
            this.btDetain.TabIndex = 62;
            this.btDetain.Text = "Detain";
            this.btDetain.UseVisualStyleBackColor = false;
            this.btDetain.Click += new System.EventHandler(this.btDetain_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.Image = global::DVLD.Properties.Resources.icons8_driver_license_326;
            this.label4.Location = new System.Drawing.Point(249, 889);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 33);
            this.label4.TabIndex = 61;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudFineFees);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.lblLcenseID);
            this.groupBox1.Controls.Add(this.lblCreatedBy);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblLDetainDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblAddNewApplication);
            this.groupBox1.Controls.Add(this.lblDetainID);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 694);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1119, 179);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detain Info";
            // 
            // nudFineFees
            // 
            this.nudFineFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold);
            this.nudFineFees.Location = new System.Drawing.Point(293, 130);
            this.nudFineFees.Name = "nudFineFees";
            this.nudFineFees.Size = new System.Drawing.Size(169, 27);
            this.nudFineFees.TabIndex = 1;
            this.nudFineFees.Validating += new System.ComponentModel.CancelEventHandler(this.nudFineFees_Validating);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label18.Location = new System.Drawing.Point(635, 39);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(116, 24);
            this.label18.TabIndex = 64;
            this.label18.Text = "License ID :";
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
            // lblLcenseID
            // 
            this.lblLcenseID.AutoSize = true;
            this.lblLcenseID.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblLcenseID.Location = new System.Drawing.Point(906, 44);
            this.lblLcenseID.Name = "lblLcenseID";
            this.lblLcenseID.Size = new System.Drawing.Size(51, 23);
            this.lblLcenseID.TabIndex = 66;
            this.lblLcenseID.Text = "[???]";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblCreatedBy.Location = new System.Drawing.Point(906, 101);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(51, 23);
            this.lblCreatedBy.TabIndex = 60;
            this.lblCreatedBy.Text = "[???]";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label14.Image = global::DVLD.Properties.Resources.person_boy13;
            this.label14.Location = new System.Drawing.Point(849, 87);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 33);
            this.label14.TabIndex = 59;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label15.Location = new System.Drawing.Point(635, 96);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(127, 24);
            this.label15.TabIndex = 58;
            this.label15.Text = "Created By : ";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label9.Image = global::DVLD.Properties.Resources.icons8_expensive_price_322;
            this.label9.Location = new System.Drawing.Point(232, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 33);
            this.label9.TabIndex = 56;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label12.Location = new System.Drawing.Point(18, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 24);
            this.label12.TabIndex = 55;
            this.label12.Text = "Fine Fees : ";
            // 
            // lblLDetainDate
            // 
            this.lblLDetainDate.AutoSize = true;
            this.lblLDetainDate.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblLDetainDate.Location = new System.Drawing.Point(289, 84);
            this.lblLDetainDate.Name = "lblLDetainDate";
            this.lblLDetainDate.Size = new System.Drawing.Size(51, 23);
            this.lblLDetainDate.TabIndex = 51;
            this.lblLDetainDate.Text = "[???]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label1.Location = new System.Drawing.Point(18, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 24);
            this.label1.TabIndex = 43;
            this.label1.Text = "Detain ID :";
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
            // lblDetainID
            // 
            this.lblDetainID.AutoSize = true;
            this.lblDetainID.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblDetainID.Location = new System.Drawing.Point(289, 44);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(51, 23);
            this.lblDetainID.TabIndex = 45;
            this.lblDetainID.Text = "[???]";
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
            this.label7.Size = new System.Drawing.Size(137, 24);
            this.label7.TabIndex = 46;
            this.label7.Text = "Detain Date : ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // DetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1146, 957);
            this.Controls.Add(this.ctrFilterLicneseAndShowDetails1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbShowLicenseInfo);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btDetain);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Name = "DetainLicense";
            this.Text = "Detain License";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFineFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Applications.ctrFilterLicneseAndShowDetails ctrFilterLicneseAndShowDetails1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lbShowLicenseInfo;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btDetain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblLcenseID;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblLDetainDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAddNewApplication;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudFineFees;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}