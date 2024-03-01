using ecommerce.CQRS.Users.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.CQRS.Users.Command.ChangeUserPassword
{
    public class ChangeUserPasswordCommand : IRequest<ActionResult<UserViewModel>>
    {
        public string UsernameOrEmail { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmedPassword { get; set; }
    }
}
