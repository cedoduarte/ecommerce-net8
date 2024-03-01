using ecommerce.CQRS.Users.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.CQRS.Users.Command.DeleteAccount
{
    public class DeleteAccountCommand : IRequest<ActionResult<UserViewModel>>
    {
        public string UsernameOrEmail { get; set; }
        public string CurrentPassword { get; set; }
        public string ConfirmedPassword { get; set; }
    }
}
