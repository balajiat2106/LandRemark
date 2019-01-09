using LandmarkRemark.Business.Locations.Commands.CreateLocation;
using LandmarkRemark.Business.Locations.Queries.GetLocationDetail;
using LandmarkRemark.Business.Locations.Queries.GetLocationList;
using LandmarkRemark.Business.UserLocations.Queries;

using Microsoft.AspNetCore.Mvc;

namespace LandmarkRemark.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseLocationController : ControllerBase
    {
        protected readonly ICreateLocation _createLocation;
        protected readonly IGetLocationDetail _getLocationDetail;
        protected readonly IGetLocationListBasedOnUserId _getLocationListBasedOnUserId;
        protected readonly IGetLocationListBasedOnSearchText _getLocationListBasedOnSearchText;
        protected readonly IGetUserLocationList _getUserLocationList;

        /// <summary>
        /// Contructor injection for all the micro services
        /// </summary>
        /// <param name="createLocation">Creates a new location for the logged-in user (Input: User Id, Location object)</param>
        /// <param name="getLocationDetail">Retrieves a location details (Input: Location ID)</param>
        /// <param name="getLocationListBasedOnUserId">Retrieves list of locations for logged-in user(Input: User ID)</param>
        /// <param name="getLocationListBasedOnSearchText">Retrieves  list of locations based on remarks(Input: any text)</param>
        /// <param name="getUserLocationList">Retrieves list of locations based on username(Input: User name)</param>
        public BaseLocationController(ICreateLocation createLocation,
                                    IGetLocationDetail getLocationDetail,
                                    IGetLocationListBasedOnUserId getLocationListBasedOnUserId,
                                    IGetLocationListBasedOnSearchText getLocationListBasedOnSearchText,
                                    IGetUserLocationList getUserLocationList)
        {
            _createLocation = createLocation;
            _getLocationDetail = getLocationDetail;
            _getLocationListBasedOnUserId = getLocationListBasedOnUserId;
            _getLocationListBasedOnSearchText = getLocationListBasedOnSearchText;
            _getUserLocationList = getUserLocationList;
        }
    }
}