using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
   public static class UserMessages
    {

        public static string UserAdded = "User added";
        public static string UserUpdated = "User updated";
        public static string UserListed = "User listed";
        public static string UserDeleted = "User deleted";

        public static string UserDidNotAdd = "User did't  add";
        public static string UserDidNotUpdate = "User didn't update";
        public static string UserDidNotListed = "User didn't  list";
        public static string UserDidNotDelete = "User didn't delete";
        public static string AccessCreateToken = "";

        public static string UserNotFound = "User  didn't  find";
        public static string PasswordError = "User entry password error";
        public static string SuccessfulLogin = "Successful Login";
        public static string UserAlreadyExists = "";
    }
}

