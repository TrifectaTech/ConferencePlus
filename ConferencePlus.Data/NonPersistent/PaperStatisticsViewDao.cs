// --------------------------------
// <copyright file="PaperStatisticsViewDao.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  PaperStatisticsView Data Layer Object.   
// </summary>
// ---------------------------------

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
    /// This class connects to the PaperStatisticsView Table
    /// </summary>
    public sealed class PaperStatisticsViewDao : BaseDao
    {
		/// <summary>
        /// Searches for PaperStatisticsView
        /// </summary>
		/// <param name="item" />
        /// <returns>An IEnumerable set of PaperStatisticsView</returns>
        public static IEnumerable<PaperStatisticsView> Search(SearchPaperStatisticsView item)
        {
            List<SqlParameter> parameters
                = new List<SqlParameter>
					{
                        new SqlParameter("@ConferenceId", item.ConferenceId),
                        new SqlParameter("@Name", item.Name),
                        new SqlParameter("@PaperCategoryId", (int?)item.PaperCategory),
                        new SqlParameter("@PaperCategoryDescription", item.PaperCategoryDescription),
                        new SqlParameter("@PaperCategoryCount", item.PaperCategoryCount)
					};

            DataSet set = DataManager.ExecuteProcedure(ConferencePlusConnectionString, "PCP_GetVCP_PaperStatistics", parameters);
            IEnumerable<DataRow> dataRows = set.GetRowsFromDataSet();
            return ConvertToEntityObject(dataRows);
        }

        /// <summary>
        /// Converts an IEnumerable set of DataRows to an IEnumerable of PaperStatisticsView
        /// </summary>
        /// <param name="dataRows" />
        /// <returns />
        private static IEnumerable<PaperStatisticsView> ConvertToEntityObject(IEnumerable<DataRow> dataRows)
        {
	        return dataRows.Select(row => new PaperStatisticsView
	        {
		        ConferenceId = row.GetValue<int>("ConferenceId"),
		        Name = row.GetValue<string>("Name").TrimSafely(),
		        PaperCategory = row.GetValue<EnumPaperCategory>("PaperCategoryId"),
		        PaperCategoryDescription = row.GetValue<string>("PaperCategoryDescription").TrimSafely(),
		        PaperCategoryCount = row.GetValue<int?>("PaperCategoryCount")
	        });
        }
    }
}
