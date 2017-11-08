using HelloWorldModule.NavigationManagerns;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelloWorldModule
{
    [Export]
    public partial class Shell : Window, IView<ShellViewModel>
    {
        public Shell()
        {
            InitializeComponent();
            this.MouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(ShellView_MouseRightButtonDown);
        }

        void ShellView_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        public void AttachViewModel(ShellViewModel viewModel)
        {
            this.DataContext = viewModel;
        }

        public void Detach()
        {
            this.DataContext = null;
        }

        public void OnActivated()
        {
        }

        public void OnDeactivated()
        {
        }
    }
}
