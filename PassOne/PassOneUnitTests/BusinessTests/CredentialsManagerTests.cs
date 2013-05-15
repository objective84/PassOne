using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using PassOne.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PassOne.Domain;

namespace PassOneUnitTests.BusinessTests
{
    /// <summary>
    ///This is a test class for CredentialsManagerTest and is intended
    ///to contain all CredentialsManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CredentialsManagerTests : PassOneTests
    {
        public TestContext TestContextInstance;
        private CredentialsManager _manager = new CredentialsManager();

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return TestContextInstance;
            }
            set
            {
                TestContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _manager = new CredentialsManager();

        }
        
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {

        }
        
        #endregion


        /// <summary>
        ///A test for CreateUser
        ///</summary>
        [TestMethod()]
        public void CreateTest()
        {
            
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {

        }

        /// <summary>
        ///A test for Find
        ///</summary>
        [TestMethod()]
        public void FindTest()
        {
            
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            
        }
    }
}
