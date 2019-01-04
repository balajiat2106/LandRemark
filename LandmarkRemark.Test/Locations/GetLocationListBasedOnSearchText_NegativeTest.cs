using LandmarkRemark.Application.Locations.Queries.GetLocationList;
using LandmarkRemark.Business.Locations.Queries.GetLocationList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace LandmarkRemark.Test.Locations
{
    [TestClass]
    public class GetLocationListBasedOnSearchText_NegativeTest
    {
        private Mock<IGetLocationListBasedOnSearchTextQuery> _getLocationListBasedOnSearchTextQuery;
        private IGetLocationListBasedOnSearchText _getLocationListBasedOnSearchText;
        private List<LocationListModel> locationListModel;
        string searchText = string.Empty;

        [TestInitialize]
        public void TestInitialize()
        {
            searchText = "Invalid Text";
            locationListModel = new List<LocationListModel>();
            _getLocationListBasedOnSearchTextQuery = new Mock<IGetLocationListBasedOnSearchTextQuery>();
            _getLocationListBasedOnSearchText = new GetLocationListBasedOnSearchText(_getLocationListBasedOnSearchTextQuery.Object);
        }

        [TestMethod]
        public void GetLocationBasedOnSearchText_WithInvalidText_Returns_Null()
        {
            _getLocationListBasedOnSearchTextQuery.Setup(s => s.Execute(It.IsAny<string>())).ReturnsAsync(locationListModel);

            var result = _getLocationListBasedOnSearchText.Execute(searchText);

            Assert.AreEqual(result.Result.Count(), 0);
        }
    }
}
