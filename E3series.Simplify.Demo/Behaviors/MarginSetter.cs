using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace E3series.Simplify.Demo.Behaviors
{
    public class MarginSetter
    {
        #region Dependency Property

        public static Thickness GetMargin(DependencyObject obj)
        {
            return (Thickness) obj.GetValue(MarginProperty);
        }

        public static void SetMargin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(MarginProperty, value);
        }

        public static readonly DependencyProperty MarginProperty =
            DependencyProperty.RegisterAttached("Margin", typeof (Thickness), typeof (MarginSetter),
                new UIPropertyMetadata(new Thickness(), MarginChangedCallback));


        public static void MarginChangedCallback(object sender, DependencyPropertyChangedEventArgs e)

        {
            var panel = sender as Panel;
            if (panel == null) return;

            panel.Loaded += PanelLoaded;
        }

        #endregion
        
        #region Private Methods

        private static void PanelLoaded(object sender, RoutedEventArgs e)

        {
            var panel = sender as Panel;
            if (panel == null)
                throw new ArgumentNullException("sender");

            foreach (var fe in panel.Children.OfType<FrameworkElement>())
            {
                fe.Margin = GetMargin(panel);
            }
        }

        #endregion
    }
}