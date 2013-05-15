using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Windows.Forms;
using PassOne.Business;
using PassOne.Presentation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PassOneUnitTests
{


    /// <summary>
    ///This is a test class for PassOneControllerTest and is intended
    ///to contain all PassOneControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PassOneControllerTests : PassOneTests
    {

        public SoapFormatter Soap = new SoapFormatter();
        public FileStream Stream;

        private static PassOneModel _model;
        private static PassOneView _view;
        private static PassOneController _controller;
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
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
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _model = new PassOneModel();
            _view = new PassOneView();
            _controller = new PassOneController();

            _model.View = _view;
            _view.Controller = _controller;
            _controller.Model = _model;
            _controller.ModelState = ModelStates.Login;
            _view.ConnectEventHandlers(_controller);
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
        }

        #endregion

        /// <summary>
        ///A test for DeleteEntry
        ///</summary>
        [TestMethod()]
        public void DeleteEntryTest()
        {
            PassOneController target = new PassOneController(); // TODO: Initialize to an appropriate value
            target.DeleteEntry();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Login
        ///</summary>
        [TestMethod()]
        public void LoginTest()
        {
            
        }

        /// <summary>
        ///A test for Logout
        ///</summary>
        [TestMethod()]
        public void LogoutTest()
        {
            
        }
    }
}
