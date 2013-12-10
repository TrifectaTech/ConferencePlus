// --------------------------------
// <copyright file="SearchPaperStatisticsView.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  SearchPaperStatisticsView Search Entity Object.   
// </summary>
// ---------------------------------

using System;
using ConferencePlus.Entities.Common;

namespace ConferencePlus.Entities.NonPersistent
{
	/// <summary>
	/// SearchPaperStatisticsView search entity object. 
	/// </summary>
	[Serializable]
	public class SearchPaperStatisticsView
	{
        /// <summary>
        /// Gets or sets ConferenceId.
        /// </summary>
        public int? ConferenceId { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets PaperCategory.
        /// </summary>
        public EnumPaperCategory? PaperCategory { get; set; }

        /// <summary>
        /// Gets or sets PaperCategoryDescription.
        /// </summary>
        public string PaperCategoryDescription { get; set; }

        /// <summary>
        /// Gets or sets PaperCategoryCount.
        /// </summary>
        public int? PaperCategoryCount { get; set; }

        /// <summary>
        /// Initializes a new instance of the SearchPaperStatisticsView class.
        /// </summary>
        public SearchPaperStatisticsView()
        {
            ConferenceId = null;
            Name = null;
            PaperCategory = null;
            PaperCategoryDescription = null;
            PaperCategoryCount = null;
        }
	}
}
