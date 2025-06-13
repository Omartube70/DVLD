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

namespace DVLDBussiensTier.Detain
{
    public partial class DetainLicense : Form
    {
        public DetainLicense()
        {
            InitializeComponent();
            LoadDateToForm();
        }


        void LoadDateToForm()
        {
            lblLDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void ctrFilterLicneseAndShowDetails1_OnLicenseSelected(int obj)
        {
            lblLcenseID.Text = obj.ToString();


            clsDetainedLicens detainedLicens = clsDetainedLicens.Find( clsDetainedLicens.GetDetainIdByLicenseId(obj));

                   if(detainedLicens != null)
                 {
                       if(!detainedLicens.IsReleased)
                       {
                              MessageBox.Show("Selected License i alardy detained, choose anthoer one","not allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                              btDetain.Enabled = false;
                    return;
                }
            } 


                btDetain.Enabled = true;
        }

        private void btDetain_Click(object sender, EventArgs e)
        {
            if (ctrFilterLicneseAndShowDetails1.LicenseID == -1)
            {
                MessageBox.Show($"Place Select Local License First!", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(MessageBox.Show("Are you sure you want to detain this license?", "Confirem", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes))
            {
                return;
            }


            clsDetainedLicens detainedLicens = new clsDetainedLicens();

            detainedLicens.LicenseID = ctrFilterLicneseAndShowDetails1.LicenseID;
            detainedLicens.DetainDate = DateTime.Now;
            detainedLicens.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            detainedLicens.IsReleased = false;
            detainedLicens.FineFees = (float) nudFineFees.Value;

            if (detainedLicens.Save())
            {
                MessageBox.Show($"License Detained Successfully with id {detainedLicens.DetainID}", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btDetain.Enabled = false;
                lbShowLicenseInfo.Enabled = true;
                nudFineFees.Enabled = false;
                ctrFilterLicneseAndShowDetails1.LookFilter();

                lblDetainID.Text = detainedLicens.DetainID.ToString();

            }
            else
            {
                MessageBox.Show($"Error Saved Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseInfo frmLicenseInfo = new LicenseInfo(ctrFilterLicneseAndShowDetails1.LicenseID);
            frmLicenseInfo.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonId = clsApplication.FindByApplicationID(clsLicense.Find(ctrFilterLicneseAndShowDetails1.LicenseID).ApplicationID).ApplicationPersonID;

            Form frmLicenseHistory = new LicenseHistory(PersonId);
            frmLicenseHistory.ShowDialog();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nudFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (nudFineFees.Value <= 0)
            {
                errorProvider1.SetError(nudFineFees, "Palace Enter Fine Fees!");
                e.Cancel = true;
                btDetain.Enabled = false;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
                btDetain.Enabled = true;

            }

        }
    }
}








