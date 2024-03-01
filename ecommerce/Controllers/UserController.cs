using ecommerce.CQRS.Users.Command.ChangeUserPassword;
using ecommerce.CQRS.Users.Command.CreateUser;
using ecommerce.CQRS.Users.Command.DeleteAccount;
using ecommerce.CQRS.Users.Command.DeleteUser;
using ecommerce.CQRS.Users.Command.RestoreUser;
using ecommerce.CQRS.Users.Command.SigninUser;
using ecommerce.CQRS.Users.Command.UpdateUser;
using ecommerce.CQRS.Users.Query.GetUserById;
using ecommerce.CQRS.Users.Query.GetUserList;
using ecommerce.CQRS.Users.ViewModel;
using ecommerce.Services.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut("change-password")]
        public async Task<ActionResult<UserViewModel>> ChangeUserPassword([FromBody] ChangeUserPasswordCommand request)
        {
            try
            {
                return await _userService.ChangeUserPassword(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<UserViewModel>> CreateUser([FromBody] CreateUserCommand request)
        {
            try
            {
                return await _userService.CreateUser(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<UserViewModel>> DeleteUser([FromRoute] int id)
        {
            try
            {
                return await _userService.DeleteUser(new DeleteUserCommand()
                {
                    Id = id
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("delete-account")]
        public async Task<ActionResult<UserViewModel>> DeleteAccount([FromBody] DeleteAccountCommand request)
        {
            try
            {
                return await _userService.DeleteAccount(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("restore/{id}")]
        public async Task<ActionResult<UserViewModel>> RestoreUser([FromRoute] int id)
        {
            try
            {
                return await _userService.RestoreUser(new RestoreUserCommand()
                {
                    Id = id
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("signin")]
        public async Task<ActionResult<UserViewModel>> SigninUser([FromBody] SigninUserCommand request)
        {
            try
            {
                return await _userService.SigninUser(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<UserViewModel>> UpdateUser([FromBody] UpdateUserCommand request)
        {
            try
            {
                return await _userService.UpdateUser(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<UserViewModel>> GetUserById([FromRoute] int id)
        {
            try
            {
                return await _userService.GetUserById(new GetUserByIdQuery()
                {
                    Id = id
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("get-list")]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUserList([FromQuery] GetUserListQuery request)
        {
            try
            {
                return await _userService.GetUserList(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
