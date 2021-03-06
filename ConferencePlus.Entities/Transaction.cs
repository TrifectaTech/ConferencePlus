// --------------------------------
// <copyright file="Transaction.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  Transaction Entity Layer Object.   
// </summary>
// ---------------------------------
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using ConferencePlus.Entities.Common;

namespace ConferencePlus.Entities
{
	/// <summary>
	/// Transaction entity object. 
	/// </summary>
	[Serializable]
	public class Transaction
	{
		public bool IsItemModified { get; set; }

        private int? transactionId;

        /// <summary>
        /// Gets or sets TransactionId.
        /// </summary>
        [SqlName("TransactionId")]
        public int? TransactionId
        {   
            get 
            {
                return transactionId;
            }
            set
            {
                if (value != transactionId)
                {
                    transactionId = value;
                    IsItemModified = true;
                }
            }
        }

		private int eventId;

		/// <summary>
		/// Gets or sets EventId.
		/// </summary>
		[SqlName("EventId")]
		public int EventId
		{
			get
			{
				return eventId;
			}
			set
			{
				if (value != eventId)
				{
					eventId = value;
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

        private EnumFeeType feeType;

        /// <summary>
        /// Gets or sets FeeType.
        /// </summary>
        [SqlName("FeeTypeId")]
        public EnumFeeType FeeType
        {   
            get 
            {
                return feeType;
            }
            set
            {
                if (value != feeType)
                {
                    feeType = value;
                    IsItemModified = true;
                }
            }
        }

        private EnumFeeAdjustment? feeAdjustment;

        /// <summary>
        /// Gets or sets FeeAdjustment.
        /// </summary>
        [SqlName("FeeAdjustmentId")]
        public EnumFeeAdjustment? FeeAdjustment
        {   
            get 
            {
                return feeAdjustment;
            }
            set
            {
                if (value != feeAdjustment)
                {
                    feeAdjustment = value;
                    IsItemModified = true;
                }
            }
        }

        private decimal fee;

        /// <summary>
        /// Gets or sets Fee.
        /// </summary>
        [SqlName("Fee")]
        public decimal Fee
        {   
            get 
            {
                return fee;
            }
            set
            {
                if (value != fee)
                {
                    fee = value;
                    IsItemModified = true;
                }
            }
        }

        private string creditCardNumber;

        /// <summary>
        /// Gets or sets CreditCardNumber.
        /// </summary>
        [SqlName("CreditCardNumber")]
        public string CreditCardNumber
        {   
            get 
            {
                return creditCardNumber;
            }
            set
            {
                if (value != creditCardNumber)
                {
                    creditCardNumber = value;
                    IsItemModified = true;
                }
            }
        }

        private EnumCreditCardType creditCardType;

        /// <summary>
        /// Gets or sets CreditCardType.
        /// </summary>
        [SqlName("CreditCardTypeId")]
        public EnumCreditCardType CreditCardType
        {   
            get 
            {
                return creditCardType;
            }
            set
            {
                if (value != creditCardType)
                {
                    creditCardType = value;
                    IsItemModified = true;
                }
            }
        }

        private DateTime expirationDate;

        /// <summary>
        /// Gets or sets ExpirationDate.
        /// </summary>
        [SqlName("ExpirationDate")]
        public DateTime ExpirationDate
        {   
            get 
            {
                return expirationDate;
            }
            set
            {
                if (value != expirationDate)
                {
                    expirationDate = value;
                    IsItemModified = true;
                }
            }
        }

        private int ccv;

        /// <summary>
        /// Gets or sets CCV.
        /// </summary>
        [SqlName("CCV")]
        public int CCV
        {   
            get 
            {
                return ccv;
            }
            set
            {
				if (value != ccv)
                {
					ccv = value;
                    IsItemModified = true;
                }
            }
        }

        private string billingAddress;

        /// <summary>
        /// Gets or sets BillingAddress.
        /// </summary>
        [SqlName("BillingAddress")]
        public string BillingAddress
        {   
            get 
            {
                return billingAddress;
            }
            set
            {
                if (value != billingAddress)
                {
                    billingAddress = value;
                    IsItemModified = true;
                }
            }
        }

        private string billingCity;

        /// <summary>
        /// Gets or sets BillingCity.
        /// </summary>
        [SqlName("BillingCity")]
        public string BillingCity
        {   
            get 
            {
                return billingCity;
            }
            set
            {
                if (value != billingCity)
                {
                    billingCity = value;
                    IsItemModified = true;
                }
            }
        }

        private string billingState;

        /// <summary>
        /// Gets or sets BillingState.
        /// </summary>
        [SqlName("BillingState")]
        public string BillingState
        {   
            get 
            {
                return billingState;
            }
            set
            {
                if (value != billingState)
                {
                    billingState = value;
                    IsItemModified = true;
                }
            }
        }

        private string billingZip;

        /// <summary>
        /// Gets or sets BillingZip.
        /// </summary>
        [SqlName("BillingZip")]
        public string BillingZip
        {   
            get 
            {
                return billingZip;
            }
            set
            {
                if (value != billingZip)
                {
                    billingZip = value;
                    IsItemModified = true;
                }
            }
        }

        private DateTime transactionDate;

        /// <summary>
        /// Gets or sets TransactionDate.
        /// </summary>
        [SqlName("TransactionDate")]
        public DateTime TransactionDate
        {   
            get 
            {
                return transactionDate;
            }
            set
            {
                if (value != transactionDate)
                {
                    transactionDate = value;
                    IsItemModified = true;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the Transaction class.
        /// </summary>
        public Transaction()
        {
            TransactionId = default(int?);
	        EventId = default(int);
            UserId = default(Guid);
            FeeType = default(EnumFeeType);
            FeeAdjustment = default(EnumFeeAdjustment?);
            Fee = default(decimal);
            CreditCardNumber = default(string);
            CreditCardType = default(EnumCreditCardType);
            ExpirationDate = default(DateTime);
            CCV = default(int);
            BillingAddress = default(string);
            BillingCity = default(string);
            BillingState = default(string);
            BillingZip = default(string);
            TransactionDate = default(DateTime);
            IsItemModified = false;
        }

		public override string ToString()
		{
			return string.Format("TransactionId: {0}, UserId: {1}, FeeType: {2}, FeeAdjustment: {3}, Fee: {4};", TransactionId, UserId, FeeType, FeeAdjustment, Fee);
		}
	}
}
