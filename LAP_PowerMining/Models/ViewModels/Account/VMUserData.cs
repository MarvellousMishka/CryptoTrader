using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAP_PowerMining.Models.ViewModels.Account
{
    public class VMUserData
    {
        //[Required(ErrorMessage = "Required")]
        [MinLength(3, ErrorMessage = "min. 3 characters")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Required")]
        [MinLength(3, ErrorMessage = "min. 3 characters")]
        [MaxLength(50)]
        public string LastName { get; set; }
        
        //[Required(ErrorMessage = "Required")]
        [MaxLength(30)]
        [MinLength(7, ErrorMessage = "min. 7 characters")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        //[Required(ErrorMessage = "Required")]
        [MaxLength(30)]
        [MinLength(7, ErrorMessage = "min. 7 characters")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        //[Required(ErrorMessage = "Required")]
        [MaxLength(30)]
        [MinLength(7, ErrorMessage = "min. 7 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmNewPassword { get; set; }
    }
}