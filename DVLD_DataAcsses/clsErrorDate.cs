using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drving_VehicleDataAcssecTier
{
    public class clsErrorDate
    {

        public static bool GetErrorInfoByID(int ErrorID, ref string Message,ref string TableName, ref DateTime ErrorDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT * FROM Errors WHERE ErrorID = @ErrorID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ErrorID", ErrorID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    Message = (string)reader["Message"];
                    TableName = (string)reader["TableName"];
                    ErrorDate = (DateTime)reader["ErrorDate"];
                   


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
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }

        public static int AddNewError(string Message, string TableName , DateTime ErrorDate)
        {
            int ErrorID = -1;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string Quere = @"
INSERT INTO [Errors] ([Message] ,[TableName],[ErrorDate] ) 
VALUES(@Message ,@TableName,@ErrorDate) 
;Select SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(Quere, connection);

            command.Parameters.AddWithValue("@Message", Message);
            command.Parameters.AddWithValue("@ErrorDate", ErrorDate);
            command.Parameters.AddWithValue("@TableName", TableName);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    ErrorID = InsertedID;
                }
                else
                {
                    ErrorID = -1;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                ErrorID = -1;
            }
            finally
            {
                connection.Close();
            }
            return ErrorID;
        }

        public static bool DeleteError(int ErrorID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = @"Delete Errors WHERE ErrorID = @ErrorID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ErrorID", ErrorID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static DataTable GetAllErrors()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT * FROM Errors";

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
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (dt != null) ? dt : null;
        }

        public static bool IsErrorExist(int ErrorID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Errors WHERE ErrorID = @ErrorID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ErrorID", ErrorID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
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
