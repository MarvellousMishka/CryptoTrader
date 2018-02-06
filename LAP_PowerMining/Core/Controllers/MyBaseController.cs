using LAP_PowerMining.Core.Enums;
using LAP_PowerMining.Core.ToastrComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAP_PowerMining.Core.Controllers
{
    public class MyBaseController :Controller
    {
        public MyBaseController()
        {
            Toastr = new Toastr();
        }
        public Toastr Toastr { get; set; }

        public ToastMessage AddToastMessage(string title, string message, ToastType toastType)
        {
            return Toastr.AddToastMessage(title, message, toastType);
        }
    }
}