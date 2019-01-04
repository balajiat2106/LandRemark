using LandmarkRemark.Application.Locations.Queries.GetLocationDetail;
using System.Threading.Tasks;

namespace LandmarkRemark.Business.Locations.Queries.GetLocationDetail
{
    public class GetLocationDetail : IGetLocationDetail
    {
        private readonly IGetLocationDetailQuery _getLocationDetailQuery;

        public GetLocationDetail(IGetLocationDetailQuery getLocationDetailQuery)
        {
            _getLocationDetailQuery = getLocationDetailQuery;
        }
        public async Task<LocationDetailModel> Execute(int id)
        {
            return await _getLocationDetailQuery.Execute(id);            
        }
    }
}
