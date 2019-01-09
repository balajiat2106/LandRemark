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

        public int Execute(UserLoginModel userLoginModel)
        {
            return _userLoginQuery.Execute(userLoginModel);
        }
    }
}
