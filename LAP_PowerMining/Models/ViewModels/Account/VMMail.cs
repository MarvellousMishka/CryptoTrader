using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAP_PowerMining.Models.ViewModels.Account
{
    public class VMMail
    {
        public string FromAddress { get; set; }
        public string MailBody { get; set; }
        public string Subject { get; set; }


        public VMMail()
        {
            //Inhalt in der Mail
            this.MailBody = "<a href=http://www.yourwebsitename.com/verificationpage.aspx?custid=Session> click here to verify</a> Test";
            //Betreff Mail
            this.Subject = "Verification";
            //Von wem wird mitgeben Parameter
            FromAddress = "cryptotestmishka@hotmail.com";
        }
    }

}