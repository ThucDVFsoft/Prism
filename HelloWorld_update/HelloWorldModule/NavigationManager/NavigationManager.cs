using HelloWorldModule.ViewModels;
using HelloWorldModule.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HelloWorldModule.NavigationManagerns
{
    [Export(typeof(INavigationManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class NavigationManager : INavigationManager
    {
        private IViewFactory viewFactory;

        [ImportingConstructor]
        public NavigationManager(IViewFactory viewFactory)
        {
            this.viewFactory = viewFactory;
        }

        TView INavigationManager.NavigateTo<TView, TViewModel>(string regionName, TView view)
        {
            var region = LogicalTreeHelper.FindLogicalNode(Application.Current.MainWindow, regionName) as ContentPresenter; 

            var oldView = region.Content;
            if (oldView != null)
            {
                if (oldView is FrameworkElement)
                {
                    if (((FrameworkElement)oldView).DataContext is ViewModelBase)
                    {
                        var oldViewModel = ((FrameworkElement)oldView).DataContext as ViewModelBase;
                        oldViewModel.Detach();
                    }
                }

                if (oldView is IView)
                {
                    ((IView)oldView).Detach();
                }
                oldView = null;
            }

            if (view == null)
            {
                view = this.viewFactory.CreateView<TView, TViewModel>();
            }
            region.Content = view;

            return view;
        }

        public void RemoveView(string regionName)
        {
            
        }

        private FrameworkElement rootElement;
        public FrameworkElement RootElement
        {
            get
            {
                return this.rootElement;
            }
            set
            {
                this.rootElement = value;
            }
        }
    }
}
