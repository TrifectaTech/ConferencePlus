// --------------------------------
// <copyright file="PaymentInfoManager.cs" company="Conference Plus">
//     � 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
// Encapusulate business logic of PaymentInfo.   
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
    /// This class encapsulates the business logic of PaymentInfo entity
    /// </summary>
    public static class PaymentInfoManager
    {        
        /// <summary>
        /// Searches for PaymentInfo
        /// </summary>
        /// <param name="search" />
        /// <returns>An IEnumerable set of PaymentInfo</returns>
        public static IEnumerable<PaymentInfo> Search(SearchPaymentInfo search)
        {            
			return PaymentInfoDao.Search(search);
        }	
	     
        /// <summary>
        /// Loads PaymentInfo by the id parameter
        /// </summary>
        /// <param name="paymentInfoId">Primary Key of PaymentInfo table</param>
        /// <returns>PaymentInfo entity</returns>
        public static PaymentInfo Load(int paymentInfoId)
        {
			SearchPaymentInfo search
				= new SearchPaymentInfo
					{
						PaymentInfoId = paymentInfoId
					};    
			return Search(search).FirstOrDefault();
        }

        /// <summary>
        /// Save PaymentInfo Entity
        /// </summary>
        /// <param name="item">Entity to save</param>
        /// <param name="errorMessage">Error Message</param>
		/// <returns>return true if save successfully, else return false</returns>
        public static bool Save(PaymentInfo item, out string errorMessage)
        {
            bool isValid = Validate(item, out errorMessage);                     
            
			if (isValid)
			{
                PaymentInfoDao.Save(item);				
            }	        

            return isValid;
        }

        /// <summary>
        /// Validate PaymentInfo Entity
        /// </summary>
        /// <param name="item">Entity to validate</param>
        /// <param name="errorMessage">error message if vlidation failed</param>
        /// <returns>return true if entity passes validation logic, else return false</returns>
        public static bool Validate(PaymentInfo item, out string errorMessage)
        {
            StringBuilder builder = new StringBuilder();

            if (item.BillingAddress.IsNullOrWhiteSpace())
            {
                builder.AppendHtmlLine("*Billing Address is required");
            }

            if (item.BillingCity.IsNullOrWhiteSpace())
            {
                builder.AppendHtmlLine("*Billing City is required");
            }

            if (item.BillingState.IsNullOrWhiteSpace())
            {
                builder.AppendHtmlLine("*Billing State is required");
            }

            if (item.BillingZip.IsNullOrWhiteSpace())
            {
                builder.AppendHtmlLine("*Billing Zip is required");   
            }

            if (item.CCV == default(int))
            {
                builder.AppendHtmlLine("*CCV is required");
            }

            if (item.CreditCardNumber.IsNullOrWhiteSpace())

            {
                builder.AppendHtmlLine("*Credit card number is required");
            }

            if (item.CreditCardType == EnumCreditCardType.None)
            {
                builder.AppendHtmlLine("*Credit card type is required");
            }

            if (!item.ExpirationDate.IsValidWithSqlDateStandards())

            {
                builder.AppendHtmlLine("*Expiration date is required");   
            }

            if (item.UserId == default(Guid))
            {
                builder.AppendHtmlLine("*User Id is required");
            }

            errorMessage = builder.ToString();

            return errorMessage.IsNullOrWhiteSpace();
        }

        /// <summary>
        /// Delete a PaymentInfo entity
        /// </summary>
        /// <param name="paymentInfoId">Primary Key of PaymentInfo table</param>
        public static void Delete(int paymentInfoId)
        {            
            PaymentInfoDao.Delete(paymentInfoId);            
        }
    }
}
