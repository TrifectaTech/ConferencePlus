// --------------------------------
// <copyright file="PaymentInfoManagerTest.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  PaymentInfo Test Layer Object.   
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
    ///This is a test class for PaymentInfoManagerTest and is intended
    ///to contain all PaymentInfoManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class PaymentInfoManagerTest
    {
        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod]
        public void PaymentInfoLoadTest()
        {
			// TODO - Initiate keys
            const int paymentInfoId = 0; 

            PaymentInfo entity = PaymentInfoManager.Load(paymentInfoId);
            Assert.IsNotNull(entity, "PaymentInfo object was null");
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod]
        public void PaymentInfoSaveTest()
        {
			// TODO - Initiate keys
			const int paymentInfoId = 0; 

            PaymentInfo entity = PaymentInfoManager.Load(paymentInfoId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = PaymentInfoManager.Save(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with PaymentInfo object");
            Assert.AreEqual(expected, actual, "Save wasn't successful");
        }

        /// <summary>
        ///A test for Validate
        ///</summary>
        [TestMethod]
        public void PaymentInfoValidateTest()
        {
			// TODO - Initiate keys
			const int paymentInfoId = 0; 

            PaymentInfo entity = PaymentInfoManager.Load(paymentInfoId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = PaymentInfoManager.Validate(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with PaymentInfo object");
            Assert.AreEqual(expected, actual, "PaymentInfo object was invalid");
        }
    }
}