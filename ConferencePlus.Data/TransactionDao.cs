// --------------------------------
// <copyright file="TransactionDao.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  Transaction Data Layer Object.   
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
    /// This class connects to the Transaction Table
    /// </summary>
    public sealed class TransactionDao : BaseDao
    {
		/// <summary>
        /// Searches for Transaction
        /// </summary>
		/// <param name="item" />
        /// <returns>An IEnumerable set of Transaction</returns>
        public static IEnumerable<Transaction> Search(SearchTransaction item)
        {
            List<SqlParameter> parameters
                = new List<SqlParameter>
					{
						new SqlParameter("@TransactionId", item.TransactionId),
						new SqlParameter("@EventId", item.EventId),
                        new SqlParameter("@UserId", item.UserId),
                        new SqlParameter("@FeeTypeId", item.FeeType),
                        new SqlParameter("@FeeAdjustmentId", item.FeeAdjustment),
                        new SqlParameter("@Fee", item.Fee),
                        new SqlParameter("@CreditCardNumber", item.CreditCardNumber),
                        new SqlParameter("@CreditCardTypeId", item.CreditCardType),
                        new SqlParameter("@ExpirationDate", item.ExpirationDate),
                        new SqlParameter("@CCV", item.CCV),
                        new SqlParameter("@BillingAddress", item.BillingAddress),
                        new SqlParameter("@BillingCity", item.BillingCity),
                        new SqlParameter("@BillingState", item.BillingState),
                        new SqlParameter("@BillingZip", item.BillingZip),
                        new SqlParameter("@TransactionDate", item.TransactionDate)
					};

            DataSet set = DataManager.ExecuteProcedure(ConferencePlusConnectionString, "Transaction_Get", parameters);
            IEnumerable<DataRow> dataRows = set.GetRowsFromDataSet();
            return ConvertToEntityObject(dataRows);
        }

        /// <summary>
        /// Saves a Transaction to the data store.
        /// </summary>
        /// <param name="item">The item to save</param>
        public static void Save(Transaction item)
        {
			if (item.IsItemModified)
            {
                if (item.TransactionId == null)
                {
                    item.TransactionId = Insert(item);
                }
                else
                {
                    Update(item);
                }
            }
        }

        /// <summary>
        /// Inserts a new Transaction
        /// </summary>
        /// <param name="item">The Transaction item to insert</param>
        /// <returns>The id of the Transaction item just inserted</returns>
        private static int Insert(Transaction item)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@EventId", item.EventId),						
						new SqlParameter("@UserId", item.UserId),
                        new SqlParameter("@FeeTypeId", item.FeeType),
                        new SqlParameter("@FeeAdjustmentId", item.FeeAdjustment),
                        new SqlParameter("@Fee", item.Fee),
                        new SqlParameter("@CreditCardNumber", item.CreditCardNumber),
                        new SqlParameter("@CreditCardTypeId", item.CreditCardType),
                        new SqlParameter("@ExpirationDate", item.ExpirationDate),
                        new SqlParameter("@CCV", item.CCV),
                        new SqlParameter("@BillingAddress", item.BillingAddress),
                        new SqlParameter("@BillingCity", item.BillingCity),
                        new SqlParameter("@BillingState", item.BillingState),
                        new SqlParameter("@BillingZip", item.BillingZip),
                        new SqlParameter("@TransactionDate", item.TransactionDate)
					};
            return Convert.ToInt32(DataManager.ExecuteScalarProcedure(ConferencePlusConnectionString, "Transaction_Insert", parameters));
        }

        /// <summary>
        /// Updates a Transaction
        /// </summary>
        /// <param name="item">The Transaction item to save</param>
        private static void Update(Transaction item)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@TransactionId", item.TransactionId),
						new SqlParameter("@EventId", item.EventId),
                        new SqlParameter("@UserId", item.UserId),
                        new SqlParameter("@FeeTypeId", item.FeeType),
                        new SqlParameter("@FeeAdjustmentId", item.FeeAdjustment),
                        new SqlParameter("@Fee", item.Fee),
                        new SqlParameter("@CreditCardNumber", item.CreditCardNumber),
                        new SqlParameter("@CreditCardTypeId", item.CreditCardType),
                        new SqlParameter("@ExpirationDate", item.ExpirationDate),
                        new SqlParameter("@CCV", item.CCV),
                        new SqlParameter("@BillingAddress", item.BillingAddress),
                        new SqlParameter("@BillingCity", item.BillingCity),
                        new SqlParameter("@BillingState", item.BillingState),
                        new SqlParameter("@BillingZip", item.BillingZip),
                        new SqlParameter("@TransactionDate", item.TransactionDate)
					};
            DataManager.ExecuteProcedure(ConferencePlusConnectionString, "Transaction_Update", parameters);
        }

        /// <summary>
        /// Does a physical delete of a(n) Transaction
        /// </summary>
        /// <param name="transactionId" />
        public static void Delete(int transactionId)
        {
            List<SqlParameter> parameters 
				= new List<SqlParameter>
					{
						new SqlParameter("@TransactionId", transactionId)
					};
            DataManager.ExecuteProcedure(ConferencePlusConnectionString, "Transaction_Delete", parameters);
        }

        /// <summary>
        /// Converts an IEnumerable set of DataRows to an IEnumerable of Transaction
        /// </summary>
        /// <param name="dataRows" />
        /// <returns />
        private static IEnumerable<Transaction> ConvertToEntityObject(IEnumerable<DataRow> dataRows)
        {
            return dataRows.Select(row => new Transaction
				{
                    TransactionId = row.GetValue<int>("TransactionId"),
					EventId = row.GetValue<int>("EventId"),
                    UserId = row.GetValue<Guid>("UserId"),
                    FeeType = row.GetValue<EnumFeeType>("FeeTypeId"),
                    FeeAdjustment = row.GetValue<EnumFeeAdjustment>("FeeAdjustmentId"),
                    Fee = row.GetValue<decimal>("Fee"),
                    CreditCardNumber = row.GetValue<string>("CreditCardNumber").TrimSafely(),
                    CreditCardType = row.GetValue<EnumCreditCardType>("CreditCardTypeId"),
                    ExpirationDate = row.GetValue<DateTime>("ExpirationDate"),
                    CCV = row.GetValue<int>("CCV"),
                    BillingAddress = row.GetValue<string>("BillingAddress").TrimSafely(),
                    BillingCity = row.GetValue<string>("BillingCity").TrimSafely(),
                    BillingState = row.GetValue<string>("BillingState").TrimSafely(),
                    BillingZip = row.GetValue<string>("BillingZip").TrimSafely(),
                    TransactionDate = row.GetValue<DateTime>("TransactionDate")  
				});
        }
    }
}
