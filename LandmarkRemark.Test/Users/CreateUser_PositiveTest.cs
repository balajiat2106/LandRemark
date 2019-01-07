using LandmarkRemark.Application.Users.Commands.CreateUser;
using LandmarkRemark.Business.Users.Commands.CreateUser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace LandmarkRemark.Test.Users
{
    [TestClass]
    public class CreateUser_PositiveTest
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
                CreationDate = System.DateTime.Now.Date,
                Email="UserName@gmail.com",
                Password="Abcd1234"
            };
            _createUserCommand = new Mock<ICreateUserCommand>();
            _createUser = new CreateUser(_createUserCommand.Object);
        }

        [TestMethod]
        public void CreateUser_WithMandatoryParameters_Calls_CreateUserCommand_Once()
        {
            _createUserCommand.Setup(s => s.Execute(createUserModel)).ReturnsAsync(1);

            Task<int> result = _createUser.Execute(createUserModel);

            _createUserCommand.Verify(v => v.Execute(createUserModel), Times.Once);
        }

        [TestMethod]
        public void CreateUser_WithMandatoryParameters_Returns_1()
        {
            _createUserCommand.Setup(s => s.Execute(createUserModel)).ReturnsAsync(1);

            var result = _createUser.Execute(createUserModel);

            Assert.AreEqual(result.Result, 1);
        }
    }
}
