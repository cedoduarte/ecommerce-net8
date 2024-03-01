using AutoMapper;
using ecommerce.CQRS.Users.ViewModel;
using ecommerce.Enums;
using ecommerce.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.CQRS.Users.Query.GetUserList
{
    public class GetUserListHandler : IRequestHandler<GetUserListQuery, ActionResult<IEnumerable<UserViewModel>>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserListHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<UserViewModel>>> Handle(GetUserListQuery request, CancellationToken cancel)
        {
            try
            {
                if (request.GetAll)
                {
                    return new OkObjectResult(_mapper.Map<IEnumerable<UserViewModel>>(
                        await _dbContext.Users
                            .Where(u => !u.IsDeleted)
                            .ToListAsync(cancel))
                    );
                }

                if (string.IsNullOrEmpty(request.Keyword))
                {
                    throw new Exception("The keyword cannot be empty!");
                }
                string keyword = request.Keyword.ToLower().Trim();

                return new OkObjectResult(_mapper.Map<IEnumerable<UserViewModel>>(
                    await _dbContext.Users
                        .Where(u => !u.IsDeleted 
                                && (Convert.ToString(u.Id).Contains(keyword)
                                || u.FirstName.Contains(keyword)
                                || u.LastName.Contains(keyword)
                                || u.Email.Contains(keyword)
                                || u.Username.Contains(keyword)
                                || u.PhoneNumber.Contains(keyword)
                                || Convert.ToString(u.Birthdate).Substring(5, 2).Contains(keyword)
                                || ("enero".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("01"))
                                || ("febrero".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("02"))
                                || ("marzo".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("03"))
                                || ("abril".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("04"))
                                || ("mayo".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("05"))
                                || ("junio".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("06"))
                                || ("julio".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("07"))
                                || ("agosto".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("08"))
                                || ("septiembre".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("09"))
                                || ("octubre".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("10"))
                                || ("noviembre".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("11"))
                                || ("diciembre".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("12"))
                                || ("january".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("01"))
                                || ("february".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("02"))
                                || ("march".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("03"))
                                || ("april".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("04"))
                                || ("may".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("05"))
                                || ("june".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("06"))
                                || ("july".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("07"))
                                || ("august".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("08"))
                                || ("september".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("09"))
                                || ("october".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("10"))
                                || ("november".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("11"))
                                || ("december".Contains(keyword) && Convert.ToString(u.Birthdate).Substring(5, 2).Contains("12"))
                                || u.Country.Contains(keyword)
                                || u.Province.Contains(keyword)
                                || u.City.Contains(keyword)
                                || u.ZipCode.Contains(keyword)
                                || ("comun".Contains(keyword) && u.Type == UserType.Common)
                                || ("común".Contains(keyword) && u.Type == UserType.Common)
                                || ("normal".Contains(keyword) && u.Type == UserType.Common)
                                || ("administrador".Contains(keyword) && u.Type == UserType.Administrator)
                                || ("administrator".Contains(keyword) && u.Type == UserType.Administrator)
                                || Convert.ToString(u.LastModified).Contains(keyword)
                                || ("enero".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("01"))
                                || ("febrero".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("02"))
                                || ("marzo".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("03"))
                                || ("abril".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("04"))
                                || ("mayo".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("05"))
                                || ("junio".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("06"))
                                || ("julio".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("07"))
                                || ("agosto".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("08"))
                                || ("septiembre".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("09"))
                                || ("octubre".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("10"))
                                || ("noviembre".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("11"))
                                || ("diciembre".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("12"))
                                || ("january".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("01"))
                                || ("february".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("02"))
                                || ("march".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("03"))
                                || ("april".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("04"))
                                || ("may".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("05"))
                                || ("june".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("06"))
                                || ("july".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("07"))
                                || ("august".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("08"))
                                || ("september".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("09"))
                                || ("october".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("10"))
                                || ("november".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("11"))
                                || ("december".Contains(keyword) && Convert.ToString(u.LastModified).Substring(5, 2).Contains("12"))
                                || Convert.ToString(u.CreatedDate).Contains(keyword)
                                || ("enero".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("01"))
                                || ("febrero".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("02"))
                                || ("marzo".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("03"))
                                || ("abril".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("04"))
                                || ("mayo".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("05"))
                                || ("junio".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("06"))
                                || ("julio".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("07"))
                                || ("agosto".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("08"))
                                || ("septiembre".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("09"))
                                || ("octubre".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("10"))
                                || ("noviembre".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("11"))
                                || ("diciembre".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("12"))
                                || ("january".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("01"))
                                || ("february".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("02"))
                                || ("march".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("03"))
                                || ("april".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("04"))
                                || ("may".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("05"))
                                || ("june".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("06"))
                                || ("july".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("07"))
                                || ("august".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("08"))
                                || ("september".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("09"))
                                || ("october".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("10"))
                                || ("november".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("11"))
                                || ("december".Contains(keyword) && Convert.ToString(u.CreatedDate).Substring(5, 2).Contains("12"))
                         )
                ).ToListAsync(cancel)));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
