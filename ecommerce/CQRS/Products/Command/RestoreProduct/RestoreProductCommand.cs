using ecommerce.CQRS.Products.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.CQRS.Products.Command.RestoreProduct
{
    public class RestoreProductCommand : IRequest<ActionResult<ProductViewModel>>
    {
        public int Id { get; set; }
    }
}
