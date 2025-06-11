using ATOH.Entities.DTOs;
using ATOH.Entities.Exceptions;
using ATOH.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ATOH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller(IAdminService admin, IUserService user) : ControllerBase
    {
        [HttpPost("create/{token}")]
        public IActionResult CreateUser([FromRoute] Guid token, [FromBody] CreateUserRequest request)
        {
            try
            {
                admin.CreateUser(token, request);

                return new OkResult();
            }
            catch (UnAuthException ex)
            {
                return new UnauthorizedObjectResult(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPatch("update-field/{token}")]
        public IActionResult UpdateUserField([FromRoute] Guid token, [FromBody] UpdateUserFieldRequest request)
        {
            try
            {
                user.UpdateField(token, request);

                return new OkResult();
            }
            catch (UnAuthException ex)
            {
                return new UnauthorizedObjectResult(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPatch("recover/{token}")]
        public IActionResult RecoverUser([FromRoute] Guid token)
        {
            try
            {
                admin.RecoverUser(token);

                return new OkResult();
            }
            catch (UnAuthException ex)
            {
                return new UnauthorizedObjectResult(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet("read-all-active/{token}")]
        public IActionResult GetAllActiveUsers([FromRoute] Guid token)
        {
            try
            {
                var result = admin.GetActiveUsers(token);

                return new OkObjectResult(result);
            }
            catch (UnAuthException ex)
            {
                return new UnauthorizedObjectResult(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet("read/{token}/{login}")]
        public IActionResult GetUser([FromRoute] Guid token, [FromRoute] string login)
        {
            try
            {
                var result = admin.GetUser(token, login);

                return new OkObjectResult(result);
            }
            catch (UnAuthException ex)
            {
                return new UnauthorizedObjectResult(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet("login/{login}/{password}")]
        public IActionResult GetUser([FromRoute] string login, [FromRoute] string password)
        {
            try
            {
                var result = user.GetUser(login, password);

                return new OkObjectResult(result);
            }
            catch (UnAuthException ex)
            {
                return new UnauthorizedObjectResult(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet("read-all-older/{token}/{date}")]
        public IActionResult GetAllOlderUsers([FromRoute] Guid token, [FromRoute] DateTime date)
        {
            try
            {
                var result = admin.GetOlderUsers(token, date);

                return new OkObjectResult(result);
            }
            catch (UnAuthException ex)
            {
                return new UnauthorizedObjectResult(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpDelete("delete/{token}/{login}/{soft}")]
        public IActionResult DeleteUser([FromRoute] Guid token, [FromRoute] string login, [FromRoute] bool soft)
        {
            try
            {
                admin.DeleteUser(token, login, soft);

                return new OkResult();
            }
            catch (UnAuthException ex)
            {
                return new UnauthorizedObjectResult(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
