using LandmarkRemark.Application.Users.Queries.UserLogin;
using LandmarkRemark.Business.Users.Queries.UserLogin;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LandmarkRemark.Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        protected readonly IUserLogin _userLogin;

        public AuthController(IUserLogin userLogin)
        {
            _userLogin = userLogin;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public IActionResult PostUser([FromBody] UserLoginModel userLoginModel)
        {
            var result = _userLogin.Execute(userLoginModel);

            return (result > 0) ? Ok(result) : (IActionResult)NotFound();
        }
    }
}