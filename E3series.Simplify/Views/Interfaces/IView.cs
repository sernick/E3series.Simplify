namespace E3series.Simplify.Views.Interfaces
{
    interface IView
    {
        object DataContext { get; set; }
        void Close();
    }
}