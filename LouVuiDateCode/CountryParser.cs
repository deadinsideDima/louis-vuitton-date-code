using System;

namespace LouVuiDateCode
{
    public static class CountryParser
    {
        /// <summary>
        /// Gets a an array of <see cref="Country"/> enumeration values for a specified factory location code. One location code can belong to many countries.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <returns>An array of <see cref="Country"/> enumeration values.</returns>
        public static Country[] GetCountry(string factoryLocationCode)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }
            else
            {
                List<Country> country = new List<Country>();
                if (factoryLocationCode == "A0" || factoryLocationCode == "A1" || factoryLocationCode == "A2" || factoryLocationCode == "AA" || factoryLocationCode == "AAS" || factoryLocationCode == "AH" || factoryLocationCode == "AN" || factoryLocationCode == "AR" || factoryLocationCode == "AS" || factoryLocationCode == "BA" || factoryLocationCode == "BJ" || factoryLocationCode == "BU" || factoryLocationCode == "DR" || factoryLocationCode == "DU" || factoryLocationCode == "DT" || factoryLocationCode == "CO" || factoryLocationCode == "CT" || factoryLocationCode == "CX" || factoryLocationCode == "ET" || factoryLocationCode == "FL" || factoryLocationCode == "LA" || factoryLocationCode == "LW" || factoryLocationCode == "MB" || factoryLocationCode == "MI" || factoryLocationCode == "NO" || factoryLocationCode == "RA" || factoryLocationCode == "RI" || factoryLocationCode == "SA" || factoryLocationCode == "SD" || factoryLocationCode == "SF" || factoryLocationCode == "SL" || factoryLocationCode == "SN" || factoryLocationCode == "SP" || factoryLocationCode == "SR" || factoryLocationCode == "TA" || factoryLocationCode == "TJ" || factoryLocationCode == "TH" || factoryLocationCode == "TN" || factoryLocationCode == "TR" || factoryLocationCode == "TS" || factoryLocationCode == "VI" || factoryLocationCode == "VX")
                {
                    country.Add(Country.France);
                }

                if (factoryLocationCode == "LP" || factoryLocationCode == "OL")
                {
                    country.Add(Country.Germany);
                }

                if (factoryLocationCode == "BC" || factoryLocationCode == "BO" || factoryLocationCode == "CE" || factoryLocationCode == "FN" || factoryLocationCode == "FO" || factoryLocationCode == "MA" || factoryLocationCode == "NZ" || factoryLocationCode == "OB" || factoryLocationCode == "PL" || factoryLocationCode == "RC" || factoryLocationCode == "RE" || factoryLocationCode == "SA" || factoryLocationCode == "TD")
                {
                    country.Add(Country.Italy);
                }

                if (factoryLocationCode == "BC" || factoryLocationCode == "CA" || factoryLocationCode == "LO" || factoryLocationCode == "LB" || factoryLocationCode == "LM" || factoryLocationCode == "LW" || factoryLocationCode == "GI" || factoryLocationCode == "UB")
                {
                    country.Add(Country.Spain);
                }

                if (factoryLocationCode == "DI" || factoryLocationCode == "FA")
                {
                    country.Add(Country.Switzerland);
                }

                if (factoryLocationCode == "FC" || factoryLocationCode == "FH" || factoryLocationCode == "LA" || factoryLocationCode == "OS" || factoryLocationCode == "SD" || factoryLocationCode == "FL" || factoryLocationCode == "TX")
                {
                    country.Add(Country.USA);
                }

                return country.ToArray();
            }
        }
    }
}
