using Mediatr.Example.src.BuildingBlocks.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mediatr.Example.src.BuildingBlocks.Infrastructure
{
    public class AppDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public AppDbContext(DbContextOptions<AppDbContext> options,
                            IDomainEventDispatcher dispatcher) : base(options)
            => _dispatcher = dispatcher;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public async Task DispatchDomainEventsAsync(CancellationToken ct = default)
        {
            var entities = ChangeTracker.Entries<Entity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToList();

            var events = entities.SelectMany(e => e.DomainEvents).ToList();
            entities.ForEach(e => e.ClearDomainEvents());

            foreach (var @event in events)
                await _dispatcher.Dispatch(@event, ct);
        }

        //public static implicit operator AppContext(AppDbContext v)
        //{
        //    throw new NotImplementedException();
        //}
    }

}
