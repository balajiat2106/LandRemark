using LandmarkRemark.Application.Locations.Queries.GetLocationList;
using LandmarkRemark.Business.Locations.Queries.GetLocationList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace LandmarkRemark.Test.Locations
{
    [TestClass]
    public class GetLocationListBasedOnUserId_PositiveTest
    {
        private Mock<IGetLocationListBasedOnUserIdQuery> _getLocationListBasedOnUserIdQuery;
        private IGetLocationListBasedOnUserId _getLocationListBasedOnUserId;
        private List<LocationListModel> locationListModel;
        int UserId;

        [TestInitialize]
        public void TestInitialize()
        {
            UserId = 1;
            locationListModel = new List<LocationListModel>();
            _getLocationListBasedOnUserIdQuery = new Mock<IGetLocationListBasedOnUserIdQuery>();
            _getLocationListBasedOnUserId = new GetLocationListBasedOnUserId(_getLocationListBasedOnUserIdQuery.Object);
        }

        [TestMethod]
        public void GetLocationBasedOnUserId_WithValidUserId_Calls_GetLocationListBasedOnUserIdQuery_Once()
        {
            var result = _getLocationListBasedOnUserId.Execute(1);

            _getLocationListBasedOnUserIdQuery.Verify(v => v.Execute(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetLocationBasedOnUserId_WithValidUserId_Returns_LocationListModelWithValidText()
        {
            _getLocationListBasedOnUserIdQuery.Setup(s => s.Execute(It.IsAny<int>())).ReturnsAsync(locationListModel);

            var result = _getLocationListBasedOnUserId.Execute(1);

            Assert.IsTrue(result.Result.All(w => w.UserId==UserId));
        }
    }
}
