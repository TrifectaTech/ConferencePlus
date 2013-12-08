// --------------------------------
// <copyright file="PaymentInfoDao.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  PaymentInfo Data Layer Object.   
// </summary>
// ---------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ConferencePlus.Data.Common;
using ConferencePlus.Entities.ExtensionMethods;
using ConferencePlus.Entities;

namespace ConferencePlus.Data
{
    /// <summary>
    /// This class connects to the PaymentInfo Table
    /// </summary>
    public sealed class PaymentInfoDao : BaseDao
    {
		/// <summary>
        /// Searches for PaymentInfo
        /// </summary>
		/// <param name="item" />
        /// <returns>An IEnumerable set of PaymentInfo</returns>
        public static IEnumerable<PaymentInfo> Search(SearchPaymentInfo item)
        {
            List<SqlParameter> parameters
                = new List<SqlParameter>
					{
						new SqlParameter("@PaymentInfoId", item.PaymentInfoId),
                        new SqlParameter("@UserId", item.UserId),
                        new SqlParameter("@CreditCardNumber", item.CreditCardNumber),
                        new SqlParameter("@CreditCardTypeId", item.CreditCardType),
                        new SqlParameter("@ExpirationDate", item.ExpirationDate),
                        new SqlParameter("@CCV", item.CCV),
                        new SqlParameter("@BillingAddress", item.BillingAddress),
                        new SqlParameter("@BillingCity", item.BillingCity),
                        new SqlParameter("@BillingState", item.BillingState),
                        new SqlParameter("@BillingZip", item.BillingZip)
					};

            DataSet set = DataManager.ExecuteProcedure(ConferencePlusConnectionString, "PaymentInfo_Get", parameters);
            IEnumerable<DataRow> dataRows = set.GetRowsFromDataSet();
            return ConvertToEntityObject(dataRows);
        }

        /// <summary>
        /// Saves a PaymentInfo to the data store.
        /// </summary>
        /// <param name="item">The item to save</param>
        public static void Save(PaymentInfo item)
        {
			if (item.IsItemModified)
            {
                if (item.PaymentInfoId == null)
                {
                    item.PaymentInfoId = Insert(item);
                }
                else
                {
                    Update(item);
                }
            }
        }

        /// <summary>
        /// Inserts a new PaymentInfo
        /// </summary>
        /// <param name="item">The PaymentInfo item to insert</param>
        /// <returns>The id of the PaymentInfo item just inserted</returns>
        private static int Insert(PaymentInfo item)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@UserId", item.UserId),
                        new SqlParameter("@CreditCardNumber", item.CreditCardNumber),
                        new SqlParameter("@CreditCardTypeId", item.CreditCardType),
                        new SqlParameter("@ExpirationDate", item.ExpirationDate),
                        new SqlParameter("@CCV", item.CCV),
                        new SqlParameter("@BillingAddress", item.BillingAddress),
                        new SqlParameter("@BillingCity", item.BillingCity),
                        new SqlParameter("@BillingState", item.BillingState),
                        new SqlParameter("@BillingZip", item.BillingZip)
					};
            return Convert.ToInt32(DataManager.ExecuteScalarProcedure(ConferencePlusConnectionString, "PaymentInfo_Insert", parameters));
        }

        /// <summary>
        /// Updates a PaymentInfo
        /// </summary>
        /// <param name="item">The PaymentInfo item to save</param>
        private static void Update(PaymentInfo item)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@PaymentInfoId", item.PaymentInfoId),
                        new SqlParameter("@UserId", item.UserId),
                        new SqlParameter("@CreditCardNumber", item.CreditCardNumber),
                        new SqlParameter("@CreditCardTypeId", item.CreditCardType),
                        new SqlParameter("@ExpirationDate", item.ExpirationDate),
                        new SqlParameter("@CCV", item.CCV),
                        new SqlParameter("@BillingAddress", item.BillingAddress),
                        new SqlParameter("@BillingCity", item.BillingCity),
                        new SqlParameter("@BillingState", item.BillingState),
                        new SqlParameter("@BillingZip", item.BillingZip)
					};
            DataManager.ExecuteProcedure(ConferencePlusConnectionString, "PaymentInfo_Update", parameters);
        }

        /// <summary>
        /// Does a physical delete of a(n) PaymentInfo
        /// </summary>
        /// <param name="paymentInfoId" />
        public static void Delete(int paymentInfoId)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@PaymentInfoId", paymentInfoId)
					};
            DataManager.ExecuteProcedure(ConferencePlusConnectionString, "PaymentInfo_Delete", parameters);
        }

        /// <summary>
        /// Converts an IEnumerable set of DataRows to an IEnumerable of PaymentInfo
        /// </summary>
        /// <param name="dataRows" />
        /// <returns />
        private static IEnumerable<PaymentInfo> ConvertToEntityObject(IEnumerable<DataRow> dataRows)
        {
            return dataRows.Select(row => new PaymentInfo
				{
                    PaymentInfoId = row.GetValue<int>("PaymentInfoId"),
                    UserId = row.GetValue<Guid>("UserId"),
                    CreditCardNumber = row.GetValue<string>("CreditCardNumber").TrimSafely(),
                    CreditCardType = row.GetValue<int>("CreditCardTypeId"),
                    ExpirationDate = row.GetValue<DateTime>("ExpirationDate"),
                    CCV = row.GetValue<int>("CCV"),
                    BillingAddress = row.GetValue<string>("BillingAddress").TrimSafely(),
                    BillingCity = row.GetValue<string>("BillingCity").TrimSafely(),
                    BillingState = row.GetValue<string>("BillingState").TrimSafely(),
                    BillingZip = row.GetValue<string>("BillingZip").TrimSafely()  
				});
        }
    }
}
