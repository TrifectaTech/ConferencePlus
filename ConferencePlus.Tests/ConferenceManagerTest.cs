// --------------------------------
// <copyright file="ConferenceManagerTest.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  Conference Test Layer Object.   
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
    ///This is a test class for ConferenceManagerTest and is intended
    ///to contain all ConferenceManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class ConferenceManagerTest
    {
        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod]
        public void ConferenceLoadTest()
        {
			// TODO - Initiate keys
            const int conferenceId = 0; 

            Conference entity = ConferenceManager.Load(conferenceId);
            Assert.IsNotNull(entity, "Conference object was null");
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod]
        public void ConferenceSaveTest()
        {
			// TODO - Initiate keys
			const int conferenceId = 0; 

            Conference entity = ConferenceManager.Load(conferenceId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = ConferenceManager.Save(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with Conference object");
            Assert.AreEqual(expected, actual, "Save wasn't successful");
        }

        /// <summary>
        ///A test for Validate
        ///</summary>
        [TestMethod]
        public void ConferenceValidateTest()
        {
			// TODO - Initiate keys
			const int conferenceId = 0; 

            Conference entity = ConferenceManager.Load(conferenceId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = ConferenceManager.Validate(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with Conference object");
            Assert.AreEqual(expected, actual, "Conference object was invalid");
        }
    }
}