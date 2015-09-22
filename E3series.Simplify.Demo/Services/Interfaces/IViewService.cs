using System;
using System.Windows;
using GalaSoft.MvvmLight;

namespace E3series.Simplify.Demo.Services.Interfaces
{
    public interface IViewService
    {
        void RegisterView(Type windowType, Type viewModelType);

        void OpenWindow(ViewModelBase viewModel);

        bool? OpenDialog(ViewModelBase viewModel);

        MessageBoxResult ShowMessage(ViewModelBase viewModel, string message, string title);

        MessageBoxResult ShowMessage(ViewModelBase viewModel, string message, string title, string buttonText);

        MessageBoxResult ShowMessage(ViewModelBase viewModel, string message, string title,
            string buttonConfirmText, string buttonCancelText);
    }
}