using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DVLD_DataAccess
{
    public class clsUserData
    {
        public static bool GetUserInfoByUserID(int UserID, ref int PersonID, ref string UserName,
            ref string PasswordHash, ref bool IsActive)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("Users.GetByUserID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;

                    var personParam = command.Parameters.Add("@PersonID", SqlDbType.Int);
                    personParam.Direction = ParameterDirection.Output;

                    var userNameParam = command.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
                    userNameParam.Direction = ParameterDirection.Output;

                    var passwordParam = command.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 256);
                    passwordParam.Direction = ParameterDirection.Output;

                    var isActiveParam = command.Parameters.Add("@IsActive", SqlDbType.Bit);
                    isActiveParam.Direction = ParameterDirection.Output;

                    var isFoundParam = command.Parameters.Add("@IsFound", SqlDbType.Bit);
                    isFoundParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isFound = (bool)isFoundParam.Value;

                    if (isFound)
                    {
                        PersonID = (int)personParam.Value;
                        UserName = (string)userNameParam.Value;
                        PasswordHash = (string)passwordParam.Value;
                        IsActive = (bool)isActiveParam.Value;
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

        public static bool GetUserInfoByPersonID(int PersonID, ref int UserID, ref string UserName,
            ref string PasswordHash, ref bool IsActive)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("Users.GetByPersonID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;

                    var userIdParam = command.Parameters.Add("@UserID", SqlDbType.Int);
                    userIdParam.Direction = ParameterDirection.Output;

                    var userNameParam = command.Parameters.Add("@UserName", SqlDbType.NVarChar, 50);
                    userNameParam.Direction = ParameterDirection.Output;

                    var passwordParam = command.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 256);
                    passwordParam.Direction = ParameterDirection.Output;

                    var isActiveParam = command.Parameters.Add("@IsActive", SqlDbType.Bit);
                    isActiveParam.Direction = ParameterDirection.Output;

                    var isFoundParam = command.Parameters.Add("@IsFound", SqlDbType.Bit);
                    isFoundParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isFound = (bool)isFoundParam.Value;

                    if (isFound)
                    {
                        UserID = (int)userIdParam.Value;
                        UserName = (string)userNameParam.Value;
                        PasswordHash = (string)passwordParam.Value;
                        IsActive = (bool)isActiveParam.Value;
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

        public static bool GetUserInfoByUsernameAndPasswordHash(string UserName, string PasswordHash,
            ref int UserID, ref int PersonID, ref bool IsActive)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("Users.GetByUsernameAndPassword", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = UserName;
                    command.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 256).Value = PasswordHash;

                    var userIdParam = command.Parameters.Add("@UserID", SqlDbType.Int);
                    userIdParam.Direction = ParameterDirection.Output;

                    var personIdParam = command.Parameters.Add("@PersonID", SqlDbType.Int);
                    personIdParam.Direction = ParameterDirection.Output;

                    var isActiveParam = command.Parameters.Add("@IsActive", SqlDbType.Bit);
                    isActiveParam.Direction = ParameterDirection.Output;

                    var isFoundParam = command.Parameters.Add("@IsFound", SqlDbType.Bit);
                    isFoundParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isFound = (bool)isFoundParam.Value;

                    if (isFound)
                    {
                        UserID = (int)userIdParam.Value;
                        PersonID = (int)personIdParam.Value;
                        IsActive = (bool)isActiveParam.Value;
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

        public static DataTable GetPaged(int PageNumber, int RowsPerPage,string FilterColumn, string FilterValue)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("Users.GetPaged", connection))
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
                using (SqlCommand command = new SqlCommand("Users.GetPagingInfo", connection))
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

        public static int AddNewUser(int PersonID, string UserName, string PasswordHash, bool IsActive)
        {
            int UserID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("Users.AddNew", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@PasswordHash", PasswordHash);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    var outputParam = command.Parameters.Add("@UserID", SqlDbType.Int);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    UserID = (int)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return UserID;
        }

        public static bool UpdateUser(int UserID, int PersonID, string UserName,
            string PasswordHash, bool IsActive)
        {
            bool isUpdated = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("Users.UpdateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@PasswordHash", PasswordHash);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

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

        public static bool DeleteUser(int UserID)
        {
            bool isDeleted = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("Users.DeleteUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserID", UserID);

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

        public static bool ChangePasswordHash(int UserID, string NewPasswordHash)
        {
            bool isChanged = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("Users.ChangePassword", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@NewPasswordHash", NewPasswordHash);

                    var outputParam = command.Parameters.Add("@IsChanged", SqlDbType.Bit);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isChanged = (bool)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return isChanged;
        }

        public static bool IsUserExist(int UserID)
        {
            bool isExist = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("Users.IsExistByUserID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserID", UserID);

                    var outputParam = command.Parameters.Add("@IsExist", SqlDbType.Bit);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isExist = (bool)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return isExist;
        }

        public static bool IsUserExist(string UserName)
        {
            bool isExist = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("Users.IsExistByUsername", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserName", UserName);

                    var outputParam = command.Parameters.Add("@IsExist", SqlDbType.Bit);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isExist = (bool)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return isExist;
        }

        public static bool IsUserExistForPersonID(int PersonID)
        {
            bool isExist = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("Users.IsExistByPersonID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    var outputParam = command.Parameters.Add("@IsExist", SqlDbType.Bit);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isExist = (bool)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return isExist;
        }
    }
}