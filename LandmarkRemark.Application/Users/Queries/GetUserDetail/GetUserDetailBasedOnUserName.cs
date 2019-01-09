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

        /// <summary>
        /// Gets user details based on input text(username)
        /// </summary>
        /// <param name="userName">Valid user name</param>
        /// <returns></returns>
        public async Task<UserDetailModel> ExecuteBasedOnUserName(string userName)
        {
            //TODO: Handle exception
            return await _landmarkRemarkContext.Users.Where(u => u.UserName == userName).Select(u =>
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
