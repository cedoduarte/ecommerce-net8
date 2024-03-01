using ecommerce.CQRS.Users.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.CQRS.Users.Command.DeleteUser
{
    public class DeleteUserCommand : IRequest<ActionResult<UserViewModel>>
    {
        public int Id { get; set; }
    }
}
