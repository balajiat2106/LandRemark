using LandmarkRemark.Application.Locations.Commands.CreateLocation;
using System.Threading.Tasks;

namespace LandmarkRemark.Business.Locations.Commands.CreateLocation
{
    public interface ICreateLocation
    {
        Task<int> Execute(int userId, CreateLocationModel createLocationModel);
    }
}
