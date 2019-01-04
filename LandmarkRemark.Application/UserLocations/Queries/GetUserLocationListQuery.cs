using LandmarkRemark.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandmarkRemark.Application.UserLocation.Queries
{
    public class GetUserLocationListQuery : IGetUserLocationListQuery
    {
        private readonly LandmarkRemarkContext _landmarkRemarkContext;
        public GetUserLocationListQuery(LandmarkRemarkContext landmarkRemarkContext)
        {
            _landmarkRemarkContext = landmarkRemarkContext;
        }
        
        public async Task<IEnumerable<UserLocationListModel>> Execute(string userName)
        {
            return await _landmarkRemarkContext.Users.Join(_landmarkRemarkContext.Locations, u => u.Id, l => l.UserId, (u, l) => new { U = u, L = l }).Where(u => u.U.UserName == userName)
                .Select(c=> new UserLocationListModel { 
                    UserName=c.U.UserName,
                    Label=c.L.Label,
                    Latitude=c.L.Latitude,
                    Longitude=c.L.Longitude,
                    Remark=c.L.Remark
                }).ToListAsync();
        }
    }
}
