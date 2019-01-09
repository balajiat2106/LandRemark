using LandmarkRemark.Context;
using System.Linq;

namespace LandmarkRemark.Application.Users.Queries.UserLogin
{
    public class UserLoginQuery:IUserLoginQuery
    {
        private readonly LandmarkRemarkContext _landmarkRemarkContext;
        public UserLoginQuery(LandmarkRemarkContext landmarkRemarkContext)
        {
            _landmarkRemarkContext = landmarkRemarkContext;
        }

        /// <summary>
        /// Get user id for a username
        /// </summary>
        /// <param name="userName">Valid user name</param>
        /// <returns>User id</returns>
        public int Execute(UserLoginModel userLoginModel)
        {
            //TODO: Handle exception
            return _landmarkRemarkContext.Users.Where(u => u.UserName == userLoginModel.UserName && u.Password==userLoginModel.Password).Select(i => i.Id).SingleOrDefault();
        }
    }
}
