using LandmarkRemark.Context;
using LandmarkRemark.Domain;
using System.Threading.Tasks;

namespace LandmarkRemark.Application.Locations.Commands.CreateLocation
{
    public class CreateLocationCommand:ICreateLocationCommand
    {
        private readonly LandmarkRemarkContext _landmarkRemarkContext;

        public CreateLocationCommand(LandmarkRemarkContext landmarkRemarkContext)
        {
            _landmarkRemarkContext = landmarkRemarkContext;
        }
        public async Task<int> Execute(int userId, CreateLocationModel model)
        {
            var entity = new Location
            {
                Label = model.Label,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Remark = model.Remark,
                UserId = userId
            };

            _landmarkRemarkContext.Locations.Add(entity);

            return await _landmarkRemarkContext.SaveChangesAsync();                      
        }
    }
}
