using Application.Dtos;
using Domain.Common;
using MediatR;

namespace Application.Queries;

public class GetAllOrdersQuery : IRequest<ICollection<OrderDto>>
{
}

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, ICollection<OrderDto>>
{
    private readonly IOrderRepository _orderRepo;

    public GetAllOrdersQueryHandler(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }

    public async Task<ICollection<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepo.GetOrdersAsync(order => new OrderDto
        {
            Id = order.Id,
            Status = order.Status, 
            ItemNames = order.LineItems.Select(item => item.Name).ToList()
        }, cancellationToken);
    }
}