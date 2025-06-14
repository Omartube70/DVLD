﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drving_VehicleDataAcssecTier;

namespace Drving_VehicleBusinessTier
{
    public class clsTestAppointment
    {
            public enum enMode { AddNew = 0, Update = 1 };
            public enMode Mode { get; set; }




            public int TestAppointmentID { get; set; }
            public int TestTypeID { get; set; }
            public int LocalDrivingLicenseApplicationID { get; set; }
            public DateTime AppointmentDate { get; set; }
            public float PaidFees { get; set; }
            public int CreatedByUserID { get; set; }
            public bool IsLocked { get; set; }
            public int RetakeTestApplicationID { get; set; }


        public clsTestAppointment()
            {
                this.TestAppointmentID = -1;
                this.TestTypeID = -1;
                this.LocalDrivingLicenseApplicationID = -1;
                this.AppointmentDate = default;
                this.PaidFees = -1;
                this.CreatedByUserID = -1;
                this.IsLocked = false;
            this.RetakeTestApplicationID = -1;
                Mode = enMode.AddNew;
            }

            private clsTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
         float PaidFees, int CreatedByUserID, bool IsLocked , int RetakeTestApplicationID)
            {
                this.TestAppointmentID = TestAppointmentID;
                this.TestTypeID = TestTypeID;
                this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
                this.AppointmentDate = AppointmentDate;
                this.PaidFees = PaidFees;
                this.CreatedByUserID = CreatedByUserID;
                this.IsLocked = IsLocked;
                this.RetakeTestApplicationID = RetakeTestApplicationID;
                Mode = enMode.Update;
            }

            private bool _AddNewTestAppointment()
            {
                //call DataAccess Layer 

                this.TestAppointmentID = clsTestAppointmentDate.AddNewTestAppointment(this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate,
                  this.PaidFees, this.CreatedByUserID, this.IsLocked,this.RetakeTestApplicationID
                  );

                return (this.TestAppointmentID != -1);
            }

            private bool _UpdateTestAppointment()
            {
                //call DataAccess Layer 

                return clsTestAppointmentDate.UpdateTestAppointment(this.TestAppointmentID,this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate,
                  this.PaidFees, this.CreatedByUserID, this.IsLocked,this.RetakeTestApplicationID);
            }

            public static clsTestAppointment Find(int TestAppointmentID)
            {
                int TestTypeID = -1, LocalDrivingLicenseApplicationID = -1 , CreatedByUserID = -1, RetakeTestApplicationID = -1;
                DateTime AppointmentDate = default;
                float PaidFees = -1;
                bool IsLocked = false;


                if (clsTestAppointmentDate.GetTestAppointmentInfoByID(TestAppointmentID, ref  TestTypeID, ref  LocalDrivingLicenseApplicationID, ref  AppointmentDate,
                  ref  PaidFees, ref  CreatedByUserID, ref  IsLocked , ref RetakeTestApplicationID))

                    return new clsTestAppointment(TestAppointmentID , TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate,
                  PaidFees, CreatedByUserID,IsLocked , RetakeTestApplicationID);
                else
                    return null;

            }

            public bool Save()
            {
                switch (Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewTestAppointment())
                        {

                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:

                        return _UpdateTestAppointment();

                }




                return false;
            }

            public static DataTable GetAllTestAppointments()
            {
                return clsTestAppointmentDate.GetAllTestAppointments();

            }

        public static DataTable GetAllTestAppointmentsByLocalDrivingID(int LocalDrivingLicenseApplicationID, clsTestType.enTestTypes TestType)
        {
            return clsTestAppointmentDate.GetAllTestAppointmentsByLocalDrivingID(LocalDrivingLicenseApplicationID ,(int) TestType);

        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
            {
                return clsTestAppointmentDate.DeleteTestAppointment(TestAppointmentID);
            }

            public static bool isTestAppointmentExist(int TestAppointmentID)
            {
                return clsTestAppointmentDate.IsTestAppointmentExist(TestAppointmentID);
            }


        public static bool IsHaveAppointmentUnLocked(int LocalDrivingLicenseApplicationID, clsTestType.enTestTypes enTest)
        {
            return clsTestAppointmentDate.IsHaveAppointmentUnLocked(LocalDrivingLicenseApplicationID , (int)enTest);
        }

        public static bool IsHaveAppointment_IsRetakeTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestTypes enTest)
        {
            return clsTestAppointmentDate.IsHaveAppointment_IsRetakeTest(LocalDrivingLicenseApplicationID, (int)enTest);
        }
    }
}
