using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drving_VehicleDataAcssecTier
{
    public class clsDriverDate
    {
            public static bool GetDriverInfoByID(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = "SELECT * FROM Drivers WHERE DriverID = @DriverID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@DriverID", DriverID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        // The record was found
                        isFound = true;

                        PersonID       = (int)reader["PersonID"];
                       CreatedByUserID = (int)reader["CreatedByUserID"];
                       CreatedDate     = (DateTime)reader["CreatedDate"];


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
                                    clsErrorDate.AddNewError(ex.Message, "Drivers", DateTime.Now);
                    isFound = false;
                }
                finally
                {
                    connection.Close();
                }

                return isFound;

            }


            public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)

            {
                int DriverID = -1;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string Quere = @"
INSERT INTO [Drivers]
           ([PersonID]
           ,[CreatedByUserID]
           ,[CreatedDate])
     VALUES(@PersonID,@CreatedByUserID,@CreatedDate)
;Select SCOPE_IDENTITY();";


                SqlCommand command = new SqlCommand(Quere, connection);

                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@CreatedDate", CreatedDate);


                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {
                        DriverID = InsertedID;
                    }
                    else
                    {
                        DriverID = -1;
                    }
                }
                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message, "Detained Licenses", DateTime.Now);
                DriverID = -1;
                }
                finally
                {
                    connection.Close();
                }
                return DriverID;
            }


            public static bool UpdateDriver(int DriverID, int PersonID,int CreatedByUserID, DateTime CreatedDate)
            {

                int rowsAffected = 0;
                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = @"
UPDATE [Drivers]
   SET [PersonID] = @PersonID
      ,[CreatedByUserID] = @CreatedByUserID
      ,[CreatedDate] = @CreatedDate
 WHERE DriverID = @DriverID;
";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                command.Parameters.AddWithValue("@DriverID", DriverID);



                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                                    clsErrorDate.AddNewError(ex.Message, "Drivers", DateTime.Now);
                    return false;
                }

                finally
                {
                    connection.Close();
                }

                return (rowsAffected > 0);
            }


            public static bool DeleteDriver(int DriverID)
            {

                int rowsAffected = 0;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = @"Delete Drivers WHERE DriverID = @DriverID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@DriverID", DriverID);

                try
                {
                    connection.Open();

                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                                    clsErrorDate.AddNewError(ex.Message, "Drivers", DateTime.Now);
                }
                finally
                {

                    connection.Close();

                }

                return (rowsAffected > 0);

            }



             public static DataTable GetAllDrivers()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(Settings.ConnectionString);

            string query = "SELECT        Drivers.DriverID as [Driver ID], People.PersonID as [Person ID], People.NationalNo as [National No.], People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName as [Full Name], Drivers.CreatedDate as [Date]\r\nFROM            Drivers INNER JOIN\r\n                         People ON Drivers.PersonID = People.PersonID";

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
                clsErrorDate.AddNewError(ex.Message, "Drivers", DateTime.Now);
            }
            finally
            {
                connection.Close();
            }

            return (dt != null) ? dt : null;
        }

             public static int GetDriverIdByPersonID(int PersonID)
        {
            int DriverID = -1;

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);

            string query = "SELECT DriverID FROM  Drivers where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int Id))
                {
                    DriverID = Id;
                }

            }
            catch (Exception ex)
            {
                clsErrorDate.AddNewError(ex.Message, "Drivers", DateTime.Now);
            }
            finally
            {
                connection.Close();
            }

            return DriverID;
        }



        public static bool IsDriverExist(int DriverID)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = "SELECT Found=1 FROM Drivers WHERE DriverID = @DriverID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@DriverID", DriverID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    isFound = reader.HasRows;

                    reader.Close();
                }
                catch (Exception ex)
                {
                                    clsErrorDate.AddNewError(ex.Message, "Drivers", DateTime.Now);
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
