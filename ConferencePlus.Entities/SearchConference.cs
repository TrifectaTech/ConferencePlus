// --------------------------------
// <copyright file="SearchConference.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  SearchConference Search Entity Object.   
// </summary>
// ---------------------------------
using System;
using ConferencePlus.Entities.Common;

namespace ConferencePlus.Entities
{
	/// <summary>
	/// SearchConference search entity object. 
	/// </summary>
	[Serializable]
	public class SearchConference
	{
        /// <summary>
        /// Gets or sets ConferenceId.
        /// </summary>
        public int? ConferenceId { get; set; }

        /// <summary>
        /// Gets or sets ActivityTypeId.
        /// </summary>
        public EnumActivityType? ActivityType { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets BaseFee.
        /// </summary>
        public decimal? BaseFee { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets StartDate.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets EndDate.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Initializes a new instance of the SearchConference class.
        /// </summary>
        public SearchConference()
        {
            ConferenceId = null;
            ActivityType = null;
            Name = null;
            BaseFee = null;
            Description = null;
            StartDate = null;
            EndDate = null;
        }
	}
}
