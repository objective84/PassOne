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

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
            Stream = new FileStream(Path + "users.bin", FileMode.Create, FileAccess.ReadWrite);
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            Stream.Close();
            //Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
            //                 "//PassOne", true);
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
            actual = UserManager.Authenticate(username, password);
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
            UserManager.CreateUser(user);

            Stream = new FileStream(Path + "users.bin", FileMode.Open, FileAccess.Read);

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
            UserManager.UpdateUser(user);
            string expected = "Arwen";

            Stream = new FileStream(Path + "users.bin", FileMode.Open, FileAccess.Read);

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

            IList<string> expected = new List<string>() { testCreds1.Website, testCreds2.Website };

            user.CredentialsList.Add(testCreds1.Website, testCreds1.Id);
            user.CredentialsList.Add(testCreds1.Website, testCreds2.Id);

            testCreds1.Encrypt(user.Encryption);
            testCreds2.Encrypt(user.Encryption);
            var credStream = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                            "//PassOne//data//" + "data.bin", FileMode.Create, FileAccess.Write);
            var table = new Hashtable() { { testCreds1.Id, testCreds1 }, { testCreds2.Id, testCreds2 } };
            Soap.Serialize(credStream, table);
            credStream.Close();


            IList<string> actual;
            actual = UserManager.GetCredentialsList(user);
            Assert.AreEqual(expected[0], actual[0]);

        }
    }
}
