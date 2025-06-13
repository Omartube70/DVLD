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
    public partial class ManageUsers : Form
    {

        public ManageUsers()
        {
            InitializeComponent();
            cbColumName.SelectedIndex = 0;
        }

        private DataTable _dtAllUsers;
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterBy_KeyUp(object sender, KeyEventArgs e)
        {

            if (txtFilterBy.Text == "")
            {
                ManageUsers_Load(null, null);
                return;
            }



            switch (cbColumName.SelectedItem)
            {
                case "User ID":
                    _dtAllUsers.DefaultView.RowFilter = "[UserID] = '" + txtFilterBy.Text + "'";
                    break;

                case "Person ID":
                    _dtAllUsers.DefaultView.RowFilter = "[PersonId] = '" + txtFilterBy.Text + "'";
                    break;

                case "Full Name":
                    _dtAllUsers.DefaultView.RowFilter = string.Format("[FullName] LIKE '{0}%'", txtFilterBy.Text);
                    break;

                case "UserName":
                    _dtAllUsers.DefaultView.RowFilter = string.Format("[UserName] LIKE '{0}%'", txtFilterBy.Text);
                    break;
            }

            lblRecords.Text = dgvUsers.RowCount.ToString();
        }

        private void cbColumName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageUsers_Load(null, null);
            txtFilterBy.Text = "";

            if (cbColumName.SelectedItem.ToString() == "None")
            {
                txtFilterBy.Visible = false;
                cbIsActive.Visible = false;
                return;
            }

            if(cbColumName.SelectedItem.ToString() == "Is Active")
            {
                txtFilterBy.Visible = false;
                cbIsActive.Visible = true;
                return;
            }

            else
            {
                cbIsActive.Visible = false;
                txtFilterBy.Visible = true;
            }
        }

        private void lblAddNewUser_Click(object sender, EventArgs e)
        {
            AddEditUserInfo frmAddEditUserInfo = new AddEditUserInfo();
            frmAddEditUserInfo.ShowDialog();
            ManageUsers_Load(null, null);
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbColumName.SelectedItem.ToString() == "Person ID" || cbColumName.SelectedItem.ToString() == "User ID")
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

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {


            switch (cbIsActive.SelectedItem)
            {
                case "All":
                    _dtAllUsers.DefaultView.RowFilter = "";
                    break;

                case "Yes":
                    _dtAllUsers.DefaultView.RowFilter = "[IsActive] = '" + true + "'";
                    break;

                case "No":
                    _dtAllUsers.DefaultView.RowFilter = "[IsActive] = '" + false + "'";
                    break;
            }

            lblRecords.Text = dgvUsers.RowCount.ToString();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);

            if (MessageBox.Show($"Are you sure you want to delete User [{UserID}]", "Delete User", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (clsUser.DeleteUser(UserID))
                    ManageUsers_Load(null, null);

                else
                {
                    MessageBox.Show("User was not deleted Because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sendEmaillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Please select a user to send email.");
                return;
            }

            MessageBox.Show("Send Email Will Be Here", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Please select a user to phone call.");
                return;
            }

            MessageBox.Show("Phone Call Will Be Here", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);

            frmUserInfo UserInfo = new frmUserInfo(UserID);
            UserInfo.ShowDialog();

        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);

            ChangePassword frmchangePassword = new ChangePassword(UserID);

            frmchangePassword.ShowDialog();
        }

        private void AddNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditUserInfo frmAddEditUserInfo = new AddEditUserInfo();
            frmAddEditUserInfo.ShowDialog();
            ManageUsers_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);


            AddEditUserInfo frmEditUser = new AddEditUserInfo(UserID);

            frmEditUser.ShowDialog();
            ManageUsers_Load(null,null);
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            _dtAllUsers = clsUser.GetAllUsers();
            dgvUsers.DataSource = _dtAllUsers;
            lblRecords.Text = dgvUsers.RowCount.ToString();

            if(dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";

                dgvUsers.Columns[1].HeaderText = "Person ID";

                dgvUsers.Columns[2].HeaderText = "Full Name";

                dgvUsers.Columns[3].HeaderText = "UserName";

                dgvUsers.Columns[4].HeaderText = "Is Active";
            }

        }
    }
}
