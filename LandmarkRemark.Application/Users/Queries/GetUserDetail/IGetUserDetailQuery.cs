using System.Threading.Tasks;

namespace LandmarkRemark.Application.Users.Queries.GetUserDetail
{
    public interface IGetUserDetailQuery
    {
        Task<UserDetailModel> Execute(int id);

    }
}
