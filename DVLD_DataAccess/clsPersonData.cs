using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DVLD_DataAccess
{
    public class clsPersonData
    {
        public static bool GetPersonInfoByID(int PersonID, ref string FirstName, ref string SecondName,
            ref string ThirdName, ref string LastName, ref string NationalNo, ref DateTime DateOfBirth,
            ref short Gendor, ref string Address, ref string Phone, ref string Email,
            ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("People.GetByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;

                    var firstNameParam = command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50);
                    firstNameParam.Direction = ParameterDirection.Output;

                    var secondNameParam = command.Parameters.Add("@SecondName", SqlDbType.NVarChar, 50);
                    secondNameParam.Direction = ParameterDirection.Output;

                    var thirdNameParam = command.Parameters.Add("@ThirdName", SqlDbType.NVarChar, 50);
                    thirdNameParam.Direction = ParameterDirection.Output;

                    var lastNameParam = command.Parameters.Add("@LastName", SqlDbType.NVarChar, 50);
                    lastNameParam.Direction = ParameterDirection.Output;

                    var nationalNoParam = command.Parameters.Add("@NationalNo", SqlDbType.NVarChar, 20);
                    nationalNoParam.Direction = ParameterDirection.Output;

                    var dobParam = command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime);
                    dobParam.Direction = ParameterDirection.Output;

                    var gendorParam = command.Parameters.Add("@Gendor", SqlDbType.SmallInt);
                    gendorParam.Direction = ParameterDirection.Output;

                    var addressParam = command.Parameters.Add("@Address", SqlDbType.NVarChar, 500);
                    addressParam.Direction = ParameterDirection.Output;

                    var phoneParam = command.Parameters.Add("@Phone", SqlDbType.NVarChar, 20);
                    phoneParam.Direction = ParameterDirection.Output;

                    var emailParam = command.Parameters.Add("@Email", SqlDbType.NVarChar, 50);
                    emailParam.Direction = ParameterDirection.Output;

                    var countryParam = command.Parameters.Add("@NationalityCountryID", SqlDbType.Int);
                    countryParam.Direction = ParameterDirection.Output;

                    var imageParam = command.Parameters.Add("@ImagePath", SqlDbType.NVarChar, 250);
                    imageParam.Direction = ParameterDirection.Output;

                    var isFoundParam = command.Parameters.Add("@IsFound", SqlDbType.Bit);
                    isFoundParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isFound = (bool)isFoundParam.Value;

                    if (isFound)
                    {
                        FirstName = (string)firstNameParam.Value;
                        SecondName = (string)secondNameParam.Value;
                        ThirdName = (string)thirdNameParam.Value;
                        LastName = (string)lastNameParam.Value;
                        NationalNo = (string)nationalNoParam.Value;
                        DateOfBirth = (DateTime)dobParam.Value;
                        Gendor = (short)gendorParam.Value;
                        Address = (string)addressParam.Value;
                        Phone = (string)phoneParam.Value;
                        Email = (string)emailParam.Value;
                        NationalityCountryID = (int)countryParam.Value;
                        ImagePath = (string)imageParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
                isFound = false;
            }

            return isFound;
        }

        public static bool GetPersonInfoByNationalNo(string NationalNo, ref int PersonID,
            ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
            ref DateTime DateOfBirth, ref short Gendor, ref string Address, ref string Phone,
            ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("People.GetByNationalNo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@NationalNo", SqlDbType.NVarChar, 20).Value = NationalNo;

                    var personIdParam = command.Parameters.Add("@PersonID", SqlDbType.Int);
                    personIdParam.Direction = ParameterDirection.Output;

                    var firstNameParam = command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50);
                    firstNameParam.Direction = ParameterDirection.Output;

                    var secondNameParam = command.Parameters.Add("@SecondName", SqlDbType.NVarChar, 50);
                    secondNameParam.Direction = ParameterDirection.Output;

                    var thirdNameParam = command.Parameters.Add("@ThirdName", SqlDbType.NVarChar, 50);
                    thirdNameParam.Direction = ParameterDirection.Output;

                    var lastNameParam = command.Parameters.Add("@LastName", SqlDbType.NVarChar, 50);
                    lastNameParam.Direction = ParameterDirection.Output;

                    var dobParam = command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime);
                    dobParam.Direction = ParameterDirection.Output;

                    var gendorParam = command.Parameters.Add("@Gendor", SqlDbType.SmallInt);
                    gendorParam.Direction = ParameterDirection.Output;

                    var addressParam = command.Parameters.Add("@Address", SqlDbType.NVarChar, 500);
                    addressParam.Direction = ParameterDirection.Output;

                    var phoneParam = command.Parameters.Add("@Phone", SqlDbType.NVarChar, 20);
                    phoneParam.Direction = ParameterDirection.Output;

                    var emailParam = command.Parameters.Add("@Email", SqlDbType.NVarChar, 50);
                    emailParam.Direction = ParameterDirection.Output;

                    var countryParam = command.Parameters.Add("@NationalityCountryID", SqlDbType.Int);
                    countryParam.Direction = ParameterDirection.Output;

                    var imageParam = command.Parameters.Add("@ImagePath", SqlDbType.NVarChar, 250);
                    imageParam.Direction = ParameterDirection.Output;

                    var isFoundParam = command.Parameters.Add("@IsFound", SqlDbType.Bit);
                    isFoundParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isFound = (bool)isFoundParam.Value;

                    if (isFound)
                    {
                        PersonID = (int)personIdParam.Value;
                        FirstName = (string)firstNameParam.Value;
                        SecondName = (string)secondNameParam.Value;
                        ThirdName = (string)thirdNameParam.Value;
                        LastName = (string)lastNameParam.Value;
                        DateOfBirth = (DateTime)dobParam.Value;
                        Gendor = (short)gendorParam.Value;
                        Address = (string)addressParam.Value;
                        Phone = (string)phoneParam.Value;
                        Email = (string)emailParam.Value;
                        NationalityCountryID = (int)countryParam.Value;
                        ImagePath = (string)imageParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
                isFound = false;
            }

            return isFound;
        }

        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("People.GetAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return dt;
        }

        public static int AddNewPerson(string FirstName, string SecondName, string ThirdName,
            string LastName, string NationalNo, DateTime DateOfBirth, short Gendor, string Address,
            string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("People.AddNew", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(ThirdName) ? "" : ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", Gendor);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? "" : Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? "" : ImagePath);

                    var outputParam = command.Parameters.Add("@PersonID", SqlDbType.Int);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    PersonID = (int)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return PersonID;
        }

        public static bool UpdatePerson(int PersonID, string FirstName, string SecondName,
            string ThirdName, string LastName, string NationalNo, DateTime DateOfBirth, short Gendor,
            string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            bool isUpdated = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("People.UpdatePerson", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(ThirdName) ? "" : ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", Gendor);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? "" : Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? "" : ImagePath);

                    var outputParam = command.Parameters.Add("@IsUpdated", SqlDbType.Bit);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isUpdated = (bool)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return isUpdated;
        }

        public static bool DeletePerson(int PersonID)
        {
            bool isDeleted = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("People.DeletePerson", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    var outputParam = command.Parameters.Add("@IsDeleted", SqlDbType.Bit);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isDeleted = (bool)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return isDeleted;
        }

        public static bool IsPersonExist(int PersonID)
        {
            bool isExist = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("People.IsExistByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    var outputParam = command.Parameters.Add("@IsExist", SqlDbType.Bit);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isExist = (bool)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return isExist;
        }

        public static bool IsPersonExist(string NationalNo)
        {
            bool isExist = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("People.IsExistByNationalNo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    var outputParam = command.Parameters.Add("@IsExist", SqlDbType.Bit);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isExist = (bool)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return isExist;
        }
    }
}