using System.Linq.Expressions;
using Domain.Aggregates.Entities;
using Domain.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderDbContext _context;

    public OrderRepository(OrderDbContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<Order>> GetOrdersAsync(CancellationToken cancellationToken)
    {
        return await _context.Orders
            .AsNoTracking()
            .Include(order => order.LineItems)
            .ToListAsync(cancellationToken: cancellationToken);
    }
    
    public async Task<ICollection<TResult>> GetOrdersAsync<TResult>(Expression<Func<Order, TResult>> selector, CancellationToken cancellationToken)
    {
        return await _context.Orders
            .AsNoTracking()
            .Include(order => order.LineItems)
            .Select(selector)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task SaveAsync(Order order, CancellationToken cancellationToken)
    {
        if (order.LineItems != null) _context.LineItems.AddRange(order.LineItems);
        
        _context.Orders.Add(order);
         await _context.SaveChangesAsync(cancellationToken);
    }
}