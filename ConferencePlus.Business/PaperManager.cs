// --------------------------------
// <copyright file="PaperManager.cs" company="Conference Plus">
//     � 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
// Encapusulate business logic of Paper.   
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
    /// This class encapsulates the business logic of Paper entity
    /// </summary>
    public static class PaperManager
    {        
        /// <summary>
        /// Searches for Paper
        /// </summary>
        /// <param name="search" />
        /// <returns>An IEnumerable set of Paper</returns>
        public static IEnumerable<Paper> Search(SearchPaper search)
        {            
			return PaperDao.Search(search);
        }	
	     
        /// <summary>
        /// Loads Paper by the id parameter
        /// </summary>
        /// <param name="paperId">Primary Key of Paper table</param>
        /// <returns>Paper entity</returns>
        public static Paper Load(int paperId)
        {
			SearchPaper search
				= new SearchPaper
					{
						PaperId = paperId
					};    
			return Search(search).FirstOrDefault();
        }

        /// <summary>
        /// Save Paper Entity
        /// </summary>
        /// <param name="item">Entity to save</param>
        /// <param name="errorMessage">Error Message</param>
		/// <returns>return true if save successfully, else return false</returns>
        public static bool Save(Paper item, out string errorMessage)
        {
            bool isValid = Validate(item, out errorMessage);                     
            
			if (isValid)
			{
                PaperDao.Save(item);				
            }	        

            return isValid;
        }

        /// <summary>
        /// Validate Paper Entity
        /// </summary>
        /// <param name="item">Entity to validate</param>
        /// <param name="errorMessage">error message if vlidation failed</param>
        /// <returns>return true if entity passes validation logic, else return false</returns>
        public static bool Validate(Paper item, out string errorMessage)
        {
            // TODO: Provide any further needed validation logic 
			
			errorMessage = string.Empty;

			

			errorMessage = errorMessage.TrimSafely();
            
            return errorMessage.Length == 0;
        }

        /// <summary>
        /// Delete a Paper entity
        /// </summary>
        /// <param name="paperId">Primary Key of Paper table</param>
        public static void Delete(int paperId)
        {            
            PaperDao.Delete(paperId);            
        }
    }
}
