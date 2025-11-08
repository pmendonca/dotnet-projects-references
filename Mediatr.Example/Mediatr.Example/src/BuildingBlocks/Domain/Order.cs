using Mediatr.Example.src.Modules.Orders.Domain.Events;

namespace Mediatr.Example.src.BuildingBlocks.Domain
{
    public class Order : Entity
    {
        private Order() { }
        public string CustomerName { get; private set; } = default!;
        public decimal Total { get; private set; }
        public static Order Create(string customerName, decimal total)
        {
            var order = new Order { CustomerName = customerName, Total = total };
            order.Raise(new OrderCreated(order.Id));
            return order;
        }
    }
}
