using AutoMapper;
using ecommerce.CQRS.Products.ViewModel;
using ecommerce.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.CQRS.Products.Command.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ActionResult<ProductViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateProductHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<ProductViewModel>> Handle(UpdateProductCommand request, CancellationToken cancel)
        {
            try
            {
                ValidateInput(request);
                Product selectedProduct = await _dbContext.Products
                    .Where(p => !p.IsDeleted && p.Id == request.Id)
                    .FirstOrDefaultAsync(cancel);
                if (selectedProduct is null)
                {
                    throw new Exception($"The product with ID '{request.Id}' does not exists");
                }
                ModifyProduct(ref selectedProduct, request);
                _dbContext.Products.Update(selectedProduct);
                await _dbContext.SaveChangesAsync(cancel);
                return _mapper.Map<ProductViewModel>(selectedProduct);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ModifyProduct(ref Product selectedProduct, UpdateProductCommand request)
        {
            selectedProduct.Name = request.Name.Trim();
            selectedProduct.Description = request.Description.Trim();
            selectedProduct.Price = request.Price;
            selectedProduct.Imagehref = request.Imagehref;
        }

        private void ValidateInput(UpdateProductCommand request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new Exception("The name cannot be empty!");
            }
            if (string.IsNullOrEmpty(request.Description))
            {
                throw new Exception("The description cannot be empty!");
            }
            if (request.Price <= 0.0m)
            {
                throw new Exception("The price needs to be greater than zero!");
            }
            if (string.IsNullOrEmpty(request.Imagehref))
            {
                throw new Exception("The image URL cannot be emtyp!");
            }
        }
    }
}
