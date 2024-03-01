using ecommerce.CQRS.Users.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.CQRS.Users.Query.GetUserById
{
    public class GetUserByIdQuery : IRequest<ActionResult<UserViewModel>>
    {
        public int Id { get; set; }
    }
}
