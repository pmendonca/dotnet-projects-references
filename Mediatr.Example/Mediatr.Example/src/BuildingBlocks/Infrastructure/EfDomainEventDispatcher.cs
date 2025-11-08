using Mediatr.Example.src.BuildingBlocks.Domain;
using MediatR;

namespace Mediatr.Example.src.BuildingBlocks.Infrastructure
{
    public class EfDomainEventDispatcher(IMediator mediator) : IDomainEventDispatcher
    {
        public Task Dispatch(DomainEvent @event, CancellationToken ct = default)
            => mediator.Publish(@event, ct);

        public async Task Dispatch(IEnumerable<DomainEvent> events, CancellationToken ct = default)
        {
            foreach (var e in events) await mediator.Publish(e, ct);
        }
    }
}
