// --------------------------------
// <copyright file="ConferenceFee.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  ConferenceFee Entity Layer Object.   
// </summary>
// ---------------------------------
using System;
using ConferencePlus.Entities.Common;

namespace ConferencePlus.Entities
{
	/// <summary>
	/// ConferenceFee entity object. 
	/// </summary>
	[Serializable]
	public class ConferenceFee
	{
		public bool IsItemModified { get; set; }

        private int? conferenceFeeId;

        /// <summary>
        /// Gets or sets ConferenceFeeId.
        /// </summary>
        [SqlName("ConferenceFeeId")]
        public int? ConferenceFeeId
        {   
            get 
            {
                return conferenceFeeId;
            }
            set
            {
                if (value != conferenceFeeId)
                {
                    conferenceFeeId = value;
                    IsItemModified = true;
                }
            }
        }

        private int conferenceId;

        /// <summary>
        /// Gets or sets ConferenceId.
        /// </summary>
        [SqlName("ConferenceId")]
        public int ConferenceId
        {   
            get 
            {
                return conferenceId;
            }
            set
            {
                if (value != conferenceId)
                {
                    conferenceId = value;
                    IsItemModified = true;
                }
            }
        }

        private EnumFeeAdjustment feeAdjustment;

        /// <summary>
        /// Gets or sets FeeAdjustment.
        /// </summary>
        [SqlName("FeeAdjustmentId")]
        public EnumFeeAdjustment FeeAdjustment
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

        private decimal multiplier;

        /// <summary>
        /// Gets or sets Multiplier.
        /// </summary>
        [SqlName("Multiplier")]
        public decimal Multiplier
        {   
            get 
            {
                return multiplier;
            }
            set
            {
                if (value != multiplier)
                {
                    multiplier = value;
                    IsItemModified = true;
                }
            }
        }

        private DateTime effectiveStartDate;

        /// <summary>
        /// Gets or sets EffectiveStartDate.
        /// </summary>
        [SqlName("EffectiveStartDate")]
        public DateTime EffectiveStartDate
        {
            get
            {
                return effectiveStartDate;
            }
            set
            {
                if (value != effectiveStartDate)
                {
                    effectiveStartDate = value;
                    IsItemModified = true;
                }
            }
        }

        private DateTime effectiveEndDate;

        /// <summary>
        /// Gets or sets EffectiveEndDate.
        /// </summary>
        [SqlName("EffectiveEndDate")]
        public DateTime EffectiveEndDate
        {
            get
            {
                return effectiveEndDate;
            }
            set
            {
                if (value != effectiveEndDate)
                {
                    effectiveEndDate = value;
                    IsItemModified = true;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the ConferenceFee class.
        /// </summary>
        public ConferenceFee()
        {
            ConferenceFeeId = default(int?);
            ConferenceId = default(int);
            FeeAdjustment = default(EnumFeeAdjustment);
            FeeType = default(EnumFeeType);
            Multiplier = default(decimal);
            EffectiveStartDate = default(DateTime);
            EffectiveEndDate = default(DateTime);
            IsItemModified = false;
        }

		public override string ToString()
		{
			return string.Format("ConferenceFeeId: {0}, ConferenceId: {1}, FeeAdjustment: {2}, FeeType: {3}, Multiplier: {4};", ConferenceFeeId, ConferenceId, FeeAdjustment, FeeType, Multiplier);
		}
	}
}
