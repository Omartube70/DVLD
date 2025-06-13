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
using DVLDBussiensTier.Global_Classes;

namespace DVLDBussiensTier
{
    public partial class ManagePeople : Form
    {

        private void _LoadColumName()
        {
            DataTable dtColum = new DataTable();

            dtColum.Columns.Add("ColumName", typeof(string));

            dtColum.Rows.Add("None");

            foreach (DataGridViewColumn column in dgvPeople.Columns)
            {
                if(column.HeaderText != "Date of Birth") 
                    dtColum.Rows.Add(column.Name);
            }



            cbColumName.DataSource = dtColum;
            cbColumName.DisplayMember = "ColumName";
            cbColumName.ValueMember = "ColumName";
        }
    
       private  void _RefreshDgvPeople()
        {
            dgvPeople.DataSource = clsPerson.GetAllPeople_Format();
            lblRecords.Text = dgvPeople.RowCount.ToString();
        }


        public ManagePeople()
        {
            InitializeComponent();
            _RefreshDgvPeople();
            _LoadColumName();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblAddNewPerson_Click(object sender, EventArgs e)
        {
            Form frmAddNewPerson = new AddEditPersonInfo(AddEditPersonInfo.enMode.eAddNew);
            frmAddNewPerson.ShowDialog();
            _RefreshDgvPeople();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAddNewPerson = new AddEditPersonInfo(AddEditPersonInfo.enMode.eAddNew);
            frmAddNewPerson.ShowDialog();
            _RefreshDgvPeople();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {              
            int personID = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);
            PersonDetails frmDetails = new PersonDetails(personID);
            frmDetails.ShowDialog(); 
            _RefreshDgvPeople();
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int PersonID = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);


            Form frmAddNewPerson = new AddEditPersonInfo(AddEditPersonInfo.enMode.eUpdate, PersonID);
            frmAddNewPerson.ShowDialog();

            _RefreshDgvPeople();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);

            if(MessageBox.Show($"Are you sure you want to delete Person [{personID}]", "Delete Person", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string ImagePath = clsPerson.Find(personID).ImagePath;

                if (clsPerson.DeletePerson(personID))
                {
                    if (!string.IsNullOrEmpty(ImagePath))
                    {
                        if (!clsUtil.RemoveImageFile(ImagePath))
                        {
                            return;
                        }
                    }

                    _RefreshDgvPeople();
                }
                else
                {
                    MessageBox.Show("Person was not deleted Because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sendEmaillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Send Email Will Be Here", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phone Call Will Be Here", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cbColumName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbColumName.SelectedIndex == 0)
            {
                txtFilterBy.Visible = false;
                _RefreshDgvPeople();
                return;
            }

            txtFilterBy.Visible = true;
            txtFilterBy.Text = "";
        }

        private void txtFilterBy_KeyUp(object sender, KeyEventArgs e)
        {
            _RefreshDgvPeople();

            if (txtFilterBy.Text == "")
            {
                return;
            }


            DataView dataView =  ((DataTable)dgvPeople.DataSource).DefaultView;


            if (cbColumName.Text == "Person ID")
                dataView.RowFilter = string.Format("[{0}] = {1}", cbColumName.SelectedValue, txtFilterBy.Text);

            else
                dataView.RowFilter = string.Format("[{0}] LIKE '{1}%'", cbColumName.SelectedValue, txtFilterBy.Text); 


            dgvPeople.DataSource = dataView;
            lblRecords.Text = dgvPeople.RowCount.ToString();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbColumName.SelectedValue.ToString() == "Person ID")
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
    }
}







