// --------------------------------
// <copyright file="Paper.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  Paper Entity Layer Object.   
// </summary>
// ---------------------------------
using System;
using ConferencePlus.Entities.Common;

namespace ConferencePlus.Entities
{
	/// <summary>
	/// Paper entity object. 
	/// </summary>
	[Serializable]
	public class Paper
	{
		public bool IsItemModified { get; set; }

        private int? paperId;

        /// <summary>
        /// Gets or sets PaperId.
        /// </summary>
        [SqlName("PaperId")]
        public int? PaperId
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

        private Guid userId;

        /// <summary>
        /// Gets or sets UserId.
        /// </summary>
        [SqlName("UserId")]
        public Guid UserId
        {   
            get 
            {
                return userId;
            }
            set
            {
                if (value != userId)
                {
                    userId = value;
                    IsItemModified = true;
                }
            }
        }

        private EnumPaperCategory paperCategory;

        /// <summary>
        /// Gets or sets PaperCategory.
        /// </summary>
        [SqlName("PaperCategoryId")]
        public EnumPaperCategory PaperCategory
        {   
            get 
            {
                return paperCategory;
            }
            set
            {
                if (value != paperCategory)
                {
                    paperCategory = value;
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

        private string author;

        /// <summary>
        /// Gets or sets Author.
        /// </summary>
        [SqlName("Author")]
        public string Author
        {   
            get 
            {
                return author;
            }
            set
            {
                if (value != author)
                {
                    author = value;
                    IsItemModified = true;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the Paper class.
        /// </summary>
        public Paper()
        {
            PaperId = default(int?);
            UserId = default(Guid);
            PaperCategory = default(EnumPaperCategory);
            Name = default(string);
            Description = default(string);
            Author = default(string);
            IsItemModified = false;
        }

		public override string ToString()
		{
			return string.Format("PaperId: {0}, UserId: {1}, PaperCategory: {2}, Name: {3}, Description: {4}, Author: {5};", PaperId, UserId, PaperCategory, Name, Description, Author);
		}
	}
}
