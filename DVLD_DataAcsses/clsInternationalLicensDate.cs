using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drving_VehicleDataAcssecTier
{
    public class clsInternationalLicensDate
    {
            public static bool GetInternationalLicensInfoByID(int InternationalLicenseID, ref int ApplicationID, ref int DriverID,
            ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, 
            ref bool IsActive, ref int CreatedByUserID)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    if (reader.Read())
                    {
                        // The record was found
                        isFound = true;

                       ApplicationID = (int)reader["ApplicationID"];

                       DriverID = (int)reader["DriverID"];

                      IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];

                       IssueDate = (DateTime)reader["IssueDate"];

                      ExpirationDate = (DateTime)reader["ExpirationDate"];

                      IsActive = (bool) reader["IsActive"];

                     CreatedByUserID = (int) reader["CreatedByUserID"] ;

                     
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
                clsErrorDate.AddNewError(ex.Message, "International Licenses", DateTime.Now);
                isFound = false;
                }
                finally
                {
                    connection.Close();
                }

                return isFound;
            }


        public static int GetInternationalLicenseIddByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);

            string query = "Select InternationalLicenseID from InternationalLicenses Where IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", LocalDrivingLicenseApplicationID);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int Id))
                {
                    LicenseID = Id;
                }

            }
            catch (Exception ex)
            {
                clsErrorDate.AddNewError(ex.Message, "International Licenses", DateTime.Now);
            }
            finally
            {
                connection.Close();
            }

            return LicenseID;
        }




        public static int AddNewInternationalLicens( int ApplicationID,  int DriverID,
             int IssuedUsingLocalLicenseID,  DateTime IssueDate,  DateTime ExpirationDate,
             bool IsActive,  int CreatedByUserID)
            {
                int InternationalLicenseID = -1;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string Quere = @"

INSERT INTO [InternationalLicenses]
           ([ApplicationID]
           ,[DriverID]
           ,[IssuedUsingLocalLicenseID]
           ,[IssueDate]
           ,[ExpirationDate]
           ,[IsActive]
           ,[CreatedByUserID])
     VALUES
           (@ApplicationID,@DriverID,@IssuedUsingLocalLicenseID,@IssueDate,@ExpirationDate,@IsActive,@CreatedByUserID);
Select SCOPE_IDENTITY();";


                SqlCommand command = new SqlCommand(Quere, connection);

                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                command.Parameters.AddWithValue("@IssueDate", IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                command.Parameters.AddWithValue("@IsActive", IsActive);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {
                        InternationalLicenseID = InsertedID;
                    }
                    else
                    {
                    InternationalLicenseID = -1;
                    }
                }
                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message, "International Licenses", DateTime.Now);
                InternationalLicenseID = -1;
                }
                finally
                {
                    connection.Close();
                }


                return InternationalLicenseID;
            }


            public static bool UpdateInternationalLicens(int InternationalLicenseID, int ApplicationID, int DriverID,
             int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate,
             bool IsActive, int CreatedByUserID)
            {

                int rowsAffected = 0;
                SqlConnection connection = new SqlConnection(Settings.ConnectionString);
                string Quere = @"
UPDATE [InternationalLicenses]
   SET [ApplicationID]              = @ApplicationID
      ,[DriverID]                   = @DriverID
      ,[IssuedUsingLocalLicenseID]  = @IssuedUsingLocalLicenseID
      ,[IssueDate]                  = @IssueDate
      ,[ExpirationDate]             = @ExpirationDate
      ,[IsActive]                   = @IsActive
      ,[CreatedByUserID]            = @CreatedByUserID
       WHERE InternationalLicenseID = @InternationalLicenseID;
";

                SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
           

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message, "International Licenses", DateTime.Now);
                return false;
                }

                finally
                {
                    connection.Close();
                }

                return (rowsAffected > 0);
            }


            public static bool DeleteInternationalLicense(int InternationalLicenseID)
            {

                int rowsAffected = 0;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = @"Delete InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

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

            public static DataTable GetAllInternationalLicenses()
            {

                DataTable dt = new DataTable();
                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = "SELECT * FROM InternationalLicenses";

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
                clsErrorDate.AddNewError(ex.Message, "International Licenses", DateTime.Now);
            }
            finally
                {
                    connection.Close();
                }

                return (dt != null) ? dt : null;
            }

            public static DataTable GetAllInternationalLicenseHistory_ByPersonId(int PersonID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(Settings.ConnectionString);

            string query = "\r\nSELECT  \r\nInternationalLicenses.InternationalLicenseID as [Int.License ID],\r\nApplications.ApplicationID as [Application ID],\r\nInternationalLicenses.IssuedUsingLocalLicenseID as [L.License ID],\r\nInternationalLicenses.IssueDate as [Issue Date],\r\nInternationalLicenses.ExpirationDate as [Expiration Date],\r\nInternationalLicenses.IsActive as [Is Active]\r\nFROM  Applications INNER JOIN InternationalLicenses ON Applications.ApplicationID = InternationalLicenses.ApplicationID\r\nwhere Applications.ApplicationPersonID = @ApplicationPersonID\r\n";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("ApplicationPersonID", PersonID);


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
                clsErrorDate.AddNewError(ex.Message, "International Licenses", DateTime.Now);
            }
            finally
            {
                connection.Close();
            }

            return (dt != null) ? dt : null;
        }

            public static DataTable GetAllInternationalLicense_Format()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(Settings.ConnectionString);

            string query = "\r\nSELECT  \r\nInternationalLicenses.InternationalLicenseID as [Int.License ID],\r\nApplications.ApplicationID as [Application ID], DriverID as [Driver ID] ,  \r\nInternationalLicenses.IssuedUsingLocalLicenseID as [L.License ID],\r\nInternationalLicenses.IssueDate as [Issue Date],\r\nInternationalLicenses.ExpirationDate as [Expiration Date],\r\nInternationalLicenses.IsActive as [Is Active]\r\nFROM  Applications INNER JOIN InternationalLicenses ON Applications.ApplicationID = InternationalLicenses.ApplicationID";

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
                clsErrorDate.AddNewError(ex.Message, "International Licenses", DateTime.Now);
            }
            finally
            {
                connection.Close();
            }

            return (dt != null) ? dt : null;
        }


            public static bool IsInternationalLicensExist(int InternationalLicenseID)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = "SELECT Found=1 FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    isFound = reader.HasRows;

                    reader.Close();
                }
                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message, "International Licenses", DateTime.Now);
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
