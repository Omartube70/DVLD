using DVLD.Licenses.International_License;
using DVLD.Licenses.International_Licenses;
using DVLD.People;
using DVLD_Buisness;
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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Applications.International_License
{
    public partial class frmListInternationalLicesnseApplications : Form
    {
        private const int _RowsPerPage = 100;
        private static int _CurrentPageNumber = 1;
        private static int TotalPages;
        private static int RecordsCount;


        private static DataTable _dtAllInternationalLicenseApplications;
        private DataTable _dtInternationalLicenseApplications;


        private void _RefreshInternationalLicenseApplicationsList(string FilterColumn = "", string FilterValue = "")
        {
            if (!string.IsNullOrEmpty(FilterColumn))
            {
                _dtAllInternationalLicenseApplications = clsInternationalLicense.GetPaged(FilterColumn: FilterColumn, FilterValue: FilterValue);
            }
            else
            {
                _dtAllInternationalLicenseApplications = clsInternationalLicense.GetPaged(_CurrentPageNumber, _RowsPerPage);
            }

            _dtInternationalLicenseApplications = _dtAllInternationalLicenseApplications.DefaultView.ToTable(false, "InternationalLicenseID", "ApplicationID",
                                                       "DriverID", "IssuedUsingLocalLicenseID", "IssueDate", "ExpirationDate","IsActive");

            dgvInternationalLicenses.DataSource = _dtInternationalLicenseApplications;
            lblInternationalLicensesRecords.Text = dgvInternationalLicenses.RowCount + "/" + RecordsCount;
        }

        private void _UpdateRecordsAndPageInfo()
        {
            int TotalRecords = 0, PagedRecords = 0;

            if (clsInternationalLicense.GetPagingInfo(ref TotalRecords, ref PagedRecords, _RowsPerPage))
            {
                TotalPages = PagedRecords;
                RecordsCount = TotalRecords;
                lblInternationalLicensesRecords.Text = RecordsCount.ToString();
                lblPage.Text = _CurrentPageNumber + "/" + TotalPages.ToString();
            }
        }

        public frmListInternationalLicesnseApplications()
        {
            InitializeComponent();
            _UpdateRecordsAndPageInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListInternationalLicesnseApplications_Load(object sender, EventArgs e)
        {
            _RefreshInternationalLicenseApplicationsList();
            cbFilterBy.SelectedIndex = 0;
            btnNext.Enabled = (TotalPages > 1);

            if (dgvInternationalLicenses.Rows.Count > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenses.Columns[0].Width = 160;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 150;

                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenses.Columns[2].Width = 130;

                dgvInternationalLicenses.Columns[3].HeaderText = "L.License ID";
                dgvInternationalLicenses.Columns[3].Width = 130;

                dgvInternationalLicenses.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[4].Width = 180;

                dgvInternationalLicenses.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[5].Width = 180;

                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[6].Width = 120;

            }
        }

        private void btnNewApplication_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
            //refresh
            frmListInternationalLicesnseApplications_Load(null,null);

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)dgvInternationalLicenses.CurrentRow.Cells[0].Value;
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(InternationalLicenseID);
            frm.ShowDialog();
        }

        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int DriverID = (int)dgvInternationalLicenses.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;

            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicenses.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
            }

            else

            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsReleased.Visible = false;

                if (cbFilterBy.Text == "None")
                {
                    txtFilterValue.Enabled = false;
               
                }
                else
                    txtFilterValue.Enabled = true;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsReleased.Text;

            switch (FilterValue)
            {
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }

            _RefreshInternationalLicenseApplicationsList(FilterColumn, FilterValue);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
          

            string FilterColumn = "";
            string FilterValue = txtFilterValue.Text.Trim();
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Application ID":
                        FilterColumn = "ApplicationID";
                        break;

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;


                default:
                    FilterColumn = "None";
                    break;
            }

            _RefreshInternationalLicenseApplicationsList(FilterColumn, FilterValue);

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow numbers only becasue all fiters are numbers.
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //Get Previous Page
            _CurrentPageNumber--;

            _RefreshInternationalLicenseApplicationsList();

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

            _RefreshInternationalLicenseApplicationsList();

            lblPage.Text = _CurrentPageNumber.ToString() + "/" + TotalPages;

            if (_CurrentPageNumber == TotalPages)
                btnNext.Enabled = false;

            else
                btnNext.Enabled = true;


            btnPrevious.Enabled = (_CurrentPageNumber > 1);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
