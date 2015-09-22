namespace E3series.Simplify.Views.Interfaces
{
    interface IDialogView : IView
    {
        bool? ShowDialog();
        bool? DialogResult { get; set; }
    }
}