namespace DVLD
{
    partial class ctrPersonCardWithFilters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrPersonCardWithFilters));
            this.ctrPersonDetails1 = new DVLD.ctrPersonDetails();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblAddNewPerson = new System.Windows.Forms.Label();
            this.txtFilterBy = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbColumName = new System.Windows.Forms.ComboBox();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrPersonDetails1
            // 
            this.ctrPersonDetails1.Location = new System.Drawing.Point(7, 130);
            this.ctrPersonDetails1.Name = "ctrPersonDetails1";
            this.ctrPersonDetails1.PersonID = -1;
            this.ctrPersonDetails1.Size = new System.Drawing.Size(1159, 408);
            this.ctrPersonDetails1.TabIndex = 0;
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.lblFilter);
            this.gbFilter.Controls.Add(this.lblAddNewPerson);
            this.gbFilter.Controls.Add(this.txtFilterBy);
            this.gbFilter.Controls.Add(this.label7);
            this.gbFilter.Controls.Add(this.cbColumName);
            this.gbFilter.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gbFilter.Location = new System.Drawing.Point(25, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(846, 112);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // lblFilter
            // 
            this.lblFilter.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblFilter.Image = global::DVLD.Properties.Resources.person_boy__2_;
            this.lblFilter.Location = new System.Drawing.Point(608, 23);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(89, 55);
            this.lblFilter.TabIndex = 37;
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
            // 
            // lblAddNewPerson
            // 
            this.lblAddNewPerson.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblAddNewPerson.Image = ((System.Drawing.Image)(resources.GetObject("lblAddNewPerson.Image")));
            this.lblAddNewPerson.Location = new System.Drawing.Point(703, 33);
            this.lblAddNewPerson.Name = "lblAddNewPerson";
            this.lblAddNewPerson.Size = new System.Drawing.Size(89, 55);
            this.lblAddNewPerson.TabIndex = 36;
            this.lblAddNewPerson.Click += new System.EventHandler(this.lblAddNewPerson_Click);
            // 
            // txtFilterBy
            // 
            this.txtFilterBy.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtFilterBy.Location = new System.Drawing.Point(327, 43);
            this.txtFilterBy.Name = "txtFilterBy";
            this.txtFilterBy.Size = new System.Drawing.Size(258, 27);
            this.txtFilterBy.TabIndex = 35;
            this.txtFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterBy_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label7.Location = new System.Drawing.Point(42, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 23);
            this.label7.TabIndex = 34;
            this.label7.Text = "Filter By : ";
            // 
            // cbColumName
            // 
            this.cbColumName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColumName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cbColumName.FormattingEnabled = true;
            this.cbColumName.Items.AddRange(new object[] {
            "Person ID",
            "National No.",
            "Phone",
            "Email"});
            this.cbColumName.Location = new System.Drawing.Point(144, 43);
            this.cbColumName.Name = "cbColumName";
            this.cbColumName.Size = new System.Drawing.Size(168, 27);
            this.cbColumName.TabIndex = 33;
            // 
            // ctrPersonCardWithFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.ctrPersonDetails1);
            this.Name = "ctrPersonCardWithFilters";
            this.Size = new System.Drawing.Size(1166, 536);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrPersonDetails ctrPersonDetails1;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblAddNewPerson;
        private System.Windows.Forms.TextBox txtFilterBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbColumName;
    }
}
