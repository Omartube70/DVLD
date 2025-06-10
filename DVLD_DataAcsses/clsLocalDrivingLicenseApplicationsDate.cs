using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Drving_VehicleDataAcssecTier
{
    public class clsLocalDrivingLicenseApplicationsDate
    {
        public static bool GetLocalDrivingLicenseApplicationInfoByID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
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
                clsErrorDate.AddNewError(ex.Message, "Local Driving License Applications", DateTime.Now);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }


        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string Quere = @"
INSERT INTO [LocalDrivingLicenseApplications] ([ApplicationID],[LicenseClassID])
VALUES (@ApplicationID,@LicenseClassID)
;Select SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);




            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    LocalDrivingLicenseApplicationID = InsertedID;
                }
                else
                {
                    LocalDrivingLicenseApplicationID = -1;
                }
            }
            catch (Exception ex)
            {
                clsErrorDate.AddNewError(ex.Message, "Local Driving License Applications", DateTime.Now);
            }
            finally
            {
                connection.Close();
            }
            return LocalDrivingLicenseApplicationID;
        }


        public static bool UpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);
            string query = @"
UPDATE [LocalDrivingLicenseApplications]
   SET [ApplicationID] = @ApplicationID
      ,[LicenseClassID] = @LicenseClassID
 WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;
";

            SqlCommand command = new SqlCommand(query, connection);



            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);



            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                clsErrorDate.AddNewError(ex.Message, "Local Driving License Applications", DateTime.Now);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }


        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = @"Delete LocalDrivingLicenseApplications 
                                    WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                                clsErrorDate.AddNewError(ex.Message, "Local Driving License Applications", DateTime.Now);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }


        public static DataTable GetAllLocalDrivingLicenseApplications()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT * from LocalDrivingLicenseApplications_View";

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
                                clsErrorDate.AddNewError(ex.Message, "Local Driving License Applications", DateTime.Now);
            }
            finally
            {
                connection.Close();
            }

            return (dt != null) ? dt : null;
        }


        public static bool IsLocalDrivingLicenseApplicationExist(int LocalDrivingLicenseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT Found=1 FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                clsErrorDate.AddNewError(ex.Message, "Local Driving License Applications", DateTime.Now);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }



        public static int GetPassedTestByID(int LocalDrivingLicenseApplicationID)
        {
            int PassedTestCount = 0;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT   count(TestAppointments.LocalDrivingLicenseApplicationID) FROM TestAppointments INNER JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID And TestResult = 1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int Count))
                {
                    PassedTestCount = Count;
                }
                else
                {
                    PassedTestCount = 0;
                }


            }
            catch (Exception ex)
            {
                clsErrorDate.AddNewError(ex.Message, "Local Driving License Applications", DateTime.Now);
                PassedTestCount = 0;
            }
            finally
            {
                connection.Close();
            }

            return PassedTestCount;
        }

    }
}