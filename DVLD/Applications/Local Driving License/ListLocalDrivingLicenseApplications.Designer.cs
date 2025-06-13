namespace DVLD.Applications
{
    partial class ListLocalDrivingLicenseApplications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListLocalDrivingLicenseApplications));
            this.txtFilterBy = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbColumName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvL_D_L_Applications = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.EditApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelApplicationoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.SehduleTestslToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seheduleVisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seheduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seheduleStrettTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.IssueDrivinglToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAddNewApplication = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvL_D_L_Applications)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFilterBy
            // 
            this.txtFilterBy.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtFilterBy.Location = new System.Drawing.Point(304, 348);
            this.txtFilterBy.Name = "txtFilterBy";
            this.txtFilterBy.Size = new System.Drawing.Size(179, 27);
            this.txtFilterBy.TabIndex = 31;
            this.txtFilterBy.Visible = false;
            this.txtFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterBy_KeyPress);
            this.txtFilterBy.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFilterBy_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label7.Location = new System.Drawing.Point(17, 348);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 23);
            this.label7.TabIndex = 30;
            this.label7.Text = "Filter By : ";
            // 
            // cbColumName
            // 
            this.cbColumName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColumName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cbColumName.FormattingEnabled = true;
            this.cbColumName.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No.",
            "Full Name",
            "Status"});
            this.cbColumName.Location = new System.Drawing.Point(119, 348);
            this.cbColumName.Name = "cbColumName";
            this.cbColumName.Size = new System.Drawing.Size(168, 27);
            this.cbColumName.TabIndex = 29;
            this.cbColumName.SelectedIndexChanged += new System.EventHandler(this.cbColumName_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label4.Location = new System.Drawing.Point(43, 800);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "# Records : ";
            // 
            // dgvL_D_L_Applications
            // 
            this.dgvL_D_L_Applications.AllowUserToAddRows = false;
            this.dgvL_D_L_Applications.AllowUserToDeleteRows = false;
            this.dgvL_D_L_Applications.AllowUserToOrderColumns = true;
            this.dgvL_D_L_Applications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvL_D_L_Applications.BackgroundColor = System.Drawing.Color.White;
            this.dgvL_D_L_Applications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvL_D_L_Applications.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvL_D_L_Applications.Location = new System.Drawing.Point(12, 394);
            this.dgvL_D_L_Applications.Name = "dgvL_D_L_Applications";
            this.dgvL_D_L_Applications.ReadOnly = true;
            this.dgvL_D_L_Applications.RowHeadersWidth = 50;
            this.dgvL_D_L_Applications.Size = new System.Drawing.Size(1366, 381);
            this.dgvL_D_L_Applications.TabIndex = 25;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.EditApplicationToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.toolStripMenuItem3,
            this.CancelApplicationoolStripMenuItem,
            this.toolStripMenuItem1,
            this.SehduleTestslToolStripMenuItem,
            this.toolStripMenuItem4,
            this.IssueDrivinglToolStripMenuItem,
            this.toolStripMenuItem5,
            this.showLicenseToolStripMenuItem,
            this.toolStripMenuItem6,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(308, 248);
            this.contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showDetailsToolStripMenuItem.Image")));
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(307, 26);
            this.showDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(304, 6);
            // 
            // EditApplicationToolStripMenuItem
            // 
            this.EditApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.account_settings1;
            this.EditApplicationToolStripMenuItem.Name = "EditApplicationToolStripMenuItem";
            this.EditApplicationToolStripMenuItem.Size = new System.Drawing.Size(307, 26);
            this.EditApplicationToolStripMenuItem.Text = "Edit Application";
            this.EditApplicationToolStripMenuItem.Click += new System.EventHandler(this.addNePersonToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Image = global::DVLD.Properties.Resources.delete_row1;
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(307, 26);
            this.DeleteToolStripMenuItem.Text = "Delete Application";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.eToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(304, 6);
            // 
            // CancelApplicationoolStripMenuItem
            // 
            this.CancelApplicationoolStripMenuItem.Image = global::DVLD.Properties.Resources.close;
            this.CancelApplicationoolStripMenuItem.Name = "CancelApplicationoolStripMenuItem";
            this.CancelApplicationoolStripMenuItem.Size = new System.Drawing.Size(307, 26);
            this.CancelApplicationoolStripMenuItem.Text = "Cancel Application";
            this.CancelApplicationoolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(304, 6);
            // 
            // SehduleTestslToolStripMenuItem
            // 
            this.SehduleTestslToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seheduleVisionToolStripMenuItem,
            this.seheduleWrittenTestToolStripMenuItem,
            this.seheduleStrettTestToolStripMenuItem});
            this.SehduleTestslToolStripMenuItem.Image = global::DVLD.Properties.Resources._48388561;
            this.SehduleTestslToolStripMenuItem.Name = "SehduleTestslToolStripMenuItem";
            this.SehduleTestslToolStripMenuItem.Size = new System.Drawing.Size(307, 26);
            this.SehduleTestslToolStripMenuItem.Text = "Sehdule Tests";
            // 
            // seheduleVisionToolStripMenuItem
            // 
            this.seheduleVisionToolStripMenuItem.Image = global::DVLD.Properties.Resources.icons8_vision_321;
            this.seheduleVisionToolStripMenuItem.Name = "seheduleVisionToolStripMenuItem";
            this.seheduleVisionToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.seheduleVisionToolStripMenuItem.Text = "Sehedule Vision Test";
            this.seheduleVisionToolStripMenuItem.Click += new System.EventHandler(this.seheduleVisionToolStripMenuItem_Click);
            // 
            // seheduleWrittenTestToolStripMenuItem
            // 
            this.seheduleWrittenTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.icons8_test_results_3211;
            this.seheduleWrittenTestToolStripMenuItem.Name = "seheduleWrittenTestToolStripMenuItem";
            this.seheduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.seheduleWrittenTestToolStripMenuItem.Text = "Sehedule Written Test";
            this.seheduleWrittenTestToolStripMenuItem.Click += new System.EventHandler(this.seheduleWrittenTestToolStripMenuItem_Click);
            // 
            // seheduleStrettTestToolStripMenuItem
            // 
            this.seheduleStrettTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.icons8_amphibious_vehicle_321;
            this.seheduleStrettTestToolStripMenuItem.Name = "seheduleStrettTestToolStripMenuItem";
            this.seheduleStrettTestToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.seheduleStrettTestToolStripMenuItem.Text = "Sehedule Street Test";
            this.seheduleStrettTestToolStripMenuItem.Click += new System.EventHandler(this.seheduleStrettTestToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(304, 6);
            // 
            // IssueDrivinglToolStripMenuItem
            // 
            this.IssueDrivinglToolStripMenuItem.Image = global::DVLD.Properties.Resources.icons8_driver_license_324;
            this.IssueDrivinglToolStripMenuItem.Name = "IssueDrivinglToolStripMenuItem";
            this.IssueDrivinglToolStripMenuItem.Size = new System.Drawing.Size(307, 26);
            this.IssueDrivinglToolStripMenuItem.Text = "Issue Driving License (First Time)";
            this.IssueDrivinglToolStripMenuItem.Click += new System.EventHandler(this.IssueDrivinglToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(304, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.icons8_driver_license_324;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(307, 26);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(304, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD.Properties.Resources.user__1_3;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(307, 26);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 25.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(432, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(616, 41);
            this.label2.TabIndex = 24;
            this.label2.Text = "Local Driving License Applicatiopns";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblRecords.Location = new System.Drawing.Point(181, 804);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(33, 19);
            this.lblRecords.TabIndex = 33;
            this.lblRecords.Text = "???";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.Image = global::DVLD.Properties.Resources.icons8_local_322;
            this.label3.Location = new System.Drawing.Point(853, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 43);
            this.label3.TabIndex = 32;
            // 
            // lblAddNewApplication
            // 
            this.lblAddNewApplication.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblAddNewApplication.Image = global::DVLD.Properties.Resources.icons8_add_properties_32;
            this.lblAddNewApplication.Location = new System.Drawing.Point(1294, 320);
            this.lblAddNewApplication.Name = "lblAddNewApplication";
            this.lblAddNewApplication.Size = new System.Drawing.Size(89, 55);
            this.lblAddNewApplication.TabIndex = 28;
            this.lblAddNewApplication.Click += new System.EventHandler(this.lblAddNewApplication_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.Font = new System.Drawing.Font("Tahoma", 14F);
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1230, 800);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 45);
            this.button1.TabIndex = 26;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Image = global::DVLD.Properties.Resources._28336371;
            this.label1.Location = new System.Drawing.Point(496, -23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 290);
            this.label1.TabIndex = 23;
            // 
            // ListLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1401, 879);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilterBy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbColumName);
            this.Controls.Add(this.lblAddNewApplication);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvL_D_L_Applications);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ListLocalDrivingLicenseApplications";
            this.ShowIcon = false;
            this.Text = "Local Driving License Applicatiopns";
            this.Load += new System.EventHandler(this.ListLocalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvL_D_L_Applications)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilterBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbColumName;
        private System.Windows.Forms.Label lblAddNewApplication;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvL_D_L_Applications;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CancelApplicationoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem IssueDrivinglToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem SehduleTestslToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seheduleVisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seheduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seheduleStrettTestToolStripMenuItem;
    }
}