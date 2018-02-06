using LAP_PowerMining.Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace LAP_PowerMining.Core.Helpers
{
    public class LoginHelper
    {
        public static bool LoginUser(VMLogin loginData)
        {
            string userId = loginData.Email;
            var authTicket = new FormsAuthenticationTicket(
                            1,  //Ticketversion
                            userId, //Useridentifizierung
                            DateTime.Now, //Zeitpunkt der Erstellung
                            DateTime.Now.AddMinutes(30), //Wann das Ticket ablaeuft
                            false, //Persistentes Ticket?
                            "" //Userdata
                            );

            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            HttpContext.Current.Response.Cookies.Add(authCookie);
            return true;
        }

        public static void Logout()
        {
            FormsAuthentication.SignOut();
        }

    }
}