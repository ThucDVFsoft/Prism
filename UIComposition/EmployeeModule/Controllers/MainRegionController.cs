using System;
using System.Linq;
using EmployeeModule.Models;
using EmployeeModule.Services;
using EmployeeModule.ViewModels;
using EmployeeModule.Views;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using Prism.Regions;

namespace EmployeeModule.Controllers
{
    public class EmployeeSelectedEvent : PubSubEvent<string>
    {
    }

    class MainRegionController
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private readonly IEmployeeDataService dataService;

        public MainRegionController(IUnityContainer container,  
                                    IRegionManager regionManager,
                                    IEventAggregator eventAggregator,
                                    IEmployeeDataService dataService)
        {
            if (container == null) throw new ArgumentNullException("container");
            if (regionManager == null) throw new ArgumentNullException("regionManager");
            if (eventAggregator == null) throw new ArgumentNullException("eventAggregator");
            if (dataService == null) throw new ArgumentNullException("dataService");

            this.container = container;
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.dataService = dataService;

            // Subscribe to the EmployeeSelectedEvent event.
            // This event is fired whenever the user selects an
            // employee in the EmployeeListView.
            this.eventAggregator.GetEvent<EmployeeSelectedEvent>().Subscribe(this.EmployeeSelected, true);
        }

        private Employee selectedEmployee;

        private void EmployeeSelected(string id)
        {
            if (string.IsNullOrEmpty(id)) return;

            selectedEmployee = dataService.GetEmployees().FirstOrDefault(item => item.Id == id);

            IRegion mainRegion = regionManager.Regions[RegionNames.MainRegion];
            if (mainRegion == null) return;

            var view = mainRegion.GetView("EmployeeSummaryView") as EmployeeSummaryView;
            if (view == null)
            {
                view = container.Resolve<EmployeeSummaryView>();
                mainRegion.Add(view, "EmployeeSummaryView");
            }
            else
            {
                mainRegion.Activate(view);
            }

            EmployeeSummaryViewModel viewModel = view.DataContext as EmployeeSummaryViewModel;
            if (viewModel != null)
            {
                viewModel.CurrentEmployee = selectedEmployee;
            }
        }

    }
}
