using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Drving_VehicleDataAcssecTier;
using static System.Net.Mime.MediaTypeNames;

namespace Drving_VehicleBusinessTier
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
            public enum enMode { AddNew = 0, Update = 1 };
            public enMode Mode = enMode.AddNew;


            public int LocalDrivingLicenseApplicationID { get; set; }
            
            public int LicenseClassID { get; set; }
            public clsLicenseClass LicenseClassInfo { get; set; }



            public clsLocalDrivingLicenseApplication()
            {
                this.LocalDrivingLicenseApplicationID = -1;
                this.LicenseClassID = -1;
                Mode = enMode.AddNew;
            }

            private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID,int ApplicationID, int ApplicationPersonID,
                     DateTime ApplicationDate,int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
                     float PaidFees, int CreatedByUserID, int LicenseClassID)
              {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
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
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClass.Find(this.LicenseClassID);
            Mode = enMode.Update;
              }

            private bool _AddNewLocalDrivingLicenseApplication()
            {
                //call DataAccess Layer 

                this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsDate.AddNewLocalDrivingLicenseApplication(ApplicationID, LicenseClassID);

                return (this.LocalDrivingLicenseApplicationID != -1);
            }

            private bool _UpdateLocalDrivingLicenseApplication()
            {
                //call DataAccess Layer 

                return clsLocalDrivingLicenseApplicationsDate.UpdateLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
            }

            public static clsLocalDrivingLicenseApplication FindByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
            {
                int ApplicationID = -1 , LicenseClassID = -1;

             clsLocalDrivingLicenseApplicationsDate.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID);

             clsApplication BaseApplication = clsApplication.FindByApplicationID(ApplicationID);

            if (BaseApplication != null) 
            {
                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, BaseApplication.ApplicationPersonID,
                         BaseApplication.ApplicationDate, BaseApplication.ApplicationTypeID,
                         BaseApplication.ApplicationStatus, BaseApplication.LastStatusDate, BaseApplication.PaidFees, BaseApplication.CreatedByUserID, LicenseClassID);
            }



                return null;
            }

            public bool Save()
            {
               base.Mode = (clsApplication.enMode) this.Mode;

                if (!base.Save())
                   return false;


                switch (Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewLocalDrivingLicenseApplication())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:
                        return _UpdateLocalDrivingLicenseApplication();

                }

                return false;
            }

        public static DataTable GetAllLocalDrivingLicenseApplications()
            {
                return clsLocalDrivingLicenseApplicationsDate.GetAllLocalDrivingLicenseApplications();
            }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
            {
              clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);

           if(clsLocalDrivingLicenseApplicationsDate.DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID))
            {
                return clsApplication.DeleteApplication(localDrivingLicenseApplication.ApplicationID);
            }


           return false;
        }

        public static bool isLocalDrivingLicenseApplicationExist(int LocalDrivingLicenseApplicationID)
            {
                return clsLocalDrivingLicenseApplicationsDate.IsLocalDrivingLicenseApplicationExist(LocalDrivingLicenseApplicationID);
            }

        public int GetPassedTest()
        {
            return GetPassedTest(LocalDrivingLicenseApplicationID);
        }
        static public int GetPassedTest(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationsDate.GetPassedTestByID(LocalDrivingLicenseApplicationID);
        }


        public bool IsPassedTest(clsTestType.enTestTypes enTest)
        {
            return IsPassedTest(this.LocalDrivingLicenseApplicationID, enTest);
        }
        static public bool IsPassedTest(int LocalDrivingLicenseApplicationID  , clsTestType.enTestTypes enTest)
        {
            int PassedTest = GetPassedTest(LocalDrivingLicenseApplicationID);

            if (enTest == clsTestType.enTestTypes.eVisionTest)
            {
                return (PassedTest == 1);
            }

            if (enTest == clsTestType.enTestTypes.eWrittenTest)
            {
                return (PassedTest == 2);
            }

            if (enTest == clsTestType.enTestTypes.eStreetTest)
            {
                return (PassedTest == 3);
            }


            return false;
        }

        public bool IsPassedAllTests()
        {
            return (GetPassedTest() == 3);
        }
        public int IssueLicenseFirstTime(string Notes , int CreatedByUserID)
        {
            if(!IsPassedAllTests())
                return -1;

            if(GetActiveApplicationIDforLicenseClass(ApplicationPersonID, LicenseClassID) == -1)
            {
                return -1; // Person has another application with new or completed status
            }

            int DriverID = clsDriver.GetDriverIdByPersonID(ApplicationPersonID);

            if (DriverID == -1)
            {
                clsDriver Driver = new clsDriver();

                Driver.CreatedByUserID = CreatedByUserID;
                Driver.CreatedDate = DateTime.Now;
                Driver.PersonID = ApplicationPersonID;

                if (Driver.Save())
                {
                    DriverID = Driver.DriverID;
                }

            }

            if (DriverID != -1)
            {
                clsLicense license = new clsLicense();

                license.ApplicationID = ApplicationID;
                license.Notes = Notes;
                license.IssueDate = DateTime.Now;
                license.ExpirationDate = DateTime.Now.AddYears(LicenseClassInfo.DefaultValidityLength);
                license.CreatedByUserID = CreatedByUserID;
                license.IsActive = true;
                license.PaidFees = LicenseClassInfo.ClassFees;
                license.DriverID = DriverID;
                license.IssueReason = ((int)clsApplication.enApplicationTypes.eNewLocalDrivingLicenseService);
                license.LicenseClass = LicenseClassInfo.LicenseClassID;


                if (license.Save())
                {
                    if (SetComplete())
                    {
                        if (Save())
                        {
                            return license.LicenseID;
                        }
                    }
                }


            }

            return -1;
        }

    }
}















