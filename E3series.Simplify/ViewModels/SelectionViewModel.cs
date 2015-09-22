using e3;
using E3series.Simplify.ViewModels.Base;
using E3series.Simplify.Views;

namespace E3series.Simplify.ViewModels
{
    class SelectionViewModel : ViewModelBase<SelectionWindow>
    {
        #region Public Fields

        public e3Application SelectedE3Application { get; set; }

        #endregion
        
        #region Constructor

        public SelectionViewModel() : base(new SelectionWindow())
        {
        }

        #endregion

        #region Public Methods

        public bool? ShowDialog()
        {
            return View.ShowDialog();
        }

        #endregion
    }
}