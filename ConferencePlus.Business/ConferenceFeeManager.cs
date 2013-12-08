// --------------------------------
// <copyright file="ConferenceFeeManager.cs" company="Conference Plus">
//     � 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
// Encapusulate business logic of ConferenceFee.   
// </summary>
// ---------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using ConferencePlus.Data;
using ConferencePlus.Entities.ExtensionMethods;
using ConferencePlus.Entities;

namespace ConferencePlus.Business
{
    /// <summary>
    /// This class encapsulates the business logic of ConferenceFee entity
    /// </summary>
    public static class ConferenceFeeManager
    {        
        /// <summary>
        /// Searches for ConferenceFee
        /// </summary>
        /// <param name="search" />
        /// <returns>An IEnumerable set of ConferenceFee</returns>
        public static IEnumerable<ConferenceFee> Search(SearchConferenceFee search)
        {            
			return ConferenceFeeDao.Search(search);
        }	
	     
        /// <summary>
        /// Loads ConferenceFee by the id parameter
        /// </summary>
        /// <param name="conferenceFeeId">Primary Key of ConferenceFee table</param>
        /// <returns>ConferenceFee entity</returns>
        public static ConferenceFee Load(int conferenceFeeId)
        {
			SearchConferenceFee search
				= new SearchConferenceFee
					{
						ConferenceFeeId = conferenceFeeId
					};    
			return Search(search).FirstOrDefault();
        }

        /// <summary>
        /// Save ConferenceFee Entity
        /// </summary>
        /// <param name="item">Entity to save</param>
        /// <param name="errorMessage">Error Message</param>
		/// <returns>return true if save successfully, else return false</returns>
        public static bool Save(ConferenceFee item, out string errorMessage)
        {
            bool isValid = Validate(item, out errorMessage);                     
            
			if (isValid)
			{
                ConferenceFeeDao.Save(item);				
            }	        

            return isValid;
        }

        /// <summary>
        /// Validate ConferenceFee Entity
        /// </summary>
        /// <param name="item">Entity to validate</param>
        /// <param name="errorMessage">error message if vlidation failed</param>
        /// <returns>return true if entity passes validation logic, else return false</returns>
        public static bool Validate(ConferenceFee item, out string errorMessage)
        {
            // TODO: Provide any further needed validation logic 
			
			errorMessage = string.Empty;

			

			errorMessage = errorMessage.TrimSafely();
            
            return errorMessage.Length == 0;
        }

        /// <summary>
        /// Delete a ConferenceFee entity
        /// </summary>
        /// <param name="conferenceFeeId">Primary Key of ConferenceFee table</param>
        public static void Delete(int conferenceFeeId)
        {            
            ConferenceFeeDao.Delete(conferenceFeeId);            
        }
    }
}
