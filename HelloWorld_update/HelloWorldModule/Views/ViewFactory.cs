using HelloWorldModule.NavigationManagerns;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HelloWorldModule.Views
{
    [Export(typeof(IViewFactory))]
    public class ViewFactory : IViewFactory
    {
        private CompositionContainer container;

        public ViewFactory(CompositionContainer container)
        {
            this.container = container;
        }

        private Tuple<TView, TViewModel> Create<TView, TViewModel>()
            where TView : FrameworkElement, IView<TViewModel>
            where TViewModel : IViewModel
        {
            TView view = ServiceLocator.Current.GetInstance<TView>();
            TViewModel viewModel = ServiceLocator.Current.GetInstance<TViewModel>();

            view.AttachViewModel(viewModel);
            return new Tuple<TView, TViewModel>(view, viewModel);
        }

        TView IViewFactory.CreateView<TView, TViewModel>()
        {
            return this.Create<TView, TViewModel>().Item1;
        }

        TView IViewFactory.CreateView<TView, TViewModel>(out TViewModel viewModel)
        {
            var tuple = this.Create<TView, TViewModel>();
            viewModel = tuple.Item2;
            return tuple.Item1;
        }

        TView IViewFactory.CreateView<TView, TViewModel>(TViewModel viewModel)
        {
            TView view = ServiceLocator.Current.GetInstance<TView>();
            if (viewModel == null)
            {
                viewModel = ServiceLocator.Current.GetInstance<TViewModel>();
            }

            view.AttachViewModel(viewModel);
            return new Tuple<TView, TViewModel>(view, viewModel).Item1;
        }
    }
}
