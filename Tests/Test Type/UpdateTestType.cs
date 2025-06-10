using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Drving_VehicleBusinessTier;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDBussiensTier
{
    public partial class UpdateTestType : Form
    {
        public UpdateTestType(clsTestType.enTestTypes TestTypeID)
        {
            InitializeComponent();
            this._TestTypeID = TestTypeID;
        }

        private clsTestType.enTestTypes _TestTypeID = clsTestType.enTestTypes.eVisionTest;
        private clsTestType _TestType;


        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void ValidateTextField(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                errorProvider1.SetError(textBox, "this failed is requrment!");
                textBox.Focus();
                e.Cancel = true;
            }
            else
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateTestType_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.Find(_TestTypeID);

            if (_TestType != null)
            {
                lblTestTypeID.Text  = ((int)_TestTypeID).ToString();
                txtTitle.Text       = _TestType.Title;
                txtDescription.Text = _TestType.Description;
                txtFees.Text        = _TestType.Fees.ToString();
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("some failed are not valibe!, put the mouse over the red icon(s)",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _TestType.Title = txtTitle.Text;
            _TestType.Description = txtDescription.Text;
            _TestType.Fees = float.Parse(txtFees.Text);



            if (_TestType.UpdateTestType())
            {
                MessageBox.Show("Date Updated Successfully.", "Seved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Date Is not Saved Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


