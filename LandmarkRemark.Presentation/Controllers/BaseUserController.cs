using LandmarkRemark.Business.Users.Commands.CreateUser;
using LandmarkRemark.Business.Users.Queries.GetUserDetail;
using LandmarkRemark.Business.Users.Queries.GetUserList;
using LandmarkRemark.Business.Users.Queries.UserLogin;
using Microsoft.AspNetCore.Mvc;

namespace LandmarkRemark.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseUserController : ControllerBase
    {
        protected readonly ICreateUser _createUser;
        protected readonly IGetUserDetail _getUserDetail;
        protected readonly IGetUserList _getUserList;
        protected readonly IUserLogin _userLogin;


        public BaseUserController(ICreateUser createUser, IGetUserDetail getUserDetail, IGetUserList getUserList, IUserLogin userLogin)
        {
            _createUser = createUser;
            _getUserDetail = getUserDetail;
            _getUserList = getUserList;
            _userLogin = userLogin;
        }
    }
}