using ConferencePlus.Entities.Common;
using Enum = System.Enum;

namespace ConferencePlus.Entities.ExtensionMethods
{
    public static class EnumerationMethods
    {

        public static string ToFormattedString(this EnumCreditCardType enumValue)
        {
            switch (enumValue)
            {
                    case EnumCreditCardType.AmericanExpress:
                {
                    return "American Express";
                }
                default:
                {
                    return enumValue.ToString();
                }
            }
        }

        public static string ToFormattedString(this EnumFeeAdjustment enumValue)
        {
            switch (enumValue)
            {
                    case EnumFeeAdjustment.OnSite:
                {
                    return "On Site";
                }
                default:
                {
                    return enumValue.ToString();
                }
            }
        }

        public static string ToFormattedString(this EnumFoodPreference enumValue)
        {
            switch (enumValue)
            {
                    case EnumFoodPreference.LowCalorie:
                {
                    return "Low Calorie";
                }
                default:
                {
                    return enumValue.ToString();
                }
            }
        }

        public static string ToFormattedString(this EnumPaperCategory enumValue)
        {
            switch (enumValue)
            {
                    case EnumPaperCategory.ComputerScience:
                {
                    return "Computer Science";
                }
                    case EnumPaperCategory.DatabaseManagement:
                {
                    return "Database Management";
                }
                    case EnumPaperCategory.InformationAssurance:
                {
                    return "Information Assurance";
                }
                    case EnumPaperCategory.InformationTechnology:
                {
                    return "Information Technology";
                }
                    case EnumPaperCategory.MechanicalEngineering:
                {
                    return "Mechanical Engineering";
                }
                    case EnumPaperCategory.RocketScience:
                {
                    return "Rocket Science";
                }
                default:
                {
                    return enumValue.ToString();
                }
            }
        }

        public static string ToFormattedString(this Enum enumValue)
        {
            if (enumValue is EnumCreditCardType)
            {
                EnumCreditCardType val = (EnumCreditCardType)enumValue;

                return val.ToFormattedString();
            }

            if (enumValue is EnumFeeAdjustment)
            {
                EnumFeeAdjustment val = (EnumFeeAdjustment) enumValue;

                return val.ToFormattedString();
            }

            if (enumValue is EnumFoodPreference)
            {
                EnumFoodPreference val = (EnumFoodPreference) enumValue;

                return val.ToFormattedString();
            }

            if (enumValue is EnumPaperCategory)
            {
                EnumPaperCategory val = (EnumPaperCategory) enumValue;

                return val.ToFormattedString();
            }

            return enumValue == null ? string.Empty : enumValue.ToString();
        }

    }
}
