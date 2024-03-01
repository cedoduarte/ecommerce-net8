using AutoMapper;
using ecommerce.CQRS.Products.ViewModel;
using ecommerce.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.CQRS.Products.Query.GetProductList
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, ActionResult<IEnumerable<ProductViewModel>>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductListHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Handle(GetProductListQuery request, CancellationToken cancel)
        {
            try
            {
                if (request.GetAll)
                {
                    return new OkObjectResult(_mapper.Map<IEnumerable<ProductViewModel>>(
                        await _dbContext.Products
                            .Where(p => !p.IsDeleted)
                            .ToListAsync(cancel))
                    );
                }

                if (string.IsNullOrEmpty(request.Keyword))
                {
                    throw new Exception("The keyword cannot be empty!");
                }
                string keyword = request.Keyword.ToLower().Trim();

                return new OkObjectResult(_mapper.Map<IEnumerable<ProductViewModel>>(
                    await _dbContext.Products
                        .Where(p => !p.IsDeleted
                            && (Convert.ToString(p.Id).Contains(keyword)
                            || p.Name.Contains(keyword)
                            || p.Description.Contains(keyword)
                            || Convert.ToString(p.Price).Contains(keyword)
                            || Convert.ToString(p.Stock).Contains(keyword)
                            || Convert.ToString(p.LastModified).Contains(keyword)
                            || ("enero".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("01"))
                            || ("febrero".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("02"))
                            || ("marzo".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("03"))
                            || ("abril".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("04"))
                            || ("mayo".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("05"))
                            || ("junio".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("06"))
                            || ("julio".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("07"))
                            || ("agosto".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("08"))
                            || ("septiembre".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("09"))
                            || ("octubre".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("10"))
                            || ("noviembre".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("11"))
                            || ("diciembre".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("12"))
                            || ("january".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("01"))
                            || ("february".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("02"))
                            || ("march".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("03"))
                            || ("april".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("04"))
                            || ("may".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("05"))
                            || ("june".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("06"))
                            || ("july".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("07"))
                            || ("august".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("08"))
                            || ("september".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("09"))
                            || ("october".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("10"))
                            || ("november".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("11"))
                            || ("december".Contains(keyword) && Convert.ToString(p.LastModified).Substring(5, 2).Contains("12"))
                            || Convert.ToString(p.CreatedDate).Contains(keyword)
                            || ("enero".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("01"))
                            || ("febrero".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("02"))
                            || ("marzo".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("03"))
                            || ("abril".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("04"))
                            || ("mayo".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("05"))
                            || ("junio".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("06"))
                            || ("julio".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("07"))
                            || ("agosto".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("08"))
                            || ("septiembre".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("09"))
                            || ("octubre".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("10"))
                            || ("noviembre".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("11"))
                            || ("diciembre".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("12"))
                            || ("january".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("01"))
                            || ("february".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("02"))
                            || ("march".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("03"))
                            || ("april".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("04"))
                            || ("may".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("05"))
                            || ("june".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("06"))
                            || ("july".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("07"))
                            || ("august".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("08"))
                            || ("september".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("09"))
                            || ("october".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("10"))
                            || ("november".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("11"))
                            || ("december".Contains(keyword) && Convert.ToString(p.CreatedDate).Substring(5, 2).Contains("12"))
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
