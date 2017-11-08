using HelloWorldModule.ViewModels;
using HelloWorldModule.WorksINavigationControllerns;
using System.ComponentModel.Composition;

namespace HelloWorldModule.Views
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class WorksIDeskTopView : ViewBase<WorksIDeskTopViewModel>
    {
        private IWorksINavigationController navigationController;

        [ImportingConstructor]
        public WorksIDeskTopView(IWorksINavigationController navigationController)
        {
            this.DefaultStyleKey = typeof(WorksIDeskTopView);
            //InitializeComponent();
        }

        protected override void OnViewModelAttached(WorksIDeskTopViewModel viewModel)
        {
            base.OnViewModelAttached(viewModel);
            //this.navigationController.NavigateToRootMenuView();
            //this.navigationController.NavigateToWorkspaceHolderView();
        }
    }
}
