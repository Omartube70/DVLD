using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Drving_VehicleDataAcssecTier
{
    public class clsApplicationTypeDate
    {
            public static bool GetApplicationTypeInfoByID(int ApplicationTypeID, 
                ref string ApplicationTypeTitle, ref float ApplicationFees)
            {

                bool isFound = false;

                SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

                string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        // The record was found
                        isFound = true;

                      ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];


                     

                      ApplicationFees = Convert.ToSingle( reader["ApplicationFees"]);
                        

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
                clsErrorDate.AddNewError(ex.Message, "Application Types", DateTime.Now);
                isFound = false;
                }
                finally
                {
                    connection.Close();
                }

                return isFound;
            }



            public static bool UpdateApplicationType(int ApplicationTypeID, 
                string ApplicationTypeTitle, float ApplicationFees)
            {

                int rowsAffected = 0;
                SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

                string query = @"
UPDATE [ApplicationTypes]
   SET [ApplicationTypeTitle] = @ApplicationTypeTitle
      ,[ApplicationFees]      = @ApplicationFees
 WHERE ApplicationTypeID      = @ApplicationTypeID
";

                SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);


                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message, "Application Types", DateTime.Now);
                return false;
                }

                finally
                {
                    connection.Close();
                }

                return (rowsAffected > 0);
            }


            public static DataTable GetAllApplicationTypes()
            {

                DataTable dt = new DataTable();
                SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

                string query = "SELECT * FROM ApplicationTypes";

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
                clsErrorDate.AddNewError(ex.Message, "Application Types", DateTime.Now);
            }
            finally
                {
                    connection.Close();
                }

                return (dt != null) ? dt : null;
            }

            public static bool IsApplicationTypeExist(int ApplicationTypeID)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(clsDataAcssecTierSettings.ConnectionString);

                string query = "SELECT Found=1 FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    isFound = reader.HasRows;

                    reader.Close();
                }
                catch (Exception ex)
                {
                clsErrorDate.AddNewError(ex.Message, "Application Types", DateTime.Now);
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
