using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drving_VehicleDataAcssecTier
{
    public class clsTestTypeDate
    {

        public static bool GetTestTypeInfoByID(int TestTypeID,
     ref string TestTypeTitle, ref string TestTypeDescription , ref float TestTypeFees)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];
                    TestTypeFees = Convert.ToSingle(reader["TestTypeFees"]);


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
               clsErrorDate.AddNewError(ex.Message, "Test Types", DateTime.Now);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }



        public static bool UpdateTestType(int TestTypeID,
      string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = @"
UPDATE [TestTypes]
   SET [TestTypeTitle] = @TestTypeTitle
      ,[TestTypeDescription] = @TestTypeDescription
      ,[TestTypeFees] = @TestTypeFees
 WHERE TestTypeID = @TestTypeID
";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
               clsErrorDate.AddNewError(ex.Message, "Test Types", DateTime.Now);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }


        public static DataTable GetAllTestTypes()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT * FROM TestTypes";

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
               clsErrorDate.AddNewError(ex.Message, "Test Types", DateTime.Now);
            }
            finally
            {
                connection.Close();
            }

            return (dt != null) ? dt : null;
        }

        public static bool IsTestTypeExist(int TestTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT Found=1 FROM TestTypes WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
               clsErrorDate.AddNewError(ex.Message, "Test Types", DateTime.Now);
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
