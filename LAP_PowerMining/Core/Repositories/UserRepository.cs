using LAP_PowerMining.Models.ViewModels.Account;
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
        public bool LogInUser(VMLogin loginInfo)
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
    }
}