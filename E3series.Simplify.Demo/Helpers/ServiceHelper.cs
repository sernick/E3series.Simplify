using E3series.Simplify.Demo.Services;
using E3series.Simplify.Demo.Services.Interfaces;
using E3series.Simplify.Demo.ViewModels;
using E3series.Simplify.Demo.Views;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace E3series.Simplify.Demo.Helpers
{
    public static class ServiceHelper
    {
        public static void Initialize()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IViewService, ViewService>();
            var viewService = ServiceLocator.Current.GetInstance<IViewService>();
            viewService.RegisterView(typeof (MainWindow), typeof (MainViewModel));

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public static void OpenMainWindow()
        {
            ServiceLocator.Current.GetInstance<IViewService>()
                .OpenWindow(ServiceLocator.Current.GetInstance<MainViewModel>());
        }
    }
}