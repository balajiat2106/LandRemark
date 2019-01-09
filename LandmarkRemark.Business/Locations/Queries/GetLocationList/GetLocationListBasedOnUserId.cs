using LandmarkRemark.Application.Locations.Queries.GetLocationList;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandmarkRemark.Business.Locations.Queries.GetLocationList
{
    public class GetLocationListBasedOnUserId : IGetLocationListBasedOnUserId
    {
        private readonly IGetLocationListBasedOnUserIdQuery _getLocationListBasedOnUserIdQuery;

        public GetLocationListBasedOnUserId(IGetLocationListBasedOnUserIdQuery getLocationListBasedOnUserIdQuery)
        {
            _getLocationListBasedOnUserIdQuery = getLocationListBasedOnUserIdQuery;
        }

        public async Task<IEnumerable<LocationListModel>> Execute(int userId)
        {
            //NOTE: User validation done on the controller level itself
            return await _getLocationListBasedOnUserIdQuery.Execute(userId);
        }
    }
}
