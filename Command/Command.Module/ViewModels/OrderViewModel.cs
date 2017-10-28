using System.Linq;
using System.ComponentModel;
using Command.Module.Models;
using System.Windows.Data;
using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Microsoft.Practices.Prism.PubSubEvents;
using System.Collections.ObjectModel;
using Command.Module.SaveAll;

namespace Command.Module.ViewModels
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        private readonly IOrderRepository orderRepository = new OrderRepository();
        public OrderDetailViewModel SelectedOrder { get; private set; }
        public ICollectionView Orders { get; private set; }
        private ObservableCollection<OrderDetailViewModel> listOrderDetails;

        public OrderViewModel()
        {
            Populate();
            Orders.CurrentChanged += SelectedOrderChanged;
        }

        private void Populate()
        {
            var listOrder = orderRepository.GetOrdersToEdit();
            listOrderDetails = new ObservableCollection<OrderDetailViewModel>();

            foreach (var order in listOrder)
            {
                var orderPresentationModel = new OrderDetailViewModel(order);
                orderPresentationModel.SaveEvent += SaveMethod;

                listOrderDetails.Add(orderPresentationModel);

                SaveAllCommand.SaveAllCmd.RegisterCommand(orderPresentationModel.SaveCommand);
            }

            Orders = new ListCollectionView(listOrderDetails);
        }

        private void SaveMethod(object sender, DataEventArgs<OrderDetailViewModel> e)
        {
            if (e != null && e.Value != null)
            {
                OrderDetailViewModel orderVM = e.Value;

                if (listOrderDetails.Contains(orderVM))
                {
                    orderVM.SaveEvent -= SaveMethod;
                    SaveAllCommand.SaveAllCmd.UnregisterCommand(orderVM.SaveCommand);
                    listOrderDetails.Remove(orderVM);
                }
            }
        }

        private void SelectedOrderChanged(object sender, EventArgs e)
        {
            SelectedOrder = Orders.CurrentItem as OrderDetailViewModel;
            OnPropertyChanged("SelectedOrder");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
