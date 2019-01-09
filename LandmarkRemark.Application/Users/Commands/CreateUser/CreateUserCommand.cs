using LandmarkRemark.Context;
using LandmarkRemark.Domain;
using System.Threading.Tasks;

namespace LandmarkRemark.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand:ICreateUserCommand
    {
        private readonly LandmarkRemarkContext _landmarkRemarkContext;

        public CreateUserCommand(LandmarkRemarkContext landmarkRemarkContext)
        {
            _landmarkRemarkContext = landmarkRemarkContext;
        }

        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="model">Create user model</param>
        /// <returns>Number of rows affected</returns>
        public async Task<int> Execute(CreateUserModel model)
        {
            //TODO: Handle exception
            var entity = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Password=model.Password,
                Email = model.Email,
                IsActive = model.IsActive,
                CreationDate = model.CreationDate
            };

            _landmarkRemarkContext.Users.Add(entity);

            return await _landmarkRemarkContext.SaveChangesAsync();
        }
    }
}
