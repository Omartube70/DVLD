using DVLD.Classes;
using DVLD.Licenses.International_License;
using DVLD.People;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Drivers
{
    public partial class frmListDrivers : Form
    {

        private const int _RowsPerPage = 100;
        private static int _CurrentPageNumber = 1;
        private static int TotalPages;
        private static int RecordsCount;


        private static DataTable _dtAllDrivers;
        private DataTable _dtDrivers;

        public frmListDrivers()
        {
            InitializeComponent();
            _UpdateRecordsAndPageInfo();
        }

        private void _RefreshPeoplList(string FilterColumn = "", string FilterValue = "")
        {
            if (!string.IsNullOrEmpty(FilterColumn))
            {
                _dtAllDrivers = clsDriver.GetPaged(FilterColumn: FilterColumn, FilterValue: FilterValue);
            }
            else
            {
                _dtAllDrivers = clsDriver.GetPaged(_CurrentPageNumber, _RowsPerPage);
            }

            _dtDrivers = _dtAllDrivers.DefaultView.ToTable(false, "DriverID", "PersonID",
                                                       "NationalNo", "FullName", "Date", "ActiveLicenses");

            dgvDrivers.DataSource = _dtDrivers;
            lblRecordsCount.Text = dgvDrivers.RowCount + "/" + RecordsCount;
        }

        private void _UpdateRecordsAndPageInfo()
        {
            int TotalRecords = 0, PagedRecords = 0;

            if (clsDriver.GetPagingInfo(ref TotalRecords, ref PagedRecords, _RowsPerPage))
            {
                TotalPages = PagedRecords;
                RecordsCount = TotalRecords;
                lblRecordsCount.Text = RecordsCount.ToString();
                lblPage.Text = _CurrentPageNumber + "/" + TotalPages.ToString();
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            _RefreshPeoplList();
            cbFilterBy.SelectedIndex = 0;

            if (dgvDrivers.Rows.Count>0)
            {
                dgvDrivers.Columns[0].HeaderText = "Driver ID";
                dgvDrivers.Columns[0].Width = 120;

                dgvDrivers.Columns[1].HeaderText = "Person ID";
                dgvDrivers.Columns[1].Width = 120;

                dgvDrivers.Columns[2].HeaderText = "National No.";
                dgvDrivers.Columns[2].Width = 140;

                dgvDrivers.Columns[3].HeaderText = "Full Name";
                dgvDrivers.Columns[3].Width = 320;

                dgvDrivers.Columns[4].HeaderText = "Date";
                dgvDrivers.Columns[4].Width = 170;

                dgvDrivers.Columns[5].HeaderText = "Active Licenses";
                dgvDrivers.Columns[5].Width = 150;
            }
          


        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");
         

            if (cbFilterBy.Text == "None")
            {
                txtFilterValue.Enabled = false;
            }
            else
                txtFilterValue.Enabled = true;

            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllDrivers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "NationalNo")
                //in this case we deal with numbers not string.
                _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllDrivers.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDrivers.CurrentRow.Cells[1].Value;
            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
            //refresh
            frmListDrivers_Load(null, null);

        }

        private void issueInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet.");
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDrivers.CurrentRow.Cells[1].Value;

          
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //Get Previous Page
            _CurrentPageNumber--;

            _RefreshPeoplList();

            lblPage.Text = _CurrentPageNumber.ToString() + "/" + TotalPages;

            if (_CurrentPageNumber == TotalPages)
                btnNext.Enabled = false;

            else
                btnNext.Enabled = true;

            btnPrevious.Enabled = (_CurrentPageNumber > 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //Get Next Page
            _CurrentPageNumber++;

            _RefreshPeoplList();

            lblPage.Text = _CurrentPageNumber.ToString() + "/" + TotalPages;

            if (_CurrentPageNumber == TotalPages)
                btnNext.Enabled = false;

            else
                btnNext.Enabled = true;


            btnPrevious.Enabled = (_CurrentPageNumber > 1);
        }
    }
}
