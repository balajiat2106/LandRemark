using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandmarkRemark.Application.Locations.Queries.GetLocationList
{
    public interface IGetLocationListBasedOnSearchTextQuery
    {
        Task<IEnumerable<LocationListModel>> Execute(string searchText);
    }
}
