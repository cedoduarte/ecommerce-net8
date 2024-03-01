using AutoMapper;
using ecommerce.CQRS.Users.ViewModel;
using ecommerce.Models;
using ecommerce.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.CQRS.Users.Command.SigninUser
{
    public class SigninUserHandler : IRequestHandler<SigninUserCommand, ActionResult<UserViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public SigninUserHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<UserViewModel>> Handle(SigninUserCommand request, CancellationToken cancel)
        {
            try
            {
                ValidateInput(request);

                // Check Existance
                User existingUser = await _dbContext.Users
                    .Where(u => !u.IsDeleted
                           && (string.Compare(u.Username, request.UsernameOrEmail) == 0
                           || string.Compare(u.Email, request.UsernameOrEmail) == 0)
                           && string.Compare(u.PasswordHash, Util.GetSha256(request.Password)) == 0)
                    .FirstOrDefaultAsync(cancel);

                if (existingUser is null)
                {
                    throw new Exception("Wrong username or password!");
                }

                return _mapper.Map<UserViewModel>(existingUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidateInput(SigninUserCommand request)
        {
            if (string.IsNullOrEmpty(request.UsernameOrEmail))
            {
                throw new Exception("The username/email cannot be empty!");
            }
            if (string.IsNullOrEmpty(request.Password))
            {
                throw new Exception("The password cannot be empty!");
            }
        }
    }
}
