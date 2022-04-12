namespace Domain.Aggregates.Entities;

public class LineItem
{
    public int  ProductId { get; set; }
    public int OrderId { get; set; }
    public string? Name { get; set; }
    public int  Amount { get; set; }
    public int Quantity { get; set; }
}