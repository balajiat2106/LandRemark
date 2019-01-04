using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandmarkRemark.Application.UserLocation.Queries
{
    public interface IGetUserLocationListQuery
    {
        Task<IEnumerable<UserLocationListModel>> Execute(string userName);
    }
}
