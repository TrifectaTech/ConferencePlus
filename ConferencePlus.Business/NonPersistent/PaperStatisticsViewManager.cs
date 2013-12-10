// --------------------------------
// <copyright file="PaperStatisticsViewManager.cs" company="Conference Plus">
//     � 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
// Encapsulate business logic of PaperStatisticsView.   
// </summary>
// ---------------------------------

using System.Collections.Generic;
using ConferencePlus.Data.NonPersistent;
using ConferencePlus.Entities.NonPersistent;

namespace ConferencePlus.Business.NonPersistent
{
    /// <summary>
    /// This class encapsulates the business logic of PaperStatisticsView entity
    /// </summary>
    public static class PaperStatisticsViewManager
    {   
		/// <summary>
        /// Searches for PaperStatisticsView
        /// </summary>
        /// <param name="search" />
        /// <returns>An IEnumerable set of PaperStatisticsView</returns>
        public static IEnumerable<PaperStatisticsView> Search(SearchPaperStatisticsView search)
        {            
			return search == null ? new List <PaperStatisticsView>() : PaperStatisticsViewDao.Search(search);
        }	
    }
}
