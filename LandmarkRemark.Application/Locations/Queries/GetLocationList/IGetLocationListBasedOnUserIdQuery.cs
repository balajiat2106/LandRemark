using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandmarkRemark.Application.Locations.Queries.GetLocationList
{
    public interface IGetLocationListBasedOnUserIdQuery
    {
        Task<IEnumerable<LocationListModel>> Execute(int userId);
    }
}
