using System.Windows;

namespace QLBX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region UI even

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (btnOpen.Visibility == Visibility.Collapsed)
            {
                btnClose.Visibility = Visibility.Collapsed;
                btnOpen.Visibility = Visibility.Visible;
                expander1.IsExpanded = expander2.IsExpanded = expander3.IsExpanded = expander4.IsExpanded = expander5.IsExpanded = expander6.IsExpanded = false;
            }
            else
            {
                btnOpen.Visibility = Visibility.Collapsed;
                btnClose.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            luna.Children.Clear();
        }
        #endregion

    }
}
