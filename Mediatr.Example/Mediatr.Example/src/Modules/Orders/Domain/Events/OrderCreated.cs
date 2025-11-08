using Mediatr.Example.src.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Example.src.Modules.Orders.Domain.Events
{
    public record OrderCreated(Guid OrderId) : DomainEvent(DateTime.UtcNow);
}
