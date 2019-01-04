using LandmarkRemark.Application.Users.Queries.GetUserList;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandmarkRemark.Business.Users.Queries.GetUserList
{
    public interface IGetUserList
    {
        Task<IEnumerable<UserListModel>> Execute();
    }
}
