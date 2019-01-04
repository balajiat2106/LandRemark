using LandmarkRemark.Application.Users.Queries.GetUserList;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandmarkRemark.Business.Users.Queries.GetUserList
{
    public class GetUserList:IGetUserList
    {
        private readonly IGetUserListQuery _getUserListQuery;

        public GetUserList(IGetUserListQuery getUserListQuery)
        {
            _getUserListQuery = getUserListQuery;
        }

        public async Task<IEnumerable<UserListModel>> Execute()
        {
            return await _getUserListQuery.Execute();
        }
    }
}
