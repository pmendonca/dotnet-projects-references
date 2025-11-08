
using Mediatr.Example.src.Modules.Orders.Domain;
using MediatR;

namespace Mediatr.Example.src.Modules.Orders.Application.GetOrder
{
    public sealed class GetOrderHandler(IOrderRepository repo) : IRequestHandler<GetOrderQuery, OrderDto>
    {
        public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken ct)
        {
            var dto = await repo.GetByIdAsync(request.Id);

            return dto is null
                ? throw new KeyNotFoundException($"Order {request.Id} not found")
                : new OrderDto(dto.Id, dto.CustomerName, dto.Total);
        }
    }
}
