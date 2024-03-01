using ecommerce.CQRS.Products.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.CQRS.Products.Command.CreateProduct
{
    public class CreateProductCommand : IRequest<ActionResult<ProductViewModel>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Imagehref { get; set; }
    }
}
