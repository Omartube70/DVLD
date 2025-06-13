using Drving_VehicleBusinessTier;
using DVLDBussiensTier.Applications.Local_Driving_License;
using DVLDBussiensTier.Tests1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDBussiensTier.Applications
{
    public partial class ListLocalDrivingLicenseApplications : Form
    {
        private DataTable _dtAllLocalApplication;


        public ListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }


        private void cbColumName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbColumName.SelectedItem.ToString() == "None")
            {
                txtFilterBy.Visible = false;
                txtFilterBy.Text = "";
                ListLocalDrivingLicenseApplications_Load(null, null);
            }
            else
            {
                txtFilterBy.Visible = true;
                txtFilterBy.Text = "";
            }
        }

        private void lblAddNewApplication_Click(object sender, EventArgs e)
        {
            NewLocalDrivingLicenseApplication localDrivingLicenseApplication = new NewLocalDrivingLicenseApplication();
            localDrivingLicenseApplication.ShowDialog();
            ListLocalDrivingLicenseApplications_Load(null,null);
        }

        private void txtFilterBy_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtFilterBy.Text == "")
            {
                ListLocalDrivingLicenseApplications_Load(null,null);
                return;
            }

           switch (cbColumName.SelectedItem.ToString())
            {
                case "National No.":
                    _dtAllLocalApplication.DefaultView.RowFilter = "[NationalNo] LIKE '" + txtFilterBy.Text + "%'";
                    break;

                case "Full Name":
                    _dtAllLocalApplication.DefaultView.RowFilter = "[FullName] LIKE '" + txtFilterBy.Text + "%'";
                    break;

                case "L.D.L.AppID":
                    _dtAllLocalApplication.DefaultView.RowFilter = "[LocalDrivingLicenseApplicationID] = '" + txtFilterBy.Text + "'";
                    break;

                case "Status":
                    _dtAllLocalApplication.DefaultView.RowFilter = "Status LIKE '" + txtFilterBy.Text + "%'";
                    break;
            }

            lblRecords.Text = dgvL_D_L_Applications.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbColumName.SelectedItem.ToString() == "L.D.L.AppID")
            {
                // Verify that the pressed key isn't CTRL or any non-numeric digit
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

            }
            else
            {
                e.Handled = false;

            }
        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Are you sure you want to Canseled this application?", "Canseled Application", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int LocalApplicationID = Convert.ToInt32(dgvL_D_L_Applications.CurrentRow.Cells[0].Value);
                
                clsLocalDrivingLicenseApplication LocalApplicationInfo = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(LocalApplicationID);


                if(LocalApplicationInfo.ApplicationStatus == clsApplication.enApplicationStatus.Completed)
                {
                    MessageBox.Show("The Applcation Is Completed!","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }


                if (LocalApplicationInfo.ApplicationStatus == clsApplication.enApplicationStatus.Cancelled)
                {
                    MessageBox.Show("The Applcation Is Canseld!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                if (LocalApplicationInfo.Cancel())
                            ListLocalDrivingLicenseApplications_Load(null,null);
            }

        }

        private void addNePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalApplicationID = Convert.ToInt32(dgvL_D_L_Applications.CurrentRow.Cells[0].Value);

            NewLocalDrivingLicenseApplication localDrivingLicenseApplication = new NewLocalDrivingLicenseApplication(LocalApplicationID);
            
           

            localDrivingLicenseApplication.ShowDialog();
            ListLocalDrivingLicenseApplications_Load(null,null);
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalApplicationID = Convert.ToInt32(dgvL_D_L_Applications.CurrentRow.Cells[0].Value);

            if(clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(LocalApplicationID).ApplicationStatus == clsApplication.enApplicationStatus.Completed)
            {
                MessageBox.Show("The Applcation Is Completed!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if(MessageBox.Show("Are you sure you want to Delete this application?", "Delete Application", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
               if( !clsLocalDrivingLicenseApplication.DeleteLocalDrivingLicenseApplication(LocalApplicationID))
                {
                        MessageBox.Show("Local License Application was not deleted Because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               else
                {
                   ListLocalDrivingLicenseApplications_Load(null,null);

                }
            }



        }

        private void seheduleVisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalApplicationID = Convert.ToInt32(dgvL_D_L_Applications.CurrentRow.Cells[0].Value);

            Form visionTest = new VisionTestAppoinments(LocalApplicationID);
            visionTest.ShowDialog();

                        ListLocalDrivingLicenseApplications_Load(null,null);
        }

        private void seheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalApplicationID = Convert.ToInt32(dgvL_D_L_Applications.CurrentRow.Cells[0].Value);

            Form visionTest = new WrittenTestAppointments(LocalApplicationID);
            visionTest.ShowDialog();

                        ListLocalDrivingLicenseApplications_Load(null,null);
        }

        private void seheduleStrettTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalApplicationID = Convert.ToInt32(dgvL_D_L_Applications.CurrentRow.Cells[0].Value);

            Form visionTest = new StreetTestAppointments(LocalApplicationID);
            visionTest.ShowDialog();

                        ListLocalDrivingLicenseApplications_Load(null,null);
        }

        private void IssueDrivinglToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalApplicationID = Convert.ToInt32(dgvL_D_L_Applications.CurrentRow.Cells[0].Value);

            Form IssueDriver = new IssueDriverLicenseForFirstTime(LocalApplicationID);
            IssueDriver.ShowDialog();

                        ListLocalDrivingLicenseApplications_Load(null,null);
        }


        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalApplicationID = Convert.ToInt32(dgvL_D_L_Applications.CurrentRow.Cells[0].Value);


            LicenseInfo LicenseInfo = new LicenseInfo(clsLicense.GetLicenseIdByLocalDrivingLicenseApplicationID(LocalApplicationID));
            LicenseInfo.ShowDialog();

            ListLocalDrivingLicenseApplications_Load(null,null);
        }


        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalApplicationID = Convert.ToInt32(dgvL_D_L_Applications.CurrentRow.Cells[0].Value);


            LicenseHistory LicenseHistory = new LicenseHistory(  clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(LocalApplicationID).ApplicationPersonID);
            LicenseHistory.ShowDialog();
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            if (Convert.ToInt32(dgvL_D_L_Applications.CurrentRow.Cells[5].Value) != 3)
            {
                showDetailsToolStripMenuItem.Enabled = true;
                EditApplicationToolStripMenuItem.Enabled = true;
                DeleteToolStripMenuItem.Enabled = true;
                CancelApplicationoolStripMenuItem.Enabled = true;
                SehduleTestslToolStripMenuItem.Enabled = true;

                switch (dgvL_D_L_Applications.CurrentRow.Cells[5].Value)
                {
                    case 0:
                        seheduleVisionToolStripMenuItem.Enabled = true;
                        seheduleWrittenTestToolStripMenuItem.Enabled = false;
                        seheduleStrettTestToolStripMenuItem.Enabled = false;
                        break;

                    case 1:
                        seheduleVisionToolStripMenuItem.Enabled = false;
                        seheduleWrittenTestToolStripMenuItem.Enabled = true;
                        seheduleStrettTestToolStripMenuItem.Enabled = false;
                        break;

                    case 2:
                        seheduleVisionToolStripMenuItem.Enabled = false;
                        seheduleWrittenTestToolStripMenuItem.Enabled = false;
                        seheduleStrettTestToolStripMenuItem.Enabled = true;
                        break;

                    case 3:
                        seheduleVisionToolStripMenuItem.Enabled = false;
                        seheduleWrittenTestToolStripMenuItem.Enabled = false;
                        seheduleStrettTestToolStripMenuItem.Enabled = false;
                        break;
                }

                IssueDrivinglToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
                showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
            }

            else
            {

                if ((dgvL_D_L_Applications.CurrentRow.Cells[6].Value.ToString() == (clsApplication.enApplicationStatus.Completed.ToString())))
                {
                    showDetailsToolStripMenuItem.Enabled = true;
                    EditApplicationToolStripMenuItem.Enabled = false;
                    DeleteToolStripMenuItem.Enabled = false;
                    CancelApplicationoolStripMenuItem.Enabled = false;
                    SehduleTestslToolStripMenuItem.Enabled = false;
                    IssueDrivinglToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = true;
                    showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
                }
                else if ((dgvL_D_L_Applications.CurrentRow.Cells[6].Value.ToString() == (clsApplication.enApplicationStatus.Cancelled.ToString())))
                {
                    showDetailsToolStripMenuItem.Enabled = true;
                    EditApplicationToolStripMenuItem.Enabled = false;
                    DeleteToolStripMenuItem.Enabled = true;
                    SehduleTestslToolStripMenuItem.Enabled = false;
                    IssueDrivinglToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = false;
                    showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
                }
                else
                {
                    showDetailsToolStripMenuItem.Enabled = true;
                    EditApplicationToolStripMenuItem.Enabled = true;
                    DeleteToolStripMenuItem.Enabled = true;
                    CancelApplicationoolStripMenuItem.Enabled = true;
                    SehduleTestslToolStripMenuItem.Enabled = false;
                    IssueDrivinglToolStripMenuItem.Enabled = true;
                    showLicenseToolStripMenuItem.Enabled = false;
                    showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
                }
            }


        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalApplicationID = Convert.ToInt32(dgvL_D_L_Applications.CurrentRow.Cells[0].Value);


            frmLocalDrivingLicenseApplicationInfo frmLocalDrivingLicenseApplicationInfo = new frmLocalDrivingLicenseApplicationInfo(LocalApplicationID);
            frmLocalDrivingLicenseApplicationInfo.ShowDialog();
        }

        private void ListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _dtAllLocalApplication = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dgvL_D_L_Applications.DataSource = _dtAllLocalApplication;
            lblRecords.Text = dgvL_D_L_Applications.Rows.Count.ToString();

            if(dgvL_D_L_Applications.Rows.Count > 0)
            {
                dgvL_D_L_Applications.Columns[0].HeaderText = "L.D.L.AppID";
                dgvL_D_L_Applications.Columns[0].Width = 110;

                dgvL_D_L_Applications.Columns[1].HeaderText = "Driving Class";
                dgvL_D_L_Applications.Columns[1].Width = 250;

                dgvL_D_L_Applications.Columns[2].HeaderText = "National No.";
                dgvL_D_L_Applications.Columns[2].Width = 120;

                dgvL_D_L_Applications.Columns[3].HeaderText = "Full Name";
                dgvL_D_L_Applications.Columns[3].Width = 260;

               dgvL_D_L_Applications.Columns[4].HeaderText = "Application Date";
               dgvL_D_L_Applications.Columns[4].Width = 150;

                dgvL_D_L_Applications.Columns[5].HeaderText = "Passed Tests";
                dgvL_D_L_Applications.Columns[5].Width = 110;

                dgvL_D_L_Applications.Columns[6].HeaderText = "Status";
                dgvL_D_L_Applications.Columns[6].Width = 120;
            }

        }
    }
}




