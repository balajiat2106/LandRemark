using LandmarkRemark.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandmarkRemark.Application.Users.Queries.GetUserList
{
    public class GetUserListQuery : IGetUserListQuery
    {
        private readonly LandmarkRemarkContext _landmarkRemarkContext;
        public GetUserListQuery(LandmarkRemarkContext landmarkRemarkContext)
        {
            _landmarkRemarkContext = landmarkRemarkContext;
        }
        
        public async Task<IEnumerable<UserListModel>> Execute()
        {
            return await _landmarkRemarkContext.Users.Select(u =>
                new UserListModel
                {
                    FirstName = u.FirstName,
                    LastName=u.LastName,
                    Email=u.Email,
                    UserName=u.UserName,
                    CreationDate=u.CreationDate,
                    IsActive=u.IsActive
                }).ToListAsync();
        }
    }
}
