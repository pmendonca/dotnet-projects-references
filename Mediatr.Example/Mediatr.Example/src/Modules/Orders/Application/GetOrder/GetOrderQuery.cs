using MediatR;

namespace Mediatr.Example.src.Modules.Orders.Application.GetOrder
{    
    public sealed record GetOrderQuery(Guid Id) : IRequest<OrderDto>;

    public sealed record OrderDto(Guid Id, string CustomerName, decimal Total);
}
