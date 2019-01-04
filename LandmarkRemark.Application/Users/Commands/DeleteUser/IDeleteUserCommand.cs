using System.Threading.Tasks;

namespace LandmarkRemark.Application.Users.Commands.DeleteUser
{
    public interface IDeleteUserCommand
    {
        Task Execute(string userName);
    }
}
