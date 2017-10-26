using System.Windows;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Modularity;
using Command.Module.Order;

namespace Command
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var type = typeof(OrderModule);
            var moduleInfo = new ModuleInfo(type.Name, type.AssemblyQualifiedName);
            this.ModuleCatalog.AddModule(moduleInfo);
        }

        protected override DependencyObject CreateShell()
        {
            var shell = this.Container.Resolve<Shell>();
            return shell;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }
    }
}
