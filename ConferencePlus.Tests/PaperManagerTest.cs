// --------------------------------
// <copyright file="PaperManagerTest.cs" company="Conference Plus">
//     © 2013 Conference Plus
// </copyright>
// <author>SQLEntityClassGenerator</author>
// <summary>
//  Paper Test Layer Object.   
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
    ///This is a test class for PaperManagerTest and is intended
    ///to contain all PaperManagerTest Unit Tests
    ///</summary>
    [TestClass]
    public class PaperManagerTest
    {
        /// <summary>
        ///A test for Load
        ///</summary>
        [TestMethod]
        public void PaperLoadTest()
        {
			// TODO - Initiate keys
            const int paperId = 0; 

            Paper entity = PaperManager.Load(paperId);
            Assert.IsNotNull(entity, "Paper object was null");
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod]
        public void PaperSaveTest()
        {
			// TODO - Initiate keys
			const int paperId = 0; 

            Paper entity = PaperManager.Load(paperId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = PaperManager.Save(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with Paper object");
            Assert.AreEqual(expected, actual, "Save wasn't successful");
        }

        /// <summary>
        ///A test for Validate
        ///</summary>
        [TestMethod]
        public void PaperValidateTest()
        {
			// TODO - Initiate keys
			const int paperId = 0; 

            Paper entity = PaperManager.Load(paperId);
            string errorMessage;
            string errorMessageExpected = string.Empty;
            const bool expected = true;
            bool actual = PaperManager.Validate(entity, out errorMessage);
            Assert.AreEqual(errorMessageExpected, errorMessage, "Some errors were found with Paper object");
            Assert.AreEqual(expected, actual, "Paper object was invalid");
        }
    }
}