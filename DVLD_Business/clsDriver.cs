using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drving_VehicleDataAcssecTier;

namespace Drving_VehicleBusinessTier
{
    public class clsDriver
    {
            public enum enMode { AddNew = 0, Update = 1 };
            public enMode Mode = enMode.AddNew;


            public int DriverID { get; set; }
            public int PersonID { get; set; }
            public int CreatedByUserID { get; set; }
            public DateTime CreatedDate { get; set; }




            public clsDriver()
            {
                this.DriverID = -1;
                this.PersonID = -1;
                this.CreatedByUserID = -1;
                this.CreatedDate = default;
                Mode = enMode.AddNew;
            }

            private clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
            {
                this.DriverID = DriverID;
                this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            Mode = enMode.Update;
           }


            private bool _AddNewDriver()
            {
                //call DataAccess Layer 

                this.DriverID = clsDriverDate.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);

                return (this.DriverID != -1);
            }

            private bool _UpdateDriver()
            {
                //call DataAccess Layer 

                return clsDriverDate.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID, this.CreatedDate);
            }

            public static clsDriver Find(int DriverID)
            {
                int PersonID = -1, CreatedByUserID = -1;
                DateTime CreatedDate = default;



                if (clsDriverDate.GetDriverInfoByID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))

                    return new clsDriver(DriverID, PersonID, CreatedByUserID,CreatedDate);
                else
                    return null;
            }

            public bool Save()
            {
                switch (Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewDriver())
                        {

                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:

                        return _UpdateDriver();

                }




                return false;
            }


        public static DataTable GetAllDrivers()
        {
            return clsDriverDate.GetAllDrivers();

        }

        public static bool DeleteDriver(int DriverID)
            {
                return clsDriverDate.DeleteDriver(DriverID);
            }

            public static bool isDriverExist(int DriverID)
            {
                return clsDriverDate.IsDriverExist(DriverID);
            }

        public static int GetDriverIdByPersonID(int PersonID)
        {
            return clsDriverDate.GetDriverIdByPersonID(PersonID);
        }


    }
}
