using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;




namespace Drving_VehicleDataAcssecTier
{
    public class clsTestAppointmentDate
    {
            public static bool GetTestAppointmentInfoByID(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID,
            ref DateTime AppointmentDate, ref float PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

                string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // The record was found
                        isFound = true;

                    TestTypeID = (int)reader["TestTypeID"];

                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];

                    AppointmentDate = DateTime.Parse(reader["AppointmentDate"].ToString());

                    PaidFees = Convert.ToSingle(reader["PaidFees"]);

                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsLocked = (bool)reader["IsLocked"];

                    if (reader["RetakeTestApplicationID"] != DBNull.Value)
                        RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];

                    else
                        RetakeTestApplicationID = -1;


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


            public static int AddNewTestAppointment(int TestTypeID,  int LocalDrivingLicenseApplicationID,
             DateTime AppointmentDate,  float PaidFees,  int CreatedByUserID,  bool IsLocked, int RetakeTestApplicationID)
            {
                int TestAppointmentID = -1;

                SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

                string Quere = @"
INSERT INTO [TestAppointments]
           ([TestTypeID]
           ,[LocalDrivingLicenseApplicationID]
           ,[AppointmentDate]
           ,[PaidFees]
           ,[CreatedByUserID]
           ,[IsLocked]
           ,[RetakeTestApplicationID])
     VALUES (@TestTypeID , @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked , @RetakeTestApplicationID)
Select SCOPE_IDENTITY();";


                SqlCommand command = new SqlCommand(Quere, connection);

                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if(RetakeTestApplicationID != -1)
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);




            try
            {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {
                        TestAppointmentID = InsertedID;
                    }
                    else
                    {
                        TestAppointmentID = -1;
                    }
                }
                catch (Exception ex)
                {
                    clsErrorDate.AddNewError(ex.Message, "License Classes", DateTime.Now);
                    TestAppointmentID = -1;
                }
                finally
                {
                    connection.Close();
                }


                return TestAppointmentID;
            }


            public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
             DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
            {

                int rowsAffected = 0;
                SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);
                string Quere = @"
UPDATE [TestAppointments]
   SET [TestTypeID]                       = @TestTypeID
      ,[LocalDrivingLicenseApplicationID] = @LocalDrivingLicenseApplicationID
      ,[AppointmentDate]                  = @AppointmentDate
      ,[PaidFees]                         = @PaidFees
      ,[CreatedByUserID]                  = @CreatedByUserID
      ,[IsLocked]                         = @IsLocked
      ,[RetakeTestApplicationID]          = @RetakeTestApplicationID
       WHERE TestAppointmentID            = @TestAppointmentID;";


                SqlCommand command = new SqlCommand(Quere, connection);

                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@IsLocked", IsLocked);
                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            if (RetakeTestApplicationID != -1)
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);


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


            public static bool DeleteTestAppointment(int TestAppointmentID)
            {

                int rowsAffected = 0;

                SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

                string query = @"Delete TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                try
                {
                    connection.Open();

                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                                clsErrorDate.AddNewError(ex.Message, "License Classes", DateTime.Now);
                }
                finally
                {

                    connection.Close();

                }

                return (rowsAffected > 0);

            }

            public static DataTable GetAllTestAppointments()
            {

                DataTable dt = new DataTable();
                SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

                string query = "SELECT * FROM TestAppointments";

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

            public static DataTable GetAllTestAppointmentsByLocalDrivingID(int LocalDrivingLicenseApplicationID , int TestTypeID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "Select TestAppointmentID as [Appointment ID] , AppointmentDate as  [Appointment Date] , PaidFees as [Paid Fees] , IsLocked as [Is Locked] from TestAppointments where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID And TestTypeID = @TestTypeID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


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
                clsErrorDate.AddNewError(ex.Message, "TestAppointments", DateTime.Now);
            }
            finally
            {
                connection.Close();
            }

            return (dt != null) ? dt : null;
        }

           public static bool IsTestAppointmentExist(int TestAppointmentID)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

                string query = "SELECT Found=1 FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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


           public static bool IsHaveAppointmentUnLocked(int LocalDrivingLicenseApplicationID ,int TestTypeID)
        {
            bool IsHaveAppoUnLocked = false;
            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "Select Found = 1 from TestAppointments where (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID And TestTypeID = @TestTypeID) And IsLocked = 0;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                 connection.Open();
                 SqlDataReader rader = command.ExecuteReader();

                IsHaveAppoUnLocked = rader.HasRows;
            }
            catch (Exception ex)
            {
                clsErrorDate.AddNewError(ex.Message, "TestAppointments", DateTime.Now);
                IsHaveAppoUnLocked = false;
            }
            finally
            {
                connection.Close();
            }

            return (IsHaveAppoUnLocked);
        }


        public static bool IsHaveAppointment_IsRetakeTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsHaveAppoUnLocked = false;
            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "Select IsRetakeTest = 'yes' FROM TestAppointments where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID And TestTypeID = @TestTypeID And RetakeTestApplicationID is null";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);



            try
            {
                connection.Open();
                SqlDataReader rader = command.ExecuteReader();

                IsHaveAppoUnLocked = rader.HasRows;
            }
            catch (Exception ex)
            {
                clsErrorDate.AddNewError(ex.Message, "TestAppointments", DateTime.Now);
                IsHaveAppoUnLocked = false;
            }
            finally
            {
                connection.Close();
            }

            return (IsHaveAppoUnLocked);
        }




    }
}
