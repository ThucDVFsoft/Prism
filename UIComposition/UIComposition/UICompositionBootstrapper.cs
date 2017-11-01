using Prism.Modularity;
using Prism.Unity;
using System.Windows;

namespace UIComposition
{
    class UICompositionBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            var view = this.Container.TryResolve<Shell>();
            return view;
        }
        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(EmployeeModule.ModuleInit));
        }
    }
}
