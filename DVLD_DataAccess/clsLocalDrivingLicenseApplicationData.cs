using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseApplicationData
    {
        public static bool GetLocalDrivingLicenseApplicationInfoByID(
            int LocalDrivingLicenseApplicationID, ref int ApplicationID,
            ref int LicenseClassID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("LocalDrivingLicenseApplications.GetByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = LocalDrivingLicenseApplicationID;

                    var appIdParam = command.Parameters.Add("@ApplicationID", SqlDbType.Int);
                    appIdParam.Direction = ParameterDirection.Output;

                    var licenseClassParam = command.Parameters.Add("@LicenseClassID", SqlDbType.Int);
                    licenseClassParam.Direction = ParameterDirection.Output;

                    var isFoundParam = command.Parameters.Add("@IsFound", SqlDbType.Bit);
                    isFoundParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isFound = (bool)isFoundParam.Value;

                    if (isFound)
                    {
                        ApplicationID = (int)appIdParam.Value;
                        LicenseClassID = (int)licenseClassParam.Value;
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

        public static bool GetLocalDrivingLicenseApplicationInfoByApplicationID(
         int ApplicationID, ref int LocalDrivingLicenseApplicationID,
         ref int LicenseClassID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("LocalDrivingLicenseApplications.GetByApplicationID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;

                    var localAppIdParam = command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int);
                    localAppIdParam.Direction = ParameterDirection.Output;

                    var licenseClassParam = command.Parameters.Add("@LicenseClassID", SqlDbType.Int);
                    licenseClassParam.Direction = ParameterDirection.Output;

                    var isFoundParam = command.Parameters.Add("@IsFound", SqlDbType.Bit);
                    isFoundParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isFound = (bool)isFoundParam.Value;

                    if (isFound)
                    {
                        LocalDrivingLicenseApplicationID = (int)localAppIdParam.Value;
                        LicenseClassID = (int)licenseClassParam.Value;
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

        // Ged Paged
        public static DataTable GetPaged(int PageNumber, int RowsPerPage,
            string FilterColumn, string FilterValue)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("LocalDrivingLicenseApplications.GetPaged", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@PageNumber", SqlDbType.Int).Value = PageNumber;
                    command.Parameters.Add("@RowsPerPage", SqlDbType.Int).Value = RowsPerPage;

                    //for filter
                    command.Parameters.Add("@FilterColumn", SqlDbType.NVarChar, 50).Value
                        = string.IsNullOrEmpty(FilterColumn) ? (object)DBNull.Value : FilterColumn;

                    command.Parameters.Add("@FilterValue", SqlDbType.NVarChar, 100).Value
                         = string.IsNullOrEmpty(FilterValue) ? (object)DBNull.Value : FilterValue;


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

        // get Paged info
        public static bool GetPagingInfo(int RowsPerPage, ref int TotalRecords, ref int TotalPage)
        {
            try

            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("LocalDrivingLicenseApplications.GetPagingInfo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@RowsPerPage", SqlDbType.Int).Value = RowsPerPage;


                    var TotalRecordsParam = command.Parameters.Add("@TotalRecords", SqlDbType.Int);
                    TotalRecordsParam.Direction = ParameterDirection.Output;

                    var TotalPageParam = command.Parameters.Add("@TotalPage", SqlDbType.Int);
                    TotalPageParam.Direction = ParameterDirection.Output;


                    connection.Open();
                    command.ExecuteNonQuery();

                    if (TotalRecordsParam != null && TotalPageParam != null)
                    {
                        TotalRecords = (int)TotalRecordsParam.Value;
                        TotalPage = (int)TotalPageParam.Value;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return true;
        }


        public static int AddNewLocalDrivingLicenseApplication(
            int ApplicationID, int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("LocalDrivingLicenseApplications.AddNew", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    var outputParam = command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    LocalDrivingLicenseApplicationID = (int)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return LocalDrivingLicenseApplicationID;
        }

        public static bool UpdateLocalDrivingLicenseApplication(
            int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            bool isUpdated = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("LocalDrivingLicenseApplications.UpdateLocalDriving", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            bool isDeleted = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("LocalDrivingLicenseApplications.DeleteLocalDriving", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                    var outputParam = command.Parameters.Add("@IsDeleted", SqlDbType.Bit);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isDeleted = (bool)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return isDeleted;
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool Result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("LocalDrivingLicenseApplications.DoesPassTestType", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    var outputParam = command.Parameters.Add("@TestResult", SqlDbType.Bit);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    Result = (bool)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return Result;
        }

        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            // This can be implemented by checking if TotalTrialsPerTest > 0
            return TotalTrialsPerTest(LocalDrivingLicenseApplicationID, TestTypeID) > 0;
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            byte TotalTrialsPerTest = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("LocalDrivingLicenseApplications.TotalTrialsPerTest", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    var outputParam = command.Parameters.Add("@TotalTrials", SqlDbType.TinyInt);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    TotalTrialsPerTest = (byte)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return TotalTrialsPerTest;
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool Result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("LocalDrivingLicenseApplications.IsThereAnActiveScheduledTest", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    var outputParam = command.Parameters.Add("@Result", SqlDbType.Bit);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    Result = (bool)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return Result;
        }
    }
}
