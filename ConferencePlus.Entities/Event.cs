// --------------------------------
// <copyright file="Event.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  Event Entity Layer Object.   
// </summary>
// ---------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using ConferencePlus.Entities;
using ConferencePlus.Entities.Common;

namespace ConferencePlus.Entities
{
	/// <summary>
	/// Event entity object. 
	/// </summary>
	[Serializable]
	public class Event
	{
		public bool IsItemModified { get; set; }

        private int? eventId;

        /// <summary>
        /// Gets or sets EventId.
        /// </summary>
        [SqlName("EventId")]
        public int? EventId
        {   
            get 
            {
                return eventId;
            }
            set
            {
                if (value != eventId)
                {
                    eventId = value;
                    IsItemModified = true;
                }
            }
        }

        private int conferenceId;

        /// <summary>
        /// Gets or sets ConferenceId.
        /// </summary>
        [SqlName("ConferenceId")]
        public int ConferenceId
        {   
            get 
            {
                return conferenceId;
            }
            set
            {
                if (value != conferenceId)
                {
                    conferenceId = value;
                    IsItemModified = true;
                }
            }
        }

        private int paperId;

        /// <summary>
        /// Gets or sets PaperId.
        /// </summary>
        [SqlName("PaperId")]
        public int PaperId
        {   
            get 
            {
                return paperId;
            }
            set
            {
                if (value != paperId)
                {
                    paperId = value;
                    IsItemModified = true;
                }
            }
        }

        private int foodPreference;

        /// <summary>
        /// Gets or sets FoodPreference.
        /// </summary>
        [SqlName("FoodPreferenceId")]
        public int FoodPreference
        {   
            get 
            {
                return foodPreference;
            }
            set
            {
                if (value != foodPreference)
                {
                    foodPreference = value;
                    IsItemModified = true;
                }
            }
        }

        private string comments;

        /// <summary>
        /// Gets or sets Comments.
        /// </summary>
        [SqlName("Comments")]
        public string Comments
        {   
            get 
            {
                return comments;
            }
            set
            {
                if (value != comments)
                {
                    comments = value;
                    IsItemModified = true;
                }
            }
        }

        private DateTime startDate;

        /// <summary>
        /// Gets or sets StartDate.
        /// </summary>
        [SqlName("StartDate")]
        public DateTime StartDate
        {   
            get 
            {
                return startDate;
            }
            set
            {
                if (value != startDate)
                {
                    startDate = value;
                    IsItemModified = true;
                }
            }
        }

        private DateTime endDate;

        /// <summary>
        /// Gets or sets EndDate.
        /// </summary>
        [SqlName("EndDate")]
        public DateTime EndDate
        {   
            get 
            {
                return endDate;
            }
            set
            {
                if (value != endDate)
                {
                    endDate = value;
                    IsItemModified = true;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the Event class.
        /// </summary>
        public Event()
        {
            EventId = default(int?);
            ConferenceId = default(int);
            PaperId = default(int);
            FoodPreference = default(int);
            Comments = default(string);
            StartDate = default(DateTime);
            EndDate = default(DateTime);
            IsItemModified = false;
        }

		public override string ToString()
		{
			return string.Format("EventId: {0}, ConferenceId: {1}, PaperId: {2}, FoodPreference: {3};", EventId, ConferenceId, PaperId, FoodPreference);
		}
	}
}
