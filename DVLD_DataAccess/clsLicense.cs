using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DVLD_DataAccess
{
    public class clsLicenseData
    {
        public static bool GetLicenseInfoByID(int LicenseID, ref int ApplicationID, ref int DriverID,
            ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
            ref float PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("Licenses.GetByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;

                    var appIdParam = command.Parameters.Add("@ApplicationID", SqlDbType.Int);
                    appIdParam.Direction = ParameterDirection.Output;

                    var driverIdParam = command.Parameters.Add("@DriverID", SqlDbType.Int);
                    driverIdParam.Direction = ParameterDirection.Output;

                    var licenseClassParam = command.Parameters.Add("@LicenseClass", SqlDbType.Int);
                    licenseClassParam.Direction = ParameterDirection.Output;

                    var issueDateParam = command.Parameters.Add("@IssueDate", SqlDbType.DateTime);
                    issueDateParam.Direction = ParameterDirection.Output;

                    var expDateParam = command.Parameters.Add("@ExpirationDate", SqlDbType.DateTime);
                    expDateParam.Direction = ParameterDirection.Output;

                    var notesParam = command.Parameters.Add("@Notes", SqlDbType.NVarChar, 500);
                    notesParam.Direction = ParameterDirection.Output;

                    var feesParam = command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney);
                    feesParam.Direction = ParameterDirection.Output;

                    var isActiveParam = command.Parameters.Add("@IsActive", SqlDbType.Bit);
                    isActiveParam.Direction = ParameterDirection.Output;

                    var issueReasonParam = command.Parameters.Add("@IssueReason", SqlDbType.TinyInt);
                    issueReasonParam.Direction = ParameterDirection.Output;

                    var createdByParam = command.Parameters.Add("@CreatedByUserID", SqlDbType.Int);
                    createdByParam.Direction = ParameterDirection.Output;

                    var isFoundParam = command.Parameters.Add("@IsFound", SqlDbType.Bit);
                    isFoundParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isFound = (bool)isFoundParam.Value;

                    if (isFound)
                    {
                        ApplicationID = (int)appIdParam.Value;
                        DriverID = (int)driverIdParam.Value;
                        LicenseClass = (int)licenseClassParam.Value;
                        IssueDate = (DateTime)issueDateParam.Value;
                        ExpirationDate = (DateTime)expDateParam.Value;
                        Notes = (string)notesParam.Value;
                        PaidFees = Convert.ToSingle(feesParam.Value);
                        IsActive = (bool)isActiveParam.Value;
                        IssueReason = (byte)issueReasonParam.Value;
                        CreatedByUserID = (int)createdByParam.Value;
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

        // باقي الدوال تبقى كما هي...
        public static DataTable GetPaged(int PageNumber, int RowsPerPage)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("Licenses.GetPaged", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@PageNumber", SqlDbType.Int).Value = PageNumber;
                    command.Parameters.Add("@RowsPerPage", SqlDbType.Int).Value = RowsPerPage;

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

        public static DataTable GetDriverLicenses(int DriverID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("Licenses.GetDriverLicenses", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@DriverID", SqlDbType.Int).Value = DriverID;

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

        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes,
            float PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int LicenseID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("Licenses.AddNew", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@IssueReason", IssueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    var outputParam = command.Parameters.Add("@LicenseID", SqlDbType.Int);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    LicenseID = (int)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return LicenseID;
        }

        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes,
            float PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            bool IsUpdated = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("Licenses.UpdateLicense", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@IssueReason", IssueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    var outputParam = command.Parameters.Add("@IsUpdated", SqlDbType.Bit);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    IsUpdated = (bool)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
                return false;
            }

            return IsUpdated;
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int licenseID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("Licenses.GetActiveLicenseID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;
                    command.Parameters.Add("@LicenseClass", SqlDbType.Int).Value = LicenseClassID;

                    var outputParam = command.Parameters.Add("@LicenseID", SqlDbType.Int);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    if (outputParam.Value != DBNull.Value)
                        licenseID = (int)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return licenseID;
        }

        public static bool DeactivateLicense(int LicenseID)
        {
            bool isDeactivated = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("Licenses.Deactivate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;

                    var outputParam = command.Parameters.Add("@IsDeactivated", SqlDbType.Bit);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isDeactivated = (bool)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return isDeactivated;
        }
    }
}