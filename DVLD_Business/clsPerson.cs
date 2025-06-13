using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drving_VehicleDataAcssecTier;

namespace Drving_VehicleBusinessTier
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode { get; set; }



        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {SecondName} {ThirdName} {LastName}";
            }
        }
        
        public DateTime DateOfBirth { get; set; }
        public byte Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }

        public string ImagePath { get; set; }


        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalityCountryID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Gendor = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.ImagePath = "";
            this.DateOfBirth = default;
            Mode = enMode.AddNew;
        }

        private clsPerson(int PersonID, string NationalNo, string FirstName,
     string SecondName,  string ThirdName,  string LastName,  DateTime DateOfBirth,  byte Gendor,  string Address
            , string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalityCountryID = NationalityCountryID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.ImagePath = ImagePath;
            this.DateOfBirth = DateOfBirth;
            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                 this.LastName, this.DateOfBirth, this.Gendor, this.Address , this.Phone , this.Email , this.NationalityCountryID , this.ImagePath);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return clsPersonData.UpdatePerson(this.PersonID,this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                 this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public static clsPerson Find(int PersonID)
        {

            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "" , ImagePath = "";
            DateTime DateOfBirth = default;
            byte Gendor = 0;
            string Address = "", Phone = "", Email = "";
            int NationalityCountryID = -1;


            if (clsPersonData.GetPersonInfoByID(PersonID,ref NationalNo, ref FirstName,
                          ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor,
                          ref Address, ref Phone , ref Email , ref NationalityCountryID , ref ImagePath))

                return new clsPerson(PersonID, NationalNo,
                           FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor
                           , Address, Phone, Email, NationalityCountryID,ImagePath);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }




            return false;
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();

        }

        public static DataTable GetAllPeople_Format()
        {
            return clsPersonData.GetAllPeople_Format();

        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }

        public static bool isPersonExist(int PersonID)
        {
            return clsPersonData.IsPersonExist(PersonID);
        }

        public static bool IsNationalNumberExists(string NationalNo)
        {
            return clsPersonData.IsNationalNumberExists(NationalNo);
        }

        public static int GetPersonAge(int PersonID)
        {
            return (DateTime.Now - clsPerson.Find(PersonID).DateOfBirth).Days / 365;
        }

        public void SendEmail(string Subject , string Messge)
        {
            string EmailToSend = this.Email;



            // Code To Send Email

        }

    }


}
