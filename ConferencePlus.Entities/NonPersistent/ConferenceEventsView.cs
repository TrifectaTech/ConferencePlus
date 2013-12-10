// --------------------------------
// <copyright file="ConferenceEventsView.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  ConferenceEventsView Entity Layer Object.   
// </summary>
// ---------------------------------

using System;
using ConferencePlus.Entities.Common;

namespace ConferencePlus.Entities.NonPersistent
{
	/// <summary>
	/// ConferenceEventsView entity object. 
	/// </summary>
	[Serializable]
	public class ConferenceEventsView
	{
        /// <summary>
        /// Gets or sets EventId.
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Gets or sets UserId.
        /// </summary>
        public Guid UserId { get; set; }

		/// <summary>
		/// Gets or sets Username
		/// </summary>
		public string Username { get; set; }

        /// <summary>
        /// Gets or sets ConferenceId.
        /// </summary>
        public int ConferenceId { get; set; }

        /// <summary>
        /// Gets or sets StartDate.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets EndDate.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets FoodPreference.
        /// </summary>
        public EnumFoodPreference FoodPreference { get; set; }

        /// <summary>
        /// Gets or sets PaperId.
        /// </summary>
        public int PaperId { get; set; }

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
        public EnumPaperCategory PaperCategory { get; set; }

        /// <summary>
        /// Gets or sets Author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Initializes a new instance of the ConferenceEventsView class.
        /// </summary>
        public ConferenceEventsView()
        {
            EventId = default(int);
            UserId = default(Guid);
	        Username = default(string);
            ConferenceId = default(int);
            StartDate = default(DateTime);
            EndDate = default(DateTime);
            FoodPreference = default(EnumFoodPreference);
            PaperId = default(int);
            Name = default(string);
            Description = default(string);
            PaperCategory = default(EnumPaperCategory);
            Author = default(string);
        }

		//Returns a proper string denoting this entity
		public override string ToString()
		{
			return string.Format("EventId: {0}, UserId: {1}, ConferenceId: {2};", EventId, UserId, ConferenceId);
		}
	}
}
