using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DVLD_DataAccess
{
    public class clsTestTypeData
    {
        public static bool GetTestTypeInfoByID(int TestTypeID,
            ref string TestTypeTitle, ref string TestDescription, ref float TestFees)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("TestTypes.GetByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = TestTypeID;

                    var titleParam = command.Parameters.Add("@TestTypeTitle", SqlDbType.NVarChar, 100);
                    titleParam.Direction = ParameterDirection.Output;

                    var descParam = command.Parameters.Add("@TestDescription", SqlDbType.NVarChar, 500);
                    descParam.Direction = ParameterDirection.Output;

                    var feesParam = command.Parameters.Add("@TestFees", SqlDbType.SmallMoney);
                    feesParam.Direction = ParameterDirection.Output;

                    var isFoundParam = command.Parameters.Add("@IsFound", SqlDbType.Bit);
                    isFoundParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    isFound = (bool)isFoundParam.Value;

                    if (isFound)
                    {
                        TestTypeTitle = (string)titleParam.Value;
                        TestDescription = (string)descParam.Value;
                        TestFees = Convert.ToSingle(feesParam.Value);
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

        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("TestTypes.GetAll", connection))
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

        public static int AddNewTestType(string Title, string Description, float Fees)
        {
            int TestTypeID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("TestTypes.AddNew", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@Fees", Fees);

                    var outputParam = command.Parameters.Add("@TestTypeID", SqlDbType.Int);
                    outputParam.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    TestTypeID = (int)outputParam.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DVLD", "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return TestTypeID;
        }

        public static bool UpdateTestType(int TestTypeID, string Title, string Description, float Fees)
        {
            bool isUpdated = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand("TestTypes.UpdateTest", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@Fees", Fees);

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
    }
}