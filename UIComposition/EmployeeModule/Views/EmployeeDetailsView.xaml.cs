using System.Windows.Controls;
using EmployeeModule.Services;
using EmployeeModule.ViewModels;
using System.Linq;
using Prism.Regions;
using EmployeeModule.Models;

namespace EmployeeModule.Views
{
    /// <summary>
    /// Interaction logic for EmployeeDetailsViewModel.xaml
    /// </summary>
    public partial class EmployeeDetailsView : UserControl
    {
        public EmployeeDetailsView(EmployeeDetailsViewModel viewmodel)
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
