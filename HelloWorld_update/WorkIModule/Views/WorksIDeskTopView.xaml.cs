using WorkIModule.ViewModels;
using System.ComponentModel.Composition;

namespace WorkIModule.Views
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class WorksIDeskTopView : ViewBase<WorksIDeskTopViewModel>
    {
        [ImportingConstructor]
        public WorksIDeskTopView()
        {
            this.DefaultStyleKey = typeof(WorksIDeskTopView);
            //InitializeComponent();
        }

        protected override void OnViewModelAttached(WorksIDeskTopViewModel viewModel)
        {
            base
            this.navigationController.NavigateToRootMenuView();
            this.navigationController.NavigateToWorkspaceHolderView();
        }
    }
}
