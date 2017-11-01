using System.Windows.Controls;
using EmployeeModule.Models;
using EmployeeModule.ViewModels;
using Prism.Regions;

namespace EmployeeModule.Views
{
    /// <summary>
    /// Interaction logic for EmployeeProjectsView.xaml
    /// </summary>
    public partial class EmployeeProjectsView : UserControl
    {
        public EmployeeProjectsView(EmployeeProjectsViewModel viewmodel)
        {
            InitializeComponent();
            this.DataContext = viewmodel;
            RegionContext.GetObservableContext(this).PropertyChanged += (s, e)
                                                                        =>
                                                                        viewmodel.CurrentEmployee =
                                                                        RegionContext.GetObservableContext(this).Value
                                                                        as Employee;
        }
    }
}
