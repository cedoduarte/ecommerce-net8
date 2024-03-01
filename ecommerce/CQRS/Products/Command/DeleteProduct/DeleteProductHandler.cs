using AutoMapper;
using ecommerce.CQRS.Products.ViewModel;
using ecommerce.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.CQRS.Products.Command.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ActionResult<ProductViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteProductHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<ProductViewModel>> Handle(DeleteProductCommand request, CancellationToken cancel)
        {
            try
            {
                Product selectedProduct = await _dbContext.Products
                    .Where(p => !p.IsDeleted && p.Id == request.Id)
                    .FirstOrDefaultAsync(cancel);
                if (selectedProduct is null)
                {
                    throw new Exception($"The product with ID '{request.Id}' does not exist");
                }
                selectedProduct.IsDeleted = true;
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
