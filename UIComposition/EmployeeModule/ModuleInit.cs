using EmployeeModule.Controllers;
using EmployeeModule.Services;
using EmployeeModule.Views;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace EmployeeModule
{
    public class ModuleInit : IModule
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;
        private MainRegionController mainRegionController;
        private readonly IEventAggregator eventAggregator;
        public ModuleInit(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
            this.eventAggregator = new EventAggregator();
        }

        public void Initialize()
        {
            container.RegisterType<IEmployeeDataService, EmployeeDataService>();
            container.RegisterInstance<IEventAggregator>(eventAggregator);

            regionManager.RegisterViewWithRegion(RegionNames.LeftRegion,
                                                    () => this.container.Resolve<EmployeeListView>());

            mainRegionController = container.Resolve<MainRegionController>();

            regionManager.RegisterViewWithRegion(RegionNames.TabRegion,
                                                    () => this.container.Resolve<EmployeeDetailsView>());
            regionManager.RegisterViewWithRegion(RegionNames.TabRegion,
                                                    () => this.container.Resolve<EmployeeProjectsView>());
        }
    }
}
