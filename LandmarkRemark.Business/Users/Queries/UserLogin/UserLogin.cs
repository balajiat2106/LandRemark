using LandmarkRemark.Application.Users.Queries.UserLogin;

namespace LandmarkRemark.Business.Users.Queries.UserLogin
{
    public class UserLogin : IUserLogin
    {
        private readonly IUserLoginQuery _userLoginQuery;

        public UserLogin(IUserLoginQuery userLoginQuery)
        {
            _userLoginQuery = userLoginQuery;
        }

        public int Execute(string userName)
        {
            return _userLoginQuery.Execute(userName);
        }
    }
}
