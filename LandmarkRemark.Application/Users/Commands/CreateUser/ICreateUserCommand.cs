using System.Threading.Tasks;

namespace LandmarkRemark.Application.Users.Commands.CreateUser
{
    public interface ICreateUserCommand
    {
        Task<int> Execute(CreateUserModel createUserModel);
    }
}
