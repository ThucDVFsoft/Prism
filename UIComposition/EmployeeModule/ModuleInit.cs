using EmployeeModule.Services;
using EmployeeModule.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace EmployeeModule
{
    public class ModuleInit : IModule
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;

        public ModuleInit(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            container.RegisterType<IEmployeeDataService, EmployeeDataService>();

            regionManager.RegisterViewWithRegion(RegionNames.LeftRegion,
                                                    () => this.container.Resolve<EmployeeListView>());
        }
    }
}
