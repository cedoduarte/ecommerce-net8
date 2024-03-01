using AutoMapper;
using ecommerce.CQRS.Users.ViewModel;
using ecommerce.Models;
using ecommerce.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.CQRS.Users.Command.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, ActionResult<UserViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateUserHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<UserViewModel>> Handle(CreateUserCommand request, CancellationToken cancel)
        {
            try
            {
                ValidateInput(request);
                
                // Check Existance
                User existingUser = await _dbContext.Users
                    .Where(u =>
                        !u.IsDeleted
                        && (string.Compare(u.Username, request.Username.Trim()) == 0
                            || string.Compare(u.Email, request.Email.Trim()) == 0))
                    .FirstOrDefaultAsync(cancel);
                if (existingUser is not null)
                {
                    throw new Exception($"The user with username '{request.Username}' or email '{request.Email}' already exists!");
                }

                User newUser = CreateUserFromRequest(request);
                await _dbContext.Users.AddAsync(newUser, cancel);
                await _dbContext.SaveChangesAsync(cancel);
                return _mapper.Map<UserViewModel>(newUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private User CreateUserFromRequest(CreateUserCommand request)
        {
            return new User()
            {
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                Email = request.Email.Trim(),
                Username = request.Username.Trim(),
                PasswordHash = Util.GetSha256(request.Password),
                PhoneNumber = request.PhoneNumber.Trim(),
                Birthdate = request.Birthdate,
                Country = request.Country.Trim(),
                Province = request.Province.Trim(),
                City = request.City.Trim(),
                ZipCode = request.ZipCode.Trim(),
                Type = request.Type
            };
        }

        private void ValidateInput(CreateUserCommand request)
        {
            if (string.IsNullOrEmpty(request.FirstName))
            {
                throw new Exception("The first name cannot be empty!");
            }
            if (string.IsNullOrEmpty(request.LastName))
            {
                throw new Exception("The last name cannot be empty!");
            }
            if (string.IsNullOrEmpty(request.Email))
            {
                throw new Exception("The email cannot be empty!");
            }
            if (string.IsNullOrEmpty(request.ConfirmedEmail))
            {
                throw new Exception("The confirmed email cannot be empty!");
            }
            if (string.Compare(request.Email, request.ConfirmedEmail) != 0)
            {
                throw new Exception("The email needs to be confirmed correctly!");
            }
            if (string.IsNullOrEmpty(request.Username))
            {
                throw new Exception("The username cannot be empty!");
            }
            if (string.IsNullOrEmpty(request.Password))
            {
                throw new Exception("The password cannot be empty!");
            }
            if (string.IsNullOrEmpty(request.ConfirmedPassword))
            {
                throw new Exception("The confirmed password cannot be empty!");
            }
            if (string.Compare(request.Password, request.ConfirmedPassword) != 0)
            {
                throw new Exception("The password needs to be confirmed correctly!");
            }
            if (string.IsNullOrEmpty(request.PhoneNumber))
            {
                throw new Exception("The phone number cannot be empty!");
            }
            if (string.IsNullOrEmpty(request.Country))
            {
                throw new Exception("The country cannot be empty!");
            }
            if (string.IsNullOrEmpty(request.Province))
            {
                throw new Exception("The province cannot be empty!");
            }
            if (string.IsNullOrEmpty(request.City))
            {
                throw new Exception("The city cannot be empty!");
            }
            if (string.IsNullOrEmpty(request.ZipCode))
            {
                throw new Exception("The zip code cannot be empty!");
            }
        }
    }
}
