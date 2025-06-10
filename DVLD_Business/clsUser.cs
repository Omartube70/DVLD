using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drving_VehicleDataAcssecTier;

namespace Drving_VehicleBusinessTier
{
    public class clsUser
    {
            public enum enMode { AddNew = 0, Update = 1 };
            public enMode Mode = enMode.AddNew;


            public int UserID { get; set; }
            public int PersonID { get; set; }
            public clsPerson PersonInfo { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public bool IsActive { get; set; }
      
    


            public clsUser()
            {
                this.UserID = -1;
                this.PersonID = -1;
                this.UserName = "";
                this.Password = "";
                this.IsActive = false;
                Mode = enMode.AddNew;
            }

            private clsUser(int UserID, int PersonID, string UserName,string Password, bool IsActive)
            {
                this.UserID = UserID;
                this.PersonID = PersonID;
                this.UserName = UserName;
                this.Password = Password;
                this.IsActive = IsActive;
               this.PersonInfo = clsPerson.Find(this.PersonID);
                Mode = enMode.Update;
            }

            private bool _AddNewUser()
            {
                //call DataAccess Layer 

                this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password , this.IsActive);

                return (this.UserID != -1);
            }

            private bool _UpdateUser()
            {
                //call DataAccess Layer 

                return clsUserData.UpdateUser(this.UserID,this.PersonID, this.UserName, this.Password, this.IsActive);
            }

            public static clsUser FindByUserID(int UserID)
            {
            int PersonID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;


                if (clsUserData.GetUserInfoByID(UserID, ref PersonID, ref UserName,ref Password, ref IsActive))

                    return new clsUser(UserID, PersonID,
                               UserName, Password, IsActive);
                else
                    return null; 
            }
        public bool Save()
            {
                switch (Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewUser())
                        {

                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:

                        return _UpdateUser();

                }




                return false;
            }

            public static DataTable GetAllUsers()
            {
                return clsUserData.GetAllUsers();

            }

            public static bool DeleteUser(int UserID)
            {
                return clsUserData.DeleteUser(UserID);
            }

            public static bool isUserExist(int UserID)
            {
                return clsUserData.IsUserExist(UserID);
            }

        public static bool IsUserExistByPersonID(int UserID)
        {
            return clsUserData.IsUserExistByPersonID(UserID);
        }


        public static clsUser FineByUserName_And_Password(string UserName , string Password)
           {
            int PersonID = -1 , UserID = -1;
            bool IsActive = false;



            if (clsUserData.GetUserInfoByUserNameAndPassword(UserName, Password,ref UserID, ref PersonID,ref IsActive))

                return new clsUser(UserID, PersonID,
                           UserName, Password, IsActive);
            else
                return null;

           }

        public static bool IsUserNameExists(string UserName)
        {
            return clsUserData.IsUserNameExists(UserName);
        }

    }
}

