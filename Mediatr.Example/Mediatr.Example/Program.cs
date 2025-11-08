using Mediatr.Example.src.BuildingBlocks.Application;
using Mediatr.Example.src.BuildingBlocks.Infrastructure;
using Mediatr.Example.src.Modules.Orders.Application.CreateOrder;
using Mediatr.Example.src.Modules.Orders.Application.GetOrder;
using MediatR;
//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.AddSimpleConsole(o => { o.SingleLine = true; o.TimestampFormat = "HH:mm:ss "; });

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services
    .AddInfrastructure(@"Data Source=D:\git\tutoriais\Mediatr.Example\Mediatr.Example\App_Data\app.db;Cache=Shared")
    .AddApplication(typeof(CreateOrderCommand));

using var host = builder.Build();

//await host.MigrateDbAsync();

using var scope = host.Services.CreateScope();
var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

try
{
    var x = await mediator.Send(new CreateOrderCommand("Paulo Mendonça", 10));

    var dto = await mediator.Send(new GetOrderQuery(new Guid("3e423484-497b-4df6-ad6a-826d4f22f324")));
    var dto1 = await mediator.Send(new GetOrderQuery(new Guid("3e423484-497b-4df6-ad6a-826d4f22f324")));
    var dto2 = await mediator.Send(new GetOrderQuery(new Guid("3e423484-497b-4df6-ad6a-826d4f22f324")));

    Console.WriteLine($"🧾 Pedido {dto.Id}\nCliente: {dto.CustomerName}\nTotal: {dto.Total}");
}
catch (KeyNotFoundException)
{    
    Environment.ExitCode = 1;
}

//static class HostExtensions
//{
//    public static async Task MigrateDbAsync(this IHost host)
//    {
//        using var scope = host.Services.CreateScope();
//        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

//        // Para SQLite: garante a pasta do arquivo (ex.: App_Data/app.db)
//        var conn = db.Database.GetDbConnection();
//        if (conn.DataSource is string ds && !string.IsNullOrWhiteSpace(ds))
//        {
//            var dir = Path.GetDirectoryName(ds);
//            if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);
//        }

//        await db.Database.MigrateAsync();

//    }
//}
