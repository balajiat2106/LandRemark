using LandmarkRemark.Application.Locations.Queries.GetLocationList;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandmarkRemark.Business.Locations.Queries.GetLocationList
{
    public class GetLocationListBasedOnSearchText : IGetLocationListBasedOnSearchText
    {
        private readonly IGetLocationListBasedOnSearchTextQuery _getLocationListBasedOnSearchTextQuery;

        public GetLocationListBasedOnSearchText(IGetLocationListBasedOnSearchTextQuery getLocationListBasedOnSearchTextQuery)
        {
            _getLocationListBasedOnSearchTextQuery = getLocationListBasedOnSearchTextQuery;
        }
        public async Task<IEnumerable<LocationListModel>> Execute(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                return null;
            }
            else
            {
                return await _getLocationListBasedOnSearchTextQuery.Execute(searchText);
            }
        }
    }
}
