using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DVLD_DataAccess
{
    public class clsDetainedLicenseData
    {
        public static bool GetDetainedLicenseInfoByID(int DetainID,
            ref int LicenseID, ref DateTime DetainDate,
            ref float FineFees, ref int CreatedByUserID,
            ref bool IsReleased, ref DateTime ReleaseDate,
            ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("DetainedLicenses.GetByDetainID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@DetainID", SqlDbType.Int).Value = DetainID;

                    var licenseParam = command.Parameters.Add("@LicenseID", SqlDbType.Int);
                    licenseParam.Direction = ParameterDirection.Output;

                    var detainDateParam = command.Parameters.Add("@DetainDate", SqlDbType.DateTime);
                    detainDateParam.Direction = ParameterDirection.Output;

                    var feesParam = command.Parameters.Add("@FineFees", SqlDbType.SmallMoney);
                    feesParam.Direction = ParameterDirection.Output;

                    var createdByParam = command.Parameters.Add("@CreatedByUserID", SqlDbType.Int);
                    createdByParam.Direction = ParameterDirection.Output;

                    var isReleasedParam = command.Parameters.Add("@IsReleased", SqlDbType.Bit);
                    isReleasedParam.Direction = ParameterDirection.Output;

                    var releaseDateParam = command.Parameters.Add("@ReleaseDate", SqlDbType.DateTime);
                    releaseDateParam.Direction = ParameterDirection.Output;

                    var releasedByParam = command.Parameters.Add("@ReleasedByUserID", SqlDbType.Int);
                    releasedByParam.Direction = ParameterDirection.Output;

                    var releaseAppParam = command.Parameters.Add("@ReleaseApplicationID", SqlDbType.Int);
                    releaseAppParam.Direction = ParameterDirection.Output;

                    var isFoundParam = command.Parameters.Add("@IsFound", SqlDbType.Bit);
                    isFoundParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isFound = (bool)isFoundParam.Value;

                    if (isFound)
                    {
                        LicenseID = (int)licenseParam.Value;
                        DetainDate = (DateTime)detainDateParam.Value;
                        FineFees = Convert.ToSingle(feesParam.Value);
                        CreatedByUserID = (int)createdByParam.Value;
                        IsReleased = (bool)isReleasedParam.Value;

                        // ✅ معالجة NULL بشكل صحيح
                        ReleaseDate = (releaseDateParam.Value == DBNull.Value)
                            ? DateTime.MaxValue
                            : (DateTime)releaseDateParam.Value;

                        ReleasedByUserID = (int)releasedByParam.Value;
                        ReleaseApplicationID = (int)releaseAppParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error in GetDetainedLicenseInfoByID: " + ex.Message,
                    EventLogEntryType.Error);
                isFound = false;
            }

            return isFound;
        }

        public static bool GetDetainedLicenseInfoByLicenseID(int LicenseID,
            ref int DetainID, ref DateTime DetainDate,
            ref float FineFees, ref int CreatedByUserID,
            ref bool IsReleased, ref DateTime ReleaseDate,
            ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("DetainedLicenses.GetByLicenseID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;

                    var detainIdParam = command.Parameters.Add("@DetainID", SqlDbType.Int);
                    detainIdParam.Direction = ParameterDirection.Output;

                    var detainDateParam = command.Parameters.Add("@DetainDate", SqlDbType.DateTime);
                    detainDateParam.Direction = ParameterDirection.Output;

                    var feesParam = command.Parameters.Add("@FineFees", SqlDbType.SmallMoney);
                    feesParam.Direction = ParameterDirection.Output;

                    var createdByParam = command.Parameters.Add("@CreatedByUserID", SqlDbType.Int);
                    createdByParam.Direction = ParameterDirection.Output;

                    var isReleasedParam = command.Parameters.Add("@IsReleased", SqlDbType.Bit);
                    isReleasedParam.Direction = ParameterDirection.Output;

                    var releaseDateParam = command.Parameters.Add("@ReleaseDate", SqlDbType.DateTime);
                    releaseDateParam.Direction = ParameterDirection.Output;

                    var releasedByParam = command.Parameters.Add("@ReleasedByUserID", SqlDbType.Int);
                    releasedByParam.Direction = ParameterDirection.Output;

                    var releaseAppParam = command.Parameters.Add("@ReleaseApplicationID", SqlDbType.Int);
                    releaseAppParam.Direction = ParameterDirection.Output;

                    var isFoundParam = command.Parameters.Add("@IsFound", SqlDbType.Bit);
                    isFoundParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isFound = (bool)isFoundParam.Value;

                    if (isFound)
                    {
                        DetainID = (int)detainIdParam.Value;
                        DetainDate = (DateTime)detainDateParam.Value;
                        FineFees = Convert.ToSingle(feesParam.Value);
                        CreatedByUserID = (int)createdByParam.Value;
                        IsReleased = (bool)isReleasedParam.Value;

                        // ✅ معالجة NULL بشكل صحيح
                        ReleaseDate = (releaseDateParam.Value == DBNull.Value)
                            ? DateTime.MaxValue
                            : (DateTime)releaseDateParam.Value;

                        ReleasedByUserID = (int)releasedByParam.Value;
                        ReleaseApplicationID = (int)releaseAppParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error in GetDetainedLicenseInfoByLicenseID: " + ex.Message,
                    EventLogEntryType.Error);
                isFound = false;
            }

            return isFound;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("DetainedLicenses.GetAll", connection))
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
                EventLog.WriteEntry("DVLD", "Error in GetAllDetainedLicenses: " + ex.Message,
                    EventLogEntryType.Error);
            }

            return dt;
        }

        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate,
            float FineFees, int CreatedByUserID)
        {
            int DetainID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("DetainedLicenses.AddNew", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    var outputParam = command.Parameters.Add("@DetainID", SqlDbType.Int);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    DetainID = (int)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error in AddNewDetainedLicense: " + ex.Message,
                    EventLogEntryType.Error);
            }

            return DetainID;
        }

        public static bool UpdateDetainedLicense(int DetainID, int LicenseID,
            DateTime DetainDate, float FineFees, int CreatedByUserID)
        {
            bool isUpdated = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("DetainedLicenses.UpdateDetainedLicense", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@DetainID", DetainID);
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    var outputParam = command.Parameters.Add("@IsUpdated", SqlDbType.Bit);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isUpdated = (bool)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error in UpdateDetainedLicense: " + ex.Message,
                    EventLogEntryType.Error);
            }

            return isUpdated;
        }

        public static bool ReleaseDetainedLicense(int DetainID,
            int ReleasedByUserID, int ReleaseApplicationID)
        {
            bool isReleased = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("DetainedLicenses.Release", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@DetainID", DetainID);
                    command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                    command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

                    var outputParam = command.Parameters.Add("@IsReleased", SqlDbType.Bit);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isReleased = (bool)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error in ReleaseDetainedLicense: " + ex.Message,
                    EventLogEntryType.Error);
            }

            return isReleased;
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            bool IsDetained = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("DetainedLicenses.IsLicenseDetained", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    var outputParam = command.Parameters.Add("@IsDetained", SqlDbType.Bit);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    IsDetained = (bool)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error in IsLicenseDetained: " + ex.Message,
                    EventLogEntryType.Error);
            }

            return IsDetained;
        }
    }
}