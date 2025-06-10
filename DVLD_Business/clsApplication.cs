using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Drving_VehicleDataAcssecTier;

namespace Drving_VehicleBusinessTier
{
    public class clsApplication
    {

        public enum enApplicationTypes
        {
            eNewLocalDrivingLicenseService = 1, eRenewDrivingLicenseService = 2,
            eReplacementforaLostDrivingLicense = 3, eReplacementforaDamagedDrivingLicense = 4, eReleaseDetainedDrivingLicsense = 5,
            eNewInternationalLicense = 6, eRetakeTest = 7
        };

        public enum enMode { AddNew = 0, Update = 1 };
         public enMode Mode { get; set; }

        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };


        public int ApplicationID { get; set; }

        public int ApplicationPersonID { get; set; }
        public clsPerson ApplicationPersonInfo { get; set; }

        public DateTime ApplicationDate { get; set; }

        public int ApplicationTypeID { get; set; }
        public clsApplicationType ApplicationTypeInfo { get; set; }

        public enApplicationStatus ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }

        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo { get; set; }

        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicationPersonID = -1;
            this.ApplicationDate = default;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }

        private clsApplication(int ApplicationID, int ApplicationPersonID,
       DateTime ApplicationDate,
       int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
       float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicationPersonID = ApplicationPersonID;
            this.ApplicationPersonInfo = clsPerson.Find(this.ApplicationPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationType.Find(this.ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.FindByUserID(this.CreatedByUserID);
            Mode = enMode.Update;
        }


        private bool _AddNewApplication()
        {
            //call DataAccess Layer 

            this.ApplicationID = clsApplicationDate.AddNewApplication(this.ApplicationPersonID, this.ApplicationDate, this.ApplicationTypeID, ((int)this.ApplicationStatus),
                 this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
            //call DataAccess Layer 

            return clsApplicationDate.UpdateApplication(this.ApplicationID, this.ApplicationPersonID, this.ApplicationDate,
                 this.ApplicationTypeID, ((int)this.ApplicationStatus), this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        public static clsApplication FindByApplicationID(int ApplicationID)
        {
            DateTime ApplicationDate = default, LastStatusDate = default;
            float PaidFees = -1;
            int ApplicationPersonID = -1, ApplicationTypeID = -1, CreatedByUserID = -1;
            enApplicationStatus Status = enApplicationStatus.New;
            int ApplicationStatus = -1;

            if (clsApplicationDate.GetApplicationInfoByID(ApplicationID, ref ApplicationPersonID,
                ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                Status = (enApplicationStatus)ApplicationStatus;
                return new clsApplication(ApplicationID, ApplicationPersonID,
                           ApplicationDate, ApplicationTypeID, Status, LastStatusDate, PaidFees, CreatedByUserID);
            }

            else
                return null;

        }

         public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplication();

            }




            return false;
        }

        public bool Cancel()
        {
            return clsApplicationDate.UpdateStatus(this.ApplicationID, ((int)enApplicationStatus.Cancelled));
        }

        public bool SetComplete()
        {
            if( clsApplicationDate.UpdateStatus(this.ApplicationID, ((int)enApplicationStatus.Completed)))
            {
                ApplicationStatus = enApplicationStatus.Completed;
                return true;
            }

            return false;
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationDate.GetAllApplications();
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            return clsApplicationDate.DeleteApplication(ApplicationID);
        }

        public static bool isApplicationExist(int ApplicationID)
        {
            return clsApplicationDate.IsApplicationExist(ApplicationID);
        }

        public static int GetActiveApplicationIDforLicenseClass(int PersonID, int LicenseClassID)
        {
            return clsApplicationDate.GetActiveApplicationIDforLicenseClass(PersonID, LicenseClassID);
        }

    }
}
