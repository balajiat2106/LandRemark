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

        public int Execute(string userName)
        {
            return _landmarkRemarkContext.Users.Where(u => u.UserName == userName).Select(i => i.Id).SingleOrDefault();
        }
    }
}
