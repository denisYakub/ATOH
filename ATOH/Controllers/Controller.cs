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
        [HttpPost("create/{key}")]
        public IActionResult CreateUser([FromRoute] Guid key, [FromBody] CreateUserRequest request)
        {
            try
            {
                if (admin.IsAdmin(key))
                    admin.Create(request);
                else
                    return new UnauthorizedResult();

                return new OkResult();
            }
            catch(BadRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                return new ConflictObjectResult(ex);
            }
        }

        [HttpPatch("update-field/{key}")]
        public IActionResult UpdateUserField([FromRoute] Guid key, [FromBody] UpdateUserFieldRequest request)
        {
            try
            {
                if (admin.IsAdmin(key))
                    admin.UpdateField(request);
                else if (user.IsUser(key))
                    user.UpdateField(request);
                else
                    return new UnauthorizedResult();

                return new OkResult();
            }
            catch (BadRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                return new ConflictObjectResult(ex);
            }
        }

        [HttpPatch("recover/{key}")]
        public IActionResult RecoverUser([FromRoute] Guid key)
        {
            try
            {
                if (admin.IsAdmin(key))
                    admin.Recover();
                else
                    return new UnauthorizedResult();

                return new OkResult();
            }
            catch (BadRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                return new ConflictObjectResult(ex);
            }
        }

        [HttpGet("read-all-active/{key}")]
        public IActionResult GetAllActiveUsers([FromRoute] Guid key)
        {
            try
            {
                if (admin.IsAdmin(key))
                {
                    var result = admin.GetActiveUsers();

                    return new OkObjectResult(result);
                }
                else
                    return new UnauthorizedResult();
            }
            catch (BadRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                return new ConflictObjectResult(ex);
            }
        }

        [HttpGet("read/{key}/{login}")]
        public IActionResult GetUser([FromRoute] Guid key, [FromRoute] string login)
        {
            try
            {
                if (admin.IsAdmin(key))
                {
                    var result = admin.Get(login);

                    return new OkObjectResult(result);
                }
                else
                    return new UnauthorizedResult();
            }
            catch (BadRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                return new ConflictObjectResult(ex);
            }
        }

        [HttpGet("read/{key}/{login}/{password}")]
        public IActionResult GetUser([FromRoute] Guid key, [FromRoute] string login, [FromRoute] string password)
        {
            try
            {
                if (user.IsUser(key))
                {
                    var result = user.Get(login, password);

                    return new OkObjectResult(result);
                }
                else
                    return new UnauthorizedResult();
            }
            catch (BadRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                return new ConflictObjectResult(ex);
            }
        }

        [HttpGet("read-all-older/{key}/{Date}")]
        public IActionResult GetAllOlderUsers([FromRoute] Guid key, [FromRoute] DateTime Date)
        {
            try
            {
                if (admin.IsAdmin(key))
                {
                    var result = admin.GetOlderUsers(Date);

                    return new OkObjectResult(result);
                }
                else
                    return new UnauthorizedResult();
            }
            catch (BadRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                return new ConflictObjectResult(ex);
            }
        }

        [HttpDelete("delete/{key}/{login}/{soft}")]
        public IActionResult DeleteUser([FromRoute] Guid key, [FromRoute] string login, [FromRoute] bool soft)
        {
            try
            {
                if (admin.IsAdmin(key)) 
                    admin.Delete(login, soft);
                else
                    return new UnauthorizedResult();

                return new OkResult();
            }
            catch (BadRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                return new ConflictObjectResult(ex);
            }
        }
    }
}
