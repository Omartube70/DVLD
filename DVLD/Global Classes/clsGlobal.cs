using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;
using Microsoft.Win32;


namespace DVLD.Classes
{
    internal static  class clsGlobal
    {
        public static clsUser CurrentUser;

        private static string RegistryPath = "HKEY_CURRENT_USER\\Software\\DVLD\\Credential";


        private static string _ValueName_Username = "Username";
        private static string _ValueName_Password = "Password";

        public static bool RemoveCredentialKey()
        {
            string subKey = RegistryPath.Replace("HKEY_CURRENT_USER\\", "");

            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(subKey, false);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {

            try
            {
                if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                {
                    RemoveCredentialKey();
                }

                Registry.SetValue(RegistryPath, _ValueName_Username, Username, RegistryValueKind.String);
                Registry.SetValue(RegistryPath, _ValueName_Password, Password, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
               MessageBox.Show ($"An error occurred: {ex.Message}");
                return false;
            }

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            try
            {
                string username = Registry.GetValue(RegistryPath, _ValueName_Username, null) as string;

                if(!string.IsNullOrEmpty(username))
                {
                    Username = username;
                }
                else
                {
                    return false;
                }

                string password = Registry.GetValue(RegistryPath, _ValueName_Password, null) as string;

                if (!string.IsNullOrEmpty(password))
                {
                    Password = password;
                }
                else
                {
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show ($"An error occurred: {ex.Message}");
                return false;   
            }

        }
    }
}
