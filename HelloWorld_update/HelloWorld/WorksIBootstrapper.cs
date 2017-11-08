using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.MefExtensions;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using HelloWorldModule.Views;
using Microsoft.Practices.ServiceLocation;

namespace HelloWorldModule
{
    class WorksIBootstrapper : MefBootstrapper
    {
        //protected override void ConfigureModuleCatalog()
        //{
        //    base.ConfigureModuleCatalog();

        //    //ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
        //    this.ModuleCatalog.AddModule(new ModuleInfo("HelloWorldModule", typeof(HelloModule).AssemblyQualifiedName));
        //}

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();

            // Add this assembly to export ModuleTracker
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(WorksIBootstrapper).Assembly));

            // Module A is referenced in in the project and directly in code.
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(HelloModule).Assembly));
        }

        //protected override void ConfigureAggregateCatalog()
        //{
        //    base.ConfigureAggregateCatalog();

        //    this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(WorksIBootstrapper).Assembly));
        //    this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(HelloModule).Assembly));
        //}

        protected override IModuleCatalog CreateModuleCatalog()
        {
            // When using MEF, the existing Prism ModuleCatalog is still the place to configure modules via configuration files.
            return new ConfigurationModuleCatalog();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            var viewFactory = new ViewFactory(this.Container);
            this.Container.ComposeExportedValue<IViewFactory>(viewFactory);

            //this.Container.ComposeExportedValue<IModuleCatalog>(this.ModuleCatalog);
            //this.Container.ComposeExportedValue<IServiceLocator>(new MefServiceLocatorAdapter(this.Container));
            //this.Container.ComposeExportedValue<AggregateCatalog>(this.AggregateCatalog);

            //Lazy<ViewFactory> foo = this.Container.GetExport<ViewFactory>();
            //this.Container.ReleaseExport(foo);
        }

        protected override DependencyObject CreateShell()
        {
            var view = ServiceLocator.Current.GetInstance<Shell>();
            //var viewModel = ServiceLocator.Current.GetInstance<ShellViewModel>();
            //view.AttachViewModel(viewModel);
            return view;
            //return this.Container.GetExportedValue<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }
    }
}
