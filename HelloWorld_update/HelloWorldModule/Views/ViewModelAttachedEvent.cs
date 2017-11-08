using HelloWorldModule.NavigationManagerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldModule.Views
{
    public delegate void ViewModelAttachedEventHandler<TViewModel>(object sender, ViewModelAttachedEventArgs<TViewModel> e)
        where TViewModel : IViewModel;

    public class ViewModelAttachedEventArgs<TViewModel> : EventArgs
        where TViewModel : IViewModel
    {
        public ViewBase<TViewModel> View
        {
            get;
            set;
        }
    }
}
