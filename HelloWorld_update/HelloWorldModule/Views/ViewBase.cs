using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using System.Windows.Media;
using HelloWorldModule.NavigationManagerns;

namespace HelloWorldModule.Views
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public abstract class ViewBase<TViewModel> : Control, IView<TViewModel>
        where TViewModel : IViewModel
    {
        public event ViewModelAttachedEventHandler<TViewModel> ViewModelAttached;

        private bool isTemplateApplied;
        private bool isViewModelAttached;

        public ViewBase()
        {
            TextOptions.SetTextFormattingMode(this, TextFormattingMode.Display);

            this.isTemplateApplied = false;
            this.isViewModelAttached = false;
        }

        public virtual void AttachViewModel(TViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException("viewModel");
            }

            this.DataContext = viewModel;
            this.isViewModelAttached = true;

            if (this.isTemplateApplied == true)
            {
                this.OnViewModelAttached(this.ViewModel);
                this.RaiseViewModelAttached();
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.isTemplateApplied = true;

            if (this.isViewModelAttached == true)
            {
                this.OnViewModelAttached(this.ViewModel);
                this.RaiseViewModelAttached();
            }
        }

        protected virtual void OnViewModelAttached(TViewModel viewModel) { }

        private void RaiseViewModelAttached()
        {
            var handler = this.ViewModelAttached;
            if (handler != null)
            {
                handler(null, new ViewModelAttachedEventArgs<TViewModel>()
                {
                    View = this
                });
            }
        }

        public virtual TViewModel ViewModel
        {
            get
            {
                return (TViewModel)this.DataContext;
            }
        }

        public virtual void Detach()
        {
        }

        public virtual void OnActivated()
        {
            this.ViewModel.OnActivated();
        }

        public virtual void OnDeactivated()
        {
            this.ViewModel.OnDeactivated();
        }
    }
}
