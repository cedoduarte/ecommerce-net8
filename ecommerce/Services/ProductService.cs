using ecommerce.CQRS.Products.Command.CreateProduct;
using ecommerce.CQRS.Products.Command.DeleteProduct;
using ecommerce.CQRS.Products.Command.RestoreProduct;
using ecommerce.CQRS.Products.Command.UpdateProduct;
using ecommerce.CQRS.Products.Query.GetProductById;
using ecommerce.CQRS.Products.Query.GetProductList;
using ecommerce.CQRS.Products.ViewModel;
using ecommerce.Services.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult<ProductViewModel>> CreateProduct(CreateProductCommand request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<ProductViewModel>> DeleteProduct(DeleteProductCommand request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<ActionResult<ProductViewModel>> RestoreProduct(RestoreProductCommand request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<ProductViewModel>> UpdateProduct(UpdateProductCommand request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<ProductViewModel>> GetProductById(GetProductByIdQuery request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProductList(GetProductListQuery request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
