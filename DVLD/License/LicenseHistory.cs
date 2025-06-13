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
    public partial class LicenseHistory : Form
    {
        public LicenseHistory(int PersonID)
        {
            InitializeComponent();
            this.PersonID = PersonID;
            ctrFindPersonAndShowDetails1.ShowPersonDetailsAndWritePersonIdAndLookFilter(PersonID);
            LoadRecordesToDgvLocal_And_International();
        }

        
        public int PersonID { get; set; }

        void LoadRecordesToDgvLocal_And_International()
        {
            dgvLocalLicense.DataSource = clsLicense.GetAllLocalLicenseHistory_ByPersonId(PersonID);
            dgvInternationalLicense.DataSource = clsInternationalLicens.GetAllInternationalLicenseHistory_ByPersonId(PersonID);
            lblRecordsLocal.Text = dgvLocalLicense.RowCount.ToString();
            lblRecordsForInternational.Text = dgvInternationalLicense.RowCount.ToString();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalLicenseID = Convert.ToInt32(dgvLocalLicense.CurrentRow.Cells[0].Value);

            LicenseInfo LicenseInfo = new LicenseInfo(LocalLicenseID);
            LicenseInfo.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = Convert.ToInt32(dgvInternationalLicense.CurrentRow.Cells[0].Value);

            InternationalDriverInfo InternationalDriverInfo = new InternationalDriverInfo(InternationalLicenseID);
            InternationalDriverInfo.ShowDialog();
        }
    }
}
