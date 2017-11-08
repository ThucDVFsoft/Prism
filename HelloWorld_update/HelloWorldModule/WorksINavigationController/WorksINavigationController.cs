using HelloWorldModule.NavigationManagerns;
using HelloWorldModule.ViewModels;
using HelloWorldModule.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HelloWorldModule.WorksINavigationControllerns
{
    [Export(typeof(IWorksINavigationController))]
    public class WorksINavigationController : IWorksINavigationController
    {
        private INavigationManager navigationManager;

        public INavigationManager NavigationManager
        {
            get { return navigationManager; }
            set { navigationManager = value; }
        }

        [ImportingConstructor]
        public WorksINavigationController(INavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;
        }

        public void RegistInitialView()
        {
            this.NavigateToDesktopView();
        }

        public void NavigateToDesktopView()
        {
            this.navigationManager.NavigateTo<WorksIDeskTopView, WorksIDeskTopViewModel>(RegionNames.ShellRegion);
        }

        public TView NavigateTo<TView, TViewModel>(string regionName, FrameworkElement rootElement)
            where TView : FrameworkElement, IView<TViewModel>
            where TViewModel : IViewModel
        {
            var tmp = this.navigationManager.RootElement;
            try
            {
                this.navigationManager.RootElement = rootElement;
                return this.navigationManager.NavigateTo<TView, TViewModel>(regionName);
            }
            finally
            {
                this.navigationManager.RootElement = tmp;
            }
        }
    }
}
