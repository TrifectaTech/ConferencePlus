using System;
using System.Configuration;

namespace ConferencePlus.Data.Common
{
	/// <summary>
	/// Base DAO
	/// </summary>
	[Serializable]
	public abstract class BaseDao
	{
		/// <summary>
		/// Connection String for KarzPlus database
		/// </summary>
		protected static string ConferencePlusConnectionString
		{
            get { return ConfigurationManager.ConnectionStrings["ConferencePlusConnectionString"].ConnectionString; }
		}
	}
}
