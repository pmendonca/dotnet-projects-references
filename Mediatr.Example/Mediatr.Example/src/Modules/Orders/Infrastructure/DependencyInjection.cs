using Mediatr.Example.src.BuildingBlocks.Application.Behaviors;
using Mediatr.Example.src.Modules.Orders.Domain;
using Mediatr.Example.src.Modules.Orders.Infrastructure.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Example.src.Modules.Orders.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection OrdersDI(IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
