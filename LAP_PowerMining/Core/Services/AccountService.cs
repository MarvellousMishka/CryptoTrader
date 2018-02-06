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
            bool result = context.LogInUser(loginInfo);
            if (result == true)
            {
                LoginHelper.LoginUser(loginInfo);
            }
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
        public static int UpdateUser(VMRegister userInfo)
        {
            int result = -1;
            
            return result;
        }
    }
}