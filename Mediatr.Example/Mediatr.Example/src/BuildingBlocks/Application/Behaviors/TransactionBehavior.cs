using Mediatr.Example.src.BuildingBlocks.Domain;
using Mediatr.Example.src.BuildingBlocks.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mediatr.Example.src.BuildingBlocks.Application.Behaviors
{
    public class TransactionBehavior<TReq, TRes>(AppDbContext db, IUnitOfWork uow)
        : IPipelineBehavior<TReq, TRes>
    {
        public async Task<TRes> Handle(TReq request, RequestHandlerDelegate<TRes> next, CancellationToken ct)
        {
            var isCommand = typeof(TReq)
                .Name.EndsWith("Command", StringComparison.OrdinalIgnoreCase);

            if (!isCommand) return await next();

            var strategy = db.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                await using var tx = await db.Database.BeginTransactionAsync(ct);
                var response = await next();
                await uow.CommitAsync(ct);
                await tx.CommitAsync(ct);
                return response;
            });
        }
    }
}
