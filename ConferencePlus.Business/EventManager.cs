// --------------------------------
// <copyright file="EventManager.cs" company="Conference Plus">
//     � 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
// Encapusulate business logic of Event.   
// </summary>
// ---------------------------------

using System.Collections.Generic;
using System.Linq;
using ConferencePlus.Data;
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
            // TODO: Provide any further needed validation logic 
			
			errorMessage = string.Empty;

			if (!item.StartDate.IsValidWithSqlDateStandards())
			{
				errorMessage += "StartDate must be valid.";
			}

			if (!item.EndDate.IsValidWithSqlDateStandards())
			{
				errorMessage += "EndDate must be valid.";
			}

			errorMessage = errorMessage.TrimSafely();
            
            return errorMessage.Length == 0;
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
