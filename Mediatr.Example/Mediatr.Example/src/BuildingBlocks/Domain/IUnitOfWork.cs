namespace Mediatr.Example.src.BuildingBlocks.Domain
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken ct = default);
    }
}
