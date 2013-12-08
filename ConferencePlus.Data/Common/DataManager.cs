using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace ConferencePlus.Data.Common
{
	/// <summary>
	/// DataManager
	/// </summary>
	public static class DataManager
	{
		/// <summary>
		/// Calls any stored procedure that performs a select/get operation.
		/// </summary>
		/// <param name="connectionString">Connection string to database.</param>
		/// <param name="procedureName">Stored procedure name.</param>
		/// <param name="parameters">Parameters in procedure.</param>
		/// <param name="timeOut">Timeout to use for connection.</param>
		/// <returns>Dataset containing results of stored procedure call.</returns>
		public static DataSet ExecuteProcedure(string connectionString, string procedureName, IEnumerable<SqlParameter> parameters, int timeOut)
		{
			DataSet dataSet = new DataSet { Locale = CultureInfo.CurrentCulture, EnforceConstraints = false };

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(procedureName, connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.CommandTimeout = timeOut;

					if (parameters != null)
					{
						foreach (SqlParameter parameter in parameters)
						{
							if (parameter.Value == null)
							{
								parameter.Value = DBNull.Value;
							}

							command.Parameters.Add(parameter);
						}
					}

					connection.Open();

					DataTable table = new DataTable { Locale = CultureInfo.CurrentCulture };

					using (SqlDataAdapter adapter = new SqlDataAdapter(command))
					{
						adapter.Fill(table);
					}

					dataSet.Tables.Add(table);
					connection.Close();
				}
			}

			return dataSet;
		}

		/// <summary>
		/// Calls any stored procedure that performs a select/get operation.
		/// </summary>
		/// <param name="connectionString">Connection string to database.</param>
		/// <param name="procedureName">Stored procedure name.</param>
		/// <param name="parameters">Parameters in procedure.</param>
		/// <returns>Dataset containing results of stored procedure call.</returns>
		public static DataSet ExecuteProcedure(string connectionString, string procedureName, IEnumerable<SqlParameter> parameters)
		{
			DataSet dataSet = new DataSet { Locale = CultureInfo.CurrentCulture, EnforceConstraints = false };

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(procedureName, connection))
				{
					command.CommandType = CommandType.StoredProcedure;

					if (parameters != null)
					{
						foreach (SqlParameter parameter in parameters)
						{
							if (parameter.Value == null)
							{
								parameter.Value = DBNull.Value;
							}

							command.Parameters.Add(parameter);
						}
					}

					connection.Open();

					DataTable table = new DataTable { Locale = CultureInfo.CurrentCulture };

					using (SqlDataAdapter adapter = new SqlDataAdapter(command))
					{
						adapter.Fill(table);
					}

					dataSet.Tables.Add(table);
					connection.Close();
				}
			}

			return dataSet;
		}

		/// <summary>
		/// Calls any stored procedure that performs a select/get operation.
		/// </summary>
		/// <param name="connectionString">Connection string to database.</param>
		/// <param name="procedureName">Stored procedure name.</param>
		/// <param name="timeOut">Timeout to use for connection.</param>
		/// <param name="parameters">Parameters in procedure.</param>
		/// <returns>Dataset containing results of stored procedure call.</returns>
		public static DataSet ExecuteProcedure(string connectionString, string procedureName,  int timeOut, params SqlParameter[] parameters)
		{
			return parameters == null
				       ? ExecuteProcedure(connectionString, procedureName, new List<SqlParameter>(), timeOut)
				       : ExecuteProcedure(connectionString, procedureName, parameters.ToList(), timeOut);
		}

		/// <summary>
		/// Calls any stored procedure that performs a select/get operation.
		/// </summary>
		/// <param name="connectionString">Connection string to database.</param>
		/// <param name="procedureName">Stored procedure name.</param>
		/// <param name="parameters">Parameters in procedure.</param>
		/// <returns>Dataset containing results of stored procedure call.</returns>
		public static DataSet ExecuteProcedure(string connectionString, string procedureName, params SqlParameter[] parameters)
		{
			return parameters == null
				       ? ExecuteProcedure(connectionString, procedureName, new List<SqlParameter>())
				       : ExecuteProcedure(connectionString, procedureName, parameters.ToList());
		}

		/// <summary>
		/// Calls any stored procedure that performs an insert, update or delete operation.
		/// </summary>
		/// <param name="connectionString">Connection string to database.</param>
		/// <param name="procedureName">Stored procedure name.</param>
		/// <param name="parameters">Parameters in procedure.</param>
		/// <returns>Returns the number of rows affected.</returns>
		public static int ExecuteNonQueryProcedure(string connectionString, string procedureName, IEnumerable<SqlParameter> parameters)
		{
			int results;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(procedureName, connection))
				{
					command.CommandType = CommandType.StoredProcedure;

					if (parameters != null)
					{
						foreach (SqlParameter parameter in parameters)
						{
							if (parameter.Value == null)
							{
								parameter.Value = DBNull.Value;
							}

							command.Parameters.Add(parameter);
						}
					}

					connection.Open();
					results = command.ExecuteNonQuery();
					connection.Close();
				}
			}

			return results;
		}

		/// <summary>
		/// Calls any stored procedure that performs an insert, update or delete operation.
		/// </summary>
		/// <param name="connectionString">Connection string to database.</param>
		/// <param name="procedureName">Stored procedure name.</param>
		/// <param name="parameters">Parameters in procedure.</param>
		/// <returns>The first column of the first row in the result set, or a null reference.</returns>
		public static object ExecuteScalarProcedure(string connectionString, string procedureName, IEnumerable<SqlParameter> parameters)
		{
			object result;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(procedureName, connection))
				{
					command.CommandType = CommandType.StoredProcedure;

					if (parameters != null)
					{
						foreach (SqlParameter parameter in parameters)
						{
							if (parameter.Value == null)
							{
								parameter.Value = DBNull.Value;
							}

							command.Parameters.Add(parameter);
						}
					}

					connection.Open();
					result = command.ExecuteScalar();
					connection.Close();
				}
			}

			return result;
		}

		/// <summary>
		/// Select a single value (ExecuteScalar call)
		/// input:  SprocName, parameters
		/// </summary>
		/// <param name="connectionString" />
		/// <param name="procedureName" />
		/// <param name="parameters" />
		/// <returns>string</returns>
		public static string GetResultString(string connectionString, string procedureName, IEnumerable<SqlParameter> parameters)
		{
			string result;
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				using (SqlCommand cmd = new SqlCommand(procedureName, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					if (parameters != null)
					{
						// Adds each parameter
						foreach (SqlParameter parameter in parameters)
						{
							if (parameter.Value == null)
							{
								parameter.Value = DBNull.Value;
							}

							cmd.Parameters.Add(parameter);
						}
					}

					conn.Open();
					result = cmd.ExecuteScalar().ToString();
					conn.Close();
				}
			}

			return result;
		}
	}
}
