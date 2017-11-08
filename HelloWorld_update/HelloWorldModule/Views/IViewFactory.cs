using HelloWorldModule.NavigationManagerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HelloWorldModule.Views
{
    public interface IViewFactory
    {
        /// <summary>
        /// 指定された型の View と ViewModel を作成します。
        /// </summary>
        /// <typeparam name="TView">作成する View の型</typeparam>
        /// <typeparam name="TViewModel">作成する ViewModel の型</typeparam>
        /// <returns>作成された View のインスタンス</returns>
        TView CreateView<TView, TViewModel>()
            where TView : FrameworkElement, IView<TViewModel>
            where TViewModel : IViewModel;

        /// <summary>
        /// 指定された型の View と ViewModel を作成します。
        /// </summary>
        /// <typeparam name="TView">作成する View の型</typeparam>
        /// <typeparam name="TViewModel">作成する ViewModel の型</typeparam>
        /// <param name="viewModel">作成された ViewModel のインスタンスを受け取る出力引数</param>
        /// <returns>作成された View のインスタンス</returns>
        TView CreateView<TView, TViewModel>(out TViewModel viewModel)
            where TView : FrameworkElement, IView<TViewModel>
            where TViewModel : IViewModel;

        /// <summary>
        /// 指定された ViewModel で View を作成します。
        /// </summary>
        /// <typeparam name="TView">作成する View の型</typeparam>
        /// <param name="viewModel">作成された View の ViewModel になるインスタンス … nullの場合は新しいインスタンスを作成する</param>
        /// <returns>作成された View のインスタンス</returns>
        TView CreateView<TView, TViewModel>(TViewModel viewModel)
            where TView : FrameworkElement, IView<TViewModel>
            where TViewModel : IViewModel;
    }
}
