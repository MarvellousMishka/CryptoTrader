using LAP_PowerMining.Core.Repositories;
using LAP_PowerMining.Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAP_PowerMining.Core.Services
{
    public class AddressService
    {

        public static VMAddress GetAddress(string email)
        {
            return AddressRepository.GetAddress(email);
        }
        public static int UpdateAddress(VMAddress addressInfo)
        {
            int result = -1;
            result = AddressRepository.EditOrUpdateAddress(addressInfo);

            return result;
        }

        public static List<VMCity> GetCities(string searchTerm)
        {
            List<VMCity> result = new List<VMCity>();
            result = AddressRepository.GetCities(searchTerm);

            return result;
        }
        public static List<VMCountry> GetCountries(string searchTerm)
        {
            List<VMCountry> result = new List<VMCountry>();
            result = AddressRepository.GetCountries(searchTerm);

            return result;
        }
    }
}