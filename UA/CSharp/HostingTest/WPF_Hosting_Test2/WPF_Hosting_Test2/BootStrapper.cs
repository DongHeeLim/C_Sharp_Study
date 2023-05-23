using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Hosting_Test2
{
    internal class BootStrapper : BootstrapperBase
    {
        #region Constructor
        public BootStrapper()
        {
            Initialize();
        }
        #endregion

        #region Overrides
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            // DisplayRootViewFor<IShell>();
        }
        #endregion
    }
}
