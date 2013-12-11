// --------------------------------
// <copyright file="SearchConferenceFee.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  SearchConferenceFee Search Entity Object.   
// </summary>
// ---------------------------------
using System;
using ConferencePlus.Entities.Common;

namespace ConferencePlus.Entities
{
	/// <summary>
	/// SearchConferenceFee search entity object. 
	/// </summary>
	[Serializable]
	public class SearchConferenceFee
	{
        /// <summary>
        /// Gets or sets ConferenceFeeId.
        /// </summary>
        public int? ConferenceFeeId { get; set; }

        /// <summary>
        /// Gets or sets ConferenceId.
        /// </summary>
        public int? ConferenceId { get; set; }

        /// <summary>
        /// Gets or sets FeeAdjustment.
        /// </summary>
        public EnumFeeAdjustment? FeeAdjustment { get; set; }

        /// <summary>
        /// Gets or sets FeeType.
        /// </summary>
        public EnumFeeType? FeeType { get; set; }

        /// <summary>
        /// Gets or sets Multiplier.
        /// </summary>
        public decimal? Multiplier { get; set; }

        /// <summary>
        /// Gets or sets EffectiveStartDate.
        /// </summary>
        public DateTime? EffectiveStartDate { get; set; }

        /// <summary>
        /// Gets or sets EffectiveEndDate.
        /// </summary>
        public DateTime? EffectiveEndDate { get; set; }

        /// <summary>
        /// Initializes a new instance of the SearchConferenceFee class.
        /// </summary>
        public SearchConferenceFee()
        {
            ConferenceFeeId = null;
            ConferenceId = null;
            FeeAdjustment = null;
            FeeType = null;
            Multiplier = null;
            EffectiveStartDate = null;
            EffectiveEndDate = null;
        }
	}
}
