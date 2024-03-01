using AutoMapper;
using ecommerce.CQRS.Users.ViewModel;
using ecommerce.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.CQRS.Users.Command.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ActionResult<UserViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateUserHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<UserViewModel>> Handle(UpdateUserCommand request, CancellationToken cancel)
        {
            try
            {
                ValidateInput(request);
                User selectedUser = await _dbContext.Users
                    .Where(u => !u.IsDeleted && u.Id == request.Id)
                    .FirstOrDefaultAsync(cancel);
                if (selectedUser is null)
                {
                    throw new Exception($"The user with ID {request.Id} does not exist!");
                }
                ModifyUser(ref selectedUser, request);
                _dbContext.Users.Update(selectedUser);
                await _dbContext.SaveChangesAsync(cancel);
                return _mapper.Map<UserViewModel>(selectedUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ModifyUser(ref User selectedUser, UpdateUserCommand request)
        {
            selectedUser.FirstName = request.FirstName.Trim();
            selectedUser.LastName = request.LastName.Trim();
            selectedUser.Email = request.Email.Trim();
            selectedUser.PhoneNumber = request.PhoneNumber.Trim();
            selectedUser.Birthdate = request.Birthdate;
            selectedUser.Country = request.Country.Trim();
            selectedUser.Province = request.Province.Trim();
            selectedUser.City = request.City.Trim();
            selectedUser.ZipCode = request.ZipCode.Trim();
            selectedUser.LastModified = DateTime.Now;
        }

        private void ValidateInput(UpdateUserCommand request)
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
