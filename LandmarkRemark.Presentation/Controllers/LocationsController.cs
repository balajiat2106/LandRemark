using LandmarkRemark.Application.Locations.Commands.CreateLocation;
using LandmarkRemark.Application.Locations.Queries.GetLocationList;
using LandmarkRemark.Application.UserLocation.Queries;
using LandmarkRemark.Business.Locations.Commands.CreateLocation;
using LandmarkRemark.Business.Locations.Queries.GetLocationDetail;
using LandmarkRemark.Business.Locations.Queries.GetLocationList;
using LandmarkRemark.Business.UserLocations.Queries;

using LandmarkRemark.Presentation.Filter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace LandmarkRemark.Presentation.Controllers
{
    [Produces("application/json")]
    [Route("api/location")]
    public class LocationsController : Controller
    {
        private readonly ICreateLocation _createLocation;
        private readonly IGetLocationDetail _getLocationDetail;
        private readonly IGetLocationListBasedOnUserId _getLocationListBasedOnUserId;
        private readonly IGetLocationListBasedOnSearchText _getLocationListBasedOnSearchText;
        private readonly IGetUserLocationList _getUserLocationList;

        /// <summary>
        /// Contructor injection for all the micro services
        /// </summary>
        /// <param name="createLocation">Creates a new location for the logged-in user (Input: User Id, Location object)</param>
        /// <param name="getLocationDetail">Retrieves a location details (Input: Location ID)</param>
        /// <param name="getLocationListBasedOnUserId">Retrieves list of locations for logged-in user(Input: User ID)</param>
        /// <param name="getLocationListBasedOnSearchText">Retrieves  list of locations based on remarks(Input: any text)</param>
        /// <param name="getUserLocationList">Retrieves list of locations based on username(Input: User name)</param>
        public LocationsController(ICreateLocation createLocation,
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


        [HttpGet("{userId}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)] //Negative response type
        [ProducesResponseType(typeof(IEnumerable<LocationListModel>), (int)HttpStatusCode.OK)] //Positive response type
        [ValidateUserExists] //Validates the user existence before jumping into locations query. This method can be reused.
        public async Task<IActionResult> GetLocationsBasedOnUserId([FromRoute] int userId)
        {
            var result = await _getLocationListBasedOnUserId.Execute(userId);
            return Ok(result);
        }

        [HttpGet("{searchText}/text")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<LocationListModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLocationsBasedOnText([FromRoute] string searchText)
        {
            var result = await _getLocationListBasedOnSearchText.Execute(searchText);
            return Ok(result);
        }

        [HttpGet("{searchText}/user")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<UserLocationListModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLocationsBasedOnUserName([FromRoute] string searchText)
        {
            var result = await _getUserLocationList.Execute(searchText);
            return Ok(result);
        }

        [HttpPost("{userId}")]
        [ProducesResponseType(typeof(IDictionary<string, string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateLocationModel), (int)HttpStatusCode.Created)]
        [ValidateModel] //Validate model state. This method can be reused.
        [ValidateUserExists]
        public async Task<IActionResult> PostLocation([FromRoute] int userId, [FromBody] CreateLocationModel createLocationModel)
        {
            var result = await _createLocation.Execute(userId, createLocationModel);
            return Ok(result);
        }
    }
}