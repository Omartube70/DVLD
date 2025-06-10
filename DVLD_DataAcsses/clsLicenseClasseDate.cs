using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drving_VehicleDataAcssecTier
{
    public class clsLicenseClassDate
    {

        public static bool GetLicenseClassInfoByID(int LicenseClassID, ref string ClassName, ref string ClassDescription,
   ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;


                    ClassName = reader["ClassName"] as string;
                    ClassDescription = reader["ClassDescription"] as string;
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees =  Convert.ToSingle(reader["ClassFees"]);
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                                clsErrorDate.AddNewError(ex.Message, "License Classes", DateTime.Now);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static int AddNewLicenseClass(string ClassName, string ClassDescription,
             byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
            {
                int LicenseClassID = -1;

                SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

                string Quere = @"
INSERT INTO [LicenseClasses]
           ([ClassName]
           ,[ClassDescription]
           ,[MinimumAllowedAge]
           ,[DefaultValidityLength]
           ,[ClassFees])
VALUES(@ClassName,@ClassDescription,@MinimumAllowedAge,@DefaultValidityLength,@ClassFees);
Select SCOPE_IDENTITY();";


                SqlCommand command = new SqlCommand(Quere, connection);

                command.Parameters.AddWithValue("@ClassName", ClassName);
                command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
                command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                command.Parameters.AddWithValue("@ClassFees", ClassFees);


                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {
                        LicenseClassID = InsertedID;
                    }
                    else
                    {
                        LicenseClassID = -1;
                    }
                }
                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message, "License Classes", DateTime.Now);
                    LicenseClassID = -1;
                }
                finally
                {
                    connection.Close();
                }
                return LicenseClassID;
            }


            public static bool UpdateLicenseClass(int LicenseClassID, string ClassName, string ClassDescription,
             byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
            {

                int rowsAffected = 0;
                SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);
                string Quere = @"
UPDATE [LicenseClasses]
   SET [ClassName] = @ClassName
      ,[ClassDescription] = @ClassDescription
      ,[MinimumAllowedAge] = @MinimumAllowedAge
      ,[DefaultValidityLength] = @DefaultValidityLength
      ,[ClassFees] = @ClassFees
 WHERE LicenseClassID = @LicenseClassID;";

                SqlCommand command = new SqlCommand(Quere, connection);



                command.Parameters.AddWithValue("@ClassName", ClassName);
                command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
                command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                command.Parameters.AddWithValue("@ClassFees", ClassFees);

        

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message, "License Classes", DateTime.Now);
                return false;
                }

                finally
                {
                    connection.Close();
                }

                return (rowsAffected > 0);
            }


            public static bool DeleteLicenseClass(int LicenseClassID)
            {

                int rowsAffected = 0;

                SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

                string query = @"Delete LicenseClasses WHERE LicenseClassID = @LicenseClassID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                try
                {
                    connection.Open();

                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message, "International Licenses", DateTime.Now);
            }
            finally
                {

                    connection.Close();

                }

                return (rowsAffected > 0);

            }

            public static DataTable GetAllLicenseClasses()
            {

                DataTable dt = new DataTable();
                SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

                string query = "SELECT * FROM LicenseClasses";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                    }

                    reader.Close();


                }

                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message, "License Classes", DateTime.Now);
                }
                finally
                {
                    connection.Close();
                }

                return (dt != null) ? dt : null;
            }

            public static bool IsLicenseClassExist(int LicenseClassID)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

                string query = "SELECT Found=1 FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    isFound = reader.HasRows;

                    reader.Close();
                }
                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message, "License Classes", DateTime.Now);
                    isFound = false;
                }
                finally
                {
                    connection.Close();
                }

                return isFound;
            }
        }
}
