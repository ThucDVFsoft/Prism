using HelloWorldModule.Views;
using HelloWorldModule.WorksINavigationControllerns;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using System.ComponentModel.Composition;

namespace HelloWorldModule
{
    [ModuleExport(typeof(HelloModule))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class HelloModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        public HelloModule()
        {
            
        }

        public void Initialize()
        {
            //regionViewRegistry.RegisterViewWithRegion("ShellRegion", typeof(HelloWorldView));
            //regionViewRegistry.RegisterViewWithRegion("ShellRegion", typeof(HelloWorldView));
            var navigationController = ServiceLocator.Current.GetInstance<IWorksINavigationController>();
            navigationController.RegistInitialView();
        }
    }
}
