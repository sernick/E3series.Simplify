using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace E3series.Simplify.Demo.Models.Messages
{
    public class RequestCloseMessage : MessageBase
    {
        #region Constructor

        public RequestCloseMessage(ViewModelBase viewModel, bool? dialogResult = null)
        {
            ViewModel = viewModel;
            DialogResult = dialogResult;
        }

        #endregion
        
        #region Public Fields

        public ViewModelBase ViewModel { get; set; }
        public bool? DialogResult { get; set; }

        #endregion
    }
}