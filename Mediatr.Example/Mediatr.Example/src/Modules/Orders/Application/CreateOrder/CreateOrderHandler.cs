using Mediatr.Example.src.BuildingBlocks.Domain;
using Mediatr.Example.src.Modules.Orders.Domain;
using MediatR;

namespace Mediatr.Example.src.Modules.Orders.Application.CreateOrder
{
    public sealed class CreateOrderHandler(IOrderRepository repo, IUnitOfWork uow) : IRequestHandler<CreateOrderCommand, Guid>
    {
        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken ct)
        {
            var order = Order.Create(request.CustomerName, request.Total);

            await repo.AddAsync(order, ct);
            await uow.CommitAsync(ct);
            return order.Id;
        }
    }
}
