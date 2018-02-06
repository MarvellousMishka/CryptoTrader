using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAP_PowerMining.Models.ViewModels.Account
{
    public class VMAddress
    {
        public string UserEmail { get; set; }

        [Required]
        [Display(Name = "Street")]
        public string Street { get; set; }
        [Required]
        [Display(Name ="Number")]
        public string Numbers { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        [Display(Name = "City Name")]
        public string CityName { get; set; }
        [Required]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
        [Required]
        [Display(Name = "Country Iso")]
        public string CountryIso { get; set; }
    }
}