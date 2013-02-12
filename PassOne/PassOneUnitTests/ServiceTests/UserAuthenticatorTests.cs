using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PassOne.Domain;
using PassOne.Service;

namespace PassOneUnitTests.BusinessTests
{
    [TestClass]
    public class UserAuthenticatorTests : PassOneTests
    {
        private readonly IAuthenticatorSvc _authenticator;


        public UserAuthenticatorTests()
        {
            _authenticator = Factory.GetService(Services.UserAuthenticator, Path) as IAuthenticatorSvc;
            Directory.CreateDirectory(Path + "data");
            var soap = new SoapFormatter();
            var stream = new FileStream(Path + "\\data\\users.bin", FileMode.Create, FileAccess.Write);
            var table = new Hashtable {{TestUser.Id, TestUser}, {TestUser2.Id, TestUser2}};
            soap.Serialize(stream, table);
            stream.Close();
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
        [TestMethod]
        public void TestAuthenticateFail()
        {
            try
            {
                var test = _authenticator.Authenticate(TestUser.Username, TestUser2.Password);
                Assert.Fail();
            }
            catch (InvalidLoginException)
            {
                
            }

        }

        [TestMethod]
        public void TestAuthenticatePass()
        {
                var test = _authenticator.Authenticate(TestUser.Username, TestUser.Password);
                Assert.AreEqual(TestUser, test);
        }
    }
}
