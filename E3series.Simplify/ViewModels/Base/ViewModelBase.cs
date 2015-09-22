using System.ComponentModel;
using E3series.Simplify.Views.Interfaces;

namespace E3series.Simplify.ViewModels.Base
{
    internal class ViewModelBase<TViewType> : INotifyPropertyChanged where TViewType : IView
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Private Fields

        private readonly TViewType _view;

        #endregion

        #region Public Fields

        public TViewType View
        {
            get { return _view; }
        }

        #endregion

        #region Constructor

        public ViewModelBase(TViewType view)
        {
            _view = view;
            View.DataContext = this;
        }

        #endregion

        #region Public Methods

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}