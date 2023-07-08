using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LouVuiDateCode
{
    public static class DateCodeParser
    {
        /// <summary>
        /// Parses a date code and returns a <see cref="manufacturingYear"/> and <see cref="manufacturingMonth"/>.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseEarly1980Code(string dateCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (!Regex.IsMatch(dateCode, "^8[0-9](1[0-2]|[1-9])$"))
            {
                throw new ArgumentException("incorrect code format");
            }

            uint code = Convert.ToUInt32(dateCode, CultureInfo.InvariantCulture);

            if (code < 1000)
            {
                manufacturingYear = 1900u + (code / 10);
                manufacturingMonth = code % 10;
            }
            else
            {
                manufacturingYear = 1900u + (code / 100);
                manufacturingMonth = code % 100;
            }
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseLate1980Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            string temp1 = string.Empty, temp2 = string.Empty;
            for (int i = 0; i < dateCode.Length - 2; i++)
            {
                temp1 = string.Empty + temp1 + dateCode[i];
            }

            temp2 = string.Empty + dateCode[dateCode.Length - 2] + dateCode[dateCode.Length - 1];
            int number = int.Parse(temp1, CultureInfo.InvariantCulture);
            if ((dateCode.Length == 5 && (number <= 800 || number >= 900)) || dateCode.Length < 5 || dateCode.Length > 6)
            {
                throw new ArgumentException("Error");
            }

            if (dateCode.Length == 6 && (number % 100 > 12 || number <= 800 || number >= 9000))
            {
                throw new ArgumentException("Error");
            }

            factoryLocationCountry = CountryParser.GetCountry(temp2);
            if (factoryLocationCountry == null || factoryLocationCountry.Length == 0)
            {
                throw new ArgumentException("Error.");
            }

            factoryLocationCode = temp2;
            if (dateCode.Length == 5)
            {
                manufacturingMonth = (uint)number % 10;
                manufacturingYear = 1900 + ((uint)number / 10);
            }
            else
            {
                manufacturingMonth = (uint)number % 100;
                manufacturingYear = 1900 + ((uint)number / 100);
            }
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A six number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void Parse1990Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            string temp1 = string.Empty, temp2 = string.Empty;
            for (int i = 2; i < dateCode.Length; i++)
            {
                temp1 = string.Empty + temp1 + dateCode[i];
            }

            temp2 = string.Empty + dateCode[0] + dateCode[1];
            if (dateCode.Length < 5 || dateCode.Length > 6)
            {
                throw new ArgumentException("Error");
            }

            int number = int.Parse(temp1, CultureInfo.InvariantCulture);
            int number4 = number % 10;
            number /= 10;
            int number3 = number % 10;
            number /= 10;
            int number2 = number % 10;
            int number1 = number / 10;
            int numberMonth = (number1 * 10) + number3;
            int numberYear = (number2 * 10) + number4;
            if (numberMonth > 12 || numberMonth == 0 || (numberYear < 90 && numberYear > 6))
            {
                throw new ArgumentException("Error");
            }

            factoryLocationCountry = CountryParser.GetCountry(temp2);
            if (factoryLocationCountry == null || factoryLocationCountry.Length == 0)
            {
                throw new ArgumentException("Error.");
            }

            factoryLocationCode = temp2;
            if (numberYear < 90)
            {
                manufacturingMonth = (uint)numberMonth;
                manufacturingYear = 2000 + (uint)numberYear;
            }
            else
            {
                manufacturingMonth = (uint)numberMonth;
                manufacturingYear = 1900 + (uint)numberYear;
            }
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingWeek"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A six number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingWeek">A manufacturing week to return.</param>
        public static void Parse2007Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingWeek)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            string temp1 = string.Empty, temp2 = string.Empty;
            for (int i = 2; i < dateCode.Length; i++)
            {
                temp1 = string.Empty + temp1 + dateCode[i];
            }

            temp2 = string.Empty + dateCode[0] + dateCode[1];
            if (dateCode.Length < 5 || dateCode.Length > 6)
            {
                throw new ArgumentException("Error");
            }

            int number = int.Parse(temp1, CultureInfo.InvariantCulture);
            int number4 = number % 10;
            number /= 10;
            int number3 = number % 10;
            number /= 10;
            int number2 = number % 10;
            int number1 = number / 10;
            int numberWeek = (number1 * 10) + number3;
            int numberYear = (number2 * 10) + number4;
            if (numberWeek > 53 || numberWeek == 0 || numberYear < 7 || dateCode == "RI5137" || dateCode == "RI5138" || dateCode == "RI5139")
            {
                throw new ArgumentException("Error");
            }

            factoryLocationCountry = CountryParser.GetCountry(temp2);
            if (factoryLocationCountry == null || factoryLocationCountry.Length == 0)
            {
                throw new ArgumentException("Error.");
            }

            factoryLocationCode = temp2;
            manufacturingWeek = (uint)numberWeek;
            manufacturingYear = 2000 + (uint)numberYear;
        }
    }
}
