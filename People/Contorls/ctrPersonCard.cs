using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Drving_VehicleBusinessTier;
using DVLDBussiensTier.Properties;

namespace DVLDBussiensTier
{
    public partial class ctrPersonDetails : UserControl
    {
        public ctrPersonDetails()
        {
            InitializeComponent();
        }

        public int PersonID {get; set;}

        public void LoadPersonDetails()
        {
            clsPerson person = clsPerson.Find(PersonID);

            if (person == null)
            {
                return;
            }

            lblFullNae.Text = person.FullName;
            lblNationalNo.Text = person.NationalNo;
            lblDateOfBirth.Text = person.DateOfBirth.ToString("dd/MM/yyyy");
            lblGendor.Text = (person.Gendor == 0) ? "Male" : "Femail";
            lblAddress.Text = person.Address;
            lblPhone.Text = person.Phone;
            lblEmail.Text = person.Email;
            lblCountry.Text = clsCountry.Find(person.NationalityCountryID).CountryName;
            lblPersonID.Text = person.PersonID.ToString();

            if (!string.IsNullOrEmpty(person.ImagePath) && File.Exists(person.ImagePath))
            {
                pictureBox1.ImageLocation = person.ImagePath;
            }
            else
            {
                pictureBox1.Image = Resources.magnifier;
            }
        }


        private void llblEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frmUpdate = new AddEditPersonInfo(AddEditPersonInfo.enMode.eUpdate, PersonID);
            frmUpdate.ShowDialog();

            LoadPersonDetails();
        }
    }
}
