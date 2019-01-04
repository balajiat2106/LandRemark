using System.Threading.Tasks;

namespace LandmarkRemark.Application.Locations.Queries.GetLocationDetail
{
    public interface IGetLocationDetailQuery
    {
        Task<LocationDetailModel> Execute(int id);
    }
}
