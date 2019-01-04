using System.Threading.Tasks;

namespace LandmarkRemark.Application.Users.Queries.GetUserDetail
{
    public interface IGetUserDetailBasedOnUserName
    {
        Task<UserDetailModel> ExecuteBasedOnUserName(string searchText);
    }
}
