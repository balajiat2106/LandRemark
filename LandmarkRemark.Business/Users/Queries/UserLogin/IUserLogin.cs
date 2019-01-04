using System;
using System.Collections.Generic;
using System.Text;

namespace LandmarkRemark.Business.Users.Queries.UserLogin
{
    public interface IUserLogin
    {
        int Execute(string userName);
    }
}
