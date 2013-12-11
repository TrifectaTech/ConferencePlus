// --------------------------------
// <copyright file="ConferenceFeeDao.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  ConferenceFee Data Layer Object.   
// </summary>
// ---------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ConferencePlus.Data.Common;
using ConferencePlus.Entities.Common;
using ConferencePlus.Entities.ExtensionMethods;
using ConferencePlus.Entities;

namespace ConferencePlus.Data
{
    /// <summary>
    /// This class connects to the ConferenceFee Table
    /// </summary>
    public sealed class ConferenceFeeDao : BaseDao
    {
		/// <summary>
        /// Searches for ConferenceFee
        /// </summary>
		/// <param name="item" />
        /// <returns>An IEnumerable set of ConferenceFee</returns>
        public static IEnumerable<ConferenceFee> Search(SearchConferenceFee item)
        {
            List<SqlParameter> parameters
                = new List<SqlParameter>
					{
						new SqlParameter("@ConferenceFeeId", item.ConferenceFeeId),
                        new SqlParameter("@ConferenceId", item.ConferenceId),
                        new SqlParameter("@FeeAdjustmentId", item.FeeAdjustment),
                        new SqlParameter("@FeeTypeId", item.FeeType),
                        new SqlParameter("@Multiplier", item.Multiplier),
                        new SqlParameter("@EffectiveStartDate", item.EffectiveStartDate),
                        new SqlParameter("@EffectiveEndDate", item.EffectiveEndDate)
					};

            DataSet set = DataManager.ExecuteProcedure(ConferencePlusConnectionString, "ConferenceFee_Get", parameters);
            IEnumerable<DataRow> dataRows = set.GetRowsFromDataSet();
            return ConvertToEntityObject(dataRows);
        }

        /// <summary>
        /// Saves a ConferenceFee to the data store.
        /// </summary>
        /// <param name="item">The item to save</param>
        public static void Save(ConferenceFee item)
        {
			if (item.IsItemModified)
            {
                if (item.ConferenceFeeId == null)
                {
                    item.ConferenceFeeId = Insert(item);
                }
                else
                {
                    Update(item);
                }
            }
        }

        /// <summary>
        /// Inserts a new ConferenceFee
        /// </summary>
        /// <param name="item">The ConferenceFee item to insert</param>
        /// <returns>The id of the ConferenceFee item just inserted</returns>
        private static int Insert(ConferenceFee item)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
                        new SqlParameter("@ConferenceId", item.ConferenceId),
                        new SqlParameter("@FeeAdjustmentId", item.FeeAdjustment),
                        new SqlParameter("@FeeTypeId", item.FeeType),
                        new SqlParameter("@Multiplier", item.Multiplier),
                        new SqlParameter("@EffectiveStartDate", item.EffectiveStartDate),
                        new SqlParameter("@EffectiveEndDate", item.EffectiveEndDate)
					};
            return Convert.ToInt32(DataManager.ExecuteScalarProcedure(ConferencePlusConnectionString, "ConferenceFee_Insert", parameters));
        }

        /// <summary>
        /// Updates a ConferenceFee
        /// </summary>
        /// <param name="item">The ConferenceFee item to save</param>
        private static void Update(ConferenceFee item)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@ConferenceFeeId", item.ConferenceFeeId),
                        new SqlParameter("@ConferenceId", item.ConferenceId),
                        new SqlParameter("@FeeAdjustmentId", item.FeeAdjustment),
                        new SqlParameter("@FeeTypeId", item.FeeType),
                        new SqlParameter("@Multiplier", item.Multiplier),
                        new SqlParameter("@EffectiveStartDate", item.EffectiveStartDate),
                        new SqlParameter("@EffectiveEndDate", item.EffectiveEndDate)
					};
            DataManager.ExecuteProcedure(ConferencePlusConnectionString, "ConferenceFee_Update", parameters);
        }

        /// <summary>
        /// Does a physical delete of a(n) ConferenceFee
        /// </summary>
        /// <param name="conferenceFeeId" />
        public static void Delete(int conferenceFeeId)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@ConferenceFeeId", conferenceFeeId)
					};
            DataManager.ExecuteProcedure(ConferencePlusConnectionString, "ConferenceFee_Delete", parameters);
        }

        /// <summary>
        /// Converts an IEnumerable set of DataRows to an IEnumerable of ConferenceFee
        /// </summary>
        /// <param name="dataRows" />
        /// <returns />
        private static IEnumerable<ConferenceFee> ConvertToEntityObject(IEnumerable<DataRow> dataRows)
        {
            return dataRows.Select(row => new ConferenceFee
				{
                    ConferenceFeeId = row.GetValue<int>("ConferenceFeeId"),
                    ConferenceId = row.GetValue<int>("ConferenceId"),
                    FeeAdjustment = row.GetValue<EnumFeeAdjustment>("FeeAdjustmentId"),
                    FeeType = row.GetValue<EnumFeeType>("FeeTypeId"),
                    Multiplier = row.GetValue<decimal>("Multiplier") ,
                    EffectiveStartDate = row.GetValue<DateTime>("EffectiveStartDate"),
                    EffectiveEndDate = row.GetValue<DateTime>("EffectiveEndDate")
				});
        }
    }
}
