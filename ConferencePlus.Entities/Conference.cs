// --------------------------------
// <copyright file="Conference.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  Conference Entity Layer Object.   
// </summary>
// ---------------------------------
using System;
using ConferencePlus.Entities.Common;
using ConferencePlus.Entities.ExtensionMethods;

namespace ConferencePlus.Entities
{
	/// <summary>
	/// Conference entity object. 
	/// </summary>
	[Serializable]
	public class Conference
	{
		public bool IsItemModified { get; set; }

        private int? conferenceId;

        /// <summary>
        /// Gets or sets ConferenceId.
        /// </summary>
        [SqlName("ConferenceId")]
        public int? ConferenceId
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

        private EnumActivityType activityType;

        /// <summary>
        /// Gets or sets ActivityTypeId.
        /// </summary>
        [SqlName("ActivityTypeId")]
        public EnumActivityType ActivityType
        {   
            get 
            {
                return activityType;
            }
            set
            {
                if (value != activityType)
                {
                    activityType = value;
                    IsItemModified = true;
                }
            }
        }

        private string name;

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [SqlName("Name")]
        public string Name
        {   
            get 
            {
                return name;
            }
            set
            {
                if (value != name)
                {
                    name = value;
                    IsItemModified = true;
                }
            }
        }

        private decimal baseFee;

        /// <summary>
        /// Gets or sets BaseFee.
        /// </summary>
        [SqlName("BaseFee")]
        public decimal BaseFee
        {   
            get 
            {
                return baseFee;
            }
            set
            {
                if (value != baseFee)
                {
                    baseFee = value;
                    IsItemModified = true;
                }
            }
        }

        private string description;

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        [SqlName("Description")]
        public string Description
        {   
            get 
            {
                return description;
            }
            set
            {
                if (value != description)
                {
                    description = value;
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

	    public bool IsConferenceEnrollmentExpired
	    {
	        get
	        {
	            return !DateTime.Now.Between(StartDate, EndDate);
	        }
	    }

        /// <summary>
        /// Initializes a new instance of the Conference class.
        /// </summary>
        public Conference()
        {
            ConferenceId = default(int?);
            ActivityType = default(EnumActivityType);
            Name = default(string);
            BaseFee = default(decimal);
            Description = default(string);
            StartDate = default(DateTime);
            EndDate = default(DateTime);
            IsItemModified = false;
        }

		public override string ToString()
		{
			return string.Format("ConferenceId: {0}, ActivityTypeId: {1}, Name: {2}, Description: {3};", ConferenceId, ActivityType, Name, Description);
		}
	}
}
