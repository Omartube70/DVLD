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
    public partial class ManageApplicationTypes : Form
    {
        public ManageApplicationTypes()
        {
            InitializeComponent();
        }

        private DataTable _dtAllApplicationTypes;

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int ApplicationTypeID = Convert.ToInt32(dgvManageApplicationTypes.CurrentRow.Cells[0].Value);

            UpdateApplicationType frmUpdateApplicationType = new UpdateApplicationType(ApplicationTypeID);
            frmUpdateApplicationType.ShowDialog();

            ManageApplicationTypes_Load(null,null);
        }

        private void ManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _dtAllApplicationTypes = clsApplicationType.GetAllApplicationTypes();
            dgvManageApplicationTypes.DataSource = _dtAllApplicationTypes;
            lblRecords.Text = dgvManageApplicationTypes.RowCount.ToString();


            if (dgvManageApplicationTypes.RowCount > 0)
            {
                dgvManageApplicationTypes.Columns[0].HeaderText = "ID";
                dgvManageApplicationTypes.Columns[0].Width = 110;

                dgvManageApplicationTypes.Columns[1].HeaderText = "Title";
                dgvManageApplicationTypes.Columns[1].Width = 400;

                dgvManageApplicationTypes.Columns[2].HeaderText = "Fees";
                dgvManageApplicationTypes.Columns[2].Width = 100;
            }
        }
    }
}
