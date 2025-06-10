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
    public partial class ctrPersonCardWithFilters : UserControl
    {
        public event Action<int> OnPersonSelected;

        protected virtual void OnLicenseSelectedEvent(int PersonID)
        {
            OnPersonSelected?.Invoke(PersonID);
        }

        public ctrPersonCardWithFilters()
        {
            InitializeComponent();
            cbColumName.SelectedIndex = 0;
        }

        public int PersonID
        {
            get { return ctrPersonDetails1.PersonID;}
            set {ctrPersonDetails1.PersonID = value; ctrPersonDetails1.LoadPersonDetails(); if(PersonID != -1) OnLicenseSelectedEvent(PersonID);}
        }

        private void FormAdd_PersonAdded(int PersonID)
        {
            this.PersonID = PersonID;
            txtFilterBy.Text = PersonID.ToString();
            cbColumName.SelectedItem = "Person ID";
        }

        private void lblFilter_Click(object sender, EventArgs e)
        {
            if (txtFilterBy.Text == "")
            {
                MessageBox.Show("Palac Enter Filter Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFilterBy.Focus();
                return;
            }

            DataView dataView = clsPerson.GetAllPeople().DefaultView;

            switch (cbColumName.SelectedItem)
            {
                case "Person ID":
                    dataView.RowFilter = $"PersonId = '{txtFilterBy.Text}'";
                    break;

                case "National No.":
                    dataView.RowFilter = $"NationalNo = '{txtFilterBy.Text}'";
                    break;

                case "Phone":
                    dataView.RowFilter = $"Phone = '{txtFilterBy.Text}'";
                    break;

                case "Email":
                    dataView.RowFilter = $"Email = '{txtFilterBy.Text}'";
                    break;
            }


            if (dataView.Count == 1)
            {
                PersonID = Convert.ToInt32(dataView[0]["PersonId"]);
            }
            else
            {
                MessageBox.Show("Person Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbColumName.SelectedItem.ToString() == "Person ID")
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

        public void ShowPersonDetailsAndWritePersonIdAndLookFilter(int PersonID)
        {
            FilterEnabled = false;
            this.PersonID = PersonID;
            txtFilterBy.Text = PersonID.ToString();
            cbColumName.SelectedItem = "Person ID";
            OnLicenseSelectedEvent(PersonID);
        }

        public void FoucsFilter()
        {
            txtFilterBy.Focus();
        }

        public bool FilterEnabled {get { return gbFilter.Enabled; }  set { gbFilter.Enabled = value; } }

        private void lblAddNewPerson_Click(object sender, EventArgs e)
        {
            AddEditPersonInfo formAdd = new AddEditPersonInfo(AddEditPersonInfo.enMode.eAddNew);
            formAdd.PersonAdded += FormAdd_PersonAdded;
            formAdd.ShowDialog();
        }
    }
}
