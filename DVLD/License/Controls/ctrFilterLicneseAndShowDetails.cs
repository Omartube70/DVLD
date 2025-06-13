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

namespace DVLD.Applications
{
    public partial class ctrFilterLicneseAndShowDetails : UserControl
    {

        public event Action<int> OnLicenseSelected;

        protected virtual void OnLicenseSelectedEvent(int LicenseID)
        {
            OnLicenseSelected?.Invoke(LicenseID);
        }



        public ctrFilterLicneseAndShowDetails()
        {
            InitializeComponent();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            else
            {
                e.Handled = false;
            }
        }


        public void WriteLicenseIdToBox_And_LookFilter(int licenseID)
        {
            txtFilterBy.Text = licenseID.ToString();

            LicenseID = Convert.ToInt32(txtFilterBy.Text);

            ctrDriverLicenseInfo1.LoadDateToCtr(LicenseID);
            OnLicenseSelectedEvent(LicenseID);
            LookFilter();
        }

          public void LookFilter()
        {
            gbFilter.Enabled = false;
        }


        public int LicenseID { get; set; } = -1;

        private void lblFilter_Click(object sender, EventArgs e)
        {

            if (!clsLicense.isLicenseExist(Convert.ToInt32(txtFilterBy.Text)))
            {
                MessageBox.Show("License Not Exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            else
            {
                LicenseID = Convert.ToInt32(txtFilterBy.Text);

                ctrDriverLicenseInfo1.LoadDateToCtr(LicenseID);
                OnLicenseSelectedEvent(LicenseID);
            }
        }



    }
}





