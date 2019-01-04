using LandmarkRemark.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LandmarkRemark.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand:IDeleteUserCommand
    {
        private readonly LandmarkRemarkContext _landmarkRemarkContext;

        public DeleteUserCommand(LandmarkRemarkContext landmarkRemarkContext)
        {
            _landmarkRemarkContext = landmarkRemarkContext;
        }

        public async Task Execute(string userName)
        {
            var entity = await _landmarkRemarkContext.Users.SingleAsync(u => u.UserName == userName);

            _landmarkRemarkContext.Users.Remove(entity);

            await _landmarkRemarkContext.SaveChangesAsync();
        }
    }
}
