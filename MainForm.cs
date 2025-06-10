using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Drving_VehicleBusinessTier;
using DVLDBussiensTier.Applications;
using DVLDBussiensTier.Detain;
using DVLDBussiensTier.Users.Login;

namespace DVLDBussiensTier
{
    public partial class MainForm : Form
    {
       private Login _frmLogin;
        public MainForm(Login frmLogin)
        {
            InitializeComponent();
            this._frmLogin = frmLogin;
        }


        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagePeople frmManagePeople = new ManagePeople();
            frmManagePeople.ShowDialog();
        }

        private void singOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUsers frmManageUsers = new ManageUsers();
            frmManageUsers.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo userInfo = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            userInfo.ShowDialog();
        } 

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword frm = new ChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }


        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageApplicationTypes frm = new ManageApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageTestTypes frm = new ManageTestTypes();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLocalDrivingLicenseApplication localDrivingLicenseApplication = new NewLocalDrivingLicenseApplication();
            localDrivingLicenseApplication.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListLocalDrivingLicenseApplications localDrivingLicenseApplicatiopns = new ListLocalDrivingLicenseApplications();
            localDrivingLicenseApplicatiopns.ShowDialog();
        }

        private void interanlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewInternationalLicenseApplication internationalLicenseApplication = new NewInternationalLicenseApplication();
            internationalLicenseApplication.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListDrivers ListDrivers = new ListDrivers();
            ListDrivers.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListInternationalLicenseApplications ListInternationalLicenseApplications = new ListInternationalLicenseApplications();
            ListInternationalLicenseApplications.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenewLocalLicenseApplication RenewLocalLicenseApplication = new RenewLocalLicenseApplication();
            RenewLocalLicenseApplication.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplacmentForDamagedLicense ReplacmentForDamagedLicense = new ReplacmentForDamagedLicense();
            ReplacmentForDamagedLicense.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetainLicense DetainLicensecs = new DetainLicense();
            DetainLicensecs.ShowDialog();
        }

        private void relaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense ReleaseDetainedLicense = new ReleaseDetainedLicense();
            ReleaseDetainedLicense.ShowDialog();
        }

        private void manageDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListDetainedLicenses ListDetainedLicenses = new ListDetainedLicenses();
            ListDetainedLicenses.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense ReleaseDetainedLicense = new ReleaseDetainedLicense();
            ReleaseDetainedLicense.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListLocalDrivingLicenseApplications localDrivingLicenseApplicatiopns = new ListLocalDrivingLicenseApplications();
            localDrivingLicenseApplicatiopns.ShowDialog();
        }
    }
}
