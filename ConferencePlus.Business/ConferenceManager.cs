// --------------------------------
// <copyright file="ConferenceManager.cs" company="Conference Plus">
//     � 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
// Encapusulate business logic of Conference.   
// </summary>
// ---------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConferencePlus.Data;
using ConferencePlus.Entities.Common;
using ConferencePlus.Entities.ExtensionMethods;
using ConferencePlus.Entities;

namespace ConferencePlus.Business
{
    /// <summary>
    /// This class encapsulates the business logic of Conference entity
    /// </summary>
    public static class ConferenceManager
    {        
        /// <summary>
        /// Searches for Conference
        /// </summary>
        /// <param name="search" />
        /// <returns>An IEnumerable set of Conference</returns>
        public static IEnumerable<Conference> Search(SearchConference search)
        {            
			return ConferenceDao.Search(search);
        }	
	     
        /// <summary>
        /// Loads Conference by the id parameter
        /// </summary>
        /// <param name="conferenceId">Primary Key of Conference table</param>
        /// <returns>Conference entity</returns>
        public static Conference Load(int conferenceId)
        {
			SearchConference search
				= new SearchConference
					{
						ConferenceId = conferenceId
					};    
			return Search(search).FirstOrDefault();
        }

        /// <summary>
        /// Save Conference Entity
        /// </summary>
        /// <param name="item">Entity to save</param>
        /// <param name="errorMessage">Error Message</param>
		/// <returns>return true if save successfully, else return false</returns>
        public static bool Save(Conference item, out string errorMessage)
        {
            bool isValid = Validate(item, out errorMessage);                     
            
			if (isValid)
			{
                ConferenceDao.Save(item);				
            }	        

            return isValid;
        }

        /// <summary>
        /// Validate Conference Entity
        /// </summary>
        /// <param name="item">Entity to validate</param>
        /// <param name="errorMessage">error message if vlidation failed</param>
        /// <returns>return true if entity passes validation logic, else return false</returns>
        public static bool Validate(Conference item, out string errorMessage)
        {
            StringBuilder builder = new StringBuilder();

            if (item.ActivityType == EnumActivityType.None)
            {
                builder.AppendHtmlLine("*Activity type is required");
            }

            if (item.BaseFee == default(decimal))
            {
                builder.AppendHtmlLine("*Base fee is required");
            }

            if (item.Description.IsNullOrWhiteSpace())
            {
                builder.AppendHtmlLine("*Description is required");
            }

            if (!item.EndDate.IsValidWithSqlDateStandards())
            {
                builder.AppendHtmlLine("*End date is required");
            }

            if (!item.StartDate.IsValidWithSqlDateStandards())
            {
                builder.AppendHtmlLine("*Start date is required");
            }

            if (item.Name.IsNullOrWhiteSpace())
            {
                builder.AppendHtmlLine("*Name is required");
            }

            errorMessage = builder.ToString();

            return errorMessage.IsNullOrWhiteSpace();
        }

        /// <summary>
        /// Delete a Conference entity
        /// </summary>
        /// <param name="conferenceId">Primary Key of Conference table</param>
        public static void Delete(int conferenceId)
        {            
            ConferenceDao.Delete(conferenceId);            
        }
    }
}
