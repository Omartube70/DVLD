using Drving_VehicleBusinessTier;
using DVLDBussiensTier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Controls.ApplicationControls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {

        private clsLocalDrivingLicenseApplication _LocalApplication;

        private int _LocalApplicationID = -1;

        public int LocalApplicationID
        {
            get { return _LocalApplicationID; }
        }

        private bool _ShowLicenseInfo;

        public bool ShowLicenseInfo {get { return _ShowLicenseInfo; } set { _ShowLicenseInfo = value; llShowLicenceInfo.Enabled = _ShowLicenseInfo; } }

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
  
        }

        public void LoadLocalApplicationInfo(int LocalApplicationID)
        {
            _LocalApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(LocalApplicationID);

            if (_LocalApplication == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + LocalApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _FillApplicationInfo();
        }

        private void _FillApplicationInfo()
        {
            _LocalApplicationID = _LocalApplication.LocalDrivingLicenseApplicationID;
            lblApplicationID.Text = _LocalApplication.ApplicationID.ToString();
            lblStatus.Text = _LocalApplication.ApplicationStatus.ToString();
            lblType.Text = _LocalApplication.ApplicationTypeInfo.ApplicationTypeTitle;
            lblFees.Text = _LocalApplication.PaidFees.ToString();
            lblApplicant.Text = _LocalApplication.ApplicationPersonInfo.FullName;
            lblDate.Text = (_LocalApplication.ApplicationDate).ToShortDateString();
            lblStatusDate.Text = (_LocalApplication.LastStatusDate).ToShortDateString();
            lblCreatedByUser.Text = _LocalApplication.CreatedByUserInfo.UserName;

            lblLocalDrivingLicenseApplicationID.Text = _LocalApplication.LocalDrivingLicenseApplicationID.ToString();
            lblPassedTests.Text = _LocalApplication.GetPassedTest().ToString();
            lblAppliedFor.Text = _LocalApplication.LicenseClassInfo.ClassName;
        }

        public void ResetApplicationInfo()
        {
            _LocalApplicationID = -1;

            lblApplicationID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblType.Text = "[????]";
            lblFees.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblDate.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblCreatedByUser.Text = "[????]";

        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PersonDetails frm = new PersonDetails(_LocalApplication.ApplicationPersonID);
            frm.ShowDialog();

            //Refresh
            LoadLocalApplicationInfo(_LocalApplicationID);

        }
    }
}
