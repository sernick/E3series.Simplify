using System.Windows.Input;
using E3series.Simplify.Entities;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace E3series.Simplify.Demo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Private Fields

        private ICommand _connectToE3SeriesCommand;
        private E3Application _e3Application;
        private ICommand _disconnectToE3SeriesCommand;

        #endregion

        #region Public Fields

        public E3Application E3Application
        {
            get { return _e3Application; }
            set { Set("E3Application", ref _e3Application, value); }
        }

        #endregion

        #region Public Fields

        public ICommand ConnectToE3SeriesCommand
        {
            get
            {
                return _connectToE3SeriesCommand ??
                       (_connectToE3SeriesCommand = new RelayCommand(() =>
                       {
                           E3Application = new E3Application();
                           if (E3Application.ComObject == null)
                           {
                               E3Application = null;
                           }
                       }, () => E3Application == null));
            }
        }

        public ICommand DisconnectToE3SeriesCommand
        {
            get
            {
                return _disconnectToE3SeriesCommand ?? (_disconnectToE3SeriesCommand = new RelayCommand(() =>
                {
                    E3Application.Dispose();
                    E3Application = null;
                }, () => E3Application != null));
            }
        }

        #endregion
    }
}