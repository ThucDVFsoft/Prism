using System.Windows.Controls;
using EmployeeModule.ViewModels;

namespace EmployeeModule.Views
{
    /// <summary>
    /// Interaction logic for EmployeeSummaryView.xaml
    /// </summary>
    public partial class EmployeeSummaryView : UserControl
    {
        public EmployeeSummaryView(EmployeeSummaryViewModel viewmodel)
        {
            InitializeComponent();
            this.DataContext = viewmodel;
        }
    }
}
