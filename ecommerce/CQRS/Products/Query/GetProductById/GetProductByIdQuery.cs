using ecommerce.CQRS.Products.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.CQRS.Products.Query.GetProductById
{
    public class GetProductByIdQuery : IRequest<ActionResult<ProductViewModel>>
    {
        public int Id { get; set; }
    }
}
