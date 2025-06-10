using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drving_VehicleDataAcssecTier;


namespace Drving_VehicleBusinessTier
{
    public class clsTest
    {
            public enum enMode { AddNew = 0, Update = 1 };
            public enMode Mode { get; set; }




            public int TestID { get; set; }
            public int TestAppointmentID { get; set; }
            public bool TestResult { get; set; }
            public string Notes { get; set; }
            public int CreatedByUserID { get; set; }

            public clsTest()
            {
                this.TestID = -1;
                this.TestAppointmentID = -1;
                this.TestResult = false;
                this.Notes = "";
                this.CreatedByUserID = -1;
                Mode = enMode.AddNew;
            }

            private clsTest(int TestID, int TestAppointmentID, bool TestResult, string Notes,
                   int CreatedByUserID)
            {
                this.TestID = TestID;
                this.TestAppointmentID = TestAppointmentID;
                this.TestResult = TestResult;
                this.Notes = Notes;
                this.CreatedByUserID = CreatedByUserID;
                Mode = enMode.Update;
            }

            private bool _AddNewTest()
            {
                //call DataAccess Layer 

                this.TestID = clsTestDate.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes,
                  this.CreatedByUserID);

                return (this.TestID != -1);
            }

            private bool _UpdateTest()
            {
                //call DataAccess Layer 

                return clsTestDate.UpdateTest(this.TestID, this.TestAppointmentID, this.TestResult, this.Notes,
                  this.CreatedByUserID);
            }

            public static clsTest Find(int TestID)
            {
                int TestAppointmentID = -1, CreatedByUserID = -1;
                string Notes = "";
                bool TestResult = false;


                if (clsTestDate.GetTestInfoByID(TestID, ref TestAppointmentID, ref TestResult, ref Notes,ref CreatedByUserID))

                    return new clsTest(TestID, TestAppointmentID , TestResult, Notes,CreatedByUserID);
                else
                    return null;

            }

            public bool Save()
            {
                switch (Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewTest())
                        {

                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:

                        return _UpdateTest();

                }




                return false;
            }

            public static DataTable GetAllTests()
            {
                return clsTestDate.GetAllTests();

            }

            public static bool DeleteTest(int TestID)
            {
                return clsTestDate.DeleteTest(TestID);
            }

            public static bool isTestExist(int TestID)
            {
                return clsTestDate.IsTestExist(TestID);
            }


    }
}
