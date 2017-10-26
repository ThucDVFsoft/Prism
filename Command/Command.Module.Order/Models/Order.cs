using System;

namespace Command.Module.Order.Models
{
    class Order
    {
        public Order()
        {
            DeliveryDate = DateTime.Now;
        }

        public string Name { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Shipping { get; set; }
    }
}
