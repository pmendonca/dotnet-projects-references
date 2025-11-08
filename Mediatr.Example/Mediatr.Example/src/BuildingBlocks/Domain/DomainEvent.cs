using MediatR;

namespace Mediatr.Example.src.BuildingBlocks.Domain
{
    public abstract record DomainEvent(DateTime OccurredOn) : INotification;
}
