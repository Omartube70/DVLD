using System;
using System.Data;
using System.Runtime.InteropServices;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsUser
    {
        /// <summary>
        /// Represents the working mode of the user object (AddNew or Update).
        /// </summary>
        public enum enMode { AddNew = 0, Update = 1 };

        /// <summary>
        /// Indicates whether the current user object is in AddNew or Update mode.
        /// </summary>
        public enMode Mode = enMode.AddNew;

        /// <summary>
        /// Unique ID of the user.
        /// </summary>
        public int UserID { set; get; }

        /// <summary>
        /// ID of the related person.
        /// </summary>
        public int PersonID { set; get; }

        /// <summary>
        /// Contains detailed information about the person.
        /// </summary>
        public clsPerson PersonInfo;

        /// <summary>
        /// Username used for login.
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// Hashed password (setter hashes automatically).
        /// </summary>
        private string _PasswordHash;

        /// <summary>
        /// get hash password
        /// </summary>
        public string Password
        {
            set { _PasswordHash = clsPasswordHasher.HashPassword(value); }
        }

        /// <summary>
        /// Indicates whether the user account is active.
        /// </summary>
        public bool IsActive { set; get; }

        /// <summary>
        /// Default constructor - initializes object in AddNew mode.
        /// </summary>
        public clsUser()
        {
            this.UserID = -1;
            this.UserName = "";
            this._PasswordHash = "";
            this.IsActive = true;
            Mode = enMode.AddNew;
        }

        /// <summary>
        /// Private constructor for loading existing users from the database.
        /// </summary>
        private clsUser(int UserID, int PersonID, string Username, string PasswordHash, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.UserName = Username;
            this._PasswordHash = PasswordHash;
            this.IsActive = IsActive;
            Mode = enMode.Update;
        }

        /// <summary>
        /// Inserts a new user into the database.
        /// </summary>
        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this._PasswordHash, this.IsActive);
            return (this.UserID != -1);
        }

        /// <summary>
        /// Updates an existing user record in the database.
        /// </summary>
        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.UserName, this._PasswordHash, this.IsActive);
        }

        /// <summary>
        /// Finds a user using the UserID.
        /// </summary>
        public static clsUser FindByUserID(int UserID)
        {
            int PersonID = -1;
            string UserName = "", PasswordHash = "";
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUserID(UserID, ref PersonID, ref UserName, ref PasswordHash, ref IsActive);

            if (IsFound)
                return new clsUser(UserID, PersonID, UserName, PasswordHash, IsActive);
            else
                return null;
        }

        /// <summary>
        /// Finds a user using the PersonID.
        /// </summary>
        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", PasswordHash = "";
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByPersonID(PersonID, ref UserID, ref UserName, ref PasswordHash, ref IsActive);

            if (IsFound)
                return new clsUser(UserID, UserID, UserName, PasswordHash, IsActive);
            else
                return null;
        }

        /// <summary>
        /// Finds a user by username and password.
        /// </summary>
        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            bool IsActive = false;
            string PasswordHash = clsPasswordHasher.HashPassword(Password);

            bool IsFound = clsUserData.GetUserInfoByUsernameAndPasswordHash(UserName, PasswordHash, ref UserID, ref PersonID, ref IsActive);

            if (IsFound)
                return new clsUser(UserID, PersonID, UserName, PasswordHash, IsActive);
            else
                return null;
        }

        /// <summary>
        /// Verifies a raw password against the stored hashed password.
        /// </summary>
        public bool VerifyPassword(string Password)
        {
            string PasswordHash = clsPasswordHasher.HashPassword(Password);
            return (this._PasswordHash == PasswordHash);
        }

        /// <summary>
        /// Saves the user (insert or update based on Mode).
        /// </summary>
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
                        return false;

                case enMode.Update:
                    return _UpdateUser();
            }
            return false;
        }

        /// <summary>
        /// Returns a list of all users in the system.
        /// </summary>
        public static DataTable GetPaged(int PageNumber = 1, int RowsPerPage = 100, string FilterColumn = null, string FilterValue = null)
        {
            return clsUserData.GetPaged(PageNumber,RowsPerPage,FilterColumn,FilterValue);
        }

        public static bool GetPagingInfo(ref int TotalRecords, ref int TotalPage, int RowsPerPage = 100)
        {
            return clsUserData.GetPagingInfo(RowsPerPage, ref TotalRecords, ref TotalPage);
        }


        /// <summary>
        /// Deletes a user by UserID.
        /// </summary>
        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        /// <summary>
        /// Checks if a user exists by UserID.
        /// </summary>
        public static bool isUserExist(int UserID)
        {
            return clsUserData.IsUserExist(UserID);
        }

        /// <summary>
        /// Checks if a username exists.
        /// </summary>
        public static bool isUserExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }

        /// <summary>
        /// Checks if a user is linked to a specific PersonID.
        /// </summary>
        public static bool isUserExistForPersonID(int PersonID)
        {
            return clsUserData.IsUserExistForPersonID(PersonID);
        }
    }
}
