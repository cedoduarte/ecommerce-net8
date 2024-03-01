using ecommerce.CQRS.Products.Command.CreateProduct;
using ecommerce.CQRS.Products.Command.DeleteProduct;
using ecommerce.CQRS.Products.Command.RestoreProduct;
using ecommerce.CQRS.Products.Command.UpdateProduct;
using ecommerce.CQRS.Products.Query.GetProductById;
using ecommerce.CQRS.Products.Query.GetProductList;
using ecommerce.CQRS.Products.ViewModel;
using ecommerce.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<ProductViewModel>> CreateProduct([FromBody] CreateProductCommand request)
        {
            try
            {
                return await _productService.CreateProduct(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ProductViewModel>> DeleteProduct([FromRoute] int id)
        {
            try
            {
                return await _productService.DeleteProduct(new DeleteProductCommand()
                {
                    Id = id
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("restore/{id}")]
        public async Task<ActionResult<ProductViewModel>> RestoreProduct([FromRoute] int id)
        {
            try
            {
                return await _productService.RestoreProduct(new RestoreProductCommand()
                {
                    Id = id
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<ProductViewModel>> UpdateProduct([FromBody] UpdateProductCommand request)
        {
            try
            {
                return await _productService.UpdateProduct(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<ProductViewModel>> GetProductById([FromRoute] int id)
        {
            try
            {
                return await _productService.GetProductById(new GetProductByIdQuery()
                {
                    Id = id
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("get-list")]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProductList([FromQuery] GetProductListQuery request)
        {
            try
            {
                return await _productService.GetProductList(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
