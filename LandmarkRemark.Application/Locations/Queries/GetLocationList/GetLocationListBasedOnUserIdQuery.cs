using LandmarkRemark.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandmarkRemark.Application.Locations.Queries.GetLocationList
{
    public class GetLocationListBasedOnUserIdQuery : IGetLocationListBasedOnUserIdQuery
    {
        private readonly LandmarkRemarkContext _landmarkRemarkContext;
        public GetLocationListBasedOnUserIdQuery(LandmarkRemarkContext landmarkRemarkContext)
        {
            _landmarkRemarkContext = landmarkRemarkContext;
        }

        /// <summary>
        /// Gets an list of locations based on the input user id
        /// </summary>
        /// <param name="userId">Any valid user id</param>
        /// <returns>List of locations</returns>
        public async Task<IEnumerable<LocationListModel>> Execute(int userId)
        {            
            return await _landmarkRemarkContext.Locations.Where(l=>l.UserId==userId).Select(l =>
                new LocationListModel
                {
                    Id = l.Id,
                    Label=l.Label,
                    Latitude=l.Latitude,
                    Longitude=l.Longitude,
                    Remark=l.Remark,
                    UserId=l.UserId
                }).ToListAsync();
        }
    }
}
