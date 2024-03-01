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

namespace ecommerce.Services
{
    public class UserService : IUserService
    {
        private readonly IMediator _mediator;

        public UserService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult<UserViewModel>> ChangeUserPassword(ChangeUserPasswordCommand request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<UserViewModel>> CreateUser(CreateUserCommand request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<UserViewModel>> DeleteUser(DeleteUserCommand request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<UserViewModel>> DeleteAccount(DeleteAccountCommand request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<UserViewModel>> RestoreUser(RestoreUserCommand request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<UserViewModel>> SigninUser(SigninUserCommand request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<UserViewModel>> UpdateUser(UpdateUserCommand request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<UserViewModel>> GetUserById(GetUserByIdQuery request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUserList(GetUserListQuery request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
