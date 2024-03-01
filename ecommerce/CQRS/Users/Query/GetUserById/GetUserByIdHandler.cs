using AutoMapper;
using ecommerce.CQRS.Users.ViewModel;
using ecommerce.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.CQRS.Users.Query.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ActionResult<UserViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancel)
        {
            try
            {
                User selectedUser = await _dbContext.Users
                    .Where(u => !u.IsDeleted && u.Id == request.Id)
                    .FirstOrDefaultAsync(cancel);
                if (selectedUser is null)
                {
                    throw new Exception($"The user with ID '{request.Id}' does not exist!");
                }
                return _mapper.Map<UserViewModel>(selectedUser);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
