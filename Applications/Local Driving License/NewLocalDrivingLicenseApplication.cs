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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLDBussiensTier.Applications
{
    public partial class NewLocalDrivingLicenseApplication : Form
    {
        public enum enMode { eAddNew, eUpdate };
        private enMode _Mode { get; set; }


        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        private clsLocalDrivingLicenseApplication _LocalApplicationInfo;

        public NewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            this._Mode = enMode.eAddNew;
        }

        public NewLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            this._Mode = enMode.eUpdate;
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }




       private void _LoadDate()
        {
            ctrFindPersonAndShowDetails1.FilterEnabled = false;
            _LocalApplicationInfo = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);
    

            if(_LocalApplicationInfo == null)
            {
                MessageBox.Show($"No Application with ID = {_LocalDrivingLicenseApplicationID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }



            ctrFindPersonAndShowDetails1.PersonID = _LocalApplicationInfo.ApplicationPersonID;
            lblApplicationID.Text = _LocalApplicationInfo.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = _LocalApplicationInfo.ApplicationDate.ToString("yyyy-MM-dd");
            cbLicenseClass.SelectedValue = _LocalApplicationInfo.LicenseClassID;
            lblFees.Text = _LocalApplicationInfo.PaidFees.ToString();
            lblCretedby.Text = _LocalApplicationInfo.CreatedByUserInfo.UserName;
        }

        void _FillLicenseClassInComboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasss();
          
            cbLicenseClass.DataSource = dtLicenseClasses;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";

        }

        private void btNext_Click(object sender, EventArgs e)
        {

            if(_Mode == enMode.eUpdate)
            {
                btSave.Enabled = true;
                tpApplicationInfo.Enabled = false;
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpApplicationInfo"];
                return;
            }

            if(ctrFindPersonAndShowDetails1.PersonID != -1)
            {
                btSave.Enabled = true; 
                tpApplicationInfo.Enabled = true;
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpApplicationInfo"];
            }

            else
            {
                MessageBox.Show("Please Select a Person First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrFindPersonAndShowDetails1.FoucsFilter();
                btSave.Enabled = false;
                tpApplicationInfo.Enabled = false;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            int LicenseClassID = ((int)cbLicenseClass.SelectedValue);

            int ActiveApplicationID = clsApplication.GetActiveApplicationIDforLicenseClass(_SelectedPersonID,LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class", "the selected Person Already has", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsLicense.isLicenseExistByPersonID(_SelectedPersonID,LicenseClassID))
            {
                MessageBox.Show("Person Already have a License with same applied driving", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            byte MinAllowedAge = clsLicenseClass.GetLicenseClassMinimumAllowedAge(LicenseClassID);
            if (MinAllowedAge > Convert.ToByte(clsPerson.GetPersonAge(_SelectedPersonID)))
            {
                MessageBox.Show($"Person is not allowed for this Driving License Class, it requires a {MinAllowedAge} years old and above", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


               _LocalApplicationInfo.ApplicationPersonID = ctrFindPersonAndShowDetails1.PersonID;
                _LocalApplicationInfo.ApplicationDate = DateTime.Now;
                _LocalApplicationInfo.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                _LocalApplicationInfo.ApplicationStatus = clsApplication.enApplicationStatus.New;
                _LocalApplicationInfo.LastStatusDate = DateTime.Now;
                _LocalApplicationInfo.ApplicationTypeID = ((int)clsApplication.enApplicationTypes.eNewLocalDrivingLicenseService);
                _LocalApplicationInfo.PaidFees = Convert.ToSingle(lblFees.Text);
                _LocalApplicationInfo.LicenseClassID = LicenseClassID;


            if (!_LocalApplicationInfo.Save())
            {
                MessageBox.Show("Error in saving the Date!", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            else
            {
                MessageBox.Show("Date saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblApplicationID.Text = _LocalApplicationInfo.LocalDrivingLicenseApplicationID.ToString();

                _LocalDrivingLicenseApplicationID = _LocalApplicationInfo.LocalDrivingLicenseApplicationID;

                // Update Form Status
                _Mode = enMode.eUpdate;
                lblAddEdit.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();


            if (_Mode == enMode.eUpdate)
            {
                _LoadDate();
            }

        }

        private void _ResetDefualtValues()
        {
            _FillLicenseClassInComboBox();

            if (_Mode == enMode.eAddNew)
            {
                lblAddEdit.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LocalApplicationInfo = new clsLocalDrivingLicenseApplication();
                ctrFindPersonAndShowDetails1.FoucsFilter();
                tpApplicationInfo.Enabled = false;

                cbLicenseClass.SelectedIndex = 2;
                lblApplicationDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationTypes.eNewLocalDrivingLicenseService).ApplicationFees.ToString();
                lblCretedby.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {
                lblAddEdit.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tpApplicationInfo.Enabled = true;
                btSave.Enabled = true;
            }

        }

        private void ctrFindPersonAndShowDetails1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }

        private void NewLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
           ctrFindPersonAndShowDetails1.FoucsFilter();
        }
    }
}





