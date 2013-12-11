using System;

namespace ConferencePlus.Entities.ExtensionMethods
{
    /// <summary>
    /// Extension Methods for DecimalMethods
    /// </summary>
    public static class DecimalMethods
    {
        /// <summary>
        /// Convert percentage to Decimal
        /// </summary>
        /// <param name="value" />
        /// <returns />
        public static decimal ToDecimalFromPercent(this decimal value)
        {
            return value / 100;
        }

        /// <summary>
        /// Convert Decimal to percentage
        /// </summary>
        /// <param name="value" />
        /// <returns />
        public static decimal ToPercent(this decimal value)
        {
            return value * 100;
        }

        /// <summary>
        /// Converts Decimal to Currency
        /// </summary>
        /// <param name="value" />
        /// <returns />
        public static string ToCurrency(this decimal value)
        {
            return string.Format("{0:C}", value);
        }

        /// <summary>
        /// Returns the absolute value of decimal
        /// </summary>
        /// <param name="value" />
        /// <returns>The absolute value of the decimal</returns>
        public static decimal AbsoluteValue(this decimal value)
        {
            return Math.Abs(value);
        }

        /// <summary>
        /// Returns the negative value of decimal
        /// </summary>
        /// <param name="value" />
        /// <returns>The negative value of the decimal</returns>
        public static decimal NegativeValue(this decimal value)
        {
            return value.AbsoluteValue() * -1;
        }

        /// <summary>
        /// Returns whether or not decimal is between upper and lower bounds
        /// </summary>
        /// <param name="value" />
        /// <param name="lowerBound">The lower bound to compare</param>
        /// <param name="upperBound">The upper bound to compare</param>
        /// <param name="includeBounds">[OPTIONAL] Whether or not to include the bounds</param>
        /// <returns>Returns true, if value is between the bounds</returns>
        public static bool Between(this decimal value, decimal lowerBound, decimal upperBound, bool includeBounds = true)
        {
            return includeBounds
                       ? value >= lowerBound && value <= upperBound
                       : value > lowerBound && value < upperBound;

        }

        /// <summary>
        /// Returns whether or not decimal is negative
        /// </summary>
        /// <param name="value" />
        /// <returns>Returns true, if value is negative</returns>
        public static bool IsNegative(this decimal value)
        {
            return value < 0;
        }

        /// <summary>
        /// Returns whether or not decimal is positive
        /// </summary>
        /// <param name="value" />
        /// <returns>Returns true, if value is positive</returns>
        public static bool IsPositive(this decimal value)
        {
            return value > 0;
        }

        /// <summary>
        /// Rounds up to two decimal values with MidpointAway From zero.
        /// </summary>
        /// <param name="value" />
        /// <returns></returns>
        public static decimal Round(this decimal value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }

		/// <summary>
		/// Returns value as Double
		/// </summary>
		/// <param name="value" />
		/// <returns>Value as a Double</returns>
		public static double ToDouble(this decimal value)
		{
			return (double)value;
		}
    }
}
