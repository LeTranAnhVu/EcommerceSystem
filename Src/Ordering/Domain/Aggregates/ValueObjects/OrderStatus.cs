namespace Domain.Aggregates.ValueObjects;

public enum OrderStatus
{
    Pending = 1,
    Paid,
    Shipping,
    Delivered,
    PickedUp,
    Canceled
}