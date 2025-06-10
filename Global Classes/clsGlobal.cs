using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drving_VehicleBusinessTier;

namespace DVLDBussiensTier
{
    public class clsGlobal
    {
       static public clsUser CurrentUser { get; set; }

       static public void SaveRemberUserToFile(string UserName , string Password)
        {
            if(!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password)) 
                File.WriteAllText("RemberUser.txt", UserName + "\n" + Password);

            else
                File.WriteAllText("RemberUser.txt","");
        }

       static public bool GetStoredCredential(ref string UserName,ref string Password)
        {
            if (File.Exists("RemberUser.txt"))
            {
                string[] lines = File.ReadAllLines("RemberUser.txt");

                if (lines.Length >= 1)
                {
                    UserName = lines[0];
                    Password = lines[1];
                    return true;
                }
            }
            return false;
        }

    }
}
