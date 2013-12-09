// --------------------------------
// <copyright file="ConferenceEventsViewDao.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  ConferenceEventsView Data Layer Object.   
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
using ConferencePlus.Entities.NonPersistent;

namespace ConferencePlus.Data.NonPersistent
{
    /// <summary>
    /// This class connects to the ConferenceEventsView Table
    /// </summary>
    public sealed class ConferenceEventsViewDao : BaseDao
    {
		/// <summary>
        /// Searches for ConferenceEventsView
        /// </summary>
		/// <param name="item" />
        /// <returns>An IEnumerable set of ConferenceEventsView</returns>
        public static IEnumerable<ConferenceEventsView> Search(SearchConferenceEventsView item)
        {
            List<SqlParameter> parameters
                = new List<SqlParameter>
					{
                        new SqlParameter("@EventId", item.EventId),
                        new SqlParameter("@UserId", item.UserId),
                        new SqlParameter("@ConferenceId", item.ConferenceId),
                        new SqlParameter("@StartDate", item.StartDate),
                        new SqlParameter("@EndDate", item.EndDate),
                        new SqlParameter("@FoodPreferenceId", (int?)item.FoodPreference),
                        new SqlParameter("@PaperId", item.PaperId),
                        new SqlParameter("@Name", item.Name),
                        new SqlParameter("@Description", item.Description),
                        new SqlParameter("@PaperCategoryId", (int?)item.PaperCategory),
                        new SqlParameter("@Author", item.Author)
					};

            DataSet set = DataManager.ExecuteProcedure(ConferencePlusConnectionString, "PCP_GetVCP_ConferenceEvents", parameters);
            IEnumerable<DataRow> dataRows = set.GetRowsFromDataSet();
            return ConvertToEntityObject(dataRows);
        }

        /// <summary>
        /// Converts an IEnumerable set of DataRows to an IEnumerable of ConferenceEventsView
        /// </summary>
        /// <param name="dataRows" />
        /// <returns />
        private static IEnumerable<ConferenceEventsView> ConvertToEntityObject(IEnumerable<DataRow> dataRows)
        {
	        return dataRows.Select(row => new ConferenceEventsView
	        {
		        EventId = row.GetValue<int>("EventId"),
		        UserId = row.GetValue<Guid>("UserId"),
		        ConferenceId = row.GetValue<int>("ConferenceId"),
		        StartDate = row.GetValue<DateTime>("StartDate"),
		        EndDate = row.GetValue<DateTime>("EndDate"),
		        FoodPreference = row.GetValue<EnumFoodPreference>("FoodPreferenceId"),
		        PaperId = row.GetValue<int>("PaperId"),
		        Name = row.GetValue<string>("Name").TrimSafely(),
		        Description = row.GetValue<string>("Description").TrimSafely(),
		        PaperCategory = row.GetValue<EnumPaperCategory>("PaperCategoryId"),
		        Author = row.GetValue<string>("Author").TrimSafely()
	        });
        }
    }
}
