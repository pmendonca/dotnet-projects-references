using Mediatr.Example.src.BuildingBlocks.Domain;
using Mediatr.Example.src.BuildingBlocks.Infrastructure;
using Mediatr.Example.src.Modules.Orders.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mediatr.Example.src.Modules.Orders.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _db;
        private DbSet<Order> Orders => _db.Set<Order>();

        public OrderRepository(AppDbContext db) => _db = db;

        public Task<Order?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => Orders.FirstOrDefaultAsync(o => o.Id == id, ct);

        public Task<Order?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken ct = default)
            => Orders.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id, ct);

        public Task<bool> ExistsAsync(Guid id, CancellationToken ct = default)
            => Orders.AnyAsync(o => o.Id == id, ct);

        public async Task AddAsync(Order order, CancellationToken ct = default)
            => await Orders.AddAsync(order, ct);

        public Task RemoveAsync(Order order, CancellationToken ct = default)
        {
            Orders.Remove(order);
            return Task.CompletedTask;
        }
    }

}
