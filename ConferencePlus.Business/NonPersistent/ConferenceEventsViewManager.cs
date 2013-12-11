// --------------------------------
// <copyright file="ConferenceEventsViewManager.cs" company="Conference Plus">
//     � 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
// Encapsulate business logic of ConferenceEventsView.   
// </summary>
// ---------------------------------

using System;
using System.Collections.Generic;
using ConferencePlus.Data.NonPersistent;
using ConferencePlus.Entities.NonPersistent;

namespace ConferencePlus.Business.NonPersistent
{
    /// <summary>
    /// This class encapsulates the business logic of ConferenceEventsView entity
    /// </summary>
    public static class ConferenceEventsViewManager
    {   
		/// <summary>
        /// Searches for ConferenceEventsView
        /// </summary>
        /// <param name="search" />
        /// <returns>An IEnumerable set of ConferenceEventsView</returns>
        public static IEnumerable<ConferenceEventsView> Search(SearchConferenceEventsView search)
        {            
			return search == null ? new List <ConferenceEventsView>() : ConferenceEventsViewDao.Search(search);
        }

		/// <summary>
		/// Loads ConferenceEventsView by ConferenceId
		/// </summary>
		/// <param name="conferenceId" />
		/// <returns>An IEnumerable set of ConferenceEventsView</returns>
	    public static IEnumerable<ConferenceEventsView> LoadByConferenceId(int conferenceId)
	    {
		    return Search(new SearchConferenceEventsView
		    {
			    ConferenceId = conferenceId
		    });
	    }

        public static IEnumerable<ConferenceEventsView> LoadByUserId(Guid userId)
        {
            return Search(new SearchConferenceEventsView
            {
                UserId = userId
            });
        }
    }
}
