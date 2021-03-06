﻿using LAP_PowerMining.Models.ViewModels.Account;
using LAP_PowerMining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAP_PowerMining.Models.DatabaseModel;
using LAP_PowerMining.Core.Helpers;
using LAP_PowerMining.Core.Enums;

namespace LAP_PowerMining.Core.Repositories
{
    public class UserRepository
    {
        public bool CheckLogin(VMLogin loginInfo)
        {
            bool result = false;
            using (var db = new LocalDbEntities2())
            {
                User dbUser = db.User.Where(u => u.email == loginInfo.Email && u.active == true).FirstOrDefault();
                if (dbUser != null)
                {
                    loginInfo.Password += dbUser.salt;
                    loginInfo.Password = HashingHelper.HashBerechnen(loginInfo.Password);
                    if (loginInfo.Password == dbUser.password)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        /// Per default ADMIN ROLE will be signed to the user where
        /// EMAIL="super@user.at"
        /// TODO: Think about a better solution...

        public int CreateUser(VMRegister registerInfo)
        {
            int result = (int)RegisterType.Error;
            string hashedSaltedPw = "";
            string salt = "";

            using (var db = new LocalDbEntities2())
            {
                User dbUser = db.User.Where(u => u.email == registerInfo.Email).FirstOrDefault();
                if (dbUser == null)
                {
                    hashedSaltedPw = HashingHelper.SaltAndHashPassword(registerInfo.Password, out salt);
                    int userRole = (int)UserRoles.User;

                    if (registerInfo.Email == "super@user.at")
                    {
                        userRole = (int)UserRoles.Admin;
                    }
                    dbUser = new User
                    {
                        salt = salt,
                        password = hashedSaltedPw,
                        email = registerInfo.Email,
                        lastname = registerInfo.LastName,
                        firstname = registerInfo.FirstName,
                        role = userRole,
                        active = true,
                        status = (int)UserState.NotVerified,
                        created = DateTime.Now
                    };
                    db.User.Add(dbUser);
                    db.SaveChanges();
                    result = (int)RegisterType.Success;
                }
                else
                {
                    result = (int)RegisterType.UserExisting;
                }
            }
            return result;
        }
        public List<string> GetRoles(string email)
        {
            List<string> result = new List<string>();
            using (var db = new LocalDbEntities2())
            {
                User dbUser = db.User.Where(u => u.email == email && u.active == true).FirstOrDefault();
                switch ((int)dbUser.role)
                {
                    case (int)UserRoles.Admin:
                        result = new List<string> { UserRoles.Admin.ToString() };
                        break;

                    case (int)UserRoles.User:
                        result = new List<string> { UserRoles.User.ToString() };
                        break;
                }
            }
            return result;
        }
        public VMAddress GetAddress(string email)
        {
            VMAddress result = null;
            using (var db = new LocalDbEntities2())
            {
                var dbAddress = db.Address.Where(a => a.User.email == email).FirstOrDefault();
                result = new VMAddress
                {
                    CityName = dbAddress.City.city1,
                    CountryIso = dbAddress.City.Country.iso,
                    CountryName = dbAddress.City.Country.name,
                    Numbers = dbAddress.numbers,
                    Street = dbAddress.street,
                    Zip = dbAddress.City.zip
                };
            }
            return result;
        }
        public VMUserData GetUserData(string email)
        {
            VMUserData result = null;
            using (var db = new LocalDbEntities2())
            {
                User dbUser = db.User.Where(u => u.email == email && u.active == true).FirstOrDefault();
                result = new VMUserData
                {
                    FirstName = dbUser.firstname,
                    LastName = dbUser.lastname
                };
            }
            return result;
        }
        public int UpdateUser(VMUserData changedData, string userMail)
        {
            int result = -1;
            using (var db = new LocalDbEntities2())
            {
                User dbUser = db.User.Where(u => u.email == userMail && u.active == true).FirstOrDefault();

                if (!string.IsNullOrEmpty(changedData.FirstName))
                {
                    dbUser.firstname = changedData.FirstName;
                }
                if (!string.IsNullOrEmpty(changedData.LastName))
                {
                    dbUser.lastname = changedData.LastName;
                }
                if (!string.IsNullOrEmpty(changedData.NewPassword))
                {
                    string salt = "";
                    dbUser.password = HashingHelper.SaltAndHashPassword(changedData.NewPassword, out salt);
                    dbUser.salt = salt;
                }
                db.SaveChanges();
            }
            return result;
        }
    }
}