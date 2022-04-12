using Domain.Aggregates.ValueObjects;
using Domain.Common;

namespace Domain.Aggregates.Entities;

public class Order : IAggregateRoot
{
    public int Id { get; set; }
    public virtual IEnumerable<LineItem>? LineItems { get; set; }
    public OrderStatus Status { get; set; }
    
    public Order() {}
    public Order(IEnumerable<LineItem> lineItems)
    {
        LineItems = lineItems;
        Status = OrderStatus.Pending;
    }
}

