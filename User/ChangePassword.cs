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
    public partial class ChangePassword : Form
    {
        public ChangePassword(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }

        private int _UserID;
        private clsUser _User;

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                errorProvider1.SetError(txtNewPassword, "New Password is required");
                txtNewPassword.Focus();
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }

            if (txtNewPassword.Text == txtCurrentPassword.Text)
            {
                errorProvider1.SetError(txtNewPassword, "It is match the Current Password Try another Password!");
                txtNewPassword.Focus();
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {

            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Confirm Password is Not Math New Password");
                txtConfirmPassword.Focus();
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                errorProvider1.SetError(txtCurrentPassword, "Current Password is required");
                txtCurrentPassword.Focus();
                e.Cancel = true;
                return;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }


            if (txtCurrentPassword.Text != _User.Password)
            {
                errorProvider1.SetError(txtCurrentPassword, "Current Password is worng");
                txtCurrentPassword.Focus();
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
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

                _User.Password = txtNewPassword.Text;

                if (_User.Save())
                {
                    MessageBox.Show("Password Changed Successfully","Saved." , MessageBoxButtons.OK , MessageBoxIcon.Information);
                    txtCurrentPassword.Text = "";
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";
                }
                else
                {
                    MessageBox.Show("Error in Changing Password","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            _User = clsUser.FindByUserID(_UserID);

            if(_User == null)
            {
                MessageBox.Show($"Not Found User By ID {_UserID}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            ctrUserDetails1.LoadUserDetails(_UserID);
        }
    }
}
