using QLBX.FormChucNang;
using QLBX.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace QLBX.ViewModel
{
    public class MainViewModelTiG : BaseViewModel
    {
        private List<KHACHDIXE> _KhachHangList;
        public List<KHACHDIXE> KhachHangList
        {
            get { return _KhachHangList; }
            set { _KhachHangList = value; OnPropertyChanged(); }
        }

        private List<NHANVIENXE> _NhanVienXeList;
        public List<NHANVIENXE> NhanVienXeList
        {
            get { return _NhanVienXeList; }
            set { _NhanVienXeList = value; OnPropertyChanged(); }
        }
        private List<CHUYENXE> _ChuyenXeList;
        public List<CHUYENXE> ChuyenXeList
        {
            get { return _ChuyenXeList; }
            set { _ChuyenXeList = value; OnPropertyChanged(); }
        }
        private List<CHUYENXE> _ChuyenXeList1;
        public List<CHUYENXE> ChuyenXeList1
        {
            get { return _ChuyenXeList1; }
            set { _ChuyenXeList1 = value; OnPropertyChanged(); }
        }
        private List<int> _ChuyenXeSapChay;
        public List<int> ChuyenXeSapChay
        {
            get { return _ChuyenXeSapChay; }
            set { _ChuyenXeSapChay = value; OnPropertyChanged(); }
        }
        public List<ItemListVeVM> ListChoNgoi = new List<ItemListVeVM>();
        private ObservableCollection<ModelTuyen> _TuyenXeList;
        public ObservableCollection<ModelTuyen> TuyenXeList { get => _TuyenXeList; set { _TuyenXeList = value; OnPropertyChanged(); } }
        private ObservableCollection<ModelBenXe> _BenXeList;
        public ObservableCollection<ModelBenXe> BenXeList { get => _BenXeList; set { _BenXeList = value; OnPropertyChanged(); } }
        //private string urlimg;
        //public string Urlimg {
        //    get { return urlimg; }
        //    set { urlimg = value; }
        //}
        public ICommand Urlimg { get; set; }

        /// <summary> xu ly ve
        public List<idvevatrangthai> ListIDVeVaTrangThai = new List<idvevatrangthai>();
        /// </summary>
        public bool Isloaded = false;
        public ICommand KhachHangCommand { get; set; }
        public ICommand TaiXeCommand { get; set; }
        public ICommand DatMuaVeCommand { get; set; }
        public ICommand NhanVienBanVeCommand { get; set; }
        public ICommand KhachGuiNhanHangCommand { get; set; }
        public ICommand ChuyenXeCommand { get; set; }
        public ICommand TuyenXeCommand { get; set; }
        public ICommand BaoCaoThongKeCommand { get; set; }
        public ICommand PhuXeCommand { get; set; }
        public ICommand GiaoNhanHangCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand LoadFormTicket { get; set; }
        public string duongdan { get; set; }
        //diem di diem den form booking
        public ICommand SelectionChangedCommandBenDi { get; set; }
        private int? _DiemDi;
        public int? DiemDi { get => _DiemDi; set { _DiemDi = value; OnPropertyChanged(); } }
        public ICommand SelectionChangedCommandBenDen { get; set; }
        private int? _DiemDen;
        public int? DiemDen { get => _DiemDen; set { _DiemDen = value; OnPropertyChanged(); } }
        public static string idnvNOW = null; 
        string cocn;
        private string _testdemo;
        public string testdemo { get => _testdemo;set { _testdemo = value;OnPropertyChanged(); } }

        public MainViewModelTiG()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Isloaded = true;
                LoginForm login = new LoginForm();
                if (p == null)
                    return;
                p.Hide();
                login.ShowDialog();
                if (login.DataContext == null)
                    return;
                var loginVM = login.DataContext as LoginVM;

                if (loginVM.IsLogin)
                {
                    p.Show();
                    idnvNOW = loginVM.UserName;
                    try
                    {
                        cocn = layhinh(loginVM.UserName);
                    }
                    catch
                    {
                        cocn = null;
                    }
                }
                else
                {
                    p.Close();
                }
            }
            );

            xoavechuathanhtoan();
            //urlimg = cocn;
            ////  LoadNhanVienXe();
            //MessageBox.Show(urlimg);
            LoadTuyenXe();
            LoadBenXe();
            Urlimg = new RelayCommand<ImageBrush>((j) => { return true; }, (j) =>
            {
                if (cocn == null) return;
                Uri uri = new Uri(cocn, UriKind.Relative);
                //duongdan = "Img/admin.jpg";
                ImageSource imgSource = new BitmapImage(uri);

                j.ImageSource = imgSource;
            });

            
            



            SelectionChangedCommandBenDi = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                DiemDi = (p.SelectedItem as ModelBenXe).IDBEN;
                if (DiemDen != null)
                {
                    GetListIDvexe.ListChoNgoiVaTrangThai = new List<ItemListVeVM>();
                    ds(DiemDi, DiemDen);
                    ListIDVeVaTrangThai = new List<idvevatrangthai>();
                    ListChoNgoi = new List<ItemListVeVM>();
                }
            });
            SelectionChangedCommandBenDen = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                DiemDen = (p.SelectedItem as ModelBenXe).IDBEN;
                if (DiemDi != null)
                {
                    GetListIDvexe.ListChoNgoiVaTrangThai = new List<ItemListVeVM>();
                    ds(DiemDi, DiemDen);
                    ListIDVeVaTrangThai = new List<idvevatrangthai>();
                    ListChoNgoi = new List<ItemListVeVM>();
                }
              
            });
            #region backup
            //LoadFormTicket = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            //{
            //    //FrameworkElement c1 = p.Content as FrameworkElement;
            //    //FrameworkElement c2 = c1. as FrameworkElement;

            //    //int a1= (a2.SelectedItem as CHUYENXE).IDCHUYEN;
            //    //MessageBox.Show(a1.ToString());
            //    UCVeXe uc1 = new UCVeXe();

            //    Grid abc = p.Parent as Grid;
            //    // if (abc.Children != null)
            //    try
            //    {
            //        abc.Children.Clear();
            //        abc.Children.Add(uc1);
            //    }
            //    catch { }
            //    //else return; 
            //});
            #endregion
            LoadFormTicket = new RelayCommand<ListView>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement c1 = p.Parent as FrameworkElement;
                FrameworkElement c2 = c1.Parent as FrameworkElement;
                FrameworkElement c3 = c2.Parent as FrameworkElement;
                // if (abc.Children != null)
                try
                {

                    StaticIDChuyen.StaIDchuyen = new int();
                    StaticIDChuyen.StaIDchuyen = (p.SelectedItem as CHUYENXE).IDCHUYEN;
                    getidve((p.SelectedItem as CHUYENXE).IDCHUYEN);
                    ghexe(ListIDVeVaTrangThai);
                    UCVeXe uc1 = new UCVeXe();
                    ChuyenXeList.Clear();
                    Grid abc = c3.Parent as Grid;
                    abc.Children.Clear();
                    abc.Children.Add(uc1);
                }
                catch { }
                //else return; 
            });

        }
        public void LoadKhachHang()
        {
            KhachHangList = DataProvider.Ins.DB.KHACHDIXEs.ToList();
        }
        public void LoadNhanVienXe()
        {
            NhanVienXeList = DataProvider.Ins.DB.NHANVIENXEs.ToList();
        }
        public void LoadTuyenXe()
        {
            TuyenXeList = new ObservableCollection<ModelTuyen>();
            var ojbe = DataProvider.Ins.DB.TUYENXEs;
            foreach (var item in ojbe)
            {
                ModelTuyen tuyenVM = new ModelTuyen();
                tuyenVM.IDTUYEN = item.IDTUYEN;
                tuyenVM.BENDI = (int)item.BENDI;
                tuyenVM.BENDEN = (int)item.BENDEN;
                TuyenXeList.Add(tuyenVM);
            }
        }
        public void LoadBenXe()
        {
            BenXeList = new ObservableCollection<ModelBenXe>();
            var ojbe = DataProvider.Ins.DB.BENXEs;
            foreach (var item in ojbe)
            {
                ModelBenXe tuyenVM = new ModelBenXe();
                tuyenVM.IDBEN = item.IDBEN;
                tuyenVM.TENBEN = item.TENBEN;
                tuyenVM.TINH = item.TINH;
                BenXeList.Add(tuyenVM);
            }
        }
        public int LoadTuyenXeKhiClick(int? a, int? b)
        {
            int d=-1;
            var result = from c in DataProvider.Ins.DB.TUYENXEs where c.BENDI == a && c.BENDEN == b select c;
            foreach (var item in result)
            {
                d = item.IDTUYEN;
            }
            return d;
        }
        int ktngay(DateTime? a,DateTime b)
        {
            string c = a.Value.ToShortDateString();
            DateTime d = Convert.ToDateTime(c);
            return DateTime.Compare(d, b);
        }
        public void LoadChuyen(int a)
        {
            ChuyenXeList1 = new List<CHUYENXE>();
            ChuyenXeList = new List<CHUYENXE>();
            ChuyenXeList1 = (from c in DataProvider.Ins.DB.CHUYENXEs where c.IDTUYEN == a  select c).ToList();
            foreach (var item in ChuyenXeList1)
            {
                DateTime? ngay = item.NGAYKHOIHANH;

                if (ktngay(ngay, DateTime.Now) > -1)
                {
                    ChuyenXeList.Add(item);
                }
            }
        }
        public void ds(int? a, int? b)
        {
            LoadChuyen(LoadTuyenXeKhiClick(a, b));
        }
        public void getidve(int a)
        {
            var result = (from c in DataProvider.Ins.DB.VEXEs where c.IDCHUYEN == a select c).ToList();
            foreach (var item in result)
            {
                idvevatrangthai b = new idvevatrangthai();
                b.idve = item.IDVE;
                b.trangthai = item.TRANGTHAI;
                ListIDVeVaTrangThai.Add(b);
            }
            
        }
        public void ghexe(List<idvevatrangthai> a)
        {
            foreach (var item in a)
            {
                var result = (from c in DataProvider.Ins.DB.CHITIETVEs where c.IDVE == item.idve select c).ToList();
                //ListChoNgoi = new List<int?>();
                foreach (var item1 in result)
                {
                    ItemListVeVM b1 = new ItemListVeVM();
                    b1.chongoi = item1.SOGHE;
                    b1.trangthai = item.trangthai;
                    b1.idkhach = item1.IDKHACH;
                    ListChoNgoi.Add(b1);
                }
            }
            GetListIDvexe.ListChoNgoiVaTrangThai = ListChoNgoi;
        }
        //public void test()
        //{
        //    var result = (from c in DataProvider.Ins.DB.KHACHDIXEs select c).ToList();
        //    string s = result.OrderByDescending(p => p.IDKHACH).First().IDKHACH.ToString();
        //    MessageBox.Show(s);
        //}
        private string layhinh(string a)
        {
            var b = DataProvider.Ins.DB.NhanViens.Where(x => x.UserName == a).First();
            return b.Hinh;
            
        }
        int trungay(DateTime? a, DateTime b)
        {
            string c = a.Value.ToShortDateString();
            DateTime d = Convert.ToDateTime(c);
            TimeSpan diff = b - d;
            return diff.Days;
        }
        void DsChuyenSapChay()
        {
            ChuyenXeSapChay = new List<int>();
            var result = DataProvider.Ins.DB.CHUYENXEs.ToList();
            foreach(var item in result)
            {
                DateTime? ngay = item.NGAYKHOIHANH;
                if (trungay(ngay, DateTime.Now) >-1 )
                {
                    ChuyenXeSapChay.Add(item.IDCHUYEN);
                }
            }
        }
        void xoavechuathanhtoan()
        {
            DsChuyenSapChay();
            var dsvexe1 = DataProvider.Ins.DB.VEXEs;
            List<VEXE> resuolt = new List<VEXE>();
            foreach (var item in ChuyenXeSapChay)
            {
                foreach(var item1 in dsvexe1)
                {
                    if(item1.IDCHUYEN==item)
                    {
                        resuolt.Add(item1);
                    }
                }
                //var res = DataProvider.Ins.DB.VEXEs.Where(x => x.IDCHUYEN == item);
                //resuolt.Add(res);
            }
            List<VEXE> vechuathanhtoan = new List<VEXE>();
            foreach(var item in resuolt)
            {
                if(item.TRANGTHAI==false)
                {
                    vechuathanhtoan.Add(item);
                }
            }
            List<CHITIETVE> dschitietvechuathanhtoan = new List<CHITIETVE>();
            var dschitetve = DataProvider.Ins.DB.CHITIETVEs.ToList();
            foreach(var item1 in dschitetve)
            {
                foreach(var item2 in vechuathanhtoan)
                {
                    if (item2.IDVE == item1.IDVE)
                        dschitietvechuathanhtoan.Add(item1);
                }
            }
            foreach(var item in dschitietvechuathanhtoan)
            {
                DataProvider.Ins.DB.CHITIETVEs.Remove(item);
                DataProvider.Ins.DB.SaveChanges();
            }
            foreach (var item in vechuathanhtoan)
            {
                DataProvider.Ins.DB.VEXEs.Remove(item);
                DataProvider.Ins.DB.SaveChanges();
            }
        }
    }
}
