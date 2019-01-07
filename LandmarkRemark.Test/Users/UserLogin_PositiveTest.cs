using LandmarkRemark.Application.Users.Queries.UserLogin;
using LandmarkRemark.Business.Users.Queries.UserLogin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace LandmarkRemark.Test.Users
{    
    [TestClass]
    public class UserLogin_PositiveTest
    {
        private Mock<IUserLoginQuery> _userLoginQuery;
        private IUserLogin _userLogin;

        [TestInitialize]
        public void TestInitialize()
        {
            _userLoginQuery = new Mock<IUserLoginQuery>();
            _userLogin = new UserLogin(_userLoginQuery.Object);
        }

        [TestMethod]
        public void UserLogin_Success()
        {
            string userName = "hjhj";

            _userLoginQuery.Setup(s => s.Execute(userName)).Returns(1);

            int result = _userLogin.Execute(userName);

            Assert.AreEqual(result, 1);
        }
    }
}
