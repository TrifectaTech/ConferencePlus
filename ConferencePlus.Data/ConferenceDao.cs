// --------------------------------
// <copyright file="ConferenceDao.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  Conference Data Layer Object.   
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
    /// This class connects to the Conference Table
    /// </summary>
    public sealed class ConferenceDao : BaseDao
    {
		/// <summary>
        /// Searches for Conference
        /// </summary>
		/// <param name="item" />
        /// <returns>An IEnumerable set of Conference</returns>
        public static IEnumerable<Conference> Search(SearchConference item)
        {
            List<SqlParameter> parameters
                = new List<SqlParameter>
					{
						new SqlParameter("@ConferenceId", item.ConferenceId),
                        new SqlParameter("@ActivityTypeId", item.ActivityType),
                        new SqlParameter("@Name", item.Name),
                        new SqlParameter("@BaseFee", item.BaseFee),
                        new SqlParameter("@Description", item.Description),
                        new SqlParameter("@StartDate", item.StartDate),
                        new SqlParameter("@EndDate", item.EndDate)
					};

            DataSet set = DataManager.ExecuteProcedure(ConferencePlusConnectionString, "Conference_Get", parameters);
            IEnumerable<DataRow> dataRows = set.GetRowsFromDataSet();
            return ConvertToEntityObject(dataRows);
        }

        /// <summary>
        /// Saves a Conference to the data store.
        /// </summary>
        /// <param name="item">The item to save</param>
        public static void Save(Conference item)
        {
			if (item.IsItemModified)
            {
                if (item.ConferenceId == null)
                {
                    item.ConferenceId = Insert(item);
                }
                else
                {
                    Update(item);
                }
            }
        }

        /// <summary>
        /// Inserts a new Conference
        /// </summary>
        /// <param name="item">The Conference item to insert</param>
        /// <returns>The id of the Conference item just inserted</returns>
        private static int Insert(Conference item)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@ActivityTypeId", item.ActivityType),
                        new SqlParameter("@Name", item.Name),
                        new SqlParameter("@BaseFee", item.BaseFee),
                        new SqlParameter("@Description", item.Description),
                        new SqlParameter("@StartDate", item.StartDate),
                        new SqlParameter("@EndDate", item.EndDate)
					};
            return Convert.ToInt32(DataManager.ExecuteScalarProcedure(ConferencePlusConnectionString, "Conference_Insert", parameters));
        }

        /// <summary>
        /// Updates a Conference
        /// </summary>
        /// <param name="item">The Conference item to save</param>
        private static void Update(Conference item)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@ConferenceId", item.ConferenceId),
                        new SqlParameter("@ActivityTypeId", item.ActivityType),
                        new SqlParameter("@Name", item.Name),
                        new SqlParameter("@BaseFee", item.BaseFee),
                        new SqlParameter("@Description", item.Description),
                        new SqlParameter("@StartDate", item.StartDate),
                        new SqlParameter("@EndDate", item.EndDate)
					};
            DataManager.ExecuteProcedure(ConferencePlusConnectionString, "Conference_Update", parameters);
        }

        /// <summary>
        /// Does a physical delete of a(n) Conference
        /// </summary>
        /// <param name="conferenceId" />
        public static void Delete(int conferenceId)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@ConferenceId", conferenceId)
					};
            DataManager.ExecuteProcedure(ConferencePlusConnectionString, "Conference_Delete", parameters);
        }

        /// <summary>
        /// Converts an IEnumerable set of DataRows to an IEnumerable of Conference
        /// </summary>
        /// <param name="dataRows" />
        /// <returns />
        private static IEnumerable<Conference> ConvertToEntityObject(IEnumerable<DataRow> dataRows)
        {
            return dataRows.Select(row => new Conference
				{
                    ConferenceId = row.GetValue<int>("ConferenceId"),
                    ActivityType = row.GetValue<EnumActivityType>("ActivityTypeId"),
                    Name = row.GetValue<string>("Name").TrimSafely(),
                    BaseFee = row.GetValue<decimal>("BaseFee"),
                    Description = row.GetValue<string>("Description").TrimSafely(),
                    StartDate = row.GetValue<DateTime>("StartDate"),
                    EndDate = row.GetValue<DateTime>("EndDate")  
				});
        }
    }
}
