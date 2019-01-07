using LandmarkRemark.Application.Users.Commands.CreateUser;
using LandmarkRemark.Business.Users.Commands.CreateUser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LandmarkRemark.Test.Users
{
    [TestClass]
    public class CreateUser_NegativeTest
    {
        private Mock<ICreateUserCommand> _createUserCommand;
        private CreateUserModel createUserModel;
        private ICreateUser _createUser;

        [TestInitialize]
        public void TestInitialize()
        {
            createUserModel = new CreateUserModel()
            {
                FirstName = "User",
                LastName = "Name",
                UserName = "UserName",
                IsActive = true,
                CreationDate = DateTime.Now.Date,
                Email = "UserName@gmail.com",
                Password = "Abcd1234"
            };
            _createUserCommand = new Mock<ICreateUserCommand>();
            _createUser = new CreateUser(_createUserCommand.Object);
        }

        [TestMethod]
        public void CreateUser_WithoutFirstName_NeverCalls_CreateUserCommand()
        {
            createUserModel.FirstName = string.Empty;

            Task<int> result = _createUser.Execute(createUserModel);

            _createUserCommand.Verify(v => v.Execute(createUserModel), Times.Never);
        }

        [TestMethod]
        public void CreateUser_WithoutLastName_NeverCalls_CreateUserCommand()
        {
            createUserModel.LastName = string.Empty;

            Task<int> result = _createUser.Execute(createUserModel);

            _createUserCommand.Verify(v => v.Execute(createUserModel), Times.Never);
        }

        [TestMethod]
        public void CreateUser_WithoutUserName_NeverCalls_CreateUserCommand()
        {
            createUserModel.UserName = string.Empty;

            Task<int> result = _createUser.Execute(createUserModel);

            _createUserCommand.Verify(v => v.Execute(createUserModel), Times.Never);
        }

        [TestMethod]
        public void CreateUser_WithoutEmail_NeverCalls_CreateUserCommand()
        {
            createUserModel.Email = string.Empty;

            Task<int> result = _createUser.Execute(createUserModel);

            _createUserCommand.Verify(v => v.Execute(createUserModel), Times.Never);
        }

        [TestMethod]
        public void CreateUser_WithoutPassword_NeverCalls_CreateUserCommand()
        {
            createUserModel.Password = string.Empty;

            Task<int> result = _createUser.Execute(createUserModel);

            _createUserCommand.Verify(v => v.Execute(createUserModel), Times.Never);
        }
    }
}
