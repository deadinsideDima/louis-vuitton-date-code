using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LouVuiDateCode
{
    public static class DateCodeGenerator
    {
        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980Code(uint manufacturingYear, uint manufacturingMonth)
        {
            if (manufacturingYear < 1980 || manufacturingYear > 1989)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            return (manufacturingYear % 100).ToString(CultureInfo.InvariantCulture) + manufacturingMonth.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980Code(DateTime manufacturingDate)
        {
            if (manufacturingDate.Year < 1980 || manufacturingDate.Year > 1989)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            if (manufacturingDate.Month < 1 || manufacturingDate.Month > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            return (manufacturingDate.Year % 100).ToString(CultureInfo.InvariantCulture) + manufacturingDate.Month.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Generates a date code using rules from late 1980s.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            if (manufacturingYear < 1980 || manufacturingYear > 1989)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (!Regex.IsMatch(factoryLocationCode, "^[a-zA-Z]{2}$"))
            {
                throw new ArgumentException("incorrect code format");
            }

            return (manufacturingYear % 100).ToString(CultureInfo.InvariantCulture) + manufacturingMonth.ToString(CultureInfo.InvariantCulture) + factoryLocationCode.ToUpper(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Generates a date code using rules from late 1980s.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (manufacturingDate.Year < 1980 || manufacturingDate.Year > 1989)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            if (manufacturingDate.Month < 1 || manufacturingDate.Month > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (!Regex.IsMatch(factoryLocationCode, "^[a-zA-Z]{2}$"))
            {
                throw new ArgumentException("incorrect code format");
            }

            return (manufacturingDate.Year % 100).ToString(CultureInfo.InvariantCulture) + manufacturingDate.Month.ToString(CultureInfo.InvariantCulture) + factoryLocationCode.ToUpper(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            if (manufacturingYear < 1990 || manufacturingYear > 2006)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (!Regex.IsMatch(factoryLocationCode, "^[a-zA-Z]{2}$"))
            {
                throw new ArgumentException("incorrect code format");
            }

            string year = string.Empty, month = string.Empty;

            if (manufacturingYear % 100 < 10)
            {
                year += "0";
            }

            if (manufacturingMonth < 10)
            {
                month += "0";
            }

            year += (manufacturingYear % 100).ToString(CultureInfo.InvariantCulture);
            month += manufacturingMonth.ToString(CultureInfo.InvariantCulture);

            return factoryLocationCode.ToUpper(CultureInfo.InvariantCulture) + month[0] + year[0] + month[1] + year[1];
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (manufacturingDate.Year > 2006 || manufacturingDate.Year < 1990 || manufacturingDate.Month > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            if (factoryLocationCode.Length != 2)
            {
                throw new ArgumentException("Error.");
            }

            for (int i = 0; i < factoryLocationCode.Length; i++)
            {
                if ((int)char.GetNumericValue(factoryLocationCode[i]) != -1)
                {
                    throw new ArgumentException("Error.");
                }
            }

            char[] temp = factoryLocationCode.ToCharArray();
            for (int i = 0; i < factoryLocationCode.Length; i++)
            {
                temp[i] = char.ToUpper(temp[i], CultureInfo.InvariantCulture);
            }

            return string.Concat(new string(temp), (manufacturingDate.Month / 10).ToString(CultureInfo.InvariantCulture), ((manufacturingDate.Year % 100) / 10).ToString(CultureInfo.InvariantCulture), (manufacturingDate.Month % 10).ToString(CultureInfo.InvariantCulture), (manufacturingDate.Year % 10).ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Generates a date code using rules from post 2007 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingWeek">A manufacturing week number.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate2007Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingWeek)
        {
            if (manufacturingYear < 2007)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            int weekAllowance = 52;
            if (manufacturingYear % 5 == 0)
            {
                weekAllowance++;
            }

            if (manufacturingWeek < 1 || manufacturingWeek > weekAllowance)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingWeek));
            }

            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (!Regex.IsMatch(factoryLocationCode, "^[a-zA-Z]{2}$"))
            {
                throw new ArgumentException("incorrect code format");
            }

            string year = string.Empty, week = string.Empty;

            if (manufacturingYear % 100 < 10)
            {
                year += "0";
            }

            if (manufacturingWeek < 10)
            {
                week += "0";
            }

            year += (manufacturingYear % 100).ToString(CultureInfo.InvariantCulture);
            week += manufacturingWeek.ToString(CultureInfo.InvariantCulture);

            return factoryLocationCode.ToUpper(CultureInfo.InvariantCulture) + week[0] + year[0] + week[1] + year[1];
        }

        /// <summary>
        /// Generates a date code using rules from post 2007 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate2007Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            int numberWeek = cal.GetWeekOfYear(manufacturingDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            if (manufacturingDate.Year < 2007 || (DateTime.IsLeapYear(manufacturingDate.Year) && numberWeek > 53) || (!DateTime.IsLeapYear(manufacturingDate.Year) && numberWeek > 52) || numberWeek == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            if (factoryLocationCode.Length != 2)
            {
                throw new ArgumentException("Error.");
            }

            for (int i = 0; i < factoryLocationCode.Length; i++)
            {
                if ((int)char.GetNumericValue(factoryLocationCode[i]) != -1)
                {
                    throw new ArgumentException("Error.");
                }
            }

            char[] temp = factoryLocationCode.ToCharArray();
            for (int i = 0; i < factoryLocationCode.Length; i++)
            {
                temp[i] = char.ToUpper(temp[i], CultureInfo.InvariantCulture);
            }

            if ((manufacturingDate.Day == 1 || manufacturingDate.Day == 3) && manufacturingDate.Month == 1 && (manufacturingDate.Year == 2016 || manufacturingDate.Year == 2017))
            {
                return string.Concat(new string(temp), (numberWeek / 10).ToString(CultureInfo.InvariantCulture), ((manufacturingDate.Year % 100) / 10).ToString(CultureInfo.InvariantCulture), (numberWeek % 10).ToString(CultureInfo.InvariantCulture), ((manufacturingDate.Year - 1) % 10).ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                return string.Concat(new string(temp), (numberWeek / 10).ToString(CultureInfo.InvariantCulture), ((manufacturingDate.Year % 100) / 10).ToString(CultureInfo.InvariantCulture), (numberWeek % 10).ToString(CultureInfo.InvariantCulture), (manufacturingDate.Year % 10).ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}
