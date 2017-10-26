using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Command.Module.Order.Models;
using System.Windows.Data;

namespace Command.Module.Order.ViewModels
{
    public class OrderViewModel
    {
        private readonly IOrderRepository orderRepository;

        public OrderViewModel()
        {
            orderRepository = new OrderRepository();
            var listOrder = orderRepository.GetOrdersToEdit();
            Orders = new ListCollectionView(listOrder.ToList());
        }

        public ICollectionView Orders { get; set; }
    }
}
