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

namespace DVLD.Applications
{
    public partial class IssueDriverLicenseForFirstTime : Form
    {
        public IssueDriverLicenseForFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
           
        }

        private int _LocalDrivingLicenseApplicationID  = -1;

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            if (_LocalDrivingLicenseApplicationID != -1)
            {
                clsLocalDrivingLicenseApplication LocalDrivingLicenseInfo =  clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);

                int LicenseID = LocalDrivingLicenseInfo.IssueLicenseFirstTime(txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);

                    if (LicenseID != -1)
                    {

                            MessageBox.Show($"License Issued Successfully with ID = {LicenseID}", "Succeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //ctrApplicationDeatils.ShowLicenseInfo = true;
                    }
                   else
                   {
                       MessageBox.Show("Error Saved Date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }

            }

        }

        private void IssueDriverLicenseForFirstTime_Load(object sender, EventArgs e)
        {
            ctrlApplicationBasicInfo1.ShowLicenseInfo = false;
            ctrlApplicationBasicInfo1.LoadLocalApplicationInfo(_LocalDrivingLicenseApplicationID);
        }


    }
}










