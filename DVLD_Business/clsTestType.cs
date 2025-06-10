using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drving_VehicleDataAcssecTier;
using System.Data;


namespace Drving_VehicleBusinessTier
{
    public class clsTestType
    {

           public enum enTestTypes { eVisionTest = 1 , eWrittenTest = 2 , eStreetTest = 3}


            public enTestTypes ID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public float Fees { get; set; }


            private clsTestType(enTestTypes ID, string Title, string Description, float Fees)
            {
                this.ID = ID;
                this.Title = Title;
                this.Description = Description;
                this.Fees = Fees;
           }

            private bool _UpdateTestType()
            {
                //call DataAccess Layer 

                return clsTestTypeDate.UpdateTestType( ((int)this.ID), this.Title, this.Description , this.Fees);
            }

            public static clsTestType Find(enTestTypes ID)
            {
                string Title = "" , Description = "";
                float Fees = 0;


                if (clsTestTypeDate.GetTestTypeInfoByID(((int)ID), ref Title, ref Description, ref Fees))
                    return new clsTestType(ID, Title, Description, Fees);
                else
                    return null;

            }

            public bool UpdateTestType()
            {
                return _UpdateTestType();
            }

            public static DataTable GetAllTestTypes()
            {
                return clsTestTypeDate.GetAllTestTypes();

            }


            public static bool isTestTypeExist(enTestTypes ID)
            {
                return clsTestTypeDate.IsTestTypeExist(((int)ID));
            }  
    }
}