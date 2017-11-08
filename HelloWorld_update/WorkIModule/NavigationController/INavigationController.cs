using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkIModule.NavigationController
{
    public interface INavigationController
    {
        /// <summary>
        /// 各モジュールのリージョンの初期表示 View を設定します。
        /// </summary>
        void RegistInitialView();
    }
}
