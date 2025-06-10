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

namespace DVLDBussiensTier
{
    public partial class AddEditUserInfo : Form
    {
        public enum enMode { eAddNew, eUpdate };
        public enMode Mode { get; set; }
        private int _UserID = -1;
        private clsUser _User;

        public AddEditUserInfo()
        {
            InitializeComponent();
            this.Mode = enMode.eAddNew;
        }

        public AddEditUserInfo(int UserId)
        {
            InitializeComponent();

            this.Mode = enMode.eUpdate;
            this._UserID = UserId;
        }

        void LoadDateFromUserToForm()
        {
            _User = clsUser.FindByUserID(this._UserID);
            if (_User != null)
            {
                txtUsername.Text = _User.UserName;
                txtUserPassword.Text = _User.Password;
                txtConfirmUserPassword.Text = _User.Password;
                chbIsActive.Checked = _User.IsActive;
                lblCurrentUserID.Text = _User.UserID.ToString();
                personDetailsControl.ShowPersonDetailsAndWritePersonIdAndLookFilter(_User.PersonID);
            }
            else
            {
                MessageBox.Show($"Not Found User By ID {_UserID}!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        void EditLabelText()
        {
            if (Mode == enMode.eUpdate)
            {
                LoadDateFromUserToForm();
                FormMode.Text = "Update User";
                this.Text = "Update User";

                btnSave.Enabled = true;
                LoginInfo.Enabled = true;
            }
            else
            {
                FormMode.Text = "Add New User";
                this.Text = "Add New User";

                LoginInfo.Enabled = false;
                btnSave.Enabled = false;
                _User = new clsUser();
            }
        }

       private bool _IsUserNameUnqiue()
        {
            if (Mode == enMode.eUpdate)
            {
                if(_User.UserName == txtUsername.Text)
                {
                    return true;
                }
            }

            return !clsUser.IsUserNameExists(txtUsername.Text);
        }

        private void btNext_Click(object sender, EventArgs e)
        {    
            tabUserDetails.SelectedIndex = 1;
        }

        private void AddEditUserInfo_Load(object sender, EventArgs e)
        {
            EditLabelText();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmUserPassword.Text != txtUserPassword.Text)
            {
                errorProvider1.SetError(txtConfirmUserPassword, "Password not match");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserPassword.Text))
            {
                errorProvider1.SetError(txtUserPassword, "Please enter your Password");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Please enter your UserName");
                e.Cancel = true;
            }

            else
            {
                if (!_IsUserNameUnqiue())
                {
                    errorProvider1.SetError(txtUsername, "This UserName already exists");
                    e.Cancel = true;
                    return;
                }

                else
                {

                    errorProvider1.Clear();
                    e.Cancel = false;
                }
                 
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("some failed are not valibe!, put the mouse over the red icon(s)",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

                _User.PersonID = personDetailsControl.PersonID;
                _User.UserName = txtUsername.Text;
                _User.Password = txtUserPassword.Text;
                _User.IsActive = chbIsActive.Checked;


                if (_User.Save())
                {
                    MessageBox.Show("User saved successfully","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this._UserID = _User.UserID;
                    lblCurrentUserID.Text = _User.UserID.ToString();


                Mode = enMode.eUpdate;
                FormMode.Text = "Update User";
                this.Text = "Update User";
            }
                else
                {
                    MessageBox.Show("Error saving user","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void personDetailsControl_OnPersonSelected(int obj)
        {
            if (personDetailsControl.PersonID == -1)
            {
                MessageBox.Show("Please select a person first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                LoginInfo.Enabled = false;
                return;
            }

            if (Mode == enMode.eAddNew && clsUser.IsUserExistByPersonID(personDetailsControl.PersonID))
            {
                MessageBox.Show("Selected Person Alardy Has a User, Choose anthoer one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                LoginInfo.Enabled = false;
                return;
            }

            btnSave.Enabled = true;
            LoginInfo.Enabled = true;
        }
    }
}









