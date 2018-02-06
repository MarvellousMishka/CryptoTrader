using LAP_PowerMining.Core.Enums;
using LAP_PowerMining.Core.Helpers;
using LAP_PowerMining.Core.Repositories;
using LAP_PowerMining.Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAP_PowerMining.Core.Services
{
    public static class AccountService
    {
        static UserRepository context = new UserRepository();

        public static bool LogOutUser()
        {
            LoginHelper.Logout();
            return true;
        }
        public static bool LogInUser(VMLogin loginInfo)
        {
            bool result = context.CheckLogin(loginInfo);
            if (result == true)
            {
                LoginHelper.LoginUser(loginInfo);
            }
            loginInfo.Password = "";
            return result;
        }
        public static int RegisterUser(VMRegister registerInfo)
        {
            if (registerInfo.Password != registerInfo.ConfirmPassword)
            {
                return (int)RegisterType.PasswordsDifferent;
            }
            int result = context.CreateUser(registerInfo);
            if (result == (int)RegisterType.Success)
            {
                LoginHelper.LoginUser(new VMLogin
                {
                    Email = registerInfo.Email,
                    Password = registerInfo.Password
                });
                MailHelper.SendEmail(registerInfo.Email);
            }
            return result;
        }
        public static int UpdateUser(VMUserData userData, string userMail)
        {
            int result = -1;
            int tempResult = -1;
            // Gathers all data which are allowed to be changed
            VMUserData dataValidToChange = new VMUserData();

            if (!string.IsNullOrEmpty(userData.FirstName)) { dataValidToChange.FirstName = userData.FirstName; }
            if (!string.IsNullOrEmpty(userData.LastName)) { dataValidToChange.LastName = userData.LastName; }

            if (!string.IsNullOrEmpty(userData.OldPassword) && !string.IsNullOrEmpty(userData.NewPassword) && !string.IsNullOrEmpty(userData.ConfirmNewPassword))
            {
                VMLogin testOldPw = new VMLogin
                {
                    Email = userMail,
                    Password = userData.OldPassword
                };
                if (userData.NewPassword == userData.ConfirmNewPassword)
                {
                    if (context.CheckLogin(testOldPw))
                    {
                        dataValidToChange.NewPassword = userData.NewPassword;
                    }
                }
            }
            tempResult = context.UpdateUser(dataValidToChange, userMail);
            
            userData.ConfirmNewPassword = "";
            userData.NewPassword = "";
            userData.OldPassword = "";
            return result;
        }

        public static VMUserData GetUserData(string email)
        {
            return context.GetUserData(email);
        }
    }
}