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

namespace DVLDBussiensTier.Tests1
{
    public partial class WrittenTestAppointments : Form
    {

        void RefreshdgvAppointments()
        {
            dgvAppointments.DataSource = clsTestAppointment.GetAllTestAppointmentsByLocalDrivingID(LocalDrivingLicenseApplicationID , clsTestType.enTestTypes.eWrittenTest);
            lblRecords.Text = dgvAppointments.Rows.Count.ToString();
        }

        public WrittenTestAppointments(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            ctrlApplicationBasicInfo1.LoadLocalApplicationInfo(LocalDrivingLicenseApplicationID);
            RefreshdgvAppointments();
        }
        public int LocalDrivingLicenseApplicationID { get; set; }



        private void WrittenTestAppointments_Load(object sender, EventArgs e)
        {

        }

        private void lblAddNewTest_Click(object sender, EventArgs e)
        {

            if (clsLocalDrivingLicenseApplication.IsPassedTest(LocalDrivingLicenseApplicationID, clsTestType.enTestTypes.eWrittenTest))
            {
                MessageBox.Show($"The Person alardy passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsTestAppointment.IsHaveAppointmentUnLocked(LocalDrivingLicenseApplicationID, clsTestType.enTestTypes.eWrittenTest))
            {
                MessageBox.Show($"Has Alardy a Appointment Active!", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            Form form = new SeheduleTest(LocalDrivingLicenseApplicationID, clsTestType.enTestTypes.eWrittenTest);
            form.ShowDialog();
            RefreshdgvAppointments();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = Convert.ToInt32(dgvAppointments.CurrentRow.Cells[0].Value);

            Form form = new SeheduleTest(LocalDrivingLicenseApplicationID, TestAppointmentID, clsTestType.enTestTypes.eWrittenTest);
            form.ShowDialog();

            RefreshdgvAppointments();

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = Convert.ToInt32(dgvAppointments.CurrentRow.Cells[0].Value);


            Form form = new TakeTest(LocalDrivingLicenseApplicationID, TestAppointmentID, clsTestType.enTestTypes.eWrittenTest);
            form.ShowDialog();

            RefreshdgvAppointments();
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(dgvAppointments.CurrentRow.Cells[3].Value) == true)
            {
                takeTestToolStripMenuItem.Enabled = false;
            }

            else
            {
                takeTestToolStripMenuItem.Enabled = true;
            }
        
    }
    }
}
