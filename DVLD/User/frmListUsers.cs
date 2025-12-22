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

namespace DVLD.User
{
    public partial class frmListUsers : Form
    {
        private const int _RowsPerPage = 50;
        private static int _CurrentPageNumber = 1;
        private static int TotalPages;
        private static int RecordsCount;


        private static DataTable _dtAllUsers ;
        private DataTable _dtUsers;

        public frmListUsers()
        {
            InitializeComponent();
            _UpdateRecordsAndPageInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _RefreshUsersList(string FilterColumn = "", string FilterValue = "")
        {
            if (!string.IsNullOrEmpty(FilterColumn))
            {
                _dtAllUsers = clsUser.GetPaged(FilterColumn: FilterColumn, FilterValue: FilterValue);
            }
            else
            {
                _dtAllUsers = clsUser.GetPaged(_CurrentPageNumber, _RowsPerPage);
            }

            _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "UserID", "PersonID",
                "FullName", "UserName", "IsActive");

            dgvUsers.DataSource = _dtUsers;
            lblRecordsCount.Text = dgvUsers.RowCount + "/" + RecordsCount;
        }

        private void _UpdateRecordsAndPageInfo()
        {
            int TotalRecords = 0, PagedRecords = 0;

            if (clsUser.GetPagingInfo(ref TotalRecords, ref PagedRecords, _RowsPerPage))
            {
                RecordsCount = TotalRecords;
                TotalPages = PagedRecords;
                lblRecordsCount.Text = RecordsCount.ToString();
                lblPage.Text = _CurrentPageNumber + "/" + TotalPages.ToString();
            }
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _RefreshUsersList();

            cbFilterBy.SelectedIndex = 0;

            dgvUsers.Columns[0].HeaderText = "User ID";
            dgvUsers.Columns[0].Width = 110;

            dgvUsers.Columns[1].HeaderText = "Person ID";
            dgvUsers.Columns[1].Width = 120;

            dgvUsers.Columns[2].HeaderText = "Full Name";
            dgvUsers.Columns[2].Width = 350;

            dgvUsers.Columns[3].HeaderText = "UserName";
            dgvUsers.Columns[3].Width = 120;

            dgvUsers.Columns[4].HeaderText = "Is Active";
            dgvUsers.Columns[4].Width = 120;

           
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible= false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            } 
            
            else

            {
                
                txtFilterValue.Visible = (cbFilterBy.Text !="None") ;
                cbIsActive.Visible = false;

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

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            string FilterValue = txtFilterValue.Text.Trim();
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
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
                _RefreshUsersList();
                return;
            }

            _RefreshUsersList(FilterColumn,FilterValue);
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
          string FilterColumn = "IsActive";
          string FilterValue = cbIsActive.Text;

            _RefreshUsersList(FilterColumn,FilterValue);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser Frm1 = new frmAddUpdateUser ();
            Frm1.ShowDialog();
            frmListUsers_Load(null, null);  
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAddUpdateUser Frm1 = new frmAddUpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            Frm1.ShowDialog();
            frmListUsers_Load(null, null);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser Frm1 = new frmAddUpdateUser();
            Frm1.ShowDialog();
            frmListUsers_Load(null, null);

        }

        private void dgvUsers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmUserInfo Frm1 = new frmUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            Frm1.ShowDialog();
           
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo Frm1 = new frmUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            Frm1.ShowDialog();
           
        }

        private void ChangePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {

            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            frmChangePassword Frm1 = new frmChangePassword(UserID);
            Frm1.ShowDialog();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            if (clsUser.DeleteUser(UserID))
            {
                MessageBox.Show("User has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmListUsers_Load(null, null);
            }

            else
                MessageBox.Show("User is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);


            


        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //Get Previous Page
            _CurrentPageNumber--;

            _RefreshUsersList();

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

            _RefreshUsersList();

            lblPage.Text = _CurrentPageNumber.ToString() + "/" + TotalPages;

            if (_CurrentPageNumber == TotalPages)
                btnNext.Enabled = false;

            else
                btnNext.Enabled = true;


            btnPrevious.Enabled = (_CurrentPageNumber > 1);
        }
    }
}
