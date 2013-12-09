// --------------------------------
// <copyright file="ConferenceEventsViewManager.cs" company="Conference Plus">
//     � 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
// Encapsulate business logic of ConferenceEventsView.   
// </summary>
// ---------------------------------

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
    }
}
