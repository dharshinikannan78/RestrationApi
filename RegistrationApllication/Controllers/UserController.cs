using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationApllication.Data;
using RegistrationApllication.Modal;
using System.Linq;

namespace RegistrationApllication.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly UserDbContext dataModel;
        public UserController(UserDbContext userData)
        {
            dataModel = userData;

        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserModelClass userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                var user = dataModel.AdminLogin.Where(q =>
                q.Username == userObj.Username
                && q.Password == userObj.Password).FirstOrDefault();

                if (user != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Login Sucessfully"

                    });
                }
                else
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "User Not Found"
                    });
                }

            }

        }

    }
}
