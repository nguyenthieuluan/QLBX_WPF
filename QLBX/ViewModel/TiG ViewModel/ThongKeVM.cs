using QLBX.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace QLBX.ViewModel
{
    public class ThongKeVM:BaseViewModel
    {
        //List<ThongKeChuyen> listThongKe = new List<ThongKeChuyen>();

        private ObservableCollection<ThongKeChuyen> _listviewThongKe;
        public ObservableCollection<ThongKeChuyen> listviewThongKe { get => _listviewThongKe; set { _listviewThongKe = value; OnPropertyChanged(); } }
        private ObservableCollection<ThongKeHangHoa> _listHangHoa;
        public ObservableCollection<ThongKeHangHoa> listHangHoa { get => _listHangHoa; set { _listHangHoa = value; OnPropertyChanged(); } }
        private ObservableCollection<FindTuyen> _Fchuyen;
        public ObservableCollection<FindTuyen> Fchuyen { get => _Fchuyen; set { _Fchuyen = value; OnPropertyChanged(); } }
        public ICommand ChonTuyen { get; set; }
        public ICommand hover { get; set; }

        private int? _MaTuyen;
        public int? MaTuyen { get => _MaTuyen; set { _MaTuyen = value; OnPropertyChanged(); } }

        void process(int? Fchuyen = null)
        {
           // List<object> result = new List<object>();
            if (Fchuyen == null)
            {
                var result = (from a in DataProvider.Ins.DB.CHUYENXEs
                              join b in DataProvider.Ins.DB.VEXEs
                              on a.IDCHUYEN equals b.IDCHUYEN
                              join c in DataProvider.Ins.DB.CHITIETVEs
                              on b.IDVE equals c.IDVE
                              select new
                              {
                                  idchuyen = a.IDCHUYEN,
                                  idtuyen = a.IDTUYEN,
                                  trangthai = b.TRANGTHAI,
                                  tenghe = c.SOGHE,
                                  tine = a.GIAVECHUYEN
                              }).ToList();





                listviewThongKe = new ObservableCollection<ThongKeChuyen>();
                foreach (var item in result)
                {
                    ThongKeChuyen a = new ThongKeChuyen();
                    a.TenTuyen = TenTuyen(item.idtuyen, item.idchuyen, item.tine);
                    if (item.trangthai == true)
                        a.TrangThai = "Da Thanh Toan";
                    else a.TrangThai = "Chua Thanh Toan";
                    a.TenGhe = item.tenghe;
                    a.Tien = item.tine;
                    listviewThongKe.Add(a);
                }
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listviewThongKe);

                PropertyGroupDescription groupDescription = new PropertyGroupDescription("TenTuyen");

                view.GroupDescriptions.Add(groupDescription);
            }
            else
            {
                var result= (from a in DataProvider.Ins.DB.CHUYENXEs
                             join b in DataProvider.Ins.DB.VEXEs
                             on a.IDCHUYEN equals b.IDCHUYEN
                             join c in DataProvider.Ins.DB.CHITIETVEs
                             on b.IDVE equals c.IDVE
                             where a.IDTUYEN==Fchuyen
                             select new
                             {
                                 idchuyen = a.IDCHUYEN,
                                 idtuyen = a.IDTUYEN,
                                 trangthai = b.TRANGTHAI,
                                 tenghe = c.SOGHE,
                                 tine = a.GIAVECHUYEN
                             }).ToList();
                listviewThongKe = new ObservableCollection<ThongKeChuyen>();
                foreach (var item in result)
                {
                    ThongKeChuyen a = new ThongKeChuyen();
                    a.TenTuyen = TenTuyen(item.idtuyen, item.idchuyen, item.tine);
                    if (item.trangthai == true)
                        a.TrangThai = "Da Thanh Toan";
                    else a.TrangThai = "Chua Thanh Toan";
                    a.TenGhe = item.tenghe;
                    a.Tien = item.tine;
                    listviewThongKe.Add(a);
                }
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listviewThongKe);

                PropertyGroupDescription groupDescription = new PropertyGroupDescription("TenTuyen");

                view.GroupDescriptions.Add(groupDescription);
            }
           
        }

        void process1(int? Fchuyen = null)
        {
            // List<object> result = new List<object>();
            if (Fchuyen == null)
            {
                var result = (from a in DataProvider.Ins.DB.CHUYENXEs
                              join b in DataProvider.Ins.DB.GUIHANGHOAs
                              on a.IDCHUYEN equals b.IDCHUYEN
                              
                              select new
                              {
                                  idchuyen = a.IDCHUYEN,
                                  idtuyen = a.IDTUYEN,
                                  tenkhach = b.HOTEN,
                                  diachi = b.DIACHI,
                                  sdt=b.SDT,
                                  tenhang=b.TENHANG,
                                  tien=b.GIATIEN
                              }).ToList();





                listHangHoa = new ObservableCollection<ThongKeHangHoa>();
                foreach (var item in result)
                {
                    ThongKeHangHoa a = new ThongKeHangHoa();
                    a.TenTuyen = TenTuyen1(item.idtuyen, item.idchuyen);
                    a.ten = item.tenkhach;
                    a.diachi = item.diachi;
                    a.sdt = item.sdt;
                    a.tenhang = item.tenhang;
                    a.tien = item.tien;
                    listHangHoa.Add(a);
                }
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listHangHoa);

                PropertyGroupDescription groupDescription = new PropertyGroupDescription("TenTuyen");

                view.GroupDescriptions.Add(groupDescription);
            }
            else
            {
                var result = (from a in DataProvider.Ins.DB.CHUYENXEs
                              join b in DataProvider.Ins.DB.GUIHANGHOAs
                              on a.IDCHUYEN equals b.IDCHUYEN
                              where a.IDTUYEN==Fchuyen
                              select new
                              {
                                  idchuyen = a.IDCHUYEN,
                                  idtuyen = a.IDTUYEN,
                                  tenkhach = b.HOTEN,
                                  diachi = b.DIACHI,
                                  sdt = b.SDT,
                                  tenhang = b.TENHANG,
                                  tien = b.GIATIEN
                              }).ToList();





                listHangHoa = new ObservableCollection<ThongKeHangHoa>();
                foreach (var item in result)
                {
                    ThongKeHangHoa a = new ThongKeHangHoa();
                    a.TenTuyen = TenTuyen1(item.idtuyen, item.idchuyen);
                    a.ten = item.tenkhach;
                    a.diachi = item.diachi;
                    a.sdt = item.sdt;
                    a.tenhang = item.tenhang;
                    a.tien = item.tien;
                    listHangHoa.Add(a);
                }
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listHangHoa);

                PropertyGroupDescription groupDescription = new PropertyGroupDescription("TenTuyen");

                view.GroupDescriptions.Add(groupDescription);
            }

        }

        void loadCB()
        {
            Fchuyen = new ObservableCollection<FindTuyen>();
            FindTuyen a1 = new FindTuyen();
            a1.id = 0; a1.ten = "Tat ca";
            Fchuyen.Add(a1);
            var res = DataProvider.Ins.DB.CHUYENXEs.ToList();
            foreach (var item in res)
            {
                FindTuyen a = new FindTuyen();
                var ben = DataProvider.Ins.DB.TUYENXEs.Where(x => x.IDTUYEN == item.IDTUYEN);
                a.id = item.IDTUYEN;
                int? bendi = ben.First().BENDI;
                int? benden = ben.First().BENDEN;
                a.ten = layben(bendi).Replace(" ", "") + "  -  " + layben(benden).Replace(" ", "");
                Fchuyen.Add(a);
            }
        }

        public ThongKeVM()
        {
            loadCB();
            process();
            process1();
            hover = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
             //   MessageBox.Show("asdf");
            }
            );

            ChonTuyen = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                MaTuyen = (p.SelectedItem as FindTuyen).id;
                if (MaTuyen == 0)
                {
                    process();
                    process1();
                }
                else
                {
                    process(MaTuyen);
                    process1(MaTuyen);
                }
            });

        }
        string TenTuyen(int? id, int? idchuyen, Decimal? tien)
        {
            int dem = 0;
            var ben = DataProvider.Ins.DB.TUYENXEs.Where(x => x.IDTUYEN == id);
            var kq = DataProvider.Ins.DB.VEXEs.Where(x => x.IDCHUYEN == idchuyen).ToList();
            var kq2 = DataProvider.Ins.DB.CHUYENXEs.Where(x => x.IDCHUYEN == idchuyen).ToList();
            string ngay = kq2[0].NGAYKHOIHANH.ToString();
            foreach (var item in kq)
            {
                var kq1 = DataProvider.Ins.DB.CHITIETVEs.Where(x => x.IDVE == item.IDVE).ToList();
                dem += kq1.Count();
            }
            int n = dem * Convert.ToInt32(tien);
            int? bendi = ben.First().BENDI;
            int? benden = ben.First().BENDEN;
            return layben(bendi).Replace(" ", "") + " - " + layben(benden).Replace(" ", "") + "  Tong Tien: " + n.ToString() + "  Ngay Khoi Hanh:  " + ngay.Replace(" 12:00:00 AM", "");
        }

        string TenTuyen1(int? id, int? idchuyen)
        {
            int? dem = 0;
            var ben = DataProvider.Ins.DB.TUYENXEs.Where(x => x.IDTUYEN == id);
            var kq = DataProvider.Ins.DB.GUIHANGHOAs.Where(x => x.IDCHUYEN == idchuyen).ToList();
            var kq2 = DataProvider.Ins.DB.CHUYENXEs.Where(x => x.IDCHUYEN == idchuyen).ToList();
            string ngay = kq2[0].NGAYKHOIHANH.ToString();
            foreach (var item in kq)
            {
                dem +=item.GIATIEN;
            }
            int? bendi = ben.First().BENDI;
            int? benden = ben.First().BENDEN;
            return layben(bendi).Replace(" ", "") + " - " + layben(benden).Replace(" ", "") + "  Tong Tien: " + dem.ToString() + "  Ngay Khoi Hanh:  " + ngay.Replace(" 12:00:00 AM", "");
        }

        private string layben(int? a)
        {
            var resule = DataProvider.Ins.DB.BENXEs.Where(x => x.IDBEN == a);
            return resule.First().TENBEN;
        }
    }
    public class ThongKeChuyen
    {
        public string TenTuyen { get; set; }
        public string TrangThai { get; set; }
        public int? TenGhe { get; set; }
        public Decimal? Tien { get; set; }
    }
    public class ThongKeHangHoa
    {
        public string TenTuyen { get; set; }
        public string ten { get; set; }
        public string diachi { get; set; }
        public string sdt { get; set; }
        public string tenhang { get; set; }
        public int? tien { get; set; }
    }
    public class FindTuyen
    {
        public string ten { get; set; }
        public int? id { get; set; }
    }
    //}
}
