using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandmarkRemark.Application.Users.Queries.GetUserList
{
    public interface IGetUserListQuery
    {
        Task<IEnumerable<UserListModel>> Execute();
    }
}
