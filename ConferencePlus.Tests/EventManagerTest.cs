// --------------------------------
// <copyright file="EventManagerTest.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  Event Test Layer Object.   
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
    ///This is a test class for EventManagerTest and is intended
    ///to contain all EventManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class EventManagerTest
    {
        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod]
        public void EventLoadTest()
        {
			// TODO - Initiate keys
            const int eventId = 0; 

            Event entity = EventManager.Load(eventId);
            Assert.IsNotNull(entity, "Event object was null");
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod]
        public void EventSaveTest()
        {
			// TODO - Initiate keys
			const int eventId = 0; 

            Event entity = EventManager.Load(eventId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = EventManager.Save(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with Event object");
            Assert.AreEqual(expected, actual, "Save wasn't successful");
        }

        /// <summary>
        ///A test for Validate
        ///</summary>
        [TestMethod]
        public void EventValidateTest()
        {
			// TODO - Initiate keys
			const int eventId = 0; 

            Event entity = EventManager.Load(eventId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = EventManager.Validate(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with Event object");
            Assert.AreEqual(expected, actual, "Event object was invalid");
        }
    }
}