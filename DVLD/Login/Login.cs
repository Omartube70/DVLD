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

namespace DVLD.Users.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if(txtUserName.Text == "")
            {
                errorProvider1.SetError(txtUserName, "Please enter your username");
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
            if (txtPassword.Text == "")
            {
                errorProvider1.SetError(txtPassword, "Please enter your Password");

                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }



        private void btLogin_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Palace Enter UserName And Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return;
            }

            clsUser User = clsUser.FineByUserName_And_Password(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if (User == null)
            {
                MessageBox.Show("Invalid UserName/Password!", "Worng Credential", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (User.IsActive == true)
            {
                if(cbRemberMe.Checked)
                    clsGlobal.SaveRememberUserToSettings(txtUserName.Text.Trim() , txtPassword.Text.Trim());
                else
                    clsGlobal.SaveRememberUserToSettings("","");


                clsGlobal.CurrentUser = User;
                this.Hide();
                MainForm frmMainForm = new MainForm(this);
                frmMainForm.ShowDialog();

            }
            else
            {
                MessageBox.Show("User Is Not Active Contact Your Admin");
                return;
            }
            
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                cbRemberMe.Checked = true;
            }
            else
            {
                cbRemberMe.Checked = false;
            }
        }
    }
}