using QLBX.Model;
using QLBX.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLBX.FormChucNang
{
    /// <summary>
    /// Interaction logic for UCBooking.xaml
    /// </summary>
    public partial class UCBooking : UserControl
    {
        public UCBooking()
        {
            InitializeComponent();
            GetListIDvexe.ListChoNgoiVaTrangThai = new List<ItemListVeVM>();
            StaticIDChuyen.StaIDchuyen = new int(); 
        }

        private void listchuyen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
           // MessageBox.Show(DiemDi.ToString());
        }





        //private void cbDiemDi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //MessageBox.Show(cbDiemDi.SelectedIndex.ToString());
        //   // MessageBox.Show((cbDiemDi.SelectedItem as BenXeVM).IDBEN);
        //} 


    }
}
