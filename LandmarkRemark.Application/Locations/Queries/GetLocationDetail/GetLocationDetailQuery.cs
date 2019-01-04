using LandmarkRemark.Context;
using System.Threading.Tasks;

namespace LandmarkRemark.Application.Locations.Queries.GetLocationDetail
{
    public class GetLocationDetailQuery:IGetLocationDetailQuery
    {
        private readonly LandmarkRemarkContext _landmarkRemarkContext;

        public GetLocationDetailQuery(LandmarkRemarkContext landmarkRemarkContext)
        {
            _landmarkRemarkContext = landmarkRemarkContext;
        }

        public async Task<LocationDetailModel> Execute(int id)
        {
            var entity = await _landmarkRemarkContext.Locations.FindAsync(id);

            if (entity == null)
                return null;

            return new LocationDetailModel
            {
                Label=entity.Label,
                Latitude=entity.Latitude,
                Longitude=entity.Longitude,
                Remark=entity.Remark
            };
        }
    }
}
