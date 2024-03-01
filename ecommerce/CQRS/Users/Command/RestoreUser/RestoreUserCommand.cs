using ecommerce.CQRS.Users.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.CQRS.Users.Command.RestoreUser
{
    public class RestoreUserCommand : IRequest<ActionResult<UserViewModel>>
    {
        public int Id { get; set; }
    }
}
