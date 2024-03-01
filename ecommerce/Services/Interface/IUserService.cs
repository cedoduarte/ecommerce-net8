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
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Services.Interface
{
    public interface IUserService
    {
        Task<ActionResult<UserViewModel>> ChangeUserPassword(ChangeUserPasswordCommand request);
        Task<ActionResult<UserViewModel>> CreateUser(CreateUserCommand request);
        Task<ActionResult<UserViewModel>> DeleteUser(DeleteUserCommand request);
        Task<ActionResult<UserViewModel>> DeleteAccount(DeleteAccountCommand request);
        Task<ActionResult<UserViewModel>> RestoreUser(RestoreUserCommand request);
        Task<ActionResult<UserViewModel>> SigninUser(SigninUserCommand request);
        Task<ActionResult<UserViewModel>> UpdateUser(UpdateUserCommand request);
        Task<ActionResult<UserViewModel>> GetUserById(GetUserByIdQuery request);
        Task<ActionResult<IEnumerable<UserViewModel>>> GetUserList(GetUserListQuery request);
    }
}
