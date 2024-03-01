using ecommerce.CQRS.Products.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.CQRS.Products.Command.DeleteProduct
{
    public class DeleteProductCommand : IRequest<ActionResult<ProductViewModel>>
    {
        public int Id { get; set; }
    }
}
