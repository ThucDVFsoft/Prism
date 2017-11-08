using HelloWorldModule.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldModule
{
    [Export]
    public class ShellViewModel : ViewModelBase
	{
        public ShellViewModel()
		{
		}
    }
}
