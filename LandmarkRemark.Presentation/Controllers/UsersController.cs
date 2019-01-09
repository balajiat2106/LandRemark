using LandmarkRemark.Application.Users.Commands.CreateUser;
using LandmarkRemark.Application.Users.Queries.GetUserList;
using LandmarkRemark.Business.Users.Commands.CreateUser;
using LandmarkRemark.Business.Users.Queries.GetUserDetail;
using LandmarkRemark.Business.Users.Queries.GetUserList;
using LandmarkRemark.Business.Users.Queries.UserLogin;
using LandmarkRemark.Presentation.Filter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LandmarkRemark.Presentation.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    public class UsersController : BaseUserController
    {
        //To have a clean code in controller, all the dependencies have been moved to base user controller
        //TODO: This can be still refactored using MediatR
        public UsersController(ICreateUser createUser, 
                               IGetUserDetail getUserDetail, 
                               IGetUserList getUserList, 
                               IUserLogin userLogin):base(createUser,
                                                          getUserDetail,
                                                          getUserList,
                                                          userLogin)
        {            
        }
        
        [HttpGet("{userName}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public IActionResult GetUser([FromRoute] string userName)
        {
            var result =_userLogin.Execute(userName);

            return (result > 0) ? Ok(result): (IActionResult)NotFound();
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<UserListModel>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllUsers()
        {
            var result = _getUserList.Execute();

            return result.Result.Any() ? Ok(result) : (IActionResult)NotFound();
        }

        [HttpPost]
        [ProducesResponseType(typeof(IDictionary<string, string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ValidateModel]
        public async Task<IActionResult> PostUser([FromBody] CreateUserModel createUserModel)
        {
            var result = await _createUser.Execute(createUserModel);

            return (result > 0) ? Ok(result) : (IActionResult)NotFound();
        }
    }
}