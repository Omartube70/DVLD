using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Drving_VehicleBusinessTier;

namespace DVLD.Detain
{
    public partial class ListDetainedLicenses : Form
    {
        public ListDetainedLicenses()
        {
            InitializeComponent();
            RefrshDgvDetainLicense();
        }

        void RefrshDgvDetainLicense()
        {
            dgvDetainedLicenseed.DataSource = clsDetainedLicens.GetAllDetainedLicenses_Format();
            lblRecords.Text = dgvDetainedLicenseed.RowCount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Release_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense ReleaseDetainedLicense = new ReleaseDetainedLicense();
            ReleaseDetainedLicense.ShowDialog();

            RefrshDgvDetainLicense();
        }

        private void lblAddNewDetain_Click(object sender, EventArgs e)
        {
            DetainLicense DetainLicensecs = new DetainLicense();
            DetainLicensecs.ShowDialog();

            RefrshDgvDetainLicense();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(dgvDetainedLicenseed.CurrentRow.Cells[1].Value);


            PersonDetails personDetails = new PersonDetails(clsApplication.FindByApplicationID( clsLicense.Find(LicenseID).ApplicationID).ApplicationPersonID);
            personDetails.ShowDialog();

            RefrshDgvDetainLicense();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(dgvDetainedLicenseed.CurrentRow.Cells[1].Value);


            LicenseInfo LicenseInfo = new LicenseInfo(LicenseID);
            LicenseInfo.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(dgvDetainedLicenseed.CurrentRow.Cells[1].Value);


            LicenseHistory LicenseHistory = new LicenseHistory(clsApplication.FindByApplicationID(clsLicense.Find(LicenseID).ApplicationID).ApplicationPersonID);
            LicenseHistory.ShowDialog();

        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            int DetainID = Convert.ToInt32(dgvDetainedLicenseed.CurrentRow.Cells[0].Value);

            if(clsDetainedLicens.Find(DetainID).IsReleased)
            {
                ReleaseDetainToolStripMenuItem.Enabled = false;
            }

            else
            {
                ReleaseDetainToolStripMenuItem.Enabled = true;
            }
        }

        private void ReleaseDetainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(dgvDetainedLicenseed.CurrentRow.Cells[1].Value);


            ReleaseDetainedLicense releaseDetained = new ReleaseDetainedLicense(LicenseID);
            releaseDetained.ShowDialog();

            RefrshDgvDetainLicense();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbColumName.SelectedItem.ToString() == "Detain ID" || cbColumName.SelectedItem.ToString() == "Released Application ID")
            {
                // Verify that the pressed key isn't CTRL or any non-numeric digit
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

            }
            else
            {
                e.Handled = false;

            }
        }

        private void txtFilterBy_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtFilterBy.Text == "")
            {
                RefrshDgvDetainLicense();
                return;
            }






            DataTable dtLocal = clsDetainedLicens.GetAllDetainedLicenses_Format();

            switch (cbColumName.SelectedItem.ToString())
            {
                case "Detain ID":
                    dtLocal.DefaultView.RowFilter = "[D.ID] = " + txtFilterBy.Text + "";
                    break;

                case "Is Released":
                    dtLocal.DefaultView.RowFilter = "[Is Released] LIKE '" + txtFilterBy.Text + "%'";
                    break;

                case "Full Name":
                    dtLocal.DefaultView.RowFilter = "[Full Name] like '" + txtFilterBy.Text + "%'";
                    break;

                case "Status":
                    dtLocal.DefaultView.RowFilter = "[Rlease.App.ID Application ID] = '" + txtFilterBy.Text + "'";
                    break;

                default:
                    RefrshDgvDetainLicense();
                    return;
            }

            dgvDetainedLicenseed.DataSource = dtLocal;

        }

        private void cbColumName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbColumName.SelectedItem.ToString() == "None")
            {
                txtFilterBy.Visible = false;
                txtFilterBy.Text = "";
                RefrshDgvDetainLicense();
            }
            else
            {
                txtFilterBy.Visible = true;
                txtFilterBy.Text = "";
            }
        }
    }
}
