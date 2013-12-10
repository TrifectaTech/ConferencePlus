// --------------------------------
// <copyright file="SearchConferenceEventsView.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  SearchConferenceEventsView Search Entity Object.   
// </summary>
// ---------------------------------

using System;
using ConferencePlus.Entities.Common;

namespace ConferencePlus.Entities.NonPersistent
{
	/// <summary>
	/// SearchConferenceEventsView search entity object. 
	/// </summary>
	[Serializable]
	public class SearchConferenceEventsView
	{
        /// <summary>
        /// Gets or sets EventId.
        /// </summary>
        public int? EventId { get; set; }

        /// <summary>
        /// Gets or sets UserId.
        /// </summary>
        public Guid? UserId { get; set; }

		/// <summary>
		/// Gets or sets Username
		/// </summary>
		public string Username { get; set; }

        /// <summary>
        /// Gets or sets ConferenceId.
        /// </summary>
        public int? ConferenceId { get; set; }

        /// <summary>
        /// Gets or sets StartDate.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets EndDate.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets FoodPreference.
        /// </summary>
        public EnumFoodPreference? FoodPreference { get; set; }

        /// <summary>
        /// Gets or sets PaperId.
        /// </summary>
        public int? PaperId { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets PaperCategory.
        /// </summary>
        public EnumPaperCategory? PaperCategory { get; set; }

        /// <summary>
        /// Gets or sets Author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Initializes a new instance of the SearchConferenceEventsView class.
        /// </summary>
        public SearchConferenceEventsView()
        {
            EventId = null;
            UserId = null;
	        Username = null;
            ConferenceId = null;
            StartDate = null;
            EndDate = null;
            FoodPreference = null;
            PaperId = null;
            Name = null;
            Description = null;
            PaperCategory = null;
            Author = null;
        }
	}
}
