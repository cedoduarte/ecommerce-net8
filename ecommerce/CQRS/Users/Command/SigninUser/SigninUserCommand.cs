using ecommerce.CQRS.Users.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.CQRS.Users.Command.SigninUser
{
    public class SigninUserCommand : IRequest<ActionResult<UserViewModel>>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
