using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Drving_VehicleBusinessTier;
using DVLD.Global_Classes;
using DVLD.Properties;

namespace DVLD
{
    public partial class AddEditPersonInfo : Form
    {
        public delegate void PersonAddedEventHandler(int personID);

        public event PersonAddedEventHandler PersonAdded;

        public enum enMode { eAddNew, eUpdate };
        public enMode Mode { get; set; }

        public int PersonID { get; set; } = -1;


        public AddEditPersonInfo(enMode mode, int personID = -1)
        {
            InitializeComponent();
            LoadCountryList();
            Mode = mode;
            this.PersonID = personID;
        }

        public void PopulatePersonDetails()
        {
            if (PersonID == -1)
            {
                return;
            }

            clsPerson person = clsPerson.Find(PersonID);

            if (person == null)
            {
                return;
            }

            lblPersonID.Text = person.PersonID.ToString();
            txtFirstName.Text = person.FirstName;
            txtSecondName.Text = person.SecondName;
            txtMiddleName.Text = person.FirstName;
            txtLastName.Text = person.LastName;
            txtNationalID.Text = person.NationalNo;
            dtpDateOfBirth.Value = person.DateOfBirth;

            if (!string.IsNullOrEmpty(person.ImagePath) && File.Exists(person.ImagePath))
            {
                picPersonImage.ImageLocation = person.ImagePath;
                lnkSetImage.Visible = false;
                lnkRemoveImage.Visible = true;
            }

            if (person.Gendor == 0)
            {
                rdMale.Checked = true;
            }
            else
            {
                rdFemale.Checked = true;
            }

            txtPhoneNumber.Text = person.Phone;
            txtEmailAddress.Text = person.Email;
            cmbCountries.SelectedValue = person.NationalityCountryID;
            txtHomeAddress.Text = person.Address;
        }

        private void LoadCountryList()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();
            cmbCountries.DataSource = dtCountries;
            cmbCountries.DisplayMember = "CountryName";
            cmbCountries.ValueMember = "CountryID";
        }

        void UpdateFormTitle()
        {
            if (Mode == enMode.eUpdate)
            {
                PopulatePersonDetails();
                lblFormStatus.Text = "Update Person";
                this.Name = "Update Person";
            }
            else
            {
                lblFormStatus.Text = "Add New Person";
                this.Name = "Add New Person";
            }
        }

        void SetMaxDateOfBirth()
        {
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
        }

        void ConfigureImageDialog()
        {
            dlgOpenImage.Filter = "|*.jpg;*.png;*.jpeg";
        }

        private void AddEditPersonInfo_Load(object sender, EventArgs e)
        {
            SetMaxDateOfBirth();
            UpdateFormTitle();
            ConfigureImageDialog();
        }


        private void lnkSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dlgOpenImage.ShowDialog() == DialogResult.OK)
            {
                picPersonImage.ImageLocation = dlgOpenImage.FileName;
                lnkSetImage.Visible = false;
                lnkRemoveImage.Visible = true;
            }
        }

        private void lnkRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            picPersonImage.Image = Resources.magnifier;
            picPersonImage.ImageLocation = null;
            lnkRemoveImage.Visible = false;
            lnkSetImage.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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


        private void txtNationalID_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextField(sender, e);

            if (!e.Cancel)
            {

                if (Mode == enMode.eUpdate)
                {
                    if (txtNationalID.Text == clsPerson.Find(PersonID).NationalNo)
                    {
                        errorProvider1.Clear();
                        btnSave.Enabled = true;
                        return;
                    }
                    
                }


               if (clsPerson.IsNationalNumberExists(txtNationalID.Text))
                    {
                        errorProvider1.SetError(txtNationalID, "National ID already exists.");
                        txtNationalID.Focus();
                        e.Cancel = true;
                        btnSave.Enabled = false;
                }
               else
                 {
                        errorProvider1.Clear();
                        btnSave.Enabled = true;

                }

            }
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) 
                return false;

            var emailRegex = new System.Text.RegularExpressions.Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",System.Text.RegularExpressions.RegexOptions.Compiled);

            return emailRegex.IsMatch(email);
        }

        private void txtEmailAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmailAddress.Text))
            {
                errorProvider1.Clear();
                e.Cancel = false;
                return;
            }

            if (IsValidEmail(txtEmailAddress.Text))
            {
                errorProvider1.Clear();
                e.Cancel = false;
            }
            else
            {
                errorProvider1.SetError(txtEmailAddress, "Email is not valid");
                txtEmailAddress.Focus();
                btnSave.Enabled = false;
                e.Cancel = true;
            }
        }

       private void _HandlPersonImage(ref clsPerson person)
        {

            if (!string.IsNullOrEmpty(person.ImagePath) && picPersonImage.ImageLocation != person.ImagePath)
            {
              clsUtil.RemoveImageFile(person.ImagePath);
            }


            if (!string.IsNullOrEmpty(picPersonImage.ImageLocation) && picPersonImage.Image != Resources.magnifier)
            {
                if (person.ImagePath != picPersonImage.ImageLocation)
                {

                    string savedLocation = "C:\\DVLD People Image\\" + Guid.NewGuid().ToString() + clsUtil.GetImageExtinon(picPersonImage.ImageLocation);
                    File.Copy(picPersonImage.ImageLocation, savedLocation);

                    
                    person.ImagePath = savedLocation;
                    return;
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("some failed are not valibe!, put the mouse over the red icon(s)", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsPerson person = null;

            if (Mode == enMode.eAddNew)
            {
                person = new clsPerson();
            }
            else
            {
                if (PersonID != -1)
                {
                    person = clsPerson.Find(PersonID);
                }
            }

            if (person == null)
            {
                MessageBox.Show("Failed to save person.");
                return;
            }

            person.FirstName = txtFirstName.Text;
            person.SecondName = txtSecondName.Text;
            person.ThirdName = txtMiddleName.Text;
            person.LastName = txtLastName.Text;

            person.Gendor = (byte) ((rdMale.Checked == true) ? 0 : 1);

            person.DateOfBirth = dtpDateOfBirth.Value;
            person.NationalNo = txtNationalID.Text;
            person.NationalityCountryID = (int)cmbCountries.SelectedValue;
            person.Phone = txtPhoneNumber.Text;
            person.Email = txtEmailAddress.Text;
            person.Address = txtHomeAddress.Text;

            _HandlPersonImage(ref person);

            if (person.Save())
            {
                MessageBox.Show("Data saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.PersonID = person.PersonID;
                lblPersonID.Text = person.PersonID.ToString();
                PersonAdded?.Invoke(person.PersonID);
                btnSave.Enabled = false;
            }
        }


    }
}
