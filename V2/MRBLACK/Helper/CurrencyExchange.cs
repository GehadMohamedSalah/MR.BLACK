using MRBLACK.Models.Database;
using MRBLACK.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRBLACK.Helper
{
    public static class CurrencyExchange
    {
        //ex: from dollar to pound - from yoro to pound
        public static decimal ConvertToMainPrice(decimal price, int countryId, Repository<Country> _country)
        {
            var currentCountry = _country.GetFirstOrDefault(c => c.Id == countryId, "CurrencyType");
            decimal result = 0;
            if(currentCountry != null)
            {
                result = price * currentCountry.CurrencyType.ValueInPound;
            }
            return result;
        }

        //from pound to dollar - from pound to yoro
        public static decimal ConvertFromMainPrice(decimal price, int countryId, Repository<Country> _country)
        {
            var currentCountry = _country.GetFirstOrDefault(c => c.Id == countryId, "CurrencyType");
            decimal result = 0;
            if (currentCountry != null)
            {
                result = price / currentCountry.CurrencyType.ValueInPound;
            }
            return result;
        }

        public static decimal GetCountryFactor(int countryId, Repository<Country> _country)
        {
            decimal result = 0;
            var currentCountry = _country.GetFirstOrDefault(c => c.Id == countryId, "CurrencyType");
            if(currentCountry != null)
            {
                result = currentCountry.CurrencyType.ValueInPound;
            }
            return result;
        }
    }
}
