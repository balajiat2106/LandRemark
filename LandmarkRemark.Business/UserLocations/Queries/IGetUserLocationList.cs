using LandmarkRemark.Application.UserLocation.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandmarkRemark.Business.UserLocations.Queries
{
    public interface IGetUserLocationList
    {
        Task<IEnumerable<UserLocationListModel>> Execute(string userName);
    }
}
