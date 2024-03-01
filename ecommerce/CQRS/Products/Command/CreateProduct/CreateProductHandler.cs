using AutoMapper;
using ecommerce.CQRS.Products.ViewModel;
using ecommerce.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.CQRS.Products.Command.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ActionResult<ProductViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateProductHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<ProductViewModel>> Handle(CreateProductCommand request, CancellationToken cancel)
        {
            try
            {
                ValidateInput(request);
                Product newProduct = CreateProductFromRequest(request);
                await _dbContext.Products.AddAsync(newProduct, cancel);
                await _dbContext.SaveChangesAsync(cancel);
                return _mapper.Map<ProductViewModel>(newProduct);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Product CreateProductFromRequest(CreateProductCommand request)
        {
            return new Product()
            {
                Name = request.Name.Trim(),
                Description = request.Description.Trim(),
                Price = request.Price,
                Stock = request.Stock,
                Imagehref = request.Imagehref
            };
        }

        private void ValidateInput(CreateProductCommand request)
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
            if (request.Stock < 0)
            {
                throw new Exception("The stock needs to be equal or greater than zero");
            }
            if (string.IsNullOrEmpty(request.Imagehref))
            {
                throw new Exception("The image URL cannot be empty!");
            }
        }
    }
}
