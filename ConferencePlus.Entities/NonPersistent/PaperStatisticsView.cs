// --------------------------------
// <copyright file="PaperStatisticsView.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  PaperStatisticsView Entity Layer Object.   
// </summary>
// ---------------------------------

using System;
using ConferencePlus.Entities.Common;

namespace ConferencePlus.Entities.NonPersistent
{
	/// <summary>
	/// PaperStatisticsView entity object. 
	/// </summary>
	[Serializable]
	public class PaperStatisticsView
	{
        /// <summary>
        /// Gets or sets ConferenceId.
        /// </summary>
        public int ConferenceId { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets PaperCategory.
        /// </summary>
        public EnumPaperCategory PaperCategory { get; set; }

        /// <summary>
        /// Gets or sets PaperCategoryDescription.
        /// </summary>
        public string PaperCategoryDescription { get; set; }

        /// <summary>
        /// Gets or sets PaperCategoryCount.
        /// </summary>
        public int? PaperCategoryCount { get; set; }

        /// <summary>
        /// Initializes a new instance of the PaperStatisticsView class.
        /// </summary>
        public PaperStatisticsView()
        {
            ConferenceId = default(int);
            Name = default(string);
            PaperCategory = default(EnumPaperCategory);
            PaperCategoryDescription = default(string);
            PaperCategoryCount = default(int?);
        }

		//Returns a proper string denoting this entity
		public override string ToString()
		{
			return string.Format("ConferenceId: {0}, Name: {1}, PaperCategory: {2}, PaperCategoryCount: {3};", ConferenceId, Name, PaperCategory, PaperCategoryCount);
		}
	}
}
