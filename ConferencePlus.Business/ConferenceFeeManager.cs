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
using System.Text;
using ConferencePlus.Data;
using ConferencePlus.Entities.Common;
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
		/// Load ConferenceFee on ConferenceId
		/// </summary>
		/// <param name="conferenceId" />
		/// <returns>An IEnumerable set of ConferenceFee</returns>
		public static IEnumerable<ConferenceFee> LoadOnConferenceId(int conferenceId)
		{
			SearchConferenceFee search
				= new SearchConferenceFee
					{
						ConferenceId = conferenceId
					};
			return Search(search);
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
			StringBuilder builder = new StringBuilder();

			if (item.ConferenceId == default(int))
			{
				builder.AppendHtmlLine("*Please specify the conference to assign this fee to");
			}

			if (item.FeeAdjustment == EnumFeeAdjustment.None)
			{
				builder.AppendHtmlLine("*Please specify pricing type for this conference");
			}

			if (item.FeeType == EnumFeeType.None)
			{
				builder.AppendHtmlLine("*Please specify the type of fee for this conference");
			}

			if (item.Multiplier < 0)
			{
				builder.AppendHtmlLine("*Multiplier must be greater than or equal to 0");
			}

			if (!item.EffectiveStartDate.IsValidWithSqlDateStandards())
			{
				builder.AppendHtmlLine("*EffectiveStartDate is not valid with Sql Date Standards.");
			}

			if (!item.EffectiveEndDate.IsValidWithSqlDateStandards())
			{
				builder.AppendHtmlLine("*EffectiveEndDate is not valid with Sql Date Standards.");
			}

			if (item.EffectiveEndDate <= item.EffectiveStartDate)
			{
				builder.AppendHtmlLine("*Effective End Date needs to be after the Effective Start Date");
			}

			//Validate Conference
			if (builder.ToString().IsNullOrWhiteSpace())
			{
				SearchConference search = new SearchConference { ConferenceId = item.ConferenceId };
				Conference conference = ConferenceManager.Search(search).FirstOrDefault();

				if (conference == null)
				{
					builder.AppendHtmlLine("*Conference Does not exists.");
				}
				else
				{
					if (item.EffectiveStartDate.OnOrAfter(conference.StartDate))
					{
						builder.AppendHtmlLine("*There is a conflict with the Conference Start date.");
					}
				}
			}

			//Validate ConferenceFees
			if (builder.ToString().IsNullOrWhiteSpace())
			{
				SearchConferenceFee searchList = new SearchConferenceFee { FeeType = item.FeeType, FeeAdjustment = item.FeeAdjustment, ConferenceId = item.ConferenceId };
				List<ConferenceFee> feeList = Search(searchList).Where(t => t.ConferenceFeeId != item.ConferenceFeeId.GetValueOrDefault(0)).ToList();

				if (feeList.SafeAny())
				{
					builder.AppendHtmlLine("*Cannot contain a duplicate Conference Fee Type Entry.");
				}
				else
				{
					SearchConferenceFee allSearch = new SearchConferenceFee { FeeType = item.FeeType, ConferenceId = item.ConferenceId };
					List<ConferenceFee> allList = Search(allSearch).Where(t => t.ConferenceFeeId != item.ConferenceFeeId.GetValueOrDefault(0)).ToList();

					if (allList.SafeAny())
					{

						if (allList.SafeAny(t => item.EffectiveStartDate.Between(t.EffectiveStartDate, t.EffectiveEndDate) || item.EffectiveEndDate.Between(t.EffectiveStartDate, t.EffectiveEndDate)))
						{
							builder.AppendHtmlLine("*There is a conflict with the dates for Conference Fee.");
						}

						if (builder.ToString().IsNullOrWhiteSpace())
						{
							if (item.FeeAdjustment == EnumFeeAdjustment.Early)
							{
								if (allList.SafeAny(t => item.EffectiveStartDate.OnOrAfter(t.EffectiveStartDate)))
								{
									builder.AppendHtmlLine("*Early Fee Type needs to be before Normal or On-Site Fee Type.");
								}
							}
							else if (item.FeeAdjustment == EnumFeeAdjustment.Normal)
							{
								if (allList.SafeAny(t => item.EffectiveStartDate.OnOrAfter(t.EffectiveStartDate) && t.FeeAdjustment == EnumFeeAdjustment.OnSite))
								{
									builder.AppendHtmlLine("*Normal Fee Type needs to be before On-Site Fee Type.");
								}
								else if (allList.SafeAny(t => item.EffectiveStartDate.OnOrBefore(t.EffectiveEndDate) && t.FeeAdjustment == EnumFeeAdjustment.Early))
								{
									builder.AppendHtmlLine("*Normal Fee Type needs to be after Early Fee Type.");
								}
							}
							else if (item.FeeAdjustment == EnumFeeAdjustment.OnSite)
							{
								if (allList.SafeAny(t => item.EffectiveStartDate.OnOrBefore(t.EffectiveEndDate)))
								{
									builder.AppendHtmlLine("*On-Site Fee Type needs to be after Normal or Early Fee Type.");
								}
							}
						}
					}
				}
			}

			errorMessage = builder.ToString();

			return errorMessage.IsNullOrWhiteSpace();
		}

		/// <summary>
		/// Delete a ConferenceFee entity
		/// </summary>
		/// <param name="conferenceFeeId">Primary Key of ConferenceFee table</param>
		public static void Delete(int conferenceFeeId)
		{
			ConferenceFeeDao.Delete(conferenceFeeId);
		}

		/// <summary>
		/// Calculates Fee
		/// </summary>
		/// <param name="conferenceId" />
		/// <param name="feeType" />
		/// <param name="conferenceFee" />
		/// <returns>Fee for specific FeeType</returns>
		public static decimal CalculateFee(int conferenceId, EnumFeeType feeType, out ConferenceFee conferenceFee)
		{
			decimal fee = default(decimal);
			conferenceFee = null;

			Conference conference = ConferenceManager.Load(conferenceId);
			if (conference != null)
			{
				fee = conference.BaseFee;

				List<ConferenceFee> conferenceFeeList = LoadOnConferenceId(conferenceId).Where(c => c.FeeType == feeType).ToList();
				if (conferenceFeeList.SafeAny())
				{
					conferenceFee
						= conferenceFeeList.FirstOrDefault(c => DateTimeMethods.DoDatesOverlap(c.EffectiveStartDate,
																							   c.EffectiveEndDate,
																							   DateTime.Today,
																							   DateTime.Today));

					if (conferenceFee != null)
					{
						fee *= conferenceFee.Multiplier;
					}
				}
			}

			return fee;
		}
	}
}
