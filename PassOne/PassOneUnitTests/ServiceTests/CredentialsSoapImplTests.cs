using System;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PassOne.Domain;
using PassOne.Service;

namespace PassOneUnitTests.ServiceTests
{
    [TestClass]
    public class CredentialsSoapImplTests : PassOneTests
    {

        private readonly ISerializeSvc _credSrv;

        //Constructor
        public CredentialsSoapImplTests()
        {
            _credSrv = Factory.GetService(Services.CredentialsSoapSerializer, Path, TestUser) as ISerializeSvc;
        }

        //Setup and TearDown
        [TestInitialize]
        public void Init()
        {
        }

        [TestCleanup]
        public void Dispose()
        {
            Directory.Delete(Path, true);
        }

        /// <summary>
        /// Test to store a single set of credentials, should pass.
        /// </summary>
        [TestMethod]
        public void StoreCredentialsTest()
        {
            _credSrv.UpdateTable(TestCredentials);
            TestCredentials.Decrypt(TestUser.Encryption);
            Assert.AreEqual(TestCredentials, _credSrv.RetreiveById(1));
        }

        /// <summary>
        /// Test to store multiple credentials, should pass.
        /// </summary>
        [TestMethod]
        public void StoreMultipleCredentials()
        {
            _credSrv.UpdateTable(TestCredentials);
            _credSrv.UpdateTable(TestCredentials2);
            TestCredentials.Decrypt(TestUser.Encryption);
            TestCredentials2.Decrypt(TestUser.Encryption);
            Assert.AreEqual(TestCredentials, _credSrv.RetreiveById(1));
            Assert.AreEqual(TestCredentials2, _credSrv.RetreiveById(2));
        }

        /// <summary>
        /// Test updating a pre-existing credential set.
        /// </summary>
        [TestMethod]
        public void UpdateCredentialsTest()
        {
            _credSrv.UpdateTable(TestCredentials);
            TestCredentials.Password = TestCredentials2.Password;
            _credSrv.UpdateTable(TestCredentials);
            var creds = _credSrv.RetreiveById(1);
            Assert.AreEqual(TestCredentials2.Password, ((Credentials)creds).Password);
        }
    }
}
