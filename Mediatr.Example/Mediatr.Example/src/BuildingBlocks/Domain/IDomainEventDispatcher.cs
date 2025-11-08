namespace Mediatr.Example.src.BuildingBlocks.Domain
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(DomainEvent @event, CancellationToken ct = default);
        Task Dispatch(IEnumerable<DomainEvent> events, CancellationToken ct = default);
    }
}