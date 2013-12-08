using System;

namespace ConferencePlus.Entities.ExtensionMethods
{
    /// <summary>
    /// Extension Methods for doubleMethods
    /// </summary>
    public static class DoubleMethods
    {
        /// <summary>
        /// Convert percentage to double
        /// </summary>
        /// <param name="value" />
        /// <returns />
        public static double ToDoubleFromPercent(this double value)
        {
            return value / 100;
        }

        /// <summary>
        /// Convert double to percentage
        /// </summary>
        /// <param name="value" />
        /// <returns />
        public static double ToPercent(this double value)
        {
            return value * 100;
        }

        /// <summary>
        /// Converts double to Currency
        /// </summary>
        /// <param name="value" />
        /// <returns />
        public static string ToCurrency(this double value)
        {
            return string.Format("{0:C}", value);
        }

        /// <summary>
        /// Returns the absolute value of double
        /// </summary>
        /// <param name="value" />
        /// <returns>The absolute value of the double</returns>
        public static double AbsoluteValue(this double value)
        {
            return Math.Abs(value);
        }

        /// <summary>
        /// Returns the negative value of double
        /// </summary>
        /// <param name="value" />
        /// <returns>The negative value of the double</returns>
        public static double NegativeValue(this double value)
        {
            return value.AbsoluteValue() * -1;
        }

        /// <summary>
        /// Returns whether or not double is between upper and lower bounds
        /// </summary>
        /// <param name="value" />
        /// <param name="lowerBound">The lower bound to compare</param>
        /// <param name="upperBound">The upper bound to compare</param>
        /// <param name="includeBounds">[OPTIONAL] Whether or not to include the bounds</param>
        /// <returns>Returns true, if value is between the bounds</returns>
        public static bool Between(this double value, double lowerBound, double upperBound, bool includeBounds = true)
        {
            return includeBounds
                       ? value >= lowerBound && value <= upperBound
                       : value > lowerBound && value < upperBound;

        }

        /// <summary>
        /// Returns whether or not double is negative
        /// </summary>
        /// <param name="value" />
        /// <returns>Returns true, if value is negative</returns>
        public static bool IsNegative(this double value)
        {
            return value < 0;
        }

        /// <summary>
        /// Returns whether or not double is positive
        /// </summary>
        /// <param name="value" />
        /// <returns>Returns true, if value is positive</returns>
        public static bool IsPositive(this double value)
        {
            return value > 0;
        }
        /// <summary>
        /// Rounds up to two double values with MidpointAway From zero.
        /// </summary>
        /// <param name="value" />
        /// <returns></returns>
        public static double Round(this double value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }
    }
}
