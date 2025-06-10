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
    public partial class ctrDriverInternationalInterNationalLicenInfo : UserControl
    {
        public ctrDriverInternationalInterNationalLicenInfo()
        {
            InitializeComponent();
        }




        public void LoadDateToCtr(int InterNationalLicenseID)
        {
            if (InterNationalLicenseID == -1)
            {
                return;
            }

            clsInternationalLicens InterNationalLicen = clsInternationalLicens.Find(InterNationalLicenseID);

            if (InterNationalLicen == null)
            {
                return;
            }


            clsPerson person = InterNationalLicen.ApplicationInfo.ApplicationPersonInfo;


            lblFullName.Text = person.FullName;


            lblInterNationalLicneseID.Text = InterNationalLicen.InternationalLicenseID.ToString();
            lblLicenseID.Text = InterNationalLicen.IssuedUsingLocalLicenseID.ToString();


            lblNationalNumber.Text = person.NationalNo;
            lblGendor.Text = (person.Gendor == 'M') ? "Male" : "Famele";

            
            lblIssueDate.Text = InterNationalLicen.IssueDate.ToShortDateString();
            lblExpirationDate.Text = InterNationalLicen.ExpiryDate.ToShortDateString();
            lblDriverID.Text = InterNationalLicen.DriverID.ToString();

            lblDateOfBirth.Text = person.DateOfBirth.ToShortDateString();

            lblIsActive.Text = (InterNationalLicen.IsActive) ? "Yes" : "No";

            lblApplicationID.Text = InterNationalLicen.ApplicationID.ToString();



            if (!string.IsNullOrEmpty(person.ImagePath))
                pictureBox1.Image = Image.FromFile(person.ImagePath);

            else
                pictureBox1.Image = Resources.magnifier;

        }




    }
}
