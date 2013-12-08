// --------------------------------
// <copyright file="ConferenceFeeManagerTest.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  ConferenceFee Test Layer Object.   
// </summary>
// ---------------------------------

using ConferencePlus.Business;
using ConferencePlus.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConferencePlus.Tests
{
    /// <summary>
    ///This is a test class for ConferenceFeeManagerTest and is intended
    ///to contain all ConferenceFeeManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class ConferenceFeeManagerTest
    {
        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod]
        public void ConferenceFeeLoadTest()
        {
			// TODO - Initiate keys
            const int conferenceFeeId = 0; 

            ConferenceFee entity = ConferenceFeeManager.Load(conferenceFeeId);
            Assert.IsNotNull(entity, "ConferenceFee object was null");
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod]
        public void ConferenceFeeSaveTest()
        {
			// TODO - Initiate keys
			const int conferenceFeeId = 0; 

            ConferenceFee entity = ConferenceFeeManager.Load(conferenceFeeId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = ConferenceFeeManager.Save(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with ConferenceFee object");
            Assert.AreEqual(expected, actual, "Save wasn't successful");
        }

        /// <summary>
        ///A test for Validate
        ///</summary>
        [TestMethod]
        public void ConferenceFeeValidateTest()
        {
			// TODO - Initiate keys
			const int conferenceFeeId = 0; 

            ConferenceFee entity = ConferenceFeeManager.Load(conferenceFeeId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = ConferenceFeeManager.Validate(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with ConferenceFee object");
            Assert.AreEqual(expected, actual, "ConferenceFee object was invalid");
        }
    }
}