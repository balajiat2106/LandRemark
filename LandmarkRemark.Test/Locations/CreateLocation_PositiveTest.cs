using LandmarkRemark.Application.Locations.Commands.CreateLocation;
using LandmarkRemark.Business.Locations.Commands.CreateLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace LandmarkRemark.Test.Locations
{
    [TestClass]
    public class CreateLocation_PositiveTest
    {
        private Mock<ICreateLocationCommand> _createLocationCommand;
        private CreateLocation _createLocation;
        private CreateLocationModel createLocationModel;
        int userId;

        [TestInitialize]
        public void TestInitialize()
        {
            userId = 1;
            createLocationModel = new CreateLocationModel()
            {
                Label = "Argentina",
                Latitude = 3.56D,
                Longitude = 7.76D,
                Remark = "Beautiful and charming"
            };

            _createLocationCommand = new Mock<ICreateLocationCommand>();
            _createLocation = new CreateLocation(_createLocationCommand.Object);
        }


        [TestMethod]
        public void CreateLocation_WithMandatoryParameters_Calls_CreateLocationCommand_Once()
        {            
            _createLocationCommand.Setup(s => s.Execute(userId, createLocationModel)).ReturnsAsync(1);

            Task<int> result = _createLocation.Execute(userId, createLocationModel);

            _createLocationCommand.Verify(v => v.Execute(userId, createLocationModel), Times.Once);
        }

        [TestMethod]
        public void CreateLocation_WithMandatoryParameters_Returns_One()
        {
            _createLocationCommand.Setup(s => s.Execute(userId, createLocationModel)).ReturnsAsync(1);

            Task<int> result = _createLocation.Execute(userId, createLocationModel);

            Assert.AreEqual(1, result.Result);
        }
    }
}
