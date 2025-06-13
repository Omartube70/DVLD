using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Drving_VehicleBusinessTier;

namespace DVLD
{
    public partial class ReplacmentForDamagedLicense : Form
    {
        public ReplacmentForDamagedLicense()
        {
            InitializeComponent();
            ApplicationType = clsApplicationType.Find((int)clsApplication.enApplicationTypes.eReplacementforaDamagedDrivingLicense);
            LoadDateToForm();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if(rdDamaged.Checked)
            {
                this.Text = "Replacment For Damaged License ";
                lblTitle.Text = this.Text;
                ApplicationType = clsApplicationType.Find((int)clsApplication.enApplicationTypes.eReplacementforaDamagedDrivingLicense);
            }

            else
            {
                this.Text = "Replacment For Lost License ";
                lblTitle.Text = this.Text;
                ApplicationType = clsApplicationType.Find((int)clsApplication.enApplicationTypes.eReplacementforaLostDrivingLicense);
            }

            lblApplicarionFees.Text = ApplicationType.ApplicationFees.ToString();
        }

        private void LoadDateToForm()
        {
            lblLApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblApplicarionFees.Text = ApplicationType.ApplicationFees.ToString();
        }

        public int ReplacmentLicenseID { get; set; } = -1;

        public clsApplicationType ApplicationType { get; set; }

        private void ctrFilterLicneseAndShowDetails1_OnLicenseSelected(int obj)
        {
            clsLicense Oldlicense = clsLicense.Find(obj);
            if (Oldlicense == null)
            {
                return;
            }


            if (Oldlicense.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show($"Selected License is expiread", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btReplacmentLicense.Enabled = false;
            }
            else
            {
                btReplacmentLicense.Enabled = true;
            }


            lblOldLicenseid.Text = Oldlicense.LicenseID.ToString();

        }

     
        private void lbShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseInfo frmLicenseInfo = new LicenseInfo(ReplacmentLicenseID);
            frmLicenseInfo.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblOldLicenseid.Text == "[???]")
            {
                return;
            }

            int PersonId = clsApplication.FindByApplicationID(clsLicense.Find(Convert.ToInt32(lblOldLicenseid.Text)).ApplicationID).ApplicationPersonID;

            Form frmLicenseHistory = new LicenseHistory(PersonId);
            frmLicenseHistory.ShowDialog();
        }

        private void btRbtReplacmentLicense_Click(object sender, EventArgs e)
        {
            if (!(MessageBox.Show("Are you sure you want to Issue a Replacment for the license?", "Confirem", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes))
            {
                return;
            }

            clsLicense OldLicense = clsLicense.Find(Convert.ToInt32(lblOldLicenseid.Text));

            if (!OldLicense.IsActive)
            {
                MessageBox.Show("License Is Not Active!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            clsApplication applicationReplacment = new clsApplication();


            applicationReplacment.ApplicationStatus = clsApplication.enApplicationStatus.New;
            applicationReplacment.ApplicationDate = DateTime.Now;
            applicationReplacment.PaidFees = ApplicationType.ApplicationFees;
            applicationReplacment.ApplicationPersonID = clsApplication.FindByApplicationID(OldLicense.ApplicationID).ApplicationPersonID;
            applicationReplacment.ApplicationTypeID = ApplicationType.ApplicationTypeID;
            applicationReplacment.LastStatusDate = DateTime.Now;
            applicationReplacment.CreatedByUserID = clsGlobal.CurrentUser.UserID;


            if (applicationReplacment.Save())
            {
                clsLicense NewLicense = new clsLicense();
                clsLicenseClass licenseClass = clsLicenseClass.Find(OldLicense.LicenseClass);

                NewLicense.ApplicationID = applicationReplacment.ApplicationID;
                NewLicense.IssueDate = DateTime.Now;
                NewLicense.ExpirationDate = DateTime.Now.AddYears(licenseClass.DefaultValidityLength);
                NewLicense.PaidFees = licenseClass.ClassFees;
                NewLicense.DriverID = OldLicense.DriverID;
                NewLicense.IsActive = true;
                NewLicense.IssueReason =  (ApplicationType.ApplicationTypeID == (int)clsApplication.enApplicationTypes.eReplacementforaDamagedDrivingLicense) ? (byte)clsApplication.enApplicationTypes.eReplacementforaDamagedDrivingLicense : (byte)clsApplication.enApplicationTypes.eReplacementforaLostDrivingLicense;
                NewLicense.LicenseClass = licenseClass.LicenseClassID;
                NewLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;



                if (NewLicense.Save())
                {
                    OldLicense.IsActive = false;

                    if (OldLicense.Save())
                    {

                        MessageBox.Show($"Licensed Replaced Successfully with ID = {NewLicense.LicenseID.ToString()}", "License Issueed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btReplacmentLicense.Enabled = false;
                        ctrFilterLicneseAndShowDetails1.LookFilter();

                        lbShowNewLicenseInfo.Enabled = true;

                        ReplacmentLicenseID = NewLicense.LicenseID;
                        lblLReplacmentLicenseID.Text = NewLicense.LicenseID.ToString();
                        lblL_R_ApplicationID.Text = applicationReplacment.ApplicationID.ToString();
                        return;
                    }
                }
            }
        }
    }
}

