// --------------------------------
// <copyright file="TransactionManager.cs" company="Conference Plus">
//     � 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
// Encapusulate business logic of Transaction.   
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
    /// This class encapsulates the business logic of Transaction entity
    /// </summary>
    public static class TransactionManager
    {        
        /// <summary>
        /// Searches for Transaction
        /// </summary>
        /// <param name="search" />
        /// <returns>An IEnumerable set of Transaction</returns>
        public static IEnumerable<Transaction> Search(SearchTransaction search)
        {            
			return TransactionDao.Search(search);
        }	
	     
        /// <summary>
        /// Loads Transaction by the id parameter
        /// </summary>
        /// <param name="transactionId">Primary Key of Transaction table</param>
        /// <returns>Transaction entity</returns>
        public static Transaction Load(int transactionId)
        {
			SearchTransaction search
				= new SearchTransaction
					{
						TransactionId = transactionId
					};    
			return Search(search).FirstOrDefault();
        }

        /// <summary>
        /// Save Transaction Entity
        /// </summary>
        /// <param name="item">Entity to save</param>
        /// <param name="errorMessage">Error Message</param>
		/// <returns>return true if save successfully, else return false</returns>
        public static bool Save(Transaction item, out string errorMessage)
        {
            bool isValid = Validate(item, out errorMessage);                     
            
			if (isValid)
			{
                TransactionDao.Save(item);				
            }	        

            return isValid;
        }

        /// <summary>
        /// Validate Transaction Entity
        /// </summary>
        /// <param name="item">Entity to validate</param>
        /// <param name="errorMessage">error message if vlidation failed</param>
        /// <returns>return true if entity passes validation logic, else return false</returns>
        public static bool Validate(Transaction item, out string errorMessage)
        {
            StringBuilder builder = new StringBuilder();

            PaymentInfo info = TypeMapper<PaymentInfo>.Map(item);

            if (!PaymentInfoManager.Validate(info, out errorMessage))
            {
                builder.AppendHtmlLine(errorMessage);
            }

            if (item.Fee == default(decimal))
            {
                builder.AppendHtmlLine("*Fee is required");
            }

            if (item.FeeAdjustment == EnumFeeAdjustment.None)
            {
                builder.AppendHtmlLine("*Fee adjustment is required");
            }

            if (item.FeeType == EnumFeeType.None)
            {
                builder.AppendHtmlLine("*Fee type is required");
            }

            if (!item.TransactionDate.IsValidWithSqlDateStandards())
            {
                builder.AppendHtmlLine("*Transaction date is required");
            }

            if (item.UserId == default(Guid))
            {
                builder.AppendHtmlLine("*User Id is required");
            }

            errorMessage = builder.ToString();

            return errorMessage.IsNullOrWhiteSpace();
        }

        /// <summary>
        /// Delete a Transaction entity
        /// </summary>
        /// <param name="transactionId">Primary Key of Transaction table</param>
        public static void Delete(int transactionId)
        {            
            TransactionDao.Delete(transactionId);            
        }
    }
}
