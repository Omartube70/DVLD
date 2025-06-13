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
    public partial class ManageTestTypes : Form
    {

       private DataTable _dtAllTestTypes;

        public ManageTestTypes()
        {
            InitializeComponent();
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsTestType.enTestTypes TestTypeID = ((clsTestType.enTestTypes) Convert.ToInt32(dgvTestTypes.CurrentRow.Cells[0].Value));

            UpdateTestType frmUpdateTestType = new UpdateTestType(TestTypeID);
            frmUpdateTestType.ShowDialog();

            ManageTestTypes_Load(null,null);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageTestTypes_Load(object sender, EventArgs e)
        {
             _dtAllTestTypes = clsTestType.GetAllTestTypes();
            dgvTestTypes.DataSource = _dtAllTestTypes;
            lblRecords.Text = dgvTestTypes.Rows.Count.ToString();

            if (dgvTestTypes.Rows.Count > 0)
            {
                dgvTestTypes.Columns[0].HeaderText = "ID";
                dgvTestTypes.Columns[0].Width = 80;

                dgvTestTypes.Columns[1].HeaderText = "Title";
                dgvTestTypes.Columns[1].Width = 140;

                dgvTestTypes.Columns[2].HeaderText = "Description";
                dgvTestTypes.Columns[2].Width = 320;

                dgvTestTypes.Columns[3].HeaderText = "Fees";
                dgvTestTypes.Columns[3].Width = 100;
            }
        }


    }
}
