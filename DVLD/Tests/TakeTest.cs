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


namespace DVLDBussiensTier.Tests1
{
    public partial class TakeTest : Form
    {
        public TakeTest(int LocalDrivingLicenseApplicationID, int TestAppointmentID , clsTestType.enTestTypes enTest)
        {
            InitializeComponent();
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.TestAppointmentID = TestAppointmentID;
            this.enTestTypes = enTest;
            LoadDateToForm();
        }



        public int LocalDrivingLicenseApplicationID { get; set; } = -1;

        public int TestAppointmentID { get; set; } = -1;

        public clsTestType.enTestTypes enTestTypes { get; set; }

        public void LoadDateToForm()
        {
            if (LocalDrivingLicenseApplicationID == -1)
            {
                return;
            }

            clsTestAppointment testAppointment = clsTestAppointment.Find(TestAppointmentID);

            clsLocalDrivingLicenseApplication L_D_LApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);


            lbLocsllApplicationID.Text = this.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = L_D_LApp.LicenseClassInfo.ClassName;
            lblName.Text = L_D_LApp.ApplicationPersonInfo.FullName;
            lblTrail.Text = ((int)enTestTypes).ToString();

            lblDate.Text = testAppointment.AppointmentDate.ToShortDateString();
 
            lblFess.Text = clsTestType.Find(enTestTypes).Fees.ToString();

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
       



        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
           if(TestAppointmentID == -1)
            {
                return;
            }


            if (MessageBox.Show("You are sure you want to save? After that you cannot change the Pass/Fail results after the save"
                , "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }


            clsTest Test = new clsTest();


            Test.TestAppointmentID = TestAppointmentID;

            Test.TestResult = (rdPass.Checked) ? true : false;

            Test.Notes = txtNotes.Text;

            Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;


            if(Test.Save())
            {

                clsTestAppointment TestAppointment =  clsTestAppointment.Find(TestAppointmentID);

                if(TestAppointment != null)
                {
                    TestAppointment.IsLocked = true;
                }
                else
                {
                    return;
                }

                if (TestAppointment.Save())
                {

                    MessageBox.Show("Date Saved Successfully ", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lblTestID.Text = Test.TestID.ToString();
                }
            }
            else
            {
                MessageBox.Show("Error Saved Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
