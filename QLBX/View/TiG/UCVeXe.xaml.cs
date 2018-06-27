using QLBX.Model;
using QLBX.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for UCVeXe.xaml
    /// </summary>
    public partial class UCVeXe : UserControl
    {
        float tien = 0;
        float flag = 0;
        public UCVeXe()
        {
            InitializeComponent();


            GetListIDvexe.Listdave = new List<int>();
            

            tien = 0;
            tongtien.Text = "0";
            createSD(frist,1);
            createSD(second,24);
            Dsghe = new List<int>();
            var resust = (from c in DataProvider.Ins.DB.CHUYENXEs where c.IDCHUYEN == StaticIDChuyen.StaIDchuyen select c).ToList();
            if (resust!=null)
            {
                tien=float.Parse(resust.OrderByDescending(p => p.GIAVECHUYEN).First().GIAVECHUYEN.ToString());
            }
            loadstatus();
            loadstuff();
        }
        void loadstatus()
        {
            listkhach();
            listvedadat.ItemsSource = listvedadatr;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listvedadat.ItemsSource);
           // CollectionView view1 = (CollectionView)CollectionViewSource.GetDefaultView(listvedadat.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("hoten");
         //   PropertyGroupDescription groupDescription1 = new PropertyGroupDescription("idkhach");
            view.GroupDescriptions.Add(groupDescription);
       //     view1.GroupDescriptions.Add(groupDescription1);

        }
        void createSD(Grid grid,int m)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 7; j++)
                {
                    if (i % 2 == 0)
                    {
                        taobutton((m++).ToString(), i, j, grid);
                    }
                    if (i % 2 != 0 && j == 0)
                        taobutton((m++).ToString(), i, j, grid);
                }
        }

        void taobutton(string caption, int row, int column, Grid parent)
        {
            ToggleButton button = new ToggleButton();
            button.Content = caption;
            button.Tag = int.Parse(caption);
            button.IsChecked = false;
            BrushConverter bc = new BrushConverter();
            Brush brush;
            brush = (Brush)bc.ConvertFrom("#003f7d");

            button.Background = brush;
            foreach (var item in GetListIDvexe.ListChoNgoiVaTrangThai)
            {
                if (int.Parse(caption) == item.chongoi && item.trangthai==true)
                {
                    button.IsChecked = true;
                    button.Background = (Brush)bc.ConvertFrom("#000000");
                    button.IsEnabled = false;
                }
                else if (int.Parse(caption) == item.chongoi && item.trangthai == false)
                {
                    button.IsChecked = false;
                    button.Background = (Brush)bc.ConvertFrom("#990000");
                    button.IsEnabled = false;
                }
            }
            Style style = this.FindResource("MaterialDesignActionToggleButton") as Style;
            button.Style = style;
            ToolTip abc = new ToolTip();
            abc.Content = "MaterialDesignActionAccentToggleButton";
            //Color xanh = new Color.FromArgb(#FF00FF);
           
            
            button.ToolTip = abc;
            //button.Margin = new Thickness(5, 5, 5, 5);
            parent.Children.Add(button);
            button.Click += Button_Click;
            Grid.SetRow(button, row);
            Grid.SetColumn(button, column);
        }
        List<int> Dsghe = new List<int>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton btn = sender as ToggleButton;
            var bc = new BrushConverter();
            flag = 0;
            if (btn.IsChecked == true)
            {
                btn.Background = (Brush)bc.ConvertFrom("#ebadba");
                Dsghe.Add(Convert.ToInt32(btn.Tag));
            }
            if (btn.IsChecked==false)
            {
                BrushConverter bc1 = new BrushConverter();
                Brush brush;
                brush = (Brush)bc.ConvertFrom("#003f7d");
                btn.Background = brush;
                Dsghe.Remove(int.Parse(btn.Tag.ToString()));
            }
            foreach (var i in Dsghe)
            {
                flag++;
            }
            tongtien.Text = (flag * tien).ToString();
            if (listghe.ItemsSource != null)
                listghe.ItemsSource = null;
            GetListIDvexe.Listdave = Dsghe;
            listghe.ItemsSource = Dsghe;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }


        private void mouse(object sender, MouseButtonEventArgs e)
        {
           
        }

        public List<user> listvedadatr = new List<user>();
        void listkhach()
        {
            listvedadatr = new List<user>();
            foreach (var item in GetListIDvexe.ListChoNgoiVaTrangThai)
            {
                var result = (from c in DataProvider.Ins.DB.KHACHDIXEs where c.IDKHACH == item.idkhach select c.HOTEN).ToList();
                //var result1 = (from c in DataProvider.Ins.DB.KHACHDIXEs where c.IDKHACH == item.idkhach select c.id).ToList();
                user a1 = new user();
                a1.soghedamua = item.chongoi;
                a1.idkhach = item.idkhach;
                a1.hoten = result.First();
                //if (a1.soghedamua == null) break;
                a1.trangthai = item.trangthai;
                listvedadatr.Add(a1);
            }
        }
        public class user
        {
            public int? soghedamua { get; set; }
            public string hoten { get; set; }
            public int? idkhach { get; set; }
            public bool? trangthai { get; set; }
        }
        public List<stuff> listHangHoa = new List<stuff>();
        void listhanghoanek()
        {
            listHangHoa = new List<stuff>();
            var resuliit = DataProvider.Ins.DB.GUIHANGHOAs.Where(p => p.IDCHUYEN == StaticIDChuyen.StaIDchuyen).ToList();
            foreach (var item in resuliit)
            {
                //var result1 = (from c in DataProvider.Ins.DB.KHACHDIXEs where c.IDKHACH == item.idkhach select c.id).ToList();
                stuff a1 = new stuff();
                a1.hoten = item.HOTEN;
                a1.diachi = item.DIACHI;
                a1.sdt = item.SDT;
                a1.tenhang = item.TENHANG;
                a1.giatien = item.GIATIEN;
                //if (a1.soghedamua == null) break;
                listHangHoa.Add(a1);
            }
        }
        void loadstuff()
        {
            listhanghoanek();
            listhanghoa.ItemsSource = listHangHoa;
        }
        public class stuff
        {
            public string hoten { get; set; }
            public string diachi { get; set; }
            public string sdt { get; set; }
            public string tenhang { get; set; }
            public int? giatien { get; set; }
        }

    }
}
