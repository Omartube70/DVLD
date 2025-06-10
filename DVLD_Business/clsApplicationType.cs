using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drving_VehicleDataAcssecTier;
using System.Data;

namespace Drving_VehicleBusinessTier
{
    public class clsApplicationType
    {

            public int ApplicationTypeID { get; set; }
            public string ApplicationTypeTitle { get; set; }
            public float ApplicationFees { get; set; }
         
            private clsApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, float ApplicationFees)
            {
                this.ApplicationTypeID = ApplicationTypeID;
                this.ApplicationTypeTitle = ApplicationTypeTitle;
                this.ApplicationFees = ApplicationFees;
            }

            private bool _UpdateApplicationType()
            {
                //call DataAccess Layer 

                return clsApplicationTypeDate.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);
            }

            public static clsApplicationType Find(int ApplicationTypeID)
            {
            string ApplicationTypeTitle = "";
            float ApplicationFees = 0;


                if (clsApplicationTypeDate.GetApplicationTypeInfoByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))

                    return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle,ApplicationFees);
                else
                    return null;

            }

            public bool Save()
            {
               return _UpdateApplicationType();
            }



            public static DataTable GetAllApplicationTypes()
            {
                return clsApplicationTypeDate.GetAllApplicationTypes();

            }

            public static bool isApplicationTypeExist(int ApplicationTypeID)
            {
                return clsApplicationTypeDate.IsApplicationTypeExist(ApplicationTypeID);
            }
        

    }
}
