using ecommerce.CQRS.Users.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.CQRS.Users.Query.GetUserList
{
    public class GetUserListQuery : IRequest<ActionResult<IEnumerable<UserViewModel>>>
    {
        public string Keyword { get; set; }
        public bool GetAll { get; set; }
    }
}
