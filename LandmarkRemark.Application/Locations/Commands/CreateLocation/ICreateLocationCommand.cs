using System.Threading.Tasks;

namespace LandmarkRemark.Application.Locations.Commands.CreateLocation
{
    public interface ICreateLocationCommand
    {
        Task<int> Execute(int userId, CreateLocationModel createLocationModel);
    }
}
