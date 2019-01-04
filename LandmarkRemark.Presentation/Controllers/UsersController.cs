using LandmarkRemark.Application.Users.Commands.CreateUser;
using LandmarkRemark.Application.Users.Queries.GetUserList;
using LandmarkRemark.Business.Users.Commands.CreateUser;
using LandmarkRemark.Business.Users.Queries.GetUserDetail;
using LandmarkRemark.Business.Users.Queries.GetUserList;
using LandmarkRemark.Business.Users.Queries.UserLogin;
using LandmarkRemark.Presentation.Filter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace LandmarkRemark.Presentation.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    public class UsersController : Controller
    {
        private readonly ICreateUser _createUser;
        private readonly IGetUserDetail _getUserDetail;
        private readonly IGetUserList _getUserList;
        private readonly IUserLogin _userLogin;

        public UsersController(ICreateUser createUser, IGetUserDetail getUserDetail, IGetUserList getUserList, IUserLogin userLogin)
        {
            _createUser = createUser;
            _getUserDetail = getUserDetail;
            _getUserList = getUserList;
            _userLogin = userLogin;
        }
        
        [HttpGet("{userName}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public IActionResult GetUser([FromRoute] string userName)
        {
            var result =_userLogin.Execute(userName);
            return Ok(result);
        }

        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<UserListModel>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllUsers()
        {
            var result = _getUserList.Execute();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(IDictionary<string, string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ValidateModel]
        public async Task<IActionResult> PostUser([FromBody] CreateUserModel createUserModel)
        {
            var result = await _createUser.Execute(createUserModel);
            return Ok(result);
        }
    }
}