using Microsoft.EntityFrameworkCore;

namespace ecommerce.Models.Interface
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Product> Products { get; set; }
    }
}
