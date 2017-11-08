using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System.Windows;
using System.Windows.Controls;

namespace Sample.Module
{
    public class SampleModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        public SampleModule(IRegionViewRegistry registry)
        {
            this.regionViewRegistry = registry;
        }

        public void Initialize()
        {
            var region = LogicalTreeHelper.FindLogicalNode(Application.Current.MainWindow, "MainRegion") as ContentPresenter;
            region.Content = new ViewSample();
        }
    }
}
