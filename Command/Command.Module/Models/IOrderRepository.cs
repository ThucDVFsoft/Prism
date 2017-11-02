using System.Collections.Generic;

namespace Command.Module.Models
{
    interface IOrderRepository
    {
        IEnumerable<Order> GetOrdersToEdit();
    }
}
