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
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LandmarkRemark.Presentation.Controllers
{
    [Produces("application/json")]
    [Route("api/location")]
    public class LocationsController : BaseLocationController
    {
        //To have a clean code in controller, all the dependencies have been moved to base location controller
        //TODO: This can be still refactored using MediatR
        public LocationsController(ICreateLocation createLocation, 
                                   IGetLocationDetail getLocationDetail, 
                                   IGetLocationListBasedOnUserId getLocationListBasedOnUserId, 
                                   IGetLocationListBasedOnSearchText getLocationListBasedOnSearchText, 
                                   IGetUserLocationList getUserLocationList) : base(createLocation,
                                                                                    getLocationDetail,
                                                                                    getLocationListBasedOnUserId,
                                                                                    getLocationListBasedOnSearchText,
                                                                                    getUserLocationList)
        { }
                     
        [HttpGet("{userId}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)] //Negative response type
        [ProducesResponseType(typeof(IEnumerable<LocationListModel>), (int)HttpStatusCode.OK)] //Positive response type
        [ValidateUserExists] //Validates the user existence before jumping into locations query. This method can be reused.
        public async Task<IActionResult> GetLocationsBasedOnUserId([FromRoute] int userId)
        {
            var result = await _getLocationListBasedOnUserId.Execute(userId);

            return result.Any() ? Ok(result) : (IActionResult)NotFound();
        }

        [HttpGet("{searchText}/text")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<LocationListModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLocationsBasedOnText([FromRoute] string searchText)
        {
            var result = await _getLocationListBasedOnSearchText.Execute(searchText);

            return result.Any() ? Ok(result) : (IActionResult)NotFound();
        }

        [HttpGet("{searchText}/user")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<UserLocationListModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLocationsBasedOnUserName([FromRoute] string searchText)
        {
            var result = await _getUserLocationList.Execute(searchText);

            return result.Any() ? Ok(result) : (IActionResult)NotFound();
        }

        [HttpPost("{userId}")]
        [ProducesResponseType(typeof(IDictionary<string, string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateLocationModel), (int)HttpStatusCode.Created)]
        [ValidateModel] //Validate model state. This method can be reused.
        [ValidateUserExists] //Validates the user existence before jumping into locations query. This method can be reused.
        public async Task<IActionResult> PostLocation([FromRoute] int userId, [FromBody] CreateLocationModel createLocationModel)
        {
            var result = await _createLocation.Execute(userId, createLocationModel);

            return Ok(result);
        }
    }
}