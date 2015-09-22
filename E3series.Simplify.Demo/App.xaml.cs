using System.Windows;
using E3series.Simplify.Demo.Helpers;
using GalaSoft.MvvmLight.Threading;

namespace E3series.Simplify.Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DispatcherHelper.Initialize();
            ServiceHelper.Initialize();

            ServiceHelper.OpenMainWindow();
        }
    }
}
