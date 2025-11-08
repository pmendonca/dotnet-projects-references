namespace Mediatr.Example.src.BuildingBlocks.Domain
{    
    public abstract class Entity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
        private readonly List<DomainEvent> _events = new();
        public IReadOnlyCollection<DomainEvent> DomainEvents => _events.AsReadOnly();
        protected void Raise(DomainEvent @event) => _events.Add(@event);
        public void ClearDomainEvents() => _events.Clear();
    }
}
