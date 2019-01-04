using LandmarkRemark.Application.Users.Queries.GetUserDetail;
using System.Threading.Tasks;

namespace LandmarkRemark.Business.Users.Queries.GetUserDetail
{
    public class GetUserDetail : IGetUserDetail
    {
        private readonly IGetUserDetailQuery _getUserDetailQuery;

        public GetUserDetail(IGetUserDetailQuery getUserDetailQuery)
        {
            _getUserDetailQuery = getUserDetailQuery;
        }
        public async Task<UserDetailModel> Execute(int id)
        {
            return await _getUserDetailQuery.Execute(id);
        }
    }
}
