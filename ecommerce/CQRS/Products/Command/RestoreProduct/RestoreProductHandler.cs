using AutoMapper;
using ecommerce.CQRS.Products.ViewModel;
using ecommerce.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.CQRS.Products.Command.RestoreProduct
{
    public class RestoreProductHandler : IRequestHandler<RestoreProductCommand, ActionResult<ProductViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public RestoreProductHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<ProductViewModel>> Handle(RestoreProductCommand request, CancellationToken cancel)
        {
            try
            {
                Product selectedProduct = await _dbContext.Products
                    .Where(u => u.Id == request.Id)
                    .FirstOrDefaultAsync(cancel);
                if (selectedProduct is null)
                {
                    throw new Exception($"The product with ID '{request.Id}' does not exist!");
                }
                if (!selectedProduct.IsDeleted)
                {
                    throw new Exception($"The product with ID '{request.Id}' already exists!");
                }

                selectedProduct.IsDeleted = false;
                selectedProduct.LastModified = DateTime.Now;
                _dbContext.Products.Update(selectedProduct);
                await _dbContext.SaveChangesAsync(cancel);
                return _mapper.Map<ProductViewModel>(selectedProduct);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
