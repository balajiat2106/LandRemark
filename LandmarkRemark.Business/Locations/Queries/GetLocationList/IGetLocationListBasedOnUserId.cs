using LandmarkRemark.Application.Locations.Queries.GetLocationList;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LandmarkRemark.Business.Locations.Queries.GetLocationList
{
    public interface IGetLocationListBasedOnUserId
    {
        Task<IEnumerable<LocationListModel>> Execute(int userId);
    }
}
