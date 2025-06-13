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
using DVLDBussiensTier.Applications;

namespace DVLDBussiensTier
{
    public partial class ListInternationalLicenseApplications : Form
    {
        public ListInternationalLicenseApplications()
        {
            InitializeComponent();
            Refrash_dgvInternationalLicense();
        }

        void Refrash_dgvInternationalLicense()
        {
            dgvInternationalLicense.DataSource = clsInternationalLicens.GetAllInternationalLicenss_Format();
            lblRecords.Text = dgvInternationalLicense.RowCount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationlLicenseID = Convert.ToInt32(dgvInternationalLicense.CurrentRow.Cells[0].Value);


            Form frmLicenseHistory = new LicenseHistory(clsApplication.FindByApplicationID(clsInternationalLicens.Find(InternationlLicenseID).ApplicationID).ApplicationPersonID);
            frmLicenseHistory.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationlLicenseID = Convert.ToInt32(dgvInternationalLicense.CurrentRow.Cells[0].Value);


            InternationalDriverInfo InternationalDriverInfo = new InternationalDriverInfo(InternationlLicenseID);
            InternationalDriverInfo.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationlLicenseID = Convert.ToInt32(dgvInternationalLicense.CurrentRow.Cells[0].Value);

            Form frmPrsonDetails = new PersonDetails(clsApplication.FindByApplicationID(clsInternationalLicens.Find(InternationlLicenseID).ApplicationID).ApplicationPersonID);
            frmPrsonDetails.ShowDialog();
        }

        private void lblAddNewApplication_Click(object sender, EventArgs e)
        {
            NewInternationalLicenseApplication internationalLicenseApplication = new NewInternationalLicenseApplication();
            internationalLicenseApplication.ShowDialog();

            Refrash_dgvInternationalLicense();
        }

        private void cbColumName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbColumName.SelectedItem.ToString() == "None")
            {
                txtFilterBy.Visible = false;
                txtFilterBy.Text = "";
                Refrash_dgvInternationalLicense();
            }
            else
            {
                txtFilterBy.Visible = true;
                txtFilterBy.Text = "";
            }
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
                // Verify that the pressed key isn't CTRL or any non-numeric digit
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
        }

        private void txtFilterBy_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtFilterBy.Text == "")
            {
                Refrash_dgvInternationalLicense();
                return;
            }

            DataTable dtLocal = clsInternationalLicens.GetAllInternationalLicenss_Format();

            switch (cbColumName.SelectedItem.ToString())
            {
                case "International ID":
                    dtLocal.DefaultView.RowFilter = "[Int.License ID] = '" + txtFilterBy.Text + "'";
                    break;

                case "Driver ID":
                    dtLocal.DefaultView.RowFilter = "[Driver ID] = '" + txtFilterBy.Text + "'";
                    break;

                case "Local License ID":
                    dtLocal.DefaultView.RowFilter = "[L.License ID] = '" + txtFilterBy.Text + "'";
                    break;

            }

            dgvInternationalLicense.DataSource = dtLocal;
        }
    }
}
