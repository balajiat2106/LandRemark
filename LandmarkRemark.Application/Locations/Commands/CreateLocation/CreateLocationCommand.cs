using LandmarkRemark.Context;
using LandmarkRemark.Domain;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Creates a location remark for the respective user
        /// </summary>
        /// <param name="userId">Unique user identification number</param>
        /// <param name="model">CreateLocationModel</param>
        /// <returns>Number of rows affected</returns>
        public async Task<int> Execute(int userId, CreateLocationModel model)
        {
            //TODO: Handle exception
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
