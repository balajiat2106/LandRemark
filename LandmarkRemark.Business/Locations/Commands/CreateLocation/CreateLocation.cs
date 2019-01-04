using LandmarkRemark.Application.Locations.Commands.CreateLocation;
using System.Threading.Tasks;

namespace LandmarkRemark.Business.Locations.Commands.CreateLocation
{
    public class CreateLocation : ICreateLocation
    {
        private readonly ICreateLocationCommand _createLocationCommand;

        public CreateLocation(ICreateLocationCommand createLocationCommand)
        {
            _createLocationCommand = createLocationCommand;
        }
        public async Task<int> Execute(int userId, CreateLocationModel createLocationModel)
        {
            if ((string.IsNullOrEmpty(createLocationModel.Label)) || (string.IsNullOrEmpty(createLocationModel.Remark)))
            {
                return -1;
            }
            else
            {
                return await _createLocationCommand.Execute(userId, createLocationModel);
            }
        }
    }
}
