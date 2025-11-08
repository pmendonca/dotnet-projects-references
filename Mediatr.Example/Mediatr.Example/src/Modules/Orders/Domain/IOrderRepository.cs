using Mediatr.Example.src.BuildingBlocks.Domain;

namespace Mediatr.Example.src.Modules.Orders.Domain
{    
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<Order?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken ct = default);
        Task<bool> ExistsAsync(Guid id, CancellationToken ct = default);
        Task AddAsync(Order order, CancellationToken ct = default);
        Task RemoveAsync(Order order, CancellationToken ct = default);
    }
}
