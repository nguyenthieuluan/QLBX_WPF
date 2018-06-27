using QLBX.ViewModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace QLBX.UC
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public MainViewModel mainViewModel { get; set; }

        public Menu()
        {
            InitializeComponent();
            this.DataContext = mainViewModel = new MainViewModel();
        }

        #region Menu Items

        private void Books(object sender, RoutedEventArgs e)
        {
        }

        private void Info(object sender, RoutedEventArgs e)
        {

        }
        private void Customer(object sender, RoutedEventArgs e)
        {
        }

        private void ImportBook(object sender, RoutedEventArgs e)
        {
        }

        private void Sell(object sender, RoutedEventArgs e)
        {
        }

        private void Cash(object sender, RoutedEventArgs e)
        {
        }

        private void Find(object sender, RoutedEventArgs e)
        {
        }

        private void SearchCustomer(object sender, RoutedEventArgs e)
        {
        }

        private void Setting(object sender, RoutedEventArgs e)
        {
        }

        #endregion //Menu Items

        
    }
}
