using System.Linq.Expressions;
using Domain.Aggregates;
using Domain.Aggregates.Entities;

namespace Domain.Common;

public interface IOrderRepository
{
    public Task<ICollection<Order>> GetOrdersAsync(CancellationToken cancellationToken);

    public Task<ICollection<TResult>> GetOrdersAsync<TResult>(
        Expression<Func<Order, TResult>> selector,
        CancellationToken cancellationToken);

    public Task SaveAsync(Order order, CancellationToken cancellationToken);
}