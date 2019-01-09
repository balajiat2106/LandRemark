using LandmarkRemark.Application.Locations.Queries.GetLocationDetail;
using System.Threading.Tasks;

namespace LandmarkRemark.Business.Locations.Queries.GetLocationDetail
{
    public interface IGetLocationDetail
    {
        Task<LocationDetailModel> Execute(int id);
    }
}
