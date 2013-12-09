// --------------------------------
// <copyright file="SearchTransaction.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  SearchTransaction Search Entity Object.   
// </summary>
// ---------------------------------
using System;

namespace ConferencePlus.Entities
{
	/// <summary>
	/// SearchTransaction search entity object. 
	/// </summary>
	[Serializable]
	public class SearchTransaction
	{
        /// <summary>
        /// Gets or sets TransactionId.
        /// </summary>
        public int? TransactionId { get; set; }

        /// <summary>
        /// Gets or sets UserId.
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Gets or sets FeeType.
        /// </summary>
        public int? FeeType { get; set; }

        /// <summary>
        /// Gets or sets FeeAdjustment.
        /// </summary>
        public int? FeeAdjustment { get; set; }

        /// <summary>
        /// Gets or sets Fee.
        /// </summary>
        public decimal? Fee { get; set; }

        /// <summary>
        /// Gets or sets CreditCardNumber.
        /// </summary>
        public string CreditCardNumber { get; set; }

        /// <summary>
        /// Gets or sets CreditCardType.
        /// </summary>
        public int? CreditCardType { get; set; }

        /// <summary>
        /// Gets or sets ExpirationDate.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets CCV.
        /// </summary>
        public int? CCV { get; set; }

        /// <summary>
        /// Gets or sets BillingAddress.
        /// </summary>
        public string BillingAddress { get; set; }

        /// <summary>
        /// Gets or sets BillingCity.
        /// </summary>
        public string BillingCity { get; set; }

        /// <summary>
        /// Gets or sets BillingState.
        /// </summary>
        public string BillingState { get; set; }

        /// <summary>
        /// Gets or sets BillingZip.
        /// </summary>
        public string BillingZip { get; set; }

        /// <summary>
        /// Gets or sets TransactionDate.
        /// </summary>
        public DateTime? TransactionDate { get; set; }

        /// <summary>
        /// Initializes a new instance of the SearchTransaction class.
        /// </summary>
        public SearchTransaction()
        {
            TransactionId = null;
            UserId = null;
            FeeType = null;
            FeeAdjustment = null;
            Fee = null;
            CreditCardNumber = null;
            CreditCardType = null;
            ExpirationDate = null;
            CCV = null;
            BillingAddress = null;
            BillingCity = null;
            BillingState = null;
            BillingZip = null;
            TransactionDate = null;
        }
	}
}
