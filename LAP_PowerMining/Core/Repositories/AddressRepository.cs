using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAP_PowerMining.Models.ViewModels.Account;
using LAP_PowerMining.Models.DatabaseModel;

namespace LAP_PowerMining.Core.Repositories
{

    public class AddressRepository
    {
        //TODO: if existing city, country querys
        public static int EditOrUpdateAddress(VMAddress addressInfo)
        {
            int result = -1;

            using (var db = new LocalDbEntities2())
            {
                User user = db.User.Where(u => u.email == addressInfo.UserEmail).FirstOrDefault();

                Country country = db.Country.Where(c => c.name == addressInfo.CountryName).FirstOrDefault();
                if (country == null)
                {
                    country = new Country
                    {
                        iso = addressInfo.CountryIso,
                        name = addressInfo.CountryName,
                        created = DateTime.Now
                    };
                }
                City city = db.City.Where(c => c.city1 == addressInfo.CityName).FirstOrDefault();
                if (city == null)
                {
                    city = new City
                    {
                        city1 = addressInfo.CityName,
                        zip = addressInfo.Zip,
                        Country = country,
                        created = DateTime.Now
                    };
                }
                Address address = db.Address.Where(a => a.User.email == user.email).FirstOrDefault();
                if (address == null)
                {
                    address = new Address
                    {
                        street = addressInfo.Street,
                        numbers = addressInfo.Numbers,
                        created = DateTime.Now,
                        user_id = user.id,
                        city_id = city.id,
                        User = user,
                        City = city
                    };
                    db.Address.Add(address);
                }
                else
                {
                    address.street = addressInfo.Street;
                    address.numbers = addressInfo.Numbers;
                    address.user_id = user.id;
                    address.city_id = city.id;
                    address.User = user;
                    address.City = city;
                }
                db.SaveChanges();
                result = 0;
            }
            return result;
        }

        public static List<VMCountry> GetCountries(string searchTerm)
        {
            List<VMCountry> result = new List<VMCountry>();
            using (var db = new LocalDbEntities2())
            {
                var dbCountries = db.Country.Where(c => c.name.ToLower().StartsWith(searchTerm.ToLower())).ToList();

                foreach (var dbCountry in dbCountries)
                {
                    result.Add(new VMCountry
                    {
                        CountryId = dbCountry.id,
                        CountryName = dbCountry.name
                    });
                }
            }
            return result;
        }

        public static List<VMCity> GetCities(string searchTerm)
        {
            List<VMCity> result = new List<VMCity>();
            using (var db = new LocalDbEntities2())
            {
                var dbCities = db.City.Where(c => c.city1.ToLower().StartsWith(searchTerm.ToLower())).ToList();

                foreach (var dbCity in dbCities)
                {
                    result.Add(new VMCity
                    {
                        CityId = dbCity.id,
                        CityName = dbCity.city1
                    });
                }
            }
            return result;
        }

        public static VMAddress GetAddress(string email)
        {
            VMAddress result = new VMAddress();
            Address address = new Address();
            using (var db = new LocalDbEntities2())
            {
                address = db.Address.Where(a => a.User.email == email).FirstOrDefault();
            }
            if (address != null)
            {
                result = new VMAddress
                {
                    CityName = address.City.city1,
                    CountryIso = address.City.Country.iso,
                    CountryName = address.City.Country.name,
                    Numbers = address.numbers,
                    Street = address.street,
                    Zip = address.City.zip
                };
            }
            return result;
        }
    }
}