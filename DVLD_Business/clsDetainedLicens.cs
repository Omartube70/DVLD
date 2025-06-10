using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drving_VehicleDataAcssecTier;


namespace Drving_VehicleBusinessTier
{
    public class clsDetainedLicens
    {

            public enum enMode { AddNew = 0, Update = 1 };
            public enMode Mode { get; set; }



            public int DetainID { get; set; }
            public int LicenseID { get; set; }
            public DateTime DetainDate { get; set; }
            public float FineFees { get; set; }
            public int CreatedByUserID { get; set; }
            public bool IsReleased { get; set; }
            public DateTime ReleaseDate { get; set; }
            public int ReleasedByUserID { get; set; }
            public int ReleaseApplicationID { get; set; }


            public clsDetainedLicens()
            {
                this.DetainID = -1;
                this.LicenseID = 0;
                this.DetainDate = default;
                this.FineFees = 0;
                this.CreatedByUserID = 0;
                this.IsReleased = false;
                this.ReleaseDate = default;
                this.ReleasedByUserID = 0;
                this.ReleaseApplicationID = 0;
                Mode = enMode.AddNew;
            }

            private clsDetainedLicens(int DetainID,int LicenseID, DateTime DetainDate, float FineFees,
         int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
            {
                this.DetainID = DetainID;
                this.LicenseID = LicenseID;
                this.DetainDate = DetainDate;
                this.FineFees = FineFees;
                this.CreatedByUserID = CreatedByUserID;
                this.IsReleased = IsReleased;
                this.ReleaseDate = ReleaseDate;
                this.ReleasedByUserID = ReleasedByUserID;
                this.ReleaseApplicationID = ReleaseApplicationID;
                Mode = enMode.Update;

            }

            private bool _AddNewDetainedLicens()
            {
                //call DataAccess Layer 

                this.DetainID = clsDetainedLicensDate.AddNewDetainedLicens(this.LicenseID,this.DetainDate, this.FineFees,this.CreatedByUserID
                    , this.IsReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);

                return (this.DetainID != -1);
            }

            private bool _UpdateDetainedLicens()
            {
                //call DataAccess Layer 

                return clsDetainedLicensDate.UpdateDetainedLicens(this.DetainID, this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID
                    , this.IsReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);
            }

            public static clsDetainedLicens Find(int DetainID)
            {
            int LicenseID = -1, CreatedByUserID = 0, ReleasedByUserID =0, ReleaseApplicationID = 0;
            DateTime DetainDate = default, ReleaseDate = default;
            bool IsReleased = false;
            float FineFees = 0;


            if (clsDetainedLicensDate.GetDetainedLicensInfoByID(DetainID, ref  LicenseID, ref  DetainDate, ref FineFees, ref  CreatedByUserID
                    , ref  IsReleased, ref  ReleaseDate, ref  ReleasedByUserID, ref  ReleaseApplicationID))

                    return new clsDetainedLicens(DetainID, LicenseID, DetainDate,  FineFees,  CreatedByUserID
                    ,  IsReleased,  ReleaseDate,  ReleasedByUserID,  ReleaseApplicationID);
                else
                    return null;

            }

            public bool Save()
            {
                switch (Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewDetainedLicens())
                        {

                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:

                        return _UpdateDetainedLicens();

                }




                return false;
            }

            public static DataTable GetAllDetainedLicenses()
            {
                return clsDetainedLicensDate.GetAllDetainedLicenses();

            }

        public static DataTable GetAllDetainedLicenses_Format()
        {
            return clsDetainedLicensDate.GetAllDetainedLicenses_Format();
        }

        public static bool DeleteDetainedLicens(int DetainID)
            {
                return clsDetainedLicensDate.DeleteDetainedLicens(DetainID);
            }

            public static bool isDetainedLicensExist(int DetainID)
            {
                return clsDetainedLicensDate.IsDetainedLicensExist(DetainID);
            }

        public static int GetDetainIdByLicenseId(int LicenseID)
        {
            return clsDetainedLicensDate.GetDetainIdByLicenseId(LicenseID);
        }



    }
}
