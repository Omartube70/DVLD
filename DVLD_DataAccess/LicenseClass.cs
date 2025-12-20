using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DVLD_DataAccess
{
    public class clsLicenseClassData
    {
        public static bool GetLicenseClassInfoByID(int LicenseClassID,
            ref string ClassName, ref string ClassDescription, ref byte MinimumAllowedAge,
            ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("LicenseClasses.GetByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;

                    var classNameParam = command.Parameters.Add("@ClassName", SqlDbType.NVarChar, 100);
                    classNameParam.Direction = ParameterDirection.Output;

                    var descParam = command.Parameters.Add("@ClassDescription", SqlDbType.NVarChar, 500);
                    descParam.Direction = ParameterDirection.Output;

                    var minAgeParam = command.Parameters.Add("@MinimumAllowedAge", SqlDbType.TinyInt);
                    minAgeParam.Direction = ParameterDirection.Output;

                    var validityParam = command.Parameters.Add("@DefaultValidityLength", SqlDbType.TinyInt);
                    validityParam.Direction = ParameterDirection.Output;

                    var feesParam = command.Parameters.Add("@ClassFees", SqlDbType.SmallMoney);
                    feesParam.Direction = ParameterDirection.Output;

                    var isFoundParam = command.Parameters.Add("@IsFound", SqlDbType.Bit);
                    isFoundParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isFound = (bool)isFoundParam.Value;

                    if (isFound)
                    {
                        ClassName = (string)classNameParam.Value;
                        ClassDescription = (string)descParam.Value;
                        MinimumAllowedAge = (byte)minAgeParam.Value;
                        DefaultValidityLength = (byte)validityParam.Value;
                        ClassFees = Convert.ToSingle(feesParam.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
                isFound = false;
            }

            return isFound;
        }

        public static bool GetLicenseClassInfoByClassName(string ClassName, ref int LicenseClassID,
            ref string ClassDescription, ref byte MinimumAllowedAge,
            ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("LicenseClasses.GetByClassName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@ClassName", SqlDbType.NVarChar, 100).Value = ClassName;

                    var idParam = command.Parameters.Add("@LicenseClassID", SqlDbType.Int);
                    idParam.Direction = ParameterDirection.Output;

                    var descParam = command.Parameters.Add("@ClassDescription", SqlDbType.NVarChar, 500);
                    descParam.Direction = ParameterDirection.Output;

                    var minAgeParam = command.Parameters.Add("@MinimumAllowedAge", SqlDbType.TinyInt);
                    minAgeParam.Direction = ParameterDirection.Output;

                    var validityParam = command.Parameters.Add("@DefaultValidityLength", SqlDbType.TinyInt);
                    validityParam.Direction = ParameterDirection.Output;

                    var feesParam = command.Parameters.Add("@ClassFees", SqlDbType.SmallMoney);
                    feesParam.Direction = ParameterDirection.Output;

                    var isFoundParam = command.Parameters.Add("@IsFound", SqlDbType.Bit);
                    isFoundParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isFound = (bool)isFoundParam.Value;

                    if (isFound)
                    {
                        LicenseClassID = (int)idParam.Value;
                        ClassDescription = (string)descParam.Value;
                        MinimumAllowedAge = (byte)minAgeParam.Value;
                        DefaultValidityLength = (byte)validityParam.Value;
                        ClassFees = Convert.ToSingle(feesParam.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
                isFound = false;
            }

            return isFound;
        }

        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("LicenseClasses.GetAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return dt;
        }

        public static int AddNewLicenseClass(string ClassName, string ClassDescription,
            byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            int LicenseClassID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("LicenseClasses.AddNew", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ClassName", ClassName);
                    command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
                    command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                    command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                    command.Parameters.AddWithValue("@ClassFees", ClassFees);

                    var outputParam = command.Parameters.Add("@LicenseClassID", SqlDbType.Int);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    LicenseClassID = (int)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return LicenseClassID;
        }

        public static bool UpdateLicenseClass(int LicenseClassID, string ClassName,
            string ClassDescription, byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            bool isUpdated = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("LicenseClasses.UpdateLicense", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    command.Parameters.AddWithValue("@ClassName", ClassName);
                    command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
                    command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                    command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                    command.Parameters.AddWithValue("@ClassFees", ClassFees);

                    var outputParam = command.Parameters.Add("@IsUpdated", SqlDbType.Bit);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isUpdated = (bool)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return isUpdated;
        }
    }
}