using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Mediatr.Example.src.BuildingBlocks.Application.Behaviors
{
    public class LoggingBehavior<TReq, TRes>(ILogger<LoggingBehavior<TReq, TRes>> logger)
    : IPipelineBehavior<TReq, TRes>
    {
        public async Task<TRes> Handle(TReq request, RequestHandlerDelegate<TRes> next, CancellationToken ct)
        {
            var sw = Stopwatch.StartNew();
            logger.LogInformation("Handling {Name} {@Request}", typeof(TReq).Name, request);
            var response = await next();
            sw.Stop();
            logger.LogInformation("Handled {Name} in {Elapsed} ms", typeof(TReq).Name, sw.ElapsedMilliseconds);
            return response;
        }
    }
}
