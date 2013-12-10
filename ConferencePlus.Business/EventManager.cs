// --------------------------------
// <copyright file="EventManager.cs" company="Conference Plus">
//     � 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
// Encapusulate business logic of Event.   
// </summary>
// ---------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConferencePlus.Data;
using ConferencePlus.Entities.Common;
using ConferencePlus.Entities.ExtensionMethods;
using ConferencePlus.Entities;

namespace ConferencePlus.Business
{
    /// <summary>
    /// This class encapsulates the business logic of Event entity
    /// </summary>
    public static class EventManager
    {        
        /// <summary>
        /// Searches for Event
        /// </summary>
        /// <param name="search" />
        /// <returns>An IEnumerable set of Event</returns>
        public static IEnumerable<Event> Search(SearchEvent search)
        {            
			return EventDao.Search(search);
        }

        public static IEnumerable<Event> LoadByConferenceId(int conferenceId)
        {
            SearchEvent search = new SearchEvent
            {
                ConferenceId = conferenceId
            };

            return Search(search);
        }
	     
        /// <summary>
        /// Loads Event by the id parameter
        /// </summary>
        /// <param name="eventId">Primary Key of Event table</param>
        /// <returns>Event entity</returns>
        public static Event Load(int eventId)
        {
			SearchEvent search
				= new SearchEvent
					{
						EventId = eventId
					};    
			return Search(search).FirstOrDefault();
        }

        public static IEnumerable<Event> LoadByPaperId(int paperId)
        {
            SearchEvent search = new SearchEvent
            {PaperId = paperId};

            return Search(search);
        }

        public static bool IsEventValidForConference(Event ev)
        {
            Conference conference = ConferenceManager.Load(ev.ConferenceId);

            return DateTimeMethods.DoDatesOverlap(conference.StartDate, conference.EndDate, ev.StartDate, ev.EndDate);
        }

        public static bool IsEventPaperValidForConference(Event ev)
        {
            List<Event> eventsForConferenceExceptThisOne =
                LoadByConferenceId(ev.ConferenceId).Where(dd => dd.EventId != ev.EventId.GetValueOrDefault()).ToList();

            Paper paperForThisEvent = PaperManager.Load(ev.PaperId);

            return
                !eventsForConferenceExceptThisOne.SafeAny(
                    dd => PaperManager.Load(dd.PaperId).PaperCategory == paperForThisEvent.PaperCategory);
        }

        /// <summary>
        /// Save Event Entity
        /// </summary>
        /// <param name="item">Entity to save</param>
        /// <param name="errorMessage">Error Message</param>
		/// <returns>return true if save successfully, else return false</returns>
        public static bool Save(Event item, out string errorMessage)
        {
            bool isValid = Validate(item, out errorMessage);                     
            
			if (isValid)
			{
                EventDao.Save(item);				
            }	        

            return isValid;
        }

        /// <summary>
        /// Validate Event Entity
        /// </summary>
        /// <param name="item">Entity to validate</param>
        /// <param name="errorMessage">error message if vlidation failed</param>
        /// <returns>return true if entity passes validation logic, else return false</returns>
        public static bool Validate(Event item, out string errorMessage)
        {
            StringBuilder builder = new StringBuilder();

            if (item.Comments.IsNullOrWhiteSpace())
            {
                builder.AppendHtmlLine("*Comments are required");
            }

            if (!item.EndDate.IsValidWithSqlDateStandards())
            {
                builder.AppendHtmlLine("*End date is required");
            }

            if (!item.StartDate.IsValidWithSqlDateStandards())
            {
                builder.AppendHtmlLine("*Start date is required");
            }

            if (item.ConferenceId == default(int))
            {
                builder.AppendHtmlLine("*Conference is required");
            }

            if (!IsEventValidForConference(item))
            {
                builder.AppendHtmlLine("*Event is not valid for the selected conference");
            }

            if (item.FoodPreference == EnumFoodPreference.None)
            {
                builder.AppendHtmlLine("*Food preference is required");
            }

            if (item.PaperId == default(int))
            {
                builder.AppendHtmlLine("*Paper is required");
            }

            if (!IsEventPaperValidForConference(item))
            {
                builder.AppendHtmlLine("*A paper of this topic is already registered for this conference");
            }

            errorMessage = builder.ToString();

            return errorMessage.IsNullOrWhiteSpace();
        }

        /// <summary>
        /// Delete a Event entity
        /// </summary>
        /// <param name="eventId">Primary Key of Event table</param>
        public static void Delete(int eventId)
        {            
            EventDao.Delete(eventId);            
        }
    }
}
