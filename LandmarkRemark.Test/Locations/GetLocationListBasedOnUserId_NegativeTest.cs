using LandmarkRemark.Application.Locations.Queries.GetLocationList;
using LandmarkRemark.Business.Locations.Queries.GetLocationList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace LandmarkRemark.Test.Locations
{
    [TestClass]
    public class GetLocationListBasedOnUserId_NegativeTest
    {
        private Mock<IGetLocationListBasedOnUserIdQuery> _getLocationListBasedOnUserIdQuery;
        private IGetLocationListBasedOnUserId _getLocationListBasedOnUserId;
        private List<LocationListModel> locationListModel;
        int UserId;

        [TestInitialize]
        public void TestInitialize()
        {
            UserId = -1;
            locationListModel = new List<LocationListModel>();
            _getLocationListBasedOnUserIdQuery = new Mock<IGetLocationListBasedOnUserIdQuery>();
            _getLocationListBasedOnUserId = new GetLocationListBasedOnUserId(_getLocationListBasedOnUserIdQuery.Object);
        }

        [TestMethod]
        public void GetLocationBasedOnUserId_WithInvalidUserId_Returns_ZeroRecords()
        {
            _getLocationListBasedOnUserIdQuery.Setup(s => s.Execute(It.IsAny<int>())).ReturnsAsync(locationListModel);

            var result = _getLocationListBasedOnUserId.Execute(UserId);

            Assert.AreEqual(0, result.Result.Count());
        }
    }
}
