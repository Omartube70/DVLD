using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Drving_VehicleDataAcssecTier;

namespace Drving_VehicleBusinessTier
{
    public class clsLicense
    {
            public enum enMode { AddNew = 0, Update = 1 };
            public enMode Mode { get; set; }


            public int LicenseID { get; set; }
            public int ApplicationID { get; set; }
            public int DriverID { get; set; }
            public int LicenseClass { get; set; }
            public DateTime IssueDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public string Notes { get; set; }
            public float PaidFees { get; set; }
            public bool IsActive { get; set; }
            public byte IssueReason { get; set; }
            public int CreatedByUserID { get; set; }


        public clsLicense()
            {
                this.LicenseID = -1;
                this.ApplicationID = -1;
                this.DriverID = -1;
                this.LicenseClass = -1;
                this.IssueDate = default;
                this.ExpirationDate = default;
                this.Notes = "";
                this.PaidFees = -1;
                this.IsActive = false;
                this.CreatedByUserID = -1;
                this.IssueReason = 0;
                Mode = enMode.AddNew;
            }

            private clsLicense(int LicenseID, int ApplicationID, int DriverID,
           int LicenseClass, DateTime IssueDate, DateTime ExpirationDate , string Notes , float PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
            {
                this.LicenseID = LicenseID;
              this.ApplicationID = ApplicationID;
                this.DriverID = DriverID;
                this.LicenseClass = LicenseClass;
                this.IssueDate = IssueDate;
                this.ExpirationDate = ExpirationDate;
                this.Notes = Notes;
                this.PaidFees = PaidFees;
                this.IsActive = IsActive;
                this.IssueReason = IssueReason;
                this.CreatedByUserID = CreatedByUserID;
                Mode = enMode.Update;
            }


            private bool _AddNewLicense()
            {
                //call DataAccess Layer 

                this.LicenseID = clsLicenseDate.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate,
                     this.ExpirationDate, this.Notes , this.PaidFees,this.IsActive ,this.IssueReason, this.CreatedByUserID);

                return (this.LicenseID != -1);
            }

            private bool _UpdateLicense()
            {
                //call DataAccess Layer 

                return clsLicenseDate.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate,
                     this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);
            }

            public static clsLicense Find(int LicenseID)
            {
                DateTime IssueDate = default, ExpirationDate = default;
                float PaidFees = -1;
            int ApplicationID = -1, DriverID = -1, LicenseClass = -1;
                 byte IssueReason = 0;
                string Notes = "";
                bool IsActive = false;
                int CreatedByUserID = -1;

            if (clsLicenseDate.GetLicenseInfoByID(LicenseID, ref ApplicationID,
                    ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))

                    return new clsLicense(LicenseID, ApplicationID,
                               DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees ,IsActive ,IssueReason , CreatedByUserID);
                else
                    return null;

            }

            public bool Save()
            {
                switch (Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewLicense())
                        {

                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:

                        return _UpdateLicense();

                }


                return false;
            }

            public static DataTable GetAllLicenses()
            {
                return clsLicenseDate.GetAllLicenses();
            }

        public static DataTable GetAllLocalLicenseHistory_ByPersonId(int PersonID)
        {
            return clsLicenseDate.GetAllLocalLicenseHistory_ByPersonId(PersonID);
        }



        public static bool DeleteLicense(int LicenseID)
            {
                return clsLicenseDate.DeleteLicense(LicenseID);
            }

            public static bool isLicenseExist(int LicenseID)
            {
                return clsLicenseDate.IsLicenseExist(LicenseID);
            }

        public static bool isLicenseExistByPersonID(int PersonID ,int LicenseClassID)
        {
            return clsLicenseDate.isLicenseExistByPersonID(PersonID, LicenseClassID);
        }

        public static int GetLicenseIdByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            return clsLicenseDate.GetLicenseIdByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);
        }



    }
}
