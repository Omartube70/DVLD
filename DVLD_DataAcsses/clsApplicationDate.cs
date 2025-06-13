using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Drving_VehicleDataAcssecTier
{
    public class clsApplicationDate
    {

            public static bool GetApplicationInfoByID(int ApplicationID, ref int ApplicantionPersonID, ref DateTime ApplicationDate,
            ref int ApplicationTypeID, ref int ApplicationStatus , ref DateTime LastStatusDate , ref float PaidFees ,ref int CreatedByUserID)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = "SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // The record was found
                        isFound = true;

                        ApplicantionPersonID = (int)reader["ApplicationPersonID"];
                        ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                        ApplicationTypeID = (int)reader["ApplicationTypeID"];
                        ApplicationStatus = (byte)reader["ApplicationStatus"];
                        LastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]);
                        PaidFees = Convert.ToSingle(reader["PaidFees"]);
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
                                    clsErrorDate.AddNewError(ex.Message, "Applications", DateTime.Now);
                    isFound = false;
                }
                finally
                {
                    connection.Close();
                }

                return isFound;

            }


            public static int AddNewApplication(int ApplicationPersonID, DateTime ApplicationDate,
             int ApplicationTypeID,  int ApplicationStatus,  DateTime LastStatusDate,  float PaidFees, int CreatedByUserID)
            {
                int ApplicationID = -1;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string Quere = @"
INSERT INTO [Applications]
           ([ApplicationPersonID]
           ,[ApplicationDate]
           ,[ApplicationTypeID]
           ,[ApplicationStatus]
           ,[LastStatusDate]
           ,[PaidFees]
           ,[CreatedByUserID])
VALUES(@ApplicationPersonID,@ApplicationDate,@ApplicationTypeID,@ApplicationStatus,@LastStatusDate,@PaidFees,@CreatedByUserID);
Select SCOPE_IDENTITY();";


                SqlCommand command = new SqlCommand(Quere, connection);

                command.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
                command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {
                        ApplicationID = InsertedID;
                    }
                    else
                    {
                        ApplicationID = -1;
                    }
                }
                catch (Exception ex)
                {
                                    clsErrorDate.AddNewError(ex.Message,"Applications", DateTime.Now);
                    ApplicationID = -1;
                }
                finally
                {
                    connection.Close();
                }
                return ApplicationID;
            }


            public static bool UpdateApplication(int ApplicationID , int ApplicationPersonID, DateTime ApplicationDate,
             int ApplicationTypeID, int ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
            {

                int rowsAffected = 0;
                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = @"
UPDATE [Applications]
   SET [ApplicationPersonID] = @ApplicationPersonID
      ,[ApplicationDate] = @ApplicationDate
      ,[ApplicationTypeID] = @ApplicationTypeID
      ,[ApplicationStatus] = @ApplicationStatus
      ,[LastStatusDate] = @LastStatusDate
      ,[PaidFees] = @PaidFees
      ,[CreatedByUserID] = @CreatedByUserID
 WHERE ApplicationID = @ApplicationID;
";

                SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message, "Applications", DateTime.Now);
                return false;
                }

                finally
                {
                    connection.Close();
                }

                return (rowsAffected > 0);
            }


            public static bool DeleteApplication(int ApplicationID)
            {

                int rowsAffected = 0;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = @"Delete Applications WHERE ApplicationID = @ApplicationID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                try
                {
                    connection.Open();

                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message, "Applications", DateTime.Now);
            }
            finally
                {

                    connection.Close();

                }

                return (rowsAffected > 0);

            }

            public static DataTable GetAllApplications()
            {

                DataTable dt = new DataTable();
                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = "SELECT * FROM Applications";

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
                clsErrorDate.AddNewError(ex.Message, "Applications", DateTime.Now);
            }
            finally
                {
                    connection.Close();
                }

                return (dt != null) ? dt : null;
            }

            public static bool IsApplicationExist(int ApplicationID)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = "SELECT Found=1 FROM Applications WHERE ApplicationID = @ApplicationID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    isFound = reader.HasRows;

                    reader.Close();
                }
                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message, "Applications", DateTime.Now);
                isFound = false;
                }
                finally
                {
                    connection.Close();
                }

                return isFound;
            }

            public static int GetActiveApplicationIDforLicenseClass(int PersonID , int LicenseClassID)
        {
            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);

            string query = "SELECT  Applications.ApplicationID  FROM  Applications INNER JOIN LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID where Applications.ApplicationPersonID = @ApplicationPersonID And LicenseClasses.LicenseClassID = @LicenseClassID And Applications.ApplicationStatus = 1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationPersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);



            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if(result != null)
                   ApplicationID = Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                clsErrorDate.AddNewError(ex.Message, "Applications", DateTime.Now);
            }
            finally
            {
                connection.Close();
            }

            return ApplicationID;
        }

            public static bool UpdateStatus(int ApplicationID,int ApplicationStatus)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(Settings.ConnectionString);

            string query = @"
UPDATE [Applications]
   SET [ApplicationStatus] = @ApplicationStatus,
    [LastStatusDate] = @LastStatusDate
 WHERE ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);




            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                clsErrorDate.AddNewError(ex.Message, "Applications", DateTime.Now);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }


    }
}
