using AutoMapper;
using ecommerce.CQRS.Products.ViewModel;
using ecommerce.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.CQRS.Products.Query.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ActionResult<ProductViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<ProductViewModel>> Handle(GetProductByIdQuery request, CancellationToken cancel)
        {
            try
            {
                Product selectedProduct = await _dbContext.Products.Where(p => !p.IsDeleted && p.Id == request.Id).FirstOrDefaultAsync(cancel);
                if (selectedProduct is null)
                {
                    throw new Exception($"The product with ID '{request.Id}' does not exist!");
                }
                return _mapper.Map<ProductViewModel>(selectedProduct);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
