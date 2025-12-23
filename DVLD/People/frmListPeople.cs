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
using DVLD.Classes;
using DVLD_Buisness;

namespace DVLD.People
{
    public partial class frmListPeople : Form
    {
        private const int _RowsPerPage = 100;
        private static int _CurrentPageNumber = 1;
        private static int TotalPages;
        private static int RecordsCount;


        private static DataTable _dtAllPeople;

        //only select the columns that you want to show in the grid
        private DataTable _dtPeople;

        private void _RefreshPeoplList(string FilterColumn = "" , string FilterValue = "")
        {
            if (!string.IsNullOrEmpty(FilterColumn))
            {
                _dtAllPeople = clsPerson.GetPaged(FilterColumn: FilterColumn, FilterValue: FilterValue);
            }
            else
            {
                _dtAllPeople = clsPerson.GetPaged(_CurrentPageNumber, _RowsPerPage);
            }

            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

            dgvPeople.DataSource = _dtPeople;
            lblRecordsCount.Text = dgvPeople.RowCount + "/" + RecordsCount;
        }

        private void _UpdateRecordsAndPageInfo()
        {
            int TotalRecords = 0 , PagedRecords = 0;

            if(clsPerson.GetPagingInfo(ref TotalRecords, ref PagedRecords, _RowsPerPage))
            {
                TotalPages = PagedRecords;
                RecordsCount = TotalRecords;
                lblRecordsCount.Text = RecordsCount.ToString();
                lblPage.Text = _CurrentPageNumber + "/" + TotalPages.ToString();
            }
        }

        public frmListPeople()
        {
            InitializeComponent();
            _UpdateRecordsAndPageInfo();
        }

        private void frmListPeople_Load(object sender, EventArgs e)
        {
            _RefreshPeoplList();
            btnNext.Enabled = (TotalPages > 1);
            cbFilterBy.SelectedIndex = 0;
            if (dgvPeople.Rows.Count > 0)
            {

                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 110;

                dgvPeople.Columns[1].HeaderText = "National No.";
                dgvPeople.Columns[1].Width = 120;


                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 120;

                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[3].Width = 140;


                dgvPeople.Columns[4].HeaderText = "Third Name";
                dgvPeople.Columns[4].Width = 120;

                dgvPeople.Columns[5].HeaderText = "Last Name";
                dgvPeople.Columns[5].Width = 120;

                dgvPeople.Columns[6].HeaderText = "Gendor";
                dgvPeople.Columns[6].Width = 120;

                dgvPeople.Columns[7].HeaderText = "Date Of Birth";
                dgvPeople.Columns[7].Width = 140;

                dgvPeople.Columns[8].HeaderText = "Nationality";
                dgvPeople.Columns[8].Width = 120;


                dgvPeople.Columns[9].HeaderText = "Phone";
                dgvPeople.Columns[9].Width = 120;


                dgvPeople.Columns[10].HeaderText = "Email";
                dgvPeople.Columns[10].Width = 170;
            }

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            string FilterValue = txtFilterValue.Text.Trim();
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (FilterValue == "" || FilterColumn == "None")
            {
                _RefreshPeoplList();
                return;
            }

             _RefreshPeoplList(FilterColumn, FilterValue);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Gendor")
            {
                cbGendor.Visible = true;
                txtFilterValue.Visible = false;
                cbGendor.SelectedIndex = 0;
            }

            else if (cbFilterBy.Text != "None")
            {
                txtFilterValue.Visible = true;
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

            else
            {
                txtFilterValue.Visible = false;
                cbGendor.Visible = false;
                txtFilterValue.Text = "";
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            Form frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Form frm = new frmAddUpdatePerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshPeoplList();

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsPerson.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeoplList();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdatePerson();
            frm.ShowDialog();

            _RefreshPeoplList();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Form frm1 = new frmAddUpdatePerson();
            frm1.ShowDialog();
            _RefreshPeoplList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPeople_DoubleClick(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (cbFilterBy.Text=="Person ID")
              e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtNext_Click(object sender, EventArgs e)
        {
            //Get Next Page
            _CurrentPageNumber++;

            _RefreshPeoplList();

            lblPage.Text = _CurrentPageNumber.ToString()  + "/" + TotalPages;

            if (_CurrentPageNumber == TotalPages)
                btnNext.Enabled = false;
            
            else
                btnNext.Enabled = true;


            btnPrevious.Enabled = (_CurrentPageNumber > 1);
        }

        private void txtPrevious_Click(object sender, EventArgs e)
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

        private void cbGendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "Gendor";
            string FilterValue = cbGendor.Text;

            _RefreshPeoplList(FilterColumn, FilterValue);
        }
    }
}
