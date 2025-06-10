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
    public class clsLicenseClass
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode { get; set; }



        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }
     

        public clsLicenseClass()
        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge =0;
            this.DefaultValidityLength =0;
            Mode = enMode.AddNew;
        }

        private clsLicenseClass(int LicenseClassID, string ClassName, string ClassDescription,
       byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
            Mode = enMode.Update;
        }


        private bool _AddNewLicenseClass()
        {
            //call DataAccess Layer 

            this.LicenseClassID = clsLicenseClassDate.AddNewLicenseClass(this.ClassName, this.ClassDescription, this.MinimumAllowedAge,
                 this.DefaultValidityLength, this.ClassFees);

            return (this.LicenseClassID != -1);
        }

        private bool _UpdateLicenseClass()
        {
            //call DataAccess Layer 

            return clsLicenseClassDate.UpdateLicenseClass(this.LicenseClassID,this.ClassName, this.ClassDescription, this.MinimumAllowedAge,
                 this.DefaultValidityLength, this.ClassFees);
        }

        public static clsLicenseClass Find(int LicenseClassID)
        {
            string ClassName = "" , ClassDescription = "";
            byte MinimumAllowedAge = 0, DefaultValidityLength = 0;
            float ClassFees = -1;


            if (clsLicenseClassDate.GetLicenseClassInfoByID(LicenseClassID, ref ClassName,
                    ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))

                return new clsLicenseClass(LicenseClassID, ClassName,
                     ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            else
                return null;

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicenseClass())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicenseClass();

            }


            return false;
        }

        public static DataTable GetAllLicenseClasss()
        {
            return clsLicenseClassDate.GetAllLicenseClasses();
        }

        public static bool DeleteLicenseClass(int LicenseClassID)
        {
            return clsLicenseClassDate.DeleteLicenseClass(LicenseClassID);
        }

        public static bool isLicenseClassExist(int LicenseClassID)
        {
            return clsLicenseClassDate.IsLicenseClassExist(LicenseClassID);
        }

        public static byte GetLicenseClassMinimumAllowedAge(int LicenseClassID)
        {
            return clsLicenseClass.Find(LicenseClassID).MinimumAllowedAge;
        }

    }
}
