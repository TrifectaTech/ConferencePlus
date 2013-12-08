using System;

namespace ConferencePlus.Entities.ExtensionMethods
{
    /// <summary>
    /// Extension Methods for Guid
    /// </summary>
    public static class GuidMethods
    {
        /// <summary>
        /// Checks if a guid is empty, new but improperly initialized
        /// </summary>
        /// <param name="value" />
        /// <returns>True if empty or initialized, false otherwise</returns>
        public static bool IsNullOrDefault(this Guid value)
        {
            return value == default(Guid) || value == Guid.Empty || value == new Guid();
        }

        public static Guid? GetNullIfDefault(this Guid value)
        {
            return value == new Guid() || value == default(Guid) ? (Guid?) null : value;
        }

        public static bool IsNullOrDefault(this Guid? value)
        {
            return !value.HasValue || (value.Value == default(Guid) || value.Value == Guid.Empty || value.Value == new Guid());
        }
    }
}