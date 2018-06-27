using QLBX.FormChucNang;
using QLBX.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLBX.ViewModel
{
    public class TaiXeVM : BaseViewModel
    {
        #region Commands

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand TraLichCommand { get; set; }
        #endregion

        #region List
        //List tài xế
        private ObservableCollection<NHANVIENXE> _NhanVienXeList;
        public ObservableCollection<NHANVIENXE> NhanVienXeList { get { return _NhanVienXeList; } set { _NhanVienXeList = value; OnPropertyChanged(); } }
        //List chuyến xe
        private ObservableCollection<CHUYENXE> _LichTrinhNhanVienList;
        public ObservableCollection<CHUYENXE> LichTrinhNhanVienList { get { return _LichTrinhNhanVienList; } set { _LichTrinhNhanVienList = value; OnPropertyChanged(); } }
        //List bằng lái
        private ObservableCollection<LOAIBANGLAI> _LoaiBangLaiList;
        public ObservableCollection<LOAIBANGLAI> LoaiBangLaiList { get { return _LoaiBangLaiList; } set { _LoaiBangLaiList = value; OnPropertyChanged(); } }
        //List phụ xe
        private ObservableCollection<NHANVIENXE> _PhuXeList;
        public ObservableCollection<NHANVIENXE> PhuXeList { get { return _PhuXeList; } set { _PhuXeList = value; OnPropertyChanged(); } }
        #endregion

        #region SelectedItems

        private NHANVIENXE _SelectedItem;
        public NHANVIENXE SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; if (SelectedItem != null)
                {
                    ID = SelectedItem.IDNHANVIENXE;
                    TEN = SelectedItem.HOTEN;
                    NGAYSINH = SelectedItem.NAMSINH;
                    CMND = SelectedItem.CMND;
                    DIACHI = SelectedItem.DIACHI;
                    SDT = SelectedItem.SDT;
                    NGAYTHAMGIA = SelectedItem.NGAYTHAMGIA;
                    SelectedBangLai = SelectedItem.LOAIBANGLAI;
                };
            }
        }

        private LOAIBANGLAI _SelectedBangLai;
        public LOAIBANGLAI SelectedBangLai { get => _SelectedBangLai; set { _SelectedBangLai = value; OnPropertyChanged(); } }

        private int _ID;
        public int ID { get => _ID; set { _ID = value; OnPropertyChanged(); } }
        private string _TEN;
        public string TEN { get => _TEN; set { _TEN = value; OnPropertyChanged(); } }
        private DateTime? _NGAYSINH;
        public DateTime? NGAYSINH { get => _NGAYSINH; set { _NGAYSINH = value; OnPropertyChanged(); } }
        private string _CMND;
        public string CMND { get => _CMND; set { _CMND = value; OnPropertyChanged(); } }
        private string _DIACHI;
        public string DIACHI { get => _DIACHI; set { _DIACHI = value; OnPropertyChanged(); } }
        private string _SDT;
        public string SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }
        private DateTime? _NGAYTHAMGIA;
        public DateTime? NGAYTHAMGIA { get => _NGAYTHAMGIA; set { _NGAYTHAMGIA = value; OnPropertyChanged(); } }
        #endregion

        public TaiXeVM()
        {
            NhanVienXeList = new ObservableCollection<NHANVIENXE>(DataProvider.Ins.DB.NHANVIENXEs.Where((p => p.LOAINHANVIEN == 1)));
            PhuXeList = new ObservableCollection<NHANVIENXE>(DataProvider.Ins.DB.NHANVIENXEs.Where((p => p.LOAINHANVIEN == 0)));
            LoaiBangLaiList = new ObservableCollection<LOAIBANGLAI>(DataProvider.Ins.DB.LOAIBANGLAIs);


            #region Command
            AddCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
              {
                  if (ktCMND(CMND, NhanVienXeList) == 1)
                  {
                      var nv = new NHANVIENXE();
                      nv.HOTEN = TEN;
                      nv.CMND = CMND;
                      nv.DIACHI = DIACHI;
                      nv.SDT = SDT;
                      nv.NGAYTHAMGIA = NGAYTHAMGIA;
                      nv.BANGLAI = SelectedBangLai.IDLOAI;
                      nv.LOAINHANVIEN = 1;
                      DataProvider.Ins.DB.NHANVIENXEs.Add(nv);
                      DataProvider.Ins.DB.SaveChanges();
                      NhanVienXeList.Add(nv);
                  }
                  else MessageBox.Show("Trùng chứng minh nhân dân!");
              });

            EditCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

                var nv = DataProvider.Ins.DB.NHANVIENXEs.Where(x => x.IDNHANVIENXE == SelectedItem.IDNHANVIENXE).SingleOrDefault();
                nv.HOTEN = TEN;
                nv.CMND = CMND;
                nv.DIACHI = DIACHI;
                nv.SDT = SDT;
                nv.NGAYTHAMGIA = NGAYTHAMGIA;
                nv.BANGLAI = SelectedBangLai.IDLOAI;
                DataProvider.Ins.DB.SaveChanges();
            }
            );

            DeleteCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
               {
                           
                        var nv = DataProvider.Ins.DB.NHANVIENXEs.Where(x => x.IDNHANVIENXE == SelectedItem.IDNHANVIENXE).SingleOrDefault();
                    nv.LOAINHANVIEN = null;
                              // nv.BANGLAI = SelectedBangLai.IDLOAI;
                               NhanVienXeList.Remove(nv);
                               DataProvider.Ins.DB.SaveChanges();
               }
               );

            TraLichCommand = new RelayCommand<object>((q) => { return true; }, (q) =>
            {
                LichTrinhNhanVienList = new ObservableCollection<CHUYENXE>(DataProvider.Ins.DB.CHUYENXEs.Where(p => p.IDNV1 == ID || p.IDNV2 == ID || p.IDNV3 == ID || p.IDNV4 == ID));
                LichTrinhForm ltf = new LichTrinhForm();
                ltf.ShowDialog();
            });

            #endregion
        }
        int ktCMND(string cmnd,ObservableCollection<NHANVIENXE> list)
        {
            foreach(NHANVIENXE x in list)
            {
                if (cmnd == x.CMND)
                    return 0;
            }
            return 1;
        }
    }
}
