using ecommerce.CQRS.Products.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.CQRS.Products.Query.GetProductList
{
    public class GetProductListQuery : IRequest<ActionResult<IEnumerable<ProductViewModel>>>
    {
        public string Keyword { get; set; }
        public bool GetAll { get; set; }
    }
}
