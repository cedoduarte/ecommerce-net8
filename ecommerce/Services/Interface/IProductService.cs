using ecommerce.CQRS.Products.Command.CreateProduct;
using ecommerce.CQRS.Products.Command.DeleteProduct;
using ecommerce.CQRS.Products.Command.RestoreProduct;
using ecommerce.CQRS.Products.Command.UpdateProduct;
using ecommerce.CQRS.Products.Query.GetProductById;
using ecommerce.CQRS.Products.Query.GetProductList;
using ecommerce.CQRS.Products.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Services.Interface
{
    public interface IProductService
    {
        Task<ActionResult<ProductViewModel>> CreateProduct(CreateProductCommand request);
        Task<ActionResult<ProductViewModel>> DeleteProduct(DeleteProductCommand request);
        Task<ActionResult<ProductViewModel>> RestoreProduct(RestoreProductCommand request);
        Task<ActionResult<ProductViewModel>> UpdateProduct(UpdateProductCommand request);
        Task<ActionResult<ProductViewModel>> GetProductById(GetProductByIdQuery request);
        Task<ActionResult<IEnumerable<ProductViewModel>>> GetProductList(GetProductListQuery request);
    }
}
