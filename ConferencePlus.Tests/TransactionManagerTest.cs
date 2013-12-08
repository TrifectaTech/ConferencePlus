// --------------------------------
// <copyright file="TransactionManagerTest.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  Transaction Test Layer Object.   
// </summary>
// ---------------------------------

using System;
using System.Linq;
using ConferencePlus.Business;
using ConferencePlus.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConferencePlus.Tests
{
    /// <summary>
    ///This is a test class for TransactionManagerTest and is intended
    ///to contain all TransactionManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class TransactionManagerTest
    {
        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod]
        public void TransactionLoadTest()
        {
			// TODO - Initiate keys
            const int transactionId = 0; 

            Transaction entity = TransactionManager.Load(transactionId);
            Assert.IsNotNull(entity, "Transaction object was null");
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod]
        public void TransactionSaveTest()
        {
			// TODO - Initiate keys
			const int transactionId = 0; 

            Transaction entity = TransactionManager.Load(transactionId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = TransactionManager.Save(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with Transaction object");
            Assert.AreEqual(expected, actual, "Save wasn't successful");
        }

        /// <summary>
        ///A test for Validate
        ///</summary>
        [TestMethod]
        public void TransactionValidateTest()
        {
			// TODO - Initiate keys
			const int transactionId = 0; 

            Transaction entity = TransactionManager.Load(transactionId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = TransactionManager.Validate(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with Transaction object");
            Assert.AreEqual(expected, actual, "Transaction object was invalid");
        }
    }
}