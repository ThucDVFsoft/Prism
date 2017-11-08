using WorkIModule.NavigationManagerns;
using WorkIModule.ViewModels;
using WorkIModule.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WorkIModule.WorksINavigationControllerns
{
    [Export(typeof(IWorksINavigationController))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class WorksINavigationController : IWorksINavigationController
    {
        private INavigationManager navigationManager;

        public INavigationManager NavigationManager
        {
            get { return navigationManager; }
            set { navigationManager = value; }
        }

        [ImportingConstructor]
        public WorksINavigationController(NavigationManager navigationManager)
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
