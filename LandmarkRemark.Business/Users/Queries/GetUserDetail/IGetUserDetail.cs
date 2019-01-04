using LandmarkRemark.Application.Users.Queries.GetUserDetail;
using System.Threading.Tasks;

namespace LandmarkRemark.Business.Users.Queries.GetUserDetail
{
    public interface IGetUserDetail
    {
        Task<UserDetailModel> Execute(int id);
    }
}
