// --------------------------------
// <copyright file="SearchEvent.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  SearchEvent Search Entity Object.   
// </summary>
// ---------------------------------
using System;
using ConferencePlus.Entities.Common;

namespace ConferencePlus.Entities
{
	/// <summary>
	/// SearchEvent search entity object. 
	/// </summary>
	[Serializable]
	public class SearchEvent
	{
        /// <summary>
        /// Gets or sets EventId.
        /// </summary>
        public int? EventId { get; set; }

        /// <summary>
        /// Gets or sets ConferenceId.
        /// </summary>
        public int? ConferenceId { get; set; }

        /// <summary>
        /// Gets or sets PaperId.
        /// </summary>
        public int? PaperId { get; set; }

        /// <summary>
        /// Gets or sets FoodPreference.
        /// </summary>
        public EnumFoodPreference? FoodPreference { get; set; }

        /// <summary>
        /// Gets or sets Comments.
        /// </summary>s
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets StartDate.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets EndDate.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Initializes a new instance of the SearchEvent class.
        /// </summary>
        public SearchEvent()
        {
            EventId = null;
            ConferenceId = null;
            PaperId = null;
            FoodPreference = null;
            Comments = null;
            StartDate = null;
            EndDate = null;
        }
	}
}
