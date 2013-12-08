using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ConferencePlus.Entities.Common;

namespace ConferencePlus.Entities.ExtensionMethods
{
    /// <summary>
    /// Extension Methods for DataSets, DataTables, and DataRows
    /// </summary>
    public static class DataMethods
    {
        #region DataSet Methods
        /// <summary>
        /// Returns all rows in a DataSet without the risk of a null exception.
        /// </summary>
        /// <param name="ds">DataSet to get all rows from.</param>
        /// <returns>Array of DataRows.</returns>
        public static IEnumerable<DataRow> GetRowsFromDataSet(this DataSet ds)
        {
            List<DataRow> rows = new List<DataRow>();

            if (ds.HasAtLeastOneRow())
            {
                rows.AddRange(from DataTable table in ds.Tables where table.Rows != null from DataRow row in table.Rows select row);
            }

            return rows.ToArray();
        }

        /// <summary>
        /// Returns the first row without the risk of a null exception.
        /// </summary>
        /// <param name="ds">DataSet to get first row from.</param>
        /// <returns>DataRow if available, otherwise null.</returns>
        public static DataRow GetFirstRowFromDataSet(this DataSet ds)
        {
            return GetRowsFromDataSet(ds).FirstOrDefault();
        }

        /// <summary>
        /// Determines whether the DataSet has at least one row
        /// </summary>
        /// <param name="ds">DataSet to determine whether has at least one row</param>
        /// <returns>True, if DataSet has at least one row</returns>
        public static bool HasAtLeastOneRow(this DataSet ds)
        {
            return ds != null &&
                   ds.Tables.Count > 0 &&
                   ds.Tables[0].HasAtLeastOneRow();
        }
        #endregion

        #region DataTable Methods
        /// <summary>
        /// Determines whether the DataTable has at least one row
        /// </summary>
        /// <param name="dt">DataTable to determine whether has at least one row</param>
        /// <returns>True, if DataTable has at least one row</returns>
        public static bool HasAtLeastOneRow(this DataTable dt)
        {
            return dt != null &&
                   dt.Rows != null &&
                   dt.Rows.Count > 0;
        }
        #endregion

        #region DataRow Methods
        /// <summary>
        /// Gets the value of DataRow field, if it is DBNull, return the default value of that
        /// </summary>
        /// <param name="row">DataRow from database</param>
        /// <param name="fieldName">The column name where the data is located</param>
        /// <param name="dontThrowException">If true, won't throw exception if table doesn't contain column</param>
        /// <returns>Field Name of table column</returns>
        public static T GetValue<T>(this DataRow row, string fieldName, bool dontThrowException = false)
        {
            if (!row.Table.Columns.Contains(fieldName))
            {
                //Don't Throw Exception was specified
                //Returning default value
                if (dontThrowException)
                {
                    return default(T);
                }

                throw new Exception(string.Format("Invalid Mapping of Column for column {0}", fieldName));
            }

            if (DBNull.Value.Equals(row[fieldName]))
            {
                return default(T);
            }
            try
            {
                Type type = typeof(T);

                if (type == typeof(bool) || type == typeof(bool?))
                {
                    bool temp = Convert.ToBoolean(row[fieldName]);
                    T booleanValue = (T)(object)temp;
                    return booleanValue;
                }

                if (type == typeof(int) || type == typeof(int?) || type.BaseType == typeof(Enum))
                {
                    int temp = Convert.ToInt32(row[fieldName]);
                    T intValue = (T)(object)temp;
                    return intValue;
                }

                if (type == typeof(decimal) || type == typeof(decimal?))
                {
                    decimal temp = Convert.ToDecimal(row[fieldName]);
                    T decimalValue = (T)(object)temp;
                    return decimalValue;
                }

                //added case to deal solely with nullable enums since they make the iceweasel cower in fear. 
                Type typeOfNullable = Nullable.GetUnderlyingType(type);
                if (typeOfNullable != null && typeOfNullable.BaseType == typeof(Enum))
                {
                    T enumValue = default(T);
                    if (row[fieldName] != null)
                    {
                        int temp = Convert.ToInt32(row[fieldName]);
                        enumValue = EnumerationsHelper.ConvertFromInteger<T>(temp);
                    }
                    return enumValue;
                }

                T valu = (T)row[fieldName];
                return valu;
            }
            catch
            {
                throw new Exception(string.Format("Invalid Data for field {0}", fieldName));
            }
        }

        /// <summary>
        /// Gets the boolean value from the integer
        /// </summary>
        /// <param name="row" />
        /// <param name="fieldName" />
        /// <returns />
        public static bool? GetBooleanFromInt(this DataRow row, string fieldName)
        {
            bool? boolValue = null;

            int? value = row.GetValue<int?>(fieldName);
            if (value.HasValue)
            {
                boolValue = value.Value == 1;
            }

            return boolValue;
        }
        #endregion
    }
}
