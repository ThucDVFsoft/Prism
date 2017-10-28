using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Command.Module.Models;
using Command.Module.Order.Properties;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;

namespace Command.Module.ViewModels
{
    public class OrderDetailViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private Command.Module.Models.Order order;
        private readonly Dictionary<string, string> errors = new Dictionary<string, string>();
        public OrderDetailViewModel(Command.Module.Models.Order order)
        {
            this.order = order;
            SaveCommand = new DelegateCommand<OrderDetailViewModel>(SaveMethod, CanSaveMethod);
            PropertyChanged += OnPropertyChanged;
            this.Validate();
        }

        public event EventHandler<DataEventArgs<OrderDetailViewModel>> SaveEvent;

        public DelegateCommand<OrderDetailViewModel> SaveCommand { get; private set; }
        private void SaveMethod(OrderDetailViewModel obj)
        {
            var SaveEventHandler = SaveEvent;
            if (SaveEventHandler != null)
            {
                SaveEventHandler.Invoke(this, new DataEventArgs<OrderDetailViewModel>(this));
            }
        }

        private bool CanSaveMethod(object obj)
        {
            return (order.Quantity != null && order.Price != null);
        }

        public string OrderName
        {
            get { return order.Name; }
            set
            {
                order.Name = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime DeliveryDate
        {
            get { return order.DeliveryDate; }
            set
            {
                order.DeliveryDate = value;
                NotifyPropertyChanged();
            }
        }

        public int? Quantity
        {
            get { return order.Quantity; }
            set
            {
                order.Quantity = value;
                NotifyPropertyChanged();
            }
        }

        public decimal? Price
        {
            get { return order.Price; }
            set
            {
                if (order.Price != value)
                {
                    order.Price = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public decimal? Shipping
        {
            get { return order.Shipping; }
            set
            {
                order.Shipping = value;
                NotifyPropertyChanged();
            }
        }

        public decimal? Total
        {
            get
            {
                if (this.Price != null && this.Quantity != null)
                {
                    return (this.Price.Value * this.Quantity.Value) + (this.Shipping ?? 0);
                }
                return 0;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (this.PropertyChanged == null) return;
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var propertyName = e.PropertyName;
            if (propertyName == "Price" || propertyName == "Quantity" || propertyName == "Shipping")
            {
                this.NotifyPropertyChanged("Total");
            }
            this.Validate();
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void Validate()
        {
            if (this.Price == null || this.Price <= 0)
            {
                this["Price"] = Resources.Price;
            }
            else
            {
                this.ClearError("Price");
            }

            if (this.Quantity == null || this.Quantity <= 0)
            {
                this["Quantity"] = Resources.Quantity;
            }
            else
            {
                this.ClearError("Quantity");
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get 
            { 
                if (errors.ContainsKey(columnName))
                {
                    return errors[columnName];
                }
                return null;
            }
            set
            {
                errors[columnName] = value;
            }
        }

        private void ClearError(string columnName)
        {
            if (errors.ContainsKey(columnName))
            {
                errors.Remove(columnName);
            }
        }
    }
}
