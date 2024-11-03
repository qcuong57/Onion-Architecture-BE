using Microsoft.EntityFrameworkCore;
using OA.Domain.Entities;

namespace OA.Application.Interface
{
    public interface IApplicationDbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<BookCatalogue> BookCatalogues { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<CartDetail> CartDetails { get; set; }
        DbSet<Catalogue> Catalogues { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync();
    }
}
