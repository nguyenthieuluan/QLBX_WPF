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
    /// Interaction logic for UCNhanVienBanVe.xaml
    /// </summary>
    public partial class UCNhanVienBanVe : UserControl
    {
        public UCNhanVienBanVe()
        {
            InitializeComponent();
            UCQlyNhanvien a1 = new UCQlyNhanvien();
            gridphan.Children.Clear();
            gridphan.Children.Add(a1);
            BrushConverter bc = new BrushConverter();
            
            brush = (Brush)bc.ConvertFrom("#003f7d");
            BrushConverter bc1 = new BrushConverter();
           
            brush1 = (Brush)bc1.ConvertFrom("#ffffff");
            nhanvien.Background = brush;
            quyen.Background = brush1;
        }
        Brush brush;
        Brush brush1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            //GridCursor.Margin = new Thickness(10 + (150 * index), 0, 0, 0);
            Button a = sender as Button;
            BrushConverter bc = new BrushConverter();
        //    Brush brush;
            brush = (Brush)bc.ConvertFrom("#003f7d");

            BrushConverter bc1 = new BrushConverter();
          //  Brush brush1;
            brush1 = (Brush)bc1.ConvertFrom("#ffffff");

            a.Foreground = brush;
            switch (index)
            {
                case 0:
                    UCQlyNhanvien a1 = new UCQlyNhanvien();
                    nhanvien.Background = brush;
                    quyen.Background = brush1;
                    gridphan.Children.Clear();
                    gridphan.Children.Add(a1);
                    break;
                case 1:
                   
                    nhanvien.Background = brush1;
                    quyen.Background = brush;
                    UCPhanQuyen a2 = new UCPhanQuyen();
                    gridphan.Children.Clear();
                    gridphan.Children.Add(a2);
                    break;
            }
        }
    }
}
