using LandmarkRemark.Application.Locations.Queries.GetLocationList;
using LandmarkRemark.Business.Locations.Queries.GetLocationList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace LandmarkRemark.Test.Locations
{
    [TestClass]
    public class GetLocationListBasedOnSearchText_PositiveTest
    {
        private Mock<IGetLocationListBasedOnSearchTextQuery> _getLocationListBasedOnSearchTextQuery;
        private IGetLocationListBasedOnSearchText _getLocationListBasedOnSearchText;
        private List<LocationListModel> locationListModel;
        string searchText = string.Empty;

        [TestInitialize]
        public void TestInitialize()
        {
            searchText = "cool";
            locationListModel = new List<LocationListModel>();
            _getLocationListBasedOnSearchTextQuery = new Mock<IGetLocationListBasedOnSearchTextQuery>();
            _getLocationListBasedOnSearchText = new GetLocationListBasedOnSearchText(_getLocationListBasedOnSearchTextQuery.Object);
        }
        
        [TestMethod]
        public void GetLocationBasedOnSearchText_WithValidText_Calls_GetLocationListBasedOnSearchTextQuery_Once()
        {
            var result = _getLocationListBasedOnSearchText.Execute(searchText);

            _getLocationListBasedOnSearchTextQuery.Verify(v => v.Execute(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GetLocationBasedOnSearchText_WithValidText_Returns_LocationListModelWithValidText()
        {
            _getLocationListBasedOnSearchTextQuery.Setup(s => s.Execute(It.IsAny<string>())).ReturnsAsync(locationListModel);

            var result = _getLocationListBasedOnSearchText.Execute(searchText);

            Assert.IsTrue(result.Result.All(w => w.Remark.Contains(searchText)));
        }
    }
}
