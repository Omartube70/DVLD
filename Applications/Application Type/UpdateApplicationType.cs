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

namespace DVLDBussiensTier.Applications
{
    public partial class UpdateApplicationType : Form
    {
        public UpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();

            this._ApplicationID = ApplicationTypeID;
        }


        private clsApplicationType _ApplicationTypeInfo;
        private int _ApplicationID = -1;



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("some failed are not valibe!, put the mouse over the red icon(s)",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        


            _ApplicationTypeInfo.ApplicationTypeTitle = txtTitle.Text;
            _ApplicationTypeInfo.ApplicationFees = float.Parse(txtFees.Text);



            if (_ApplicationTypeInfo.Save())
            {
                MessageBox.Show("Date Saved Successfully.", "Seved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Date Is not Saved Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadApplicationTypeInfo()
        {
             _ApplicationTypeInfo = clsApplicationType.Find(_ApplicationID);

            if (_ApplicationTypeInfo == null)
            {
                _ResetApplicationTypeInfo();
                MessageBox.Show($"Not Found Application By ID {_ApplicationID}!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _FillApplicationTypeInfo();
        }

        private void _ResetApplicationTypeInfo()
        {
            lblApplicationTypeID.Text = "";
            txtTitle.Text = "";
            txtFees.Text = "";
        }

        private void _FillApplicationTypeInfo()
        {
            lblApplicationTypeID.Text = _ApplicationID.ToString();
            txtTitle.Text = _ApplicationTypeInfo.ApplicationTypeTitle;
            txtFees.Text = _ApplicationTypeInfo.ApplicationFees.ToString();
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                e.Cancel = true;
                txtTitle.Focus();
                errorProvider1.SetError(txtTitle, "Please Enter Application Type Title");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.Clear();
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text))
            {
                e.Cancel = true;
                txtFees.Focus();
                errorProvider1.SetError(txtFees, "Please Enter Application Fees");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.Clear();
            }
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateApplicationType_Load(object sender, EventArgs e)
        {
            LoadApplicationTypeInfo();
        }
    }
}
