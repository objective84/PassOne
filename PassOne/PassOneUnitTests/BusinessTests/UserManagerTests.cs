using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using PassOne.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PassOne.Domain;
using PassOne.Service;

namespace PassOneUnitTests.BusinessTests
{


    /// <summary>
    ///This is a test class for UserManagerTest and is intended
    ///to contain all UserManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserManagerTests : PassOneTests
    {
        public SoapFormatter Soap = new SoapFormatter();
        public FileStream Stream;
        private TestContext _testContextInstance;
        private UserManager _manager = new UserManager();

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return _testContextInstance; }
            set { _testContextInstance = value; }
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

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _manager = new UserManager();
            if (!Directory.Exists(Path + "data"))
                Directory.CreateDirectory(Path + "data");
            Stream = new FileStream(Path + "data\\users.bin", FileMode.Create, FileAccess.ReadWrite);
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            Stream.Close();
            Directory.Delete(Path, true);
        }

        #endregion


        /// <summary>
        ///A test for Authenticate
        ///</summary>
        [TestMethod()]
        public void AuthenticateTest()
        {
            var table = new Hashtable() {{TestUser2.Id, TestUser2}};
            Soap.Serialize(Stream, table);

            var username = TestUser2.Username;
            var password = TestUser2.Password;
            var expected = TestUser2;
            User actual;
            actual = _manager.Authenticate(username, password, Path);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CreateUser
        ///</summary>
        [TestMethod()]
        public void CreateTest()
        {
            Stream.Close();
            User user = TestUser;
            _manager.CreateUser(user, Path);

            Stream = new FileStream(Path + "data\\users.bin", FileMode.Open, FileAccess.Read);

            var table = Soap.Deserialize(Stream) as Hashtable;
            Assert.AreEqual(user, table[user.Id]);
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            var table = new Hashtable() {{TestUser.Id, TestUser}};
            Soap.Serialize(Stream, table);
            Stream.Close();
            var user = TestUser;
            user.FirstName = "Arwen";
            _manager.UpdateUser(user, Path);
            string expected = "Arwen";

            Stream = new FileStream(Path + "data\\users.bin", FileMode.Open, FileAccess.Read);

            table = Soap.Deserialize(Stream) as Hashtable;
            string actual = ((User) table[TestUser.Id]).FirstName;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetCredentialsList
        ///</summary>
        [TestMethod()]
        public void GetCredentialsListTest()
        {
            Stream.Close();
            User user = TestUser;
            Credentials testCreds1, testCreds2;
            testCreds1 = TestCredentials.Copy();
            testCreds2 = TestCredentials2.Copy();

            IDictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(testCreds1.Website, testCreds1.Id);
            expected.Add(testCreds2.Website, testCreds2.Id);

            user.CredentialsList.Add(testCreds1.Website, testCreds1.Id);
            user.CredentialsList.Add(testCreds2.Website, testCreds2.Id);

            testCreds1.Encrypt(user.Encryption);
            testCreds2.Encrypt(user.Encryption);
            var credStream = new FileStream(Path + "data\\data.bin", FileMode.Create, FileAccess.Write);
            var table = new Hashtable() { { testCreds1.Id, testCreds1 }, { testCreds2.Id, testCreds2 } };
            Soap.Serialize(credStream, table);
            credStream.Close();


            Dictionary<string, int> actual;
            actual = _manager.GetCredentialsList(user, Path);
            Assert.AreEqual(expected[TestCredentials.Website], actual[TestCredentials.Website]);

        }
    }
}
