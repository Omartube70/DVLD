using System;
using System.Data.SqlClient;
using System.Data;


namespace Drving_VehicleDataAcssecTier
{
    public class clsTestDate
    {
            public static bool GetTestInfoByID(int TestID, ref int TestAppointmentID, ref bool TestResult,
            ref string Notes, ref int CreatedByUserID)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = "SELECT * FROM Tests WHERE TestID = @TestID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@TestID", TestID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // The record was found
                        isFound = true;

                    TestAppointmentID = (int)reader["TestAppointmentID"];

                    TestResult = (bool)reader["TestResult"];


                    if(reader["Notes"] == DBNull.Value)
                    {
                        Notes = "";
                    }
                    else
                    {
                        Notes = reader["Notes"].ToString();
                    }


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
                    clsErrorDate.AddNewError(ex.Message,"Tests", DateTime.Now);
                    isFound = false;
                }
                finally
                {
                    connection.Close();
                }

                return isFound;
            }


            public static int AddNewTest(int TestAppointmentID,  bool TestResult,
             string Notes,  int CreatedByUserID)
            {
                int TestID = -1;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string Quere = @"
INSERT INTO [Tests]
           ([TestAppointmentID]
           ,[TestResult]
           ,[Notes]
           ,[CreatedByUserID])
     VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID)
Select SCOPE_IDENTITY();";


                SqlCommand command = new SqlCommand(Quere, connection);

                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                command.Parameters.AddWithValue("@TestResult", TestResult);

            if(string.IsNullOrEmpty(Notes))
                command.Parameters.AddWithValue("@Notes", DBNull.Value);

            else
                command.Parameters.AddWithValue("@Notes", Notes);



                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {
                        TestID = InsertedID;
                    }
                    else
                    {
                        TestID = -1;
                    }
                }
                catch (Exception ex)
                {
                    clsErrorDate.AddNewError(ex.Message,"Tests", DateTime.Now);
                    TestID = -1;
                }
                finally
                {
                    connection.Close();
                }


                return TestID;
            }


            public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult,
             string Notes, int CreatedByUserID)
            {

                int rowsAffected = 0;
                SqlConnection connection = new SqlConnection(Settings.ConnectionString);
                string Quere = @"
UPDATE [Tests]
   SET [TestAppointmentID]     = @TestAppointmentID
      ,[TestResult]            = @TestResult
      ,[Notes]                 = @Notes
      ,[CreatedByUserID]       = @CreatedByUserID
       WHERE TestID            = @TestID;";


                SqlCommand command = new SqlCommand(Quere, connection);

                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                command.Parameters.AddWithValue("@TestResult", TestResult);

            if (string.IsNullOrEmpty(Notes))
                command.Parameters.AddWithValue("@Notes", DBNull.Value);

            else
                command.Parameters.AddWithValue("@Notes", Notes);


            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@TestID", TestID);





                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    clsErrorDate.AddNewError(ex.Message,"Tests", DateTime.Now);
                    
                }

                finally
                {
                    connection.Close();
                }

                return (rowsAffected > 0);
            }


            public static bool DeleteTest(int TestID)
            {

                int rowsAffected = 0;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = @"Delete Tests WHERE TestID = @TestID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@TestID", TestID);

                try
                {
                    connection.Open();

                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    clsErrorDate.AddNewError(ex.Message,"Tests", DateTime.Now);
                }
                finally
                {

                    connection.Close();

                }

                return (rowsAffected > 0);

            }

            public static DataTable GetAllTests()
            {

                DataTable dt = new DataTable();
                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = "SELECT * FROM Tests";

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
                    clsErrorDate.AddNewError(ex.Message,"Tests", DateTime.Now);
                }
                finally
                {
                    connection.Close();
                }

                return (dt != null) ? dt : null;
            }

            public static bool IsTestExist(int TestID)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = "SELECT Found=1 FROM Tests WHERE TestID = @TestID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@TestID", TestID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    isFound = reader.HasRows;

                    reader.Close();
                }
                catch (Exception ex)
                {
                    clsErrorDate.AddNewError(ex.Message,"Tests", DateTime.Now);

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
