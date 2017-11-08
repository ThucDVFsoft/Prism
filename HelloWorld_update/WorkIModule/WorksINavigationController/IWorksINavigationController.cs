using WorkIModule.NavigationController;
using WorkIModule.NavigationManagerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WorkIModule.WorksINavigationControllerns
{
    interface IWorksINavigationController : INavigationController
    {
        INavigationManager NavigationManager
        {
            get;
            set;
        }

        TView NavigateTo<TView, TViewModel>(string regionName, FrameworkElement rootElement)
            where TView : FrameworkElement, IView<TViewModel>
            where TViewModel : IViewModel;

        // リージョンクリア
    }
}
