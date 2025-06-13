using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drving_VehicleDataAcssecTier;

namespace Drving_VehicleBusinessTier
{
    public class clsInternationalLicens
    {
            public enum enMode { AddNew = 0, Update = 1 };
            public enMode Mode = enMode.AddNew;


        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public clsApplication ApplicationInfo;

        public int DriverID { get; set; }
        public clsDriver DriverInfo;
        public int IssuedUsingLocalLicenseID { get; set; }
        public clsLicense LocalLicenseInfo;
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo;




            public clsInternationalLicens()
            {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.MinValue;
            this.ExpiryDate = DateTime.MinValue;
            this.IsActive = false;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
            }

            private clsInternationalLicens(int InternationalLicenseID, int ApplicationID, int DriverID , int IssuedUsingLocalLicenseID,
                 DateTime IssueDate, DateTime ExpiryDate, bool IsActive, int CreatedByUserID)
            {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.ApplicationInfo = clsApplication.FindByApplicationID(this.ApplicationID);
            this.DriverID = DriverID;
            this.DriverInfo = clsDriver.Find(DriverID);
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.LocalLicenseInfo = clsLicense.Find(IssuedUsingLocalLicenseID);
            this.IssueDate = IssueDate;
            this.ExpiryDate = ExpiryDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.FindByUserID(CreatedByUserID);
            Mode = enMode.Update;
            }

            private bool _AddNewInternationalLicens()
            {
                //call DataAccess Layer 

                this.InternationalLicenseID = clsInternationalLicensDate.AddNewInternationalLicens(this.ApplicationID,this.DriverID,
                    this.IssuedUsingLocalLicenseID,this.IssueDate,this.ExpiryDate,this.IsActive,this.CreatedByUserID);

                return (this.InternationalLicenseID != -1);
            }

            private bool _UpdateInternationalLicens()
            {
                //call DataAccess Layer 

                return clsInternationalLicensDate.UpdateInternationalLicens(this.InternationalLicenseID,this.ApplicationID, this.DriverID,
                    this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpiryDate, this.IsActive, this.CreatedByUserID);
            }

            public static clsInternationalLicens Find(int InternationalLicenseID)
            {
                int ApplicationID = -1, DriverID = -1, IssuedUsingLocalLicenseID = -1 , CreatedByUserID = -1;
                DateTime IssueDate = default, ExpiryDate = default;
                bool IsActive = false;
               

                if (clsInternationalLicensDate.GetInternationalLicensInfoByID(InternationalLicenseID, ref  ApplicationID, ref  DriverID,
                    ref  IssuedUsingLocalLicenseID, ref IssueDate, ref  ExpiryDate, ref  IsActive, ref CreatedByUserID))

                    return new clsInternationalLicens(InternationalLicenseID, ApplicationID,  DriverID,
                     IssuedUsingLocalLicenseID,  IssueDate,  ExpiryDate,  IsActive,  CreatedByUserID);
                else
                    return null;
            }

            public bool Save()
            {
                switch (Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewInternationalLicens())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:
                        return _UpdateInternationalLicens();

                }




                return false;
            }

            public static DataTable GetAllInternationalLicenss()
            {
                return clsInternationalLicensDate.GetAllInternationalLicenses();
            }


        public static DataTable GetAllInternationalLicenss_Format()
        {
            return clsInternationalLicensDate.GetAllInternationalLicense_Format();
        }


        public static DataTable GetAllInternationalLicenseHistory_ByPersonId(int LocalDrivingLicenseApplicationID)
        {
            return clsInternationalLicensDate.GetAllInternationalLicenseHistory_ByPersonId(LocalDrivingLicenseApplicationID);
        }

        public static bool DeleteInternationalLicens(int InternationalLicenseID)
            {
                return clsInternationalLicensDate.DeleteInternationalLicense(InternationalLicenseID);
            }

            public static bool isInternationalLicensExist(int InternationalLicenseID)
            {
                return clsInternationalLicensDate.IsInternationalLicensExist(InternationalLicenseID);
            }


        public static int GetInternationalLicensIdByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            return clsInternationalLicensDate.GetInternationalLicenseIddByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);
        }
    }
}
