using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drving_VehicleBusinessTier;
using DVLD.Properties;

namespace DVLD
{
    static public class clsGlobal
    {
       static public clsUser CurrentUser { get; set; }

        static public void SaveRememberUserToSettings(string userName, string password)
        {
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
            {
                Properties.Settings.Default.Username = userName;
                Properties.Settings.Default.Password = SimpleEncryptor.Encrypt(password);
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Save();
            }
        }

        static public bool GetStoredCredential(ref string userName, ref string password)
        {
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.Username) &&
                !string.IsNullOrWhiteSpace(Properties.Settings.Default.Password))
            {
                userName = Properties.Settings.Default.Username;
                password = SimpleEncryptor.Decrypt(Properties.Settings.Default.Password);
                return true;
            }

            return false;
        }

    }
}
