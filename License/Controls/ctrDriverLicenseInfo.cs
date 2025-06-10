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
using DVLDBussiensTier.Properties;

namespace DVLDBussiensTier
{
    public partial class ctrDriverLicenseInfo : UserControl
    {
        public ctrDriverLicenseInfo()
        {
            InitializeComponent();
        }

       string GetIssueReason(int IssueReason)
        {
            string IssueResuon = string.Empty;

            switch ((clsApplication.enApplicationTypes)IssueReason)
            {
                case clsApplication.enApplicationTypes.eNewLocalDrivingLicenseService:
                    IssueResuon = "First Time";
                    break;

                case clsApplication.enApplicationTypes.eRenewDrivingLicenseService:
                    IssueResuon = "Renew";
                    break;

                case clsApplication.enApplicationTypes.eReplacementforaLostDrivingLicense:
                    IssueResuon = "Replacement for Lost";
                    break;

                case clsApplication.enApplicationTypes.eReplacementforaDamagedDrivingLicense:
                    IssueResuon = "Replacement for Damaged";
                    break;

            }

            return IssueResuon;
        }


         public void LoadDateToCtr(int LicenseID)
        {
            if (LicenseID == -1)
            {
                return;
            }

            clsLicense license = clsLicense.Find(LicenseID);


     


            if(license == null)
            {
                return;
            }

             clsPerson person = clsPerson.Find(clsApplication.FindByApplicationID(license.ApplicationID).ApplicationPersonID);

            lblLicenseClass.Text = clsLicenseClass.Find(license.LicenseClass).ClassName;
            lblFullName.Text = person.FullName;
            lblLicneseID.Text = license.LicenseID.ToString();
            lblNationalNumber.Text = person.NationalNo;
            lblGendor.Text = (person.Gendor == 'M') ? "Male" : "Famele";
            lblIssueDate.Text = license.IssueDate.ToShortDateString();



            lblIssueReason.Text = GetIssueReason(license.IssueReason);




            lblNotes.Text = (license.Notes == "") ? "Not Notes" :license.Notes;
            lblIsActive.Text = (license.IsActive == true) ? "Yes" : "No";
            lblDateOfBirth.Text = person.DateOfBirth.ToShortDateString();
            lblDriverID.Text = license.DriverID.ToString();
            lblExpirationDate.Text = license.ExpirationDate.ToShortDateString();

            if(!string.IsNullOrEmpty(person.ImagePath))
                pictureBox1.Image = Image.FromFile(person.ImagePath);

            else
                pictureBox1.Image  = Resources.magnifier;

            /// Not Ready
            clsDetainedLicens detainedLicens = clsDetainedLicens.Find(clsDetainedLicens.GetDetainIdByLicenseId(license.LicenseID));


            lblIsDetained.Text = (detainedLicens == null) ? "No" : (detainedLicens.IsReleased) ? "No" : "Yes";



        }

    }
}


