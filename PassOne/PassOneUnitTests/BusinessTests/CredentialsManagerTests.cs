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
        public SoapFormatter Soap = new SoapFormatter();
        public FileStream Stream;
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
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
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
            Stream = new FileStream(Path + "data.bin", FileMode.Create, FileAccess.ReadWrite);
        }
        
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            Stream.Close();
            Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                    "//PassOne", true);
        }
        
        #endregion


        /// <summary>
        ///A test for CreateUser
        ///</summary>
        [TestMethod()]
        public void CreateTest()
        {
            Stream.Close();
            var user = TestUser; 
            var creds = TestCredentials;
            user.Create(TestCredentials);
            Stream = new FileStream(Path + "data.bin", FileMode.Open, FileAccess.Read);
            var table = Soap.Deserialize(Stream) as Hashtable;
            var expected = creds;
            var actual = table[TestCredentials.Id];
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            Credentials creds = TestCredentials.Copy();
            User user = TestUser;
            creds.Encrypt(user.Encryption);
            user.CredentialsList.Add(TestCredentials.Website, TestCredentials.Id);

            var table = new Hashtable() { { TestCredentials.Id, TestCredentials } };
            Soap.Serialize(Stream, table);
            Stream.Close();

            creds.Delete(user);
            Assert.AreEqual(0, user.CredentialsList.Count);

        }

        /// <summary>
        ///A test for Find
        ///</summary>
        [TestMethod()]
        public void FindTest()
        {
            User user = TestUser;
            int id = TestCredentials.Id;
            var expected = TestCredentials.Copy();
            expected.Encrypt(user.Encryption);
            var table = new Hashtable() { { expected.Id, expected } };
            Soap.Serialize(Stream, table);
            Stream.Close();
            expected.Decrypt(user.Encryption);

            Credentials actual = user.FindCredentials(id);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            User user = TestUser;
            Credentials creds = TestCredentials.Copy();
            var table = new Hashtable() { { creds.Id, creds } };
            Soap.Serialize(Stream, table);
            Stream.Close();
            creds.Username = TestCredentials2.Username;
            creds.Update(user);
            var expected = TestCredentials2.Username;

            Stream = new FileStream(Path + "data.bin", FileMode.Open, FileAccess.Read);
            table = Soap.Deserialize(Stream) as Hashtable;
            creds = ((Credentials) table[TestCredentials.Id]);
            creds.Decrypt(user.Encryption);
            var actual = creds.Username;
            
            Assert.AreEqual(expected, actual);
        }
    }
}
