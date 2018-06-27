using QLBX.ViewModel;

using System.Windows.Controls;


namespace QLBX.View.UC
{
    /// <summary>
    /// Interaction logic for ControlBarMainUC.xaml
    /// </summary>
    public partial class ControlBarMainUC : UserControl
    {
        public ControlBarVM viewmodel { get; set; }
        public ControlBarMainUC()
        {
            InitializeComponent();
            this.DataContext = viewmodel = new ControlBarVM();
        }
    }
}
