using LandmarkRemark.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandmarkRemark.Application.Locations.Queries.GetLocationList
{
    public class GetLocationListBasedOnSearchTextQuery: IGetLocationListBasedOnSearchTextQuery
    {
        private readonly LandmarkRemarkContext _landmarkRemarkContext;
        public GetLocationListBasedOnSearchTextQuery(LandmarkRemarkContext landmarkRemarkContext)
        {
            _landmarkRemarkContext = landmarkRemarkContext;
        }

        public async Task<IEnumerable<LocationListModel>> Execute(string searchText)
        {
            return await _landmarkRemarkContext.Locations.Where(l => l.Remark.Contains(searchText)).Select(l =>
                    new LocationListModel
                    {
                        Id = l.Id,
                        Label = l.Label,
                        Latitude = l.Latitude,
                        Longitude = l.Longitude,
                        Remark = l.Remark,
                        UserId = l.UserId
                    }).ToListAsync();
        }
    }
}
