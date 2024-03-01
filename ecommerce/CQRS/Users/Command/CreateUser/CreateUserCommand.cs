using ecommerce.CQRS.Users.ViewModel;
using ecommerce.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.CQRS.Users.Command.CreateUser
{
    public class CreateUserCommand : IRequest<ActionResult<UserViewModel>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ConfirmedEmail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public UserType Type { get; set; }
    }
}
