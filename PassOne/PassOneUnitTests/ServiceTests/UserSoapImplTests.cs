using System;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PassOne.Domain;
using PassOne.Service;

namespace PassOneUnitTests.ServiceTests
{
    [TestClass]
    public class UserSoapImplTests : PassOneTests
    {
        private readonly ISerializeSvc _userSvc;

        public UserSoapImplTests()
        {
            _userSvc = Factory.GetService(Services.UserSoapSerializer, Path) as ISerializeSvc;
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
        public void TestStoreUser()
        {
            _userSvc.UpdateTable(TestUser);
            Assert.AreEqual(TestUser, _userSvc.RetreiveById(TestUser.Id));
        }

        [TestMethod]
        public void TestStoreMultipleUsers()
        {
            _userSvc.UpdateTable(TestUser);
            _userSvc.UpdateTable(TestUser2);
            Assert.AreEqual(TestUser2, _userSvc.RetreiveById(TestUser2.Id));
        }

        [TestMethod]
        public void TestUpdateUser()
        {
            _userSvc.UpdateTable(TestUser);
            TestUser.Password = TestUser2.Password;
            _userSvc.UpdateTable(TestUser);
            Assert.AreEqual(TestUser2.Password, ((User)_userSvc.RetreiveById(TestUser.Id)).Password);
        }
    }
}
