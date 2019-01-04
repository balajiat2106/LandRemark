using LandmarkRemark.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LandmarkRemark.Application.Users.Queries.GetUserDetail
{
    public class GetUserDetailBasedOnUserName: IGetUserDetailBasedOnUserName
    {
        private readonly LandmarkRemarkContext _landmarkRemarkContext;
        public GetUserDetailBasedOnUserName(LandmarkRemarkContext landmarkRemarkContext)
        {
            _landmarkRemarkContext = landmarkRemarkContext;
        }
        public async Task<UserDetailModel> ExecuteBasedOnUserName(string searchText)
        {
            return await _landmarkRemarkContext.Users.Where(u => u.UserName == searchText).Select(u =>
                    new UserDetailModel
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        UserName = u.UserName,
                        CreationDate = u.CreationDate,
                        IsActive = u.IsActive
                    }).SingleOrDefaultAsync();
        }
    }
}
