using QLBX.ViewModel;
using System.Windows.Controls;


namespace QLBX.UC
{
    /// <summary>
    /// Interaction logic for ControlBarUC.xaml
    /// </summary>
    public partial class ControlBarUC : UserControl
    {
        public ControlBarVM viewmodel { get; set; }
        public ControlBarUC()
        {
            InitializeComponent();
            this.DataContext = viewmodel = new ControlBarVM();
        }
    }
}
