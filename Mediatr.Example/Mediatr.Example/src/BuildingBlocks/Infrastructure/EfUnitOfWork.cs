using Mediatr.Example.src.BuildingBlocks.Domain;

namespace Mediatr.Example.src.BuildingBlocks.Infrastructure
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public EfUnitOfWork(AppDbContext db) => _db = db;

        public async Task CommitAsync(CancellationToken ct = default)
        {            
            await _db.SaveChangesAsync(ct);
            await _db.DispatchDomainEventsAsync(ct); // seus DomainEvents -> MediatR.Publish
        }
    }
}
