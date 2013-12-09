// --------------------------------
// <copyright file="EventDao.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  Event Data Layer Object.   
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
    /// This class connects to the Event Table
    /// </summary>
    public sealed class EventDao : BaseDao
    {
		/// <summary>
        /// Searches for Event
        /// </summary>
		/// <param name="item" />
        /// <returns>An IEnumerable set of Event</returns>
        public static IEnumerable<Event> Search(SearchEvent item)
        {
            List<SqlParameter> parameters
                = new List<SqlParameter>
					{
						new SqlParameter("@EventId", item.EventId),
                        new SqlParameter("@ConferenceId", item.ConferenceId),
                        new SqlParameter("@PaperId", item.PaperId),
                        new SqlParameter("@FoodPreferenceId", item.FoodPreference),
                        new SqlParameter("@Comments", item.Comments),
                        new SqlParameter("@StartDate", item.StartDate),
                        new SqlParameter("@EndDate", item.EndDate)
					};

            DataSet set = DataManager.ExecuteProcedure(ConferencePlusConnectionString, "Event_Get", parameters);
            IEnumerable<DataRow> dataRows = set.GetRowsFromDataSet();
            return ConvertToEntityObject(dataRows);
        }

        /// <summary>
        /// Saves a Event to the data store.
        /// </summary>
        /// <param name="item">The item to save</param>
        public static void Save(Event item)
        {
			if (item.IsItemModified)
            {
                if (item.EventId == null)
                {
                    item.EventId = Insert(item);
                }
                else
                {
                    Update(item);
                }
            }
        }

        /// <summary>
        /// Inserts a new Event
        /// </summary>
        /// <param name="item">The Event item to insert</param>
        /// <returns>The id of the Event item just inserted</returns>
        private static int Insert(Event item)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@ConferenceId", item.ConferenceId),
                        new SqlParameter("@PaperId", item.PaperId),
                        new SqlParameter("@FoodPreferenceId", item.FoodPreference),
                        new SqlParameter("@Comments", item.Comments),
                        new SqlParameter("@StartDate", item.StartDate),
                        new SqlParameter("@EndDate", item.EndDate)
					};
            return Convert.ToInt32(DataManager.ExecuteScalarProcedure(ConferencePlusConnectionString, "Event_Insert", parameters));
        }

        /// <summary>
        /// Updates a Event
        /// </summary>
        /// <param name="item">The Event item to save</param>
        private static void Update(Event item)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@EventId", item.EventId),
                        new SqlParameter("@ConferenceId", item.ConferenceId),
                        new SqlParameter("@PaperId", item.PaperId),
                        new SqlParameter("@FoodPreferenceId", item.FoodPreference),
                        new SqlParameter("@Comments", item.Comments),
                        new SqlParameter("@StartDate", item.StartDate),
                        new SqlParameter("@EndDate", item.EndDate)
					};
            DataManager.ExecuteProcedure(ConferencePlusConnectionString, "Event_Update", parameters);
        }

        /// <summary>
        /// Does a physical delete of a(n) Event
        /// </summary>
        /// <param name="eventId" />
        public static void Delete(int eventId)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@EventId", eventId)
					};
            DataManager.ExecuteProcedure(ConferencePlusConnectionString, "Event_Delete", parameters);
        }

        /// <summary>
        /// Converts an IEnumerable set of DataRows to an IEnumerable of Event
        /// </summary>
        /// <param name="dataRows" />
        /// <returns />
        private static IEnumerable<Event> ConvertToEntityObject(IEnumerable<DataRow> dataRows)
        {
            return dataRows.Select(row => new Event
				{
                    EventId = row.GetValue<int>("EventId"),
                    ConferenceId = row.GetValue<int>("ConferenceId"),
                    PaperId = row.GetValue<int>("PaperId"),
                    FoodPreference = row.GetValue<EnumFoodPreference>("FoodPreferenceId"),
                    Comments = row.GetValue<string>("Comments").TrimSafely(),
                    StartDate = row.GetValue<DateTime>("StartDate"),
                    EndDate = row.GetValue<DateTime>("EndDate")  
				});
        }
    }
}
