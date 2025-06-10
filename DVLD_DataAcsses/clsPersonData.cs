using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;  

namespace Drving_VehicleDataAcssecTier
{
    public class clsPersonData
    {
       
        public static bool GetPersonInfoByID(int PersonID, ref string NationalNo, ref string FirstName,
    ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address 
            , ref string Phone, ref string Email , ref int NationalityCountryID, ref string ImagePath)
        {
            
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE PersonID = @PersonID";
            
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                   

                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else
                        ThirdName = string.Empty;


                    LastName = (string)reader["LastName"];

                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                  
                     Gendor = (byte) reader["Gendor"];
                  


                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];

                    if(reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = string.Empty;
                 

                    NationalityCountryID = (int)reader["NationalityCountryID"];


                    if(reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = string.Empty;
               

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
                clsErrorDate.AddNewError(ex.Message,"People", DateTime.Now);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static int AddNewPerson(string NationalNo, string FirstName,
     string SecondName,  string ThirdName,  string LastName,  DateTime DateOfBirth, byte Gendor,  string Address
            ,  string Phone,  string Email,  int NationalityCountryID, string ImagePath)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = @"
INSERT INTO [People]
           ([NationalNo]
           ,[FirstName]
           ,[SecondName]
           ,[ThirdName]
           ,[LastName]
           ,[DateOfBirth]
           ,[Gendor]
           ,[Address]
           ,[Phone]
           ,[Email]
           ,[NationalityCountryID]
           ,[ImagePath])
     VALUES
           (@NationalNo
           ,@FirstName
           ,@SecondName
           ,@ThirdName
           ,@LastName
           ,@DateOfBirth
           ,@Gendor
           ,@Address
           ,@Phone
           ,@Email
           ,@NationalityCountryID
           ,@ImagePath);
 SELECT SCOPE_IDENTITY();
";


            SqlCommand command = new SqlCommand(query, connection);


          
            command.Parameters.AddWithValue("@NationalNo", NationalNo);


            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

            command.Parameters.AddWithValue("@Gendor", Gendor);

            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
   
            


            if (!String.IsNullOrEmpty(ThirdName))
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            if (!String.IsNullOrEmpty(Email))
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);


            if (!String.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

       


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
                }
            }

            catch (Exception ex)
            {
                clsErrorDate.AddNewError(ex.Message,"People", DateTime.Now);

            }

            finally
            {
                connection.Close();
            }


            return PersonID;
        }


        public static bool UpdatePerson(int PersonID,string NationalNo, string FirstName,
     string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, byte Gendor, string Address
            , string Phone, string Email, int NationalityCountryID, string ImagePath)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = @"
UPDATE [People]
   SET [NationalNo] = @NationalNo
      ,[FirstName] = @FirstName
      ,[SecondName] = @SecondName
      ,[ThirdName] = @ThirdName
      ,[LastName] = @LastName
      ,[DateOfBirth] = @DateOfBirth
      ,[Gendor] = @Gendor
      ,[Address] = @Address
      ,[Phone] = @Phone
      ,[Email] = @Email
      ,[NationalityCountryID] = @NationalityCountryID
      ,[ImagePath] = @ImagePath
       WHERE PersonID = @PersonID;
";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
    

            if (!String.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);


            if (!String.IsNullOrEmpty(Email))
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);



            if (!String.IsNullOrEmpty(ThirdName))
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);



            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                clsErrorDate.AddNewError(ex.Message,"People", DateTime.Now);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }


        public static bool DeletePerson(int PersonID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = @"Delete People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                clsErrorDate.AddNewError(ex.Message,"People", DateTime.Now);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static DataTable GetAllPeople()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT * FROM People";

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
                clsErrorDate.AddNewError(ex.Message,"People", DateTime.Now);
            }
            finally
            {
                connection.Close();
            }

            return (dt != null) ? dt : null;
        }

        public static DataTable GetAllPeople_Format()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT  \r\nPeople.PersonID as [Person ID],\r\nPeople.NationalNo as [National No.],\r\nPeople.FirstName as [First Name],\r\nPeople.SecondName as [Secound Name],\r\nPeople.ThirdName as[Third Name],\r\nPeople.LastName as [Last Name],\r\nCASE WHEN People.Gendor = 0 THEN 'Male' WHEN People.Gendor = 1 THEN 'Femail'  END AS Gendor,\r\nPeople.DateOfBirth as [Date of Birth],\r\nCountries.CountryName as [Nationaltiy],\r\nPeople.Phone,\r\nPeople.Email\r\nFROM People INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID\r\n";

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
                clsErrorDate.AddNewError(ex.Message, "People", DateTime.Now);
            }
            finally
            {
                connection.Close();
            }

            return (dt != null) ? dt : null;
        }


        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT Found=1 FROM People WHERE PersonID = @PersonID";

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
                clsErrorDate.AddNewError(ex.Message,"People", DateTime.Now);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsNationalNumberExists(string NationalNo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "Select Exits = 'yes' From People Where People.NationalNo = @NationalNo;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                clsErrorDate.AddNewError(ex.Message,"People", DateTime.Now);
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