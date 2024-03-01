using AutoMapper;
using ecommerce.CQRS.Users.ViewModel;
using ecommerce.Models;
using ecommerce.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.CQRS.Users.Command.DeleteAccount
{
    public class DeleteAccountHandler : IRequestHandler<DeleteAccountCommand, ActionResult<UserViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteAccountHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<UserViewModel>> Handle(DeleteAccountCommand request, CancellationToken cancel)
        {
            try
            {
                ValidateInput(request);

                User selectedUser = await _dbContext.Users
                    .Where(u => !u.IsDeleted 
                           && (string.Compare(u.Username, request.UsernameOrEmail) == 0 
                           || string.Compare(u.Email, request.UsernameOrEmail) == 0)
                           && string.Compare(u.PasswordHash, Util.GetSha256(request.CurrentPassword)) == 0)
                    .FirstOrDefaultAsync(cancel);

                if (selectedUser is null)
                {
                    throw new Exception("Wrong username or password!");
                }

                selectedUser.IsDeleted = true;
                selectedUser.LastModified = DateTime.Now;
                _dbContext.Users.Update(selectedUser);
                await _dbContext.SaveChangesAsync(cancel);
                return _mapper.Map<UserViewModel>(selectedUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidateInput(DeleteAccountCommand request)
        {
            if (string.IsNullOrEmpty(request.UsernameOrEmail))
            {
                throw new Exception("The username/email cannot be empty!");
            }
            if (string.IsNullOrEmpty(request.CurrentPassword))
            {
                throw new Exception("The current password cannot be empty!");
            }
            if (string.IsNullOrEmpty(request.ConfirmedPassword))
            {
                throw new Exception("The confirmed password cannot be empty!");
            }
            if (string.Compare(request.CurrentPassword, request.ConfirmedPassword) != 0)
            {
                throw new Exception("The password needs to be confirmed!");
            }
        }
    }
}
