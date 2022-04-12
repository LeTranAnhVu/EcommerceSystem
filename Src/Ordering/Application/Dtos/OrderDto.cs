using Domain.Aggregates.ValueObjects;

namespace Application.Dtos;

public class OrderDto
{
    public OrderStatus Status { get; set; }  
    public int Id { get; set; }
    public ICollection<string> ItemNames { get; set; }
}