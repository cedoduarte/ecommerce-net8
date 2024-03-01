using AutoMapper;
using ecommerce.CQRS.Users.ViewModel;
using ecommerce.Models;
using ecommerce.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.CQRS.Users.Command.ChangeUserPassword
{
    public class ChangeUserPasswordHandler : IRequestHandler<ChangeUserPasswordCommand, ActionResult<UserViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ChangeUserPasswordHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<UserViewModel>> Handle(ChangeUserPasswordCommand request, CancellationToken cancel)
        {
            try
            {
                ValidateInput(request);
                User selectedUser = await GetSelectedUser(request, cancel);
                selectedUser.PasswordHash = Util.GetSha256(request.NewPassword);
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

        private async Task<User> GetSelectedUser(ChangeUserPasswordCommand request, CancellationToken cancel)
        {
            User selectedUser = await _dbContext.Users.Where(u =>
                !u.IsDeleted
                && (string.Compare(u.Username, request.UsernameOrEmail.Trim()) == 0 
                   || string.Compare(u.Email, request.UsernameOrEmail.Trim()) == 0)
                && string.Compare(u.PasswordHash, Util.GetSha256(request.OldPassword)) == 0
            ).FirstOrDefaultAsync(cancel);
            if (selectedUser is null)
            {
                throw new Exception($"The user's current password is wrong or the username/email '{request.UsernameOrEmail}' does not exist!");
            }
            return selectedUser;
        }

        private void ValidateInput(ChangeUserPasswordCommand request)
        {
            if (string.IsNullOrEmpty(request.UsernameOrEmail))
            {
                throw new Exception("The username of email cannot be empty!");
            }
            if (string.IsNullOrEmpty(request.OldPassword))
            {
                throw new Exception("The old password cannot be empty!");
            }
            if (string.IsNullOrEmpty(request.NewPassword))
            {
                throw new Exception("The new password cannot be empty!");
            }
            if (string.IsNullOrEmpty(request.ConfirmedPassword))
            {
                throw new Exception("The confirmed password cannot be empty!");
            }
            if (!string.Equals(request.NewPassword, request.ConfirmedPassword))
            {
                throw new Exception("The passwords need to match!");
            }
            if (!Util.IsValidPassword(request.NewPassword))
            {
                throw new Exception("The password needs to have a minimum length of 8, an upper case letter, a lower case letter, a digit, a special character!");
            }
        }
    }
}
