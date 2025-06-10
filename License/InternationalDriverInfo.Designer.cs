namespace DVLDBussiensTier
{
    partial class InternationalDriverInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InternationalDriverInfo));
            this.ctrDriverInternationalInterNationalLicenInfo1 = new DVLDBussiensTier.ctrDriverInternationalInterNationalLicenInfo();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrDriverInternationalInterNationalLicenInfo1
            // 
            this.ctrDriverInternationalInterNationalLicenInfo1.Location = new System.Drawing.Point(12, 285);
            this.ctrDriverInternationalInterNationalLicenInfo1.Name = "ctrDriverInternationalInterNationalLicenInfo1";
            this.ctrDriverInternationalInterNationalLicenInfo1.Size = new System.Drawing.Size(1134, 437);
            this.ctrDriverInternationalInterNationalLicenInfo1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 25.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(322, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(579, 41);
            this.label2.TabIndex = 29;
            this.label2.Text = "Driver International License Info";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Image = global::DVLDBussiensTier.Properties.Resources.images__2_4;
            this.label1.Location = new System.Drawing.Point(347, -31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 245);
            this.label1.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.Font = new System.Drawing.Font("Tahoma", 14F);
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(984, 728);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 45);
            this.button1.TabIndex = 27;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InternationalDriverInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1158, 804);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrDriverInternationalInterNationalLicenInfo1);
            this.Name = "InternationalDriverInfo";
            this.ShowIcon = false;
            this.Text = "International Driver Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrDriverInternationalInterNationalLicenInfo ctrDriverInternationalInterNationalLicenInfo1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}