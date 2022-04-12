using Domain.Aggregates.Entities;
using Domain.Common;
using MediatR;

namespace Application.Commands;

public class CreateNewOrderCommand : IRequest<Order>
{
    public ICollection<int> ItemIds { get; set; }
}

public class CreateNewOrderCommandHandler : IRequestHandler<CreateNewOrderCommand, Order>
{
    private readonly IOrderRepository _orderRepo;

    public CreateNewOrderCommandHandler(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }
    
    public async Task<Order> Handle(CreateNewOrderCommand request, CancellationToken cancellationToken)
    {
        var itemIds = request.ItemIds;
        // Verify items in inventory service
        // ...
        
        // Mock items
        var items = new List<LineItem>
        {
            new LineItem {ProductId = 1, Name = "Keyboard", Amount = 6999, Quantity = 1},
            new LineItem {ProductId = 2, Name = "Mouse", Amount = 5699, Quantity = 1},
        };

        var newOrder = new Order(items);
        await _orderRepo.SaveAsync(newOrder, cancellationToken);
        return newOrder;
    }
}