using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HelloWorldModule.NavigationManagerns
{
    public interface INavigationManager
    {
        FrameworkElement RootElement
		{
			get;
			set;
		}
		/// <summary>
		/// 指定された名前の領域に、指定された View を配置します。
		/// </summary>
		/// <typeparam name="TView">配置する View の型</typeparam>
		/// <typeparam name="TViewModel">配置する View に設定される ViewModel の型</typeparam>
		/// <param name="regionName">View を配置する領域の名前</param>
		TView NavigateTo<TView, TViewModel>(string regionName, TView view = null)
			where TView : FrameworkElement, IView<TViewModel>
			where TViewModel : IViewModel;

		/// <summary>
		/// 指定された名前の領域から View を削除します。
		/// </summary>
		/// <param name="regionName">View を削除する領域の名前</param>
		void RemoveView(string regionName);
    }

    public interface IView
    {
        void Detach();

        void OnActivated();
        void OnDeactivated();
    }

    /// <summary>
    /// すべての View が実装するインターフェイスを定義します。
    /// </summary>
    /// <typeparam name="TViewModel">View にアタッチされる ViewModel の型</typeparam>
    public interface IView<TViewModel> : IView
        where TViewModel : IViewModel
    {
        /// <summary>
        /// View に ViewModel をアタッチします。
        /// </summary>
        /// <param name="viewModel">アタッチする ViewModel</param>
        void AttachViewModel(TViewModel viewModel);
    }

    public interface IViewModel
    {
        void Detach();

        void OnActivated();
        void OnDeactivated();
    }
}
