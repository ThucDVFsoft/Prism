using HelloWorldModule.NavigationManagerns;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HelloWorldModule.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo, IViewModel
    {
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public ViewModelBase()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void RaisePropertyChanged(params string[] propertyNames)
        {
            if (propertyNames == null)
            {
                throw new ArgumentNullException("propertyNames");
            }

            foreach (var name in propertyNames)
            {
                this.RaisePropertyChanged(name);
            }
        }

        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            this.RaisePropertyChanged(propertyName);
        }


        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            var result = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            var property = GetType().GetProperty(propertyName);
            if (property == null)
            {
                return null;
            }

            if (Validator.TryValidateProperty(
                    GetType().GetProperty(propertyName).GetValue(this, null),
                    new ValidationContext(this, null, null) { MemberName = propertyName },
                    result))
            {
                return null;
            }
            return result.Select(vr => vr.ErrorMessage);
        }

        public bool HasErrors
        {
            get
            {
                var result = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                return !Validator.TryValidateObject(
                    this,
                    new ValidationContext(this, null, null),
                    result);
            }
        }

        private Thickness margin = new Thickness(11);
        /// <summary>
        /// Viewのマージン（初期値11px, 不要な場合は0pxで上書きする）
        /// </summary>
        public Thickness Margin
        {
            get
            {
                return this.margin;
            }
            set
            {
                this.margin = value;
                this.RaisePropertyChanged(() => this.Margin);
            }
        }

        protected void RaiseErrorsChanged(string propertyName)
        {
            EventHandler<DataErrorsChangedEventArgs> handler = this.ErrorsChanged;
            if (handler != null)
            {
                handler(this, new DataErrorsChangedEventArgs(propertyName));
            }

            this.RaisePropertyChanged(() => HasErrors);
        }

        protected void RaiseErrorsChanged(params string[] propertyNames)
        {
            if (propertyNames == null)
            {
                throw new ArgumentNullException("propertyNames");
            }

            foreach (var name in propertyNames)
            {
                this.RaiseErrorsChanged(name);
            }
        }

        protected void RaiseErrorsChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            this.RaiseErrorsChanged(propertyName);
        }

        public virtual void Detach()
        {
        }

        public virtual void OnActivated() { }
        public virtual void OnDeactivated() { }
    }
}
