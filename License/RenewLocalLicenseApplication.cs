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

namespace DVLDBussiensTier
{
    public partial class RenewLocalLicenseApplication : Form
    {
        public RenewLocalLicenseApplication()
        {
            InitializeComponent();
            LoadDateToForm();
        }

        private void LoadDateToForm()
        {
            lblLApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblApplicarionFees.Text = ApplicationType.ApplicationFees.ToString();
        }


        public clsApplicationType ApplicationType { get; } = clsApplicationType.Find((int)clsApplication.enApplicationTypes.eRenewDrivingLicenseService);



        private void ctrFilterLicneseAndShowDetails1_OnLicenseSelected(int obj)
        {
            clsLicense Oldlicense = clsLicense.Find(obj);
            if (Oldlicense == null)
            {
                return;
            }


            if (Oldlicense.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show($"Selected License is not yet, expiread, it will expire on : {Oldlicense.ExpirationDate.ToShortDateString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btRenew.Enabled = false;
            }

            else
            {
                btRenew.Enabled = true;
            }

                lblOldLicenseid.Text = Oldlicense.LicenseID.ToString();

            clsLicenseClass licenseClass = clsLicenseClass.Find(Oldlicense.LicenseClass);

            lblExpirationDate.Text = DateTime.Now.AddYears(licenseClass.DefaultValidityLength).ToShortDateString();
            lblLicenseFees.Text = licenseClass.ClassFees.ToString();

            lblTotalFees.Text = (ApplicationType.ApplicationFees + licenseClass.ClassFees).ToString();


        }


        private void btRenew_Click(object sender, EventArgs e)
        {

            if (!( MessageBox.Show( "Are you sure you want to Renew the license?", "Confirem", MessageBoxButtons.YesNo , MessageBoxIcon.Information ) == DialogResult.Yes))
            {
                return;
            }

            clsLicense OldLicense = clsLicense.Find(ctrFilterLicneseAndShowDetails1.LicenseID);

            if(!OldLicense.IsActive)
            {
                MessageBox.Show("you Have License Activeed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            clsApplication applicationRenew = new clsApplication();


            applicationRenew.ApplicationStatus = clsApplication.enApplicationStatus.New;
            applicationRenew.ApplicationDate = DateTime.Now;
            applicationRenew.PaidFees = ApplicationType.ApplicationFees;
            applicationRenew.ApplicationPersonID = clsApplication.FindByApplicationID(OldLicense.ApplicationID).ApplicationPersonID;
            applicationRenew.ApplicationTypeID = ApplicationType.ApplicationTypeID;
            applicationRenew.LastStatusDate = DateTime.Now;
            applicationRenew.CreatedByUserID = clsGlobal.CurrentUser.UserID;


            if(applicationRenew.Save())
            {
                clsLicense NewLicense = new clsLicense();


                NewLicense.ApplicationID = applicationRenew.ApplicationID;
                NewLicense.Notes = txtNotes.Text;
                NewLicense.IssueDate = DateTime.Now;
                NewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.Find(OldLicense.LicenseClass).DefaultValidityLength);
                NewLicense.PaidFees = applicationRenew.PaidFees;
                NewLicense.DriverID = OldLicense.DriverID;
                NewLicense.IsActive = true;
                NewLicense.IssueReason = ((int)clsApplication.enApplicationTypes.eRenewDrivingLicenseService);
                NewLicense.LicenseClass = OldLicense.LicenseClass;
                NewLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;



                if(NewLicense.Save())
                {
                    OldLicense.IsActive = false;

                    if (OldLicense.Save())
                    {
                        lblLRenewedLicenseID.Text = applicationRenew.ApplicationID.ToString();
                        lblLRenewedLicenseID.Text = NewLicense.LicenseID.ToString();
                        MessageBox.Show($"Licensed Renwed Successfully with ID = {NewLicense.LicenseID.ToString()}", "License Issueed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btRenew.Enabled = false;
                        ctrFilterLicneseAndShowDetails1.LookFilter();
                        txtNotes.Enabled = false;
                        lbShowNewLicenseInfo.Enabled = true;
                        return;
                    }
                }


            }

            MessageBox.Show($"Error Saved Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void lbShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseInfo frmLicenseInfo = new LicenseInfo(Convert.ToInt32(lblLRenewedLicenseID.Text));
            frmLicenseInfo.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ctrFilterLicneseAndShowDetails1.LicenseID == -1)
            {
                return;
            }

            int PersonId = clsApplication.FindByApplicationID(clsLicense.Find(ctrFilterLicneseAndShowDetails1.LicenseID).ApplicationID).ApplicationPersonID;

            Form frmLicenseHistory = new LicenseHistory(PersonId);
            frmLicenseHistory.ShowDialog();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}















