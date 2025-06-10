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
using static System.Net.Mime.MediaTypeNames;

namespace DVLDBussiensTier.Applications
{
    public partial class NewInternationalLicenseApplication : Form
    {
        public NewInternationalLicenseApplication()
        {
            InitializeComponent();
        }


        private clsApplicationType ApplicationType { get; } = clsApplicationType.Find((int)clsApplication.enApplicationTypes.eNewInternationalLicense);

        private int _InternationalLicenseApplicationID { get; set; } = -1;
       
        void LoadDetailsToApplicationInfo()
        {
            DateTime dtNow = DateTime.Now;

            lblLApplicationDate.Text = dtNow.ToShortDateString();
            lblIssueDate.Text = dtNow.ToShortDateString();
            lblExpirationDate.Text = dtNow.AddYears(1).ToShortDateString();


            lblFees.Text = ApplicationType.ApplicationFees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;

            if (ctrFilterLicneseAndShowDetails1.LicenseID != -1)
                lblLocalLicenseid.Text = ctrFilterLicneseAndShowDetails1.LicenseID.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ctrFilterLicneseAndShowDetails1.LicenseID == -1)
                return;

            int PersonId = clsApplication.FindByApplicationID(clsLicense.Find(ctrFilterLicneseAndShowDetails1.LicenseID).ApplicationID).ApplicationPersonID;

            Form frmLicenseHistory = new LicenseHistory(PersonId);
            frmLicenseHistory.ShowDialog();
        }


        bool IsHaveInterNationalLicense_And_IsLicenseExpirationDate(int LocalLicenseID)
        {
            int InternationalLicenseAppID = clsInternationalLicens.GetInternationalLicensIdByLocalDrivingLicenseApplicationID(LocalLicenseID);

            if (InternationalLicenseAppID != -1)
            {
                clsInternationalLicens internationalLicens = clsInternationalLicens.Find(InternationalLicenseAppID);


                if (internationalLicens.ExpiryDate > DateTime.Now)
                {
                    MessageBox.Show($"You Have international Licens Active With Id {internationalLicens.InternationalLicenseID}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }

            return false;
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            if(ctrFilterLicneseAndShowDetails1.LicenseID == -1)
            {
                MessageBox.Show($"Place Select Local License First!", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            clsApplication applicationForInterNational = new clsApplication();

            clsLicense licenseForLocal = clsLicense.Find(ctrFilterLicneseAndShowDetails1.LicenseID);


            if(clsLicenseClass.Find(licenseForLocal.LicenseClass).ClassName != "Class 3 - Ordinary driving license")
            {
                MessageBox.Show($"Place Select license Have :  Class 3 - Ordinary driving!", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(!licenseForLocal.IsActive)
            {
                MessageBox.Show($"Place Select license Active!", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if(IsHaveInterNationalLicense_And_IsLicenseExpirationDate(ctrFilterLicneseAndShowDetails1.LicenseID))
            {
                return;
            }



            applicationForInterNational.ApplicationDate = DateTime.Now;
            applicationForInterNational.ApplicationStatus = clsApplication.enApplicationStatus.New;
            applicationForInterNational.ApplicationTypeID = ApplicationType.ApplicationTypeID;
            applicationForInterNational.PaidFees = float.Parse(lblFees.Text);
            applicationForInterNational.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            applicationForInterNational.ApplicationPersonID = clsApplication.FindByApplicationID(licenseForLocal.ApplicationID).ApplicationPersonID;
            applicationForInterNational.LastStatusDate = DateTime.Now;



            if (!applicationForInterNational.Save())
            {
                MessageBox.Show("Error in saving the application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            clsInternationalLicens clsInternational = new clsInternationalLicens();

            clsInternational.ApplicationID = applicationForInterNational.ApplicationID;
            clsInternational.IssueDate = DateTime.Now;
            clsInternational.ExpiryDate = DateTime.Now.AddYears(1);
            clsInternational.IssuedUsingLocalLicenseID = licenseForLocal.LicenseID;
            clsInternational.DriverID = licenseForLocal.DriverID;
            clsInternational.CreatedByUserID =  clsGlobal.CurrentUser.UserID;
            clsInternational.IsActive = true;
   


            if (clsInternational.Save())
            {
                applicationForInterNational.SetComplete();

                if (applicationForInterNational.Save())
                {
                    MessageBox.Show($"License Issued Successfully with ID = {clsInternational.InternationalLicenseID}", "Succeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _InternationalLicenseApplicationID = clsInternational.InternationalLicenseID;

                    lbL_LlApplicationID.Text = applicationForInterNational.ApplicationID.ToString();
                    lblL_L_LicenseID.Text = clsInternational.InternationalLicenseID.ToString();
                }

            }
            else
            {
                MessageBox.Show("Error in saving the local driving license application");
            }


            lbShowLicenseInfo.Enabled = true;
            ctrFilterLicneseAndShowDetails1.LookFilter();
            btSave.Enabled = false;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frmDriverInfo = new InternationalDriverInfo(_InternationalLicenseApplicationID);
            frmDriverInfo.ShowDialog();
        }

        private void NewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            LoadDetailsToApplicationInfo();
        }
    }
}








