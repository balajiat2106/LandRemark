using LandmarkRemark.Application.Users.Queries.UserLogin;
using System;
using System.Collections.Generic;
using System.Text;

namespace LandmarkRemark.Business.Users.Queries.UserLogin
{
    public interface IUserLogin
    {
        int Execute(UserLoginModel userLoginModel);
    }
}
