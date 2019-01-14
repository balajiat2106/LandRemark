using LandmarkRemark.Application.UserLocation.Queries;
using LandmarkRemark.Business.UserLocations.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace LandmarkRemark.Test.UserLocations
{
    [TestClass]
    public class GetUserLocationList_NegativeTest
    {
        private Mock<IGetUserLocationListQuery> _getUserLocationListQuery;
        private GetUserLocationList _getUserLocationList;
        private List<UserLocationListModel> userLocationListModel;
        string userName = string.Empty;
        
        [TestInitialize]
        public void TestInitialize()
        {
            userName = "user123";
            _getUserLocationListQuery = new Mock<IGetUserLocationListQuery>();
            _getUserLocationList = new GetUserLocationList(_getUserLocationListQuery.Object);
            userLocationListModel = new List<UserLocationListModel>();
        }

        [TestMethod]
        public void GetUserLocationList_WithInvalidUserName_Returns_ZeroRecords()
        {
            _getUserLocationListQuery.Setup(s => s.Execute(It.IsAny<string>())).ReturnsAsync(userLocationListModel);

            var result = _getUserLocationList.Execute(userName);

            Assert.AreEqual(0, result.Result.Count());
        }
    }
}
