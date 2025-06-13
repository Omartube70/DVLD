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
    public class clsDetainedLicensDate
    {
            public static bool GetDetainedLicensInfoByID(int DetainID, ref int LicenseID, ref DateTime DetainDate,
            ref float FineFees, ref int CreatedByUserID, ref bool IsReleased , ref DateTime ReleaseDate , ref int ReleasedByUserID,
                ref int ReleaseApplicationID)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@DetainID", DetainID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // The record was found
                        isFound = true;

                     LicenseID = (int)reader["LicenseID"];

                    DetainDate = (DateTime)reader["DetainDate"];

                    FineFees =  Convert.ToSingle(reader["FineFees"]);

                    CreatedByUserID =  (int)reader["CreatedByUserID"];

                    IsReleased =  (bool)reader["IsReleased"];

                    ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? (DateTime)reader["ReleaseDate"] : DateTime.MinValue;

                    ReleasedByUserID = reader["ReleasedByUserID"] != DBNull.Value ? (int)reader["ReleasedByUserID"] : 0;

                    ReleaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value ? (int)reader["ReleaseApplicationID"] : 0;

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
                                    clsErrorDate.AddNewError(ex.Message, "Detained Licenses", DateTime.Now);
                    isFound = false;
                }
                finally
                {
                    connection.Close();
                }

                return isFound;
            }


            public static int AddNewDetainedLicens(int LicenseID, DateTime DetainDate,
             float FineFees,  int CreatedByUserID,  bool IsReleased,  DateTime ReleaseDate,  int ReleasedByUserID,
                 int ReleaseApplicationID)
            {
                int DetainID = -1;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string Quere = @"
INSERT INTO [DetainedLicenses]
           ([LicenseID]
           ,[DetainDate]
           ,[FineFees]
           ,[CreatedByUserID]
           ,[IsReleased]
           ,[ReleaseDate]
           ,[ReleasedByUserID]
           ,[ReleaseApplicationID])
     VALUES
           (@LicenseID,@DetainDate,@FineFees,@CreatedByUserID,@IsReleased,@ReleaseDate,@ReleasedByUserID,@ReleaseApplicationID);
Select SCOPE_IDENTITY();";


                SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);

 
            if(ReleaseDate != DateTime.MinValue)
            {
                command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            }



            if (ReleasedByUserID != -0)
            {
                command.Parameters.AddWithValue("@ReleasedByUserID",  ReleasedByUserID);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
            }





            if (ReleaseApplicationID != 0) {
                command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
            }
       

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    {
                    DetainID = InsertedID;
                    }
                    else
                    {
                    DetainID = -1;
                    }
                }
                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message, "Detained Licenses", DateTime.Now);
                DetainID = -1;
                }
                finally
                {
                    connection.Close();
                }


                return DetainID;
        }


            public static bool UpdateDetainedLicens(int DetainID, int LicenseID, DateTime DetainDate,
             float FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID,
                 int ReleaseApplicationID)
            {

                int rowsAffected = 0;
                SqlConnection connection = new SqlConnection(Settings.ConnectionString);
                string Quere = @"
UPDATE [DetainedLicenses]
   SET [LicenseID]            = @LicenseID
      ,[DetainDate]           = @DetainDate
      ,[FineFees]             = @FineFees
      ,[CreatedByUserID]      = @CreatedByUserID
      ,[IsReleased]           = @IsReleased
      ,[ReleaseDate]          = @ReleaseDate
      ,[ReleasedByUserID]     = @ReleasedByUserID
      ,[ReleaseApplicationID] = @ReleaseApplicationID
       WHERE DetainID = @DetainID;
";

                SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            command.Parameters.AddWithValue("@DetainID", DetainID);


            if (ReleaseDate != DateTime.MinValue)
            {
                command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            }

            if (ReleasedByUserID != 0)
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
            }

            if (ReleaseApplicationID != 0)
            {
                command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
            }



            try
            {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message, "Detained Licenses", DateTime.Now);
                return false;
                }

                finally
                {
                    connection.Close();
                }

                return (rowsAffected > 0);
            }


            public static bool DeleteDetainedLicens(int DetainID)
            {

                int rowsAffected = 0;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = @"Delete DetainedLicenses WHERE DetainID = @DetainID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@DetainID", DetainID);

                try
                {
                    connection.Open();

                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message, "Detained Licenses", DateTime.Now);
            }
            finally
                {

                    connection.Close();

                }

                return (rowsAffected > 0);

            }

            public static DataTable GetAllDetainedLicenses()
            {

                DataTable dt = new DataTable();
                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = "SELECT * FROM DetainedLicenses";

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
                clsErrorDate.AddNewError(ex.Message, "Detained Licenses", DateTime.Now);
            }
            finally
                {
                    connection.Close();
                }

                return (dt != null) ? dt : null;
            }

        public static DataTable GetAllDetainedLicenses_Format()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(Settings.ConnectionString);

            string query = "SELECT DetainedLicenses.DetainID as [D.ID],\r\nDetainedLicenses.LicenseID as [L.ID],\r\nDetainedLicenses.DetainDate as [D.Date],\r\nDetainedLicenses.IsReleased as [Is Released],\r\nDetainedLicenses.FineFees as [Fine Fees],\r\nDetainedLicenses.ReleaseDate as [Release Date],\r\nPeople.NationalNo as [N.No.], \r\nPeople.FirstName + ' ' +  People.SecondName  + ' ' +  People.ThirdName  + ' ' +  People.LastName as [Full Name],\r\nDetainedLicenses.ReleaseApplicationID as [Releas.App.ID]\r\nFROM DetainedLicenses Inner Join Licenses On DetainedLicenses.LicenseID = Licenses.LicenseID\r\nInner Join Applications On Licenses.ApplicationID = Applications.ApplicationID\r\nInner Join People On People.PersonID = Applications.ApplicationPersonID";

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
                clsErrorDate.AddNewError(ex.Message, "Detained Licenses", DateTime.Now);
            }
            finally
            {
                connection.Close();
            }

            return (dt != null) ? dt : null;
        }



        public static bool IsDetainedLicensExist(int DetainID)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = "SELECT Found=1 FROM DetainedLicenses WHERE DetainID = @DetainID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@DetainID", DetainID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    isFound = reader.HasRows;

                    reader.Close();
                }
                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message, "Detained Licenses", DateTime.Now);
                isFound = false;
                }
                finally
                {
                    connection.Close();
                }

                return isFound;
            }

        public static int GetDetainIdByLicenseId(int LicenseId)
        {
            int DetainID = -1;

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);

            string query = "SELECT DetainID FROM  DetainedLicenses where LicenseId = @LicenseId And IsReleased = 0";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseId", LicenseId);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int Id))
                {
                    DetainID = Id;
                }

            }
            catch (Exception ex)
            {
                clsErrorDate.AddNewError(ex.Message, "Detained Licenses", DateTime.Now);
            }
            finally
            {
                connection.Close();
            }

            return DetainID;
        }


    }
}
