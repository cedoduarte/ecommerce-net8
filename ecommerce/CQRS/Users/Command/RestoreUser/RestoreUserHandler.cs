using AutoMapper;
using ecommerce.CQRS.Users.ViewModel;
using ecommerce.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.CQRS.Users.Command.RestoreUser
{
    public class RestoreUserHandler : IRequestHandler<RestoreUserCommand, ActionResult<UserViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public RestoreUserHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<UserViewModel>> Handle(RestoreUserCommand request, CancellationToken cancel)
        {
            try
            {
                User selectedUser = await _dbContext.Users
                    .Where(u => u.Id == request.Id)
                    .FirstOrDefaultAsync(cancel);
                if (selectedUser is null)
                {
                    throw new Exception($"The user with ID '{request.Id}' does not exist!");
                }
                if (!selectedUser.IsDeleted) 
                {
                    throw new Exception($"The user with ID '{request.Id}' already exists!");
                }

                selectedUser.IsDeleted = false;
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
    }
}
