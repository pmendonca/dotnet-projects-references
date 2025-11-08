using MediatR;

namespace Mediatr.Example.src.Modules.Orders.Application.CreateOrder;

public record CreateOrderCommand(string CustomerName, decimal Total) : IRequest<Guid>;

