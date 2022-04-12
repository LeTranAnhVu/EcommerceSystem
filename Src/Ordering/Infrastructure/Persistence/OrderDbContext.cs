using Domain.Aggregates.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options): base(options)
    { }

    public DbSet<Order> Orders { get; set; }
    
    public DbSet<LineItem> LineItems { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().ToTable(nameof(Order));
        modelBuilder.Entity<LineItem>().ToTable(nameof(LineItem));
        
        modelBuilder.Entity<Order>().HasKey(order => order.Id);
        
        modelBuilder
            .Entity<Order>()
            .HasMany<LineItem>(order => order.LineItems)
            .WithOne()
            .HasForeignKey(lineItem => lineItem.OrderId);

        modelBuilder.Entity<LineItem>()
            .HasKey(nameof(LineItem.ProductId), nameof(LineItem.OrderId));
    }
}