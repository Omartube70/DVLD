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
using DVLD.Properties;
using static System.Net.Mime.MediaTypeNames;
using static Drving_VehicleBusinessTier.clsTestType;



namespace DVLD.Tests1
{
    public partial class SeheduleTest : Form
    {
        public SeheduleTest(int LocalDrivingLicenseApplicationID, int TestAppointmentID, clsTestType.enTestTypes enTest)
        {
            InitializeComponent();
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.TestAppointmentID = TestAppointmentID;
            this.enTestTypes = enTest;
            Mode = enMode.Update;
            LoadDateToForm();
        }


        public SeheduleTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestTypes enTest)
        {
            InitializeComponent();
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.enTestTypes = enTest;
            Mode = enMode.AddNew;
            LoadDateToForm();
        }

        public void LoadDateToForm()
        {
            clsTestAppointment testAppointment = null;

            clsLocalDrivingLicenseApplication LocalDrivingLicense_Local = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);



            lbLocsllApplicationID.Text = LocalDrivingLicense_Local.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = LocalDrivingLicense_Local.LicenseClassInfo.ClassName;
            lblName.Text = LocalDrivingLicense_Local.ApplicationPersonInfo.FullName;
            lblTrail.Text = ((int)enTestTypes).ToString();
            lblFess.Text = clsTestType.Find(enTestTypes).Fees.ToString();

            if (Mode == enMode.Update)
            {
                testAppointment = clsTestAppointment.Find(TestAppointmentID);

                dtpDate.MinDate = testAppointment.AppointmentDate;
                dtpDate.Value = testAppointment.AppointmentDate;


                // Retake Test Info


                if (testAppointment.IsLocked)
                {
                    dtpDate.Enabled = false;
                    btSave.Enabled = false;
                    lblLockedMessge.Visible = true;
                }
                else
                {
                    if(testAppointment.RetakeTestApplicationID != -1)
                    lblR_Test_App_ID.Text = testAppointment.RetakeTestApplicationID.ToString();
                }

                // End
                lblR_App_Fees.Text = "0";

                lblTotalFees.Text = (Convert.ToSingle(lblFess.Text) + Convert.ToSingle(lblR_App_Fees.Text)).ToString();


            }

            else
            {
                testAppointment = new clsTestAppointment();


                dtpDate.MinDate = DateTime.Now;

                // Retake Test Info

                if(clsTestAppointment.IsHaveAppointment_IsRetakeTest(LocalDrivingLicenseApplicationID , (enTestTypes) ))
                {
                    lblR_App_Fees.Text = clsApplicationType.Find(((int)clsApplication.enApplicationTypes.eRetakeTest)).ApplicationFees.ToString();
                    RetakeTestInfo.Enabled = true;
                }
                else
                {
                    lblR_App_Fees.Text = "0";
                    RetakeTestInfo.Enabled = false;

                }
                    // End


                    lblTotalFees.Text = (Convert.ToSingle(lblFess.Text) + Convert.ToSingle(lblR_App_Fees.Text)).ToString();

            }
        


            switch (enTestTypes)
            {
                case clsTestType.enTestTypes.eVisionTest:
                    pictureBox1.Image = Resources.images__1_;
                    break;

                case clsTestType.enTestTypes.eWrittenTest:
                    pictureBox1.Image = Resources._2833637;
                    break;


                case clsTestType.enTestTypes.eStreetTest:
                    pictureBox1.Image = Resources.stress_scale_test_with_high_level_tension_risk_for_health_stress_regulation_safe_health_arrow_on_extreme_level_from_overwork_overstrain_illustration_vector;
                    break;
            }
        }

        public int LocalDrivingLicenseApplicationID { get; set; } = -1;

        public int TestAppointmentID { get; set; } = -1;

       public clsTestType.enTestTypes enTestTypes { get; set; }

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode { get; set; }



        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            clsTestAppointment testAppointment = null;

            if(Mode == enMode.AddNew)
            {
                testAppointment = new clsTestAppointment();

                testAppointment.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
                testAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                testAppointment.PaidFees = Convert.ToSingle( lblFess.Text);
                testAppointment.TestTypeID = ((int)enTestTypes);
                testAppointment.AppointmentDate = dtpDate.Value;
                testAppointment.IsLocked = false;

                if(clsTestAppointment.IsHaveAppointment_IsRetakeTest(LocalDrivingLicenseApplicationID,enTestTypes))
                {
                    clsLocalDrivingLicenseApplication LocalDrivingLicense_Local = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);
                    clsApplication applicationRetakeTest = new clsApplication();


                    applicationRetakeTest.ApplicationStatus = clsApplication.enApplicationStatus.New;
                    applicationRetakeTest.ApplicationDate = DateTime.Now;
                    applicationRetakeTest.PaidFees = clsApplicationType.Find(((int)clsApplication.enApplicationTypes.eRetakeTest)).ApplicationFees;
                    applicationRetakeTest.ApplicationPersonID = LocalDrivingLicense_Local.ApplicationPersonID;
                    applicationRetakeTest.ApplicationTypeID = ((int)clsApplication.enApplicationTypes.eRetakeTest);
                    applicationRetakeTest.LastStatusDate = DateTime.Now;
                    applicationRetakeTest.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                    if(applicationRetakeTest.Save())
                    {
                        testAppointment.RetakeTestApplicationID = applicationRetakeTest.ApplicationID;
                    }
                }
            }
            else
            {
                testAppointment = clsTestAppointment.Find(TestAppointmentID);
                testAppointment.AppointmentDate = dtpDate.Value;
            }



            if (testAppointment.Save())
            {
                MessageBox.Show("Date Saved Successfully ", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            else
            {
                MessageBox.Show("Error Saved Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }





    }
}
