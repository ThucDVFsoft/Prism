using WorkIModule.Views;
using WorkIModule.WorksINavigationControllerns;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using System.ComponentModel.Composition;

namespace WorkIModule
{
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class HelloWorldModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        public HelloWorldModule(IRegionViewRegistry registry)
        {
            this.regionViewRegistry = registry;
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
