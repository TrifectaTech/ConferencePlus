// --------------------------------
// <copyright file="PaperDao.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  Paper Data Layer Object.   
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
    /// This class connects to the Paper Table
    /// </summary>
    public sealed class PaperDao : BaseDao
    {
		/// <summary>
        /// Searches for Paper
        /// </summary>
		/// <param name="item" />
        /// <returns>An IEnumerable set of Paper</returns>
        public static IEnumerable<Paper> Search(SearchPaper item)
        {
            List<SqlParameter> parameters
                = new List<SqlParameter>
					{
						new SqlParameter("@PaperId", item.PaperId),
                        new SqlParameter("@UserId", item.UserId),
                        new SqlParameter("@PaperCategoryId", item.PaperCategory),
                        new SqlParameter("@Name", item.Name),
                        new SqlParameter("@Description", item.Description),
                        new SqlParameter("@Author", item.Author)
					};

            DataSet set = DataManager.ExecuteProcedure(ConferencePlusConnectionString, "Paper_Get", parameters);
            IEnumerable<DataRow> dataRows = set.GetRowsFromDataSet();
            return ConvertToEntityObject(dataRows);
        }

        /// <summary>
        /// Saves a Paper to the data store.
        /// </summary>
        /// <param name="item">The item to save</param>
        public static void Save(Paper item)
        {
			if (item.IsItemModified)
            {
                if (item.PaperId == null)
                {
                    item.PaperId = Insert(item);
                }
                else
                {
                    Update(item);
                }
            }
        }

        /// <summary>
        /// Inserts a new Paper
        /// </summary>
        /// <param name="item">The Paper item to insert</param>
        /// <returns>The id of the Paper item just inserted</returns>
        private static int Insert(Paper item)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@UserId", item.UserId),
                        new SqlParameter("@PaperCategoryId", item.PaperCategory),
                        new SqlParameter("@Name", item.Name),
                        new SqlParameter("@Description", item.Description),
                        new SqlParameter("@Author", item.Author)
					};
            return Convert.ToInt32(DataManager.ExecuteScalarProcedure(ConferencePlusConnectionString, "Paper_Insert", parameters));
        }

        /// <summary>
        /// Updates a Paper
        /// </summary>
        /// <param name="item">The Paper item to save</param>
        private static void Update(Paper item)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@PaperId", item.PaperId),
                        new SqlParameter("@UserId", item.UserId),
                        new SqlParameter("@PaperCategoryId", item.PaperCategory),
                        new SqlParameter("@Name", item.Name),
                        new SqlParameter("@Description", item.Description),
                        new SqlParameter("@Author", item.Author)
					};
            DataManager.ExecuteProcedure(ConferencePlusConnectionString, "Paper_Update", parameters);
        }

        /// <summary>
        /// Does a physical delete of a(n) Paper
        /// </summary>
        /// <param name="paperId" />
        public static void Delete(int paperId)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@PaperId", paperId)
					};
            DataManager.ExecuteProcedure(ConferencePlusConnectionString, "Paper_Delete", parameters);
        }

        /// <summary>
        /// Converts an IEnumerable set of DataRows to an IEnumerable of Paper
        /// </summary>
        /// <param name="dataRows" />
        /// <returns />
        private static IEnumerable<Paper> ConvertToEntityObject(IEnumerable<DataRow> dataRows)
        {
            return dataRows.Select(row => new Paper
				{
                    PaperId = row.GetValue<int>("PaperId"),
                    UserId = row.GetValue<Guid>("UserId"),
                    PaperCategory = row.GetValue<EnumPaperCategory>("PaperCategoryId"),
                    Name = row.GetValue<string>("Name").TrimSafely(),
                    Description = row.GetValue<string>("Description").TrimSafely(),
                    Author = row.GetValue<string>("Author").TrimSafely()  
				});
        }
    }
}
