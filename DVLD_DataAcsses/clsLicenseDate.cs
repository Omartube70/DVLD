using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace Drving_VehicleDataAcssecTier
{
    public class clsLicenseDate
    {
        public static bool GetLicenseInfoByID(int LicenseID, ref int ApplicationID, ref int DriverID,
        ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref float PaidFees,
            ref bool IsActive, ref byte IssueReason , ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID      = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);


                    if (reader["Notes"] != DBNull.Value)
                        Notes = (string)reader["Notes"];

                    else
                        Notes = "";



                        PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (byte)reader["IssueReason"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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
                                clsErrorDate.AddNewError(ex.Message, "Licenses", DateTime.Now);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }


        public static int AddNewLicense(int ApplicationID,  int DriverID,
         int LicenseClass,  DateTime IssueDate,  DateTime ExpirationDate,  string Notes,  float PaidFees,
             bool IsActive, byte IssueReason,  int CreatedByUserID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string Quere = @"
INSERT INTO [Licenses]
           ([ApplicationID]
           ,[DriverID]
           ,[LicenseClass]
           ,[IssueDate]
           ,[ExpirationDate]
           ,[Notes]
           ,[PaidFees]
           ,[IsActive]
           ,[IssueReason]
           ,[CreatedByUserID])
VALUES(@ApplicationID,@DriverID,@LicenseClass,@IssueDate,@ExpirationDate,@Notes,@PaidFees,@IsActive,@IssueReason,@CreatedByUserID);
Select SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            if (string.IsNullOrEmpty(Notes))
                command.Parameters.AddWithValue("@Notes", DBNull.Value);


            else
                command.Parameters.AddWithValue("@Notes", Notes);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    LicenseID = InsertedID;
                }
                else
                {
                    LicenseID = -1;
                }
            }
            catch (Exception ex)
            {
                                clsErrorDate.AddNewError(ex.Message, "Licenses", DateTime.Now);
                LicenseID = -1;
            }
            finally
            {
                connection.Close();
            }
            return LicenseID;
        }


        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID,
         int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, float PaidFees,
             bool IsActive, byte IssueReason, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);
            string Quere = @"
UPDATE [Licenses]
   SET [ApplicationID] = @ApplicationID
      ,[DriverID] = @DriverID
      ,[LicenseClass] = @LicenseClass
      ,[IssueDate] = @IssueDate
      ,[ExpirationDate] = @ExpirationDate
      ,[Notes] = @Notes
      ,[PaidFees] = @PaidFees
      ,[IsActive] = @IsActive
      ,[IssueReason] = @IssueReason
      ,[CreatedByUserID] = @CreatedByUserID
 WHERE LicenseID = @LicenseID;";

            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            if(string.IsNullOrEmpty(Notes))
                command.Parameters.AddWithValue("@Notes", DBNull.Value);


            else
                command.Parameters.AddWithValue("@Notes", Notes);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);



            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                                clsErrorDate.AddNewError(ex.Message, "Licenses", DateTime.Now);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }


        public static bool DeleteLicense(int LicenseID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = @"Delete Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                                clsErrorDate.AddNewError(ex.Message, "Licenses", DateTime.Now);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static DataTable GetAllLicenses()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT * FROM Licenses";

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

        public static DataTable GetAllLocalLicenseHistory_ByPersonId(int PersonID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT Licenses.LicenseID as [Lic.ID],Applications.ApplicationID as [App ID],LicenseClasses.ClassName as [Class Name],\r\nLicenses.IssueDate as [Issue Date],\r\nLicenses.ExpirationDate as [Expiration Date],\r\nLicenses.IsActive as [Is Active]\r\nFROM  \r\nApplications INNER JOIN\r\nLicenses ON Applications.ApplicationID = Licenses.ApplicationID INNER JOIN\r\nLicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID where Applications.ApplicationPersonID = @ApplicationPersonID";

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
                                clsErrorDate.AddNewError(ex.Message, "Licenses", DateTime.Now);
            }
            finally
            {
                connection.Close();
            }

            return (dt != null) ? dt : null;
        }


        public static bool IsLicenseExist(int LicenseID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        public static bool isLicenseExistByPersonID(int PersonID , int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "Select Found = 1 From Licenses Inner Join Applications On Applications.ApplicationID = Licenses.ApplicationID where Applications.ApplicationPersonID = @ApplicationPersonID And Licenses.LicenseClass = @LicenseClass;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationPersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                isFound = result != null;

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

        public static int GetLicenseIdByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT LicenseID FROM  Applications INNER JOIN   Licenses ON Applications.ApplicationID = Licenses.ApplicationID INNER JOIN LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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




    }
}
