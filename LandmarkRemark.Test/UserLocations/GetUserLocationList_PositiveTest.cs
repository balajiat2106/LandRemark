using LandmarkRemark.Application.UserLocation.Queries;
using LandmarkRemark.Business.UserLocations.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace LandmarkRemark.Test.UserLocations
{
    [TestClass]
    public class GetUserLocationList_PositiveTest
    {
        private Mock<IGetUserLocationListQuery> _getUserLocationListQuery;
        private GetUserLocationList _getUserLocationList;
        private List<UserLocationListModel> userLocationListModel;
        string userName = string.Empty;

        [TestInitialize]
        public void TestInitialize()
        {
            userName = "user11";
            _getUserLocationListQuery = new Mock<IGetUserLocationListQuery>();
            _getUserLocationList = new GetUserLocationList(_getUserLocationListQuery.Object);
            userLocationListModel = new List<UserLocationListModel>();
        }

        [TestMethod]
        public void GetUserLocationList_WithValidUserName_Calls_GetUserLocationListQuery_Once()
        {
            var result = _getUserLocationList.Execute(userName);

            _getUserLocationListQuery.Verify(v => v.Execute(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GetUserLocationList_WithValidUserName_Returns_UserLocationListModelForTheValidUserName()
        {
            _getUserLocationListQuery.Setup(s => s.Execute(It.IsAny<string>())).ReturnsAsync(userLocationListModel);

            var result = _getUserLocationList.Execute(userName);

            Assert.IsTrue(result.Result.All(a => a.UserName == userName));
        }
    }
}
