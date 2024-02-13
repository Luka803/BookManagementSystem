using BookManagementSystem.Domain;
using BookManagementSystem.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystem.Persistence.DataBaseContext;

public class BookManagementSystemDbContext : DbContext
{
    public BookManagementSystemDbContext(DbContextOptions<BookManagementSystemDbContext> options) : base(options)
    {

    }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Review> Reviews { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
            .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.CreatedDate = DateTime.Now;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.ModifiedDate = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
