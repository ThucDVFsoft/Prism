using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HelloWorldModule
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            WorksIBootstrapper bootstrapper = new WorksIBootstrapper();
            bootstrapper.Run();
        }

        //public App()
        //{
        //    InitializeComponent();
        //}

    }
}
