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

namespace DVLDBussiensTier.Detain
{
    public partial class ReleaseDetainedLicense : Form
    {
        public ReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        public ReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            ctrFilterLicneseAndShowDetails1.WriteLicenseIdToBox_And_LookFilter(LicenseID);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public clsApplicationType ApplicationType { get; } = clsApplicationType.Find((int)clsApplication.enApplicationTypes.eReleaseDetainedDrivingLicsense);


        private void ctrFilterLicneseAndShowDetails1_OnLicenseSelected(int obj)
        {


            clsDetainedLicens detainedLicens = clsDetainedLicens.Find(clsDetainedLicens.GetDetainIdByLicenseId(obj));

            if (detainedLicens != null)
            {
                if (!detainedLicens.IsReleased)
                {
                    lblDetainID.Text = detainedLicens.DetainID.ToString();
                    lblLDetainDate.Text = detainedLicens.DetainDate.ToShortDateString();
                    lblApplicationFees.Text = ApplicationType.ApplicationFees.ToString();
                    lblLcenseID.Text = detainedLicens.LicenseID.ToString();
                    lblCreatedBy.Text = clsUser.FindByUserID( detainedLicens.CreatedByUserID).UserName;
                    lblFineFees.Text = detainedLicens.FineFees.ToString();
                    lblTotalFees.Text = (detainedLicens.FineFees + ApplicationType.ApplicationFees).ToString();
                    btRelease.Enabled = true;
                    return;
                }
            }

            MessageBox.Show("Selected License is not  detained, choose anthoer one", "not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            btRelease.Enabled = false;
        }

        private void btRelease_Click(object sender, EventArgs e)
        {
            if (!(MessageBox.Show("Are you sure you want to release this detain license?", "Confirem", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes))
            {
                return;
            }


            clsApplication applicationRelease = new clsApplication();

            applicationRelease.ApplicationDate = DateTime.Now;
            applicationRelease.PaidFees = ApplicationType.ApplicationFees;
            applicationRelease.ApplicationPersonID = clsApplication.FindByApplicationID(clsLicense.Find(ctrFilterLicneseAndShowDetails1.LicenseID).ApplicationID).ApplicationPersonID;
            applicationRelease.ApplicationTypeID = ApplicationType.ApplicationTypeID;
            applicationRelease.CreatedByUserID = clsGlobal.CurrentUser.UserID;


            if (applicationRelease.Save())
            {
                clsDetainedLicens detainedLicens = clsDetainedLicens.Find(Convert.ToInt32(lblDetainID.Text));

                detainedLicens.ReleaseDate = DateTime.Now;
                detainedLicens.ReleasedByUserID = clsGlobal.CurrentUser.UserID;
                detainedLicens.ReleaseApplicationID = applicationRelease.ApplicationID;
                detainedLicens.IsReleased = true;


                if (detainedLicens.Save())
                {

                    applicationRelease.SetComplete();

                    if (applicationRelease.Save())
                    {
                        lblApplicationID.Text = detainedLicens.ReleaseApplicationID.ToString();
                        MessageBox.Show($"Detained Licensed Released Successfully", "Detained Licensed Released", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btRelease.Enabled = false;
                        lbShowLicenseInfo.Enabled = true;
                        ctrFilterLicneseAndShowDetails1.LookFilter();
                        return;
                    }
                }
            }


            MessageBox.Show($"Error Saved Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void lbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseInfo frmLicenseInfo = new LicenseInfo(ctrFilterLicneseAndShowDetails1.LicenseID);
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
    }
}
