using LandmarkRemark.Application.UserLocation.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LandmarkRemark.Business.UserLocations.Queries
{
    public class GetUserLocationList : IGetUserLocationList
    {
        private readonly IGetUserLocationListQuery _getUserLocationListQuery;
        public GetUserLocationList(IGetUserLocationListQuery getUserLocationListQuery)
        {
            _getUserLocationListQuery = getUserLocationListQuery;
        }

        public async Task<IEnumerable<UserLocationListModel>> Execute(string userName)
        {
            return await _getUserLocationListQuery.Execute(userName);
        }
    }
}
