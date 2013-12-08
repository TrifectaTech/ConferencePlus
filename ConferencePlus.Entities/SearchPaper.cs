// --------------------------------
// <copyright file="SearchPaper.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  SearchPaper Search Entity Object.   
// </summary>
// ---------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using ConferencePlus.Entities;

namespace ConferencePlus.Entities
{
	/// <summary>
	/// SearchPaper search entity object. 
	/// </summary>
	[Serializable]
	public class SearchPaper
	{
        /// <summary>
        /// Gets or sets PaperId.
        /// </summary>
        public int? PaperId { get; set; }

        /// <summary>
        /// Gets or sets UserId.
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Gets or sets PaperCategory.
        /// </summary>
        public int? PaperCategory { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Initializes a new instance of the SearchPaper class.
        /// </summary>
        public SearchPaper()
        {
            PaperId = null;
            UserId = null;
            PaperCategory = null;
            Name = null;
            Description = null;
            Author = null;
        }
	}
}
