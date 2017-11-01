using System.Collections.Generic;

namespace Command.Module.Order.Models
{
    interface IOrderRepository
    {
        IEnumerable<Order> GetOrdersToEdit();
    }
}
