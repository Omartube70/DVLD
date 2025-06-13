using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Drving_VehicleDataAcssecTier
{
    public class clsUserData
    {
            public static bool GetUserInfoByID(int UserID, ref int PersonID, ref string UserName,
            ref string Password, ref bool IsActive)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = "SELECT * FROM Users WHERE UserID = @UserID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        // The record was found
                        isFound = true;

                        PersonID = (int)reader["PersonID"];
                        UserName = (string)reader["UserName"];
                        Password = (string)reader["Password"];
                        IsActive = (bool)reader["IsActive"];



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
                                    clsErrorDate.AddNewError(ex.Message, "Users",DateTime.Now);
                    isFound = false;
                }
                finally
                {
                    connection.Close();
                }

                return isFound;

            }



         public static bool GetUserInfoByUserNameAndPassword(string UserName,
             string Password, ref int UserID, ref int PersonID, ref bool IsActive)
        {
            bool isFound = false;


            SqlConnection connection = new SqlConnection(Settings.ConnectionString);

            string query = "Select * From Users where UserName = @UserName And Password = @Password";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];


                }
                else
                {
                    // The record was not found
                    isFound = false;
                }


            }
            catch (Exception ex)
            {
                clsErrorDate.AddNewError(ex.Message, "Users", DateTime.Now);
            }
            finally
            {
                connection.Close();
            }


            return isFound;
        }




        public static int AddNewUser(int PersonID, string UserName,string Password , bool IsActive)

        {
            int UserID = -1;

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);

            string Quere = @"
INSERT INTO [Users]([PersonID],[UserName],[Password],[IsActive]) 
VALUES(@PersonID,@UserName,@Password,@IsActive) 
;Select SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
          



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString() , out int InsertedID))
                {
                    UserID = InsertedID;
                }
                else
                {
                    UserID = -1;
                }
            }
            catch (Exception ex)
            {
                                    clsErrorDate.AddNewError(ex.Message, "Users",DateTime.Now);
                UserID = -1;
            }
            finally
            {
                connection.Close();
            }
            return UserID;
        }


            public static bool UpdateUser(int UserID, int PersonID, string UserName,
             string Password, bool IsActive)
            {

                int rowsAffected = 0;
                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = @"

UPDATE [Users]
   SET [PersonID] = @PersonID
      ,[UserName] = @UserName
      ,[Password] = @Password
      ,[IsActive] = @IsActive
 WHERE UserID = @UserID;
";

                SqlCommand command = new SqlCommand(query, connection);



            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@UserID", UserID);



            try
            {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message, "Users", DateTime.Now);
                return false;
                }

                finally
                {
                    connection.Close();
                }

                return (rowsAffected > 0);
            }


            public static bool DeleteUser(int UserID)
            {

                int rowsAffected = 0;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = @"Delete Users WHERE UserID = @UserID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();

                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                                       clsErrorDate.AddNewError(ex.Message, "Users",DateTime.Now);
                }
                finally
                {

                    connection.Close();

                }

                return (rowsAffected > 0);

            }

            public static DataTable GetAllUsers()
            {

                DataTable dt = new DataTable();
                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = "Select UserID ,People.PersonID , FirstName + ' ' + SecondName +' ' + ISNULL(ThirdName,'') +' ' + LastName as FullName ,UserName , IsActive   From Users Inner Join People On Users.PersonID = People.PersonID;";

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
                                       clsErrorDate.AddNewError(ex.Message, "Users",DateTime.Now);
                }
                finally
                {
                    connection.Close();
                }

                return (dt != null) ? dt : null;
            }



        public static bool IsUserExist(int UserID)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(Settings.ConnectionString);

                string query = "SELECT Found=1 FROM Users WHERE UserID = @UserID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    isFound = reader.HasRows;

                    reader.Close();
                }
                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message,"Users", DateTime.Now);
                isFound = false;
                }
                finally
                {
                    connection.Close();
                }

                return isFound;
            }

        public static bool IsUserExistByPersonID(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                clsErrorDate.AddNewError(ex.Message, "Users", DateTime.Now);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsUserNameExists(string UserName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(Settings.ConnectionString);

            string query = "Select Exits = 'yes' From Users Where Users.UserName = @UserName;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                clsErrorDate.AddNewError(ex.Message, "Users", DateTime.Now);
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
