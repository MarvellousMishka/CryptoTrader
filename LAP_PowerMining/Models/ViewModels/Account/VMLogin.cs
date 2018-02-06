using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAP_PowerMining.Models.ViewModels.Account
{
    public class VMLogin
    {
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        [MinLength(7, ErrorMessage = "min. 7 characters")]
        public string Password { get; set; }

        public bool ValidLogin { get; set; }
    }
}