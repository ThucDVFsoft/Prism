using Command.Module.Order.Models;
using Command.Module.Order.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Command.Module.Order
{
    public class OrderModule : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;

        public OrderModule(IRegionManager region, IUnityContainer con)
        {
            this.regionManager = region;
            this.container = con;
        }

        public void Initialize()
        {
            this.container.RegisterType<IOrderRepository, OrderRepository>(new ContainerControlledLifetimeManager());

            this.regionManager.RegisterViewWithRegion("MainRegion", () => this.container.Resolve<OrderEditView>());
            this.regionManager.RegisterViewWithRegion("GlobalCommandsRegion", () => this.container.Resolve<Toolbar>());
        }
    }
}
