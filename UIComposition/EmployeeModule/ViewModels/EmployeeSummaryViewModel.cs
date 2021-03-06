﻿using System.ComponentModel;
using EmployeeModule.Models;

namespace EmployeeModule.ViewModels
{
    public class EmployeeSummaryViewModel : INotifyPropertyChanged
    {
        private Employee currentEmployee;

        public Employee CurrentEmployee
        {
            get { return this.currentEmployee; }
            set
            {
                this.currentEmployee = value;
                this.NotifyPropertyChanged("CurrentEmployee");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
