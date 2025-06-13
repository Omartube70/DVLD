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

namespace DVLD
{
    public partial class ctrUserDetails : UserControl
    {
        public ctrUserDetails()
        {
            InitializeComponent();
        }

        private int _UserID = -1;
        private clsUser _User;
        public int UserID { get {return _UserID; } }


        public void LoadUserDetails(int UserID)
        {
            _User = clsUser.FindByUserID(UserID);


            if (_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show($"Not Found User By ID {UserID}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _UserID = _User.UserID;
            _FillUserInfo();
        }

        private void _FillUserInfo()
        {
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName;
            lblIsActive.Text = _User.IsActive ? "Active" : "Not Active";

            ctrPersonDetails1.PersonID = _User.PersonID;
            ctrPersonDetails1.LoadPersonDetails();

        }


        private void _ResetUserInfo()
        {
            lblUserID.Text = "N/A";
            lblUserName.Text = string.Empty;
            lblIsActive.Text = string.Empty;
            ctrPersonDetails1.PersonID = -1;
        }
    }
}


