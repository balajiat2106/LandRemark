using LandmarkRemark.Application.Locations.Commands.CreateLocation;
using LandmarkRemark.Business.Locations.Commands.CreateLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace LandmarkRemark.Test.Locations
{
    [TestClass]
    public class CreateLocation_NegativeTest
    {
        private Mock<ICreateLocationCommand> _createLocationCommand;
        private ICreateLocation _createLocation;
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
        public void CreateLocation_WithoutLabel_NeverCalls_CreateLocationCommand()
        {
            createLocationModel.Label = string.Empty;

            Task<int> result = _createLocation.Execute(userId, createLocationModel);

            _createLocationCommand.Verify(v => v.Execute(userId, createLocationModel), Times.Never);
        }        

        [TestMethod]
        public void CreateLocation_WithoutRemark_NeverCalls_CreateLocationCommand()
        {            
            createLocationModel.Remark = string.Empty;

            Task<int> result = _createLocation.Execute(userId, createLocationModel);

            _createLocationCommand.Verify(v => v.Execute(userId, createLocationModel), Times.Never);
        }
    }
}
