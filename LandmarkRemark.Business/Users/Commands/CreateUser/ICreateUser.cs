using LandmarkRemark.Application.Users.Commands.CreateUser;
using System.Threading.Tasks;

namespace LandmarkRemark.Business.Users.Commands.CreateUser
{
    public interface ICreateUser
    {
        Task<int> Execute(CreateUserModel model);
    }
}
