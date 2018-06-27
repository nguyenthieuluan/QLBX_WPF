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
    public class QuanLyXeVM : BaseViewModel
    {
        private bool flag;
        //Commands
        #region Commands
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddLoaiXeCommand { get; set; }
        public ICommand EditLoaiXeCommand { get; set; }
        public ICommand DeleteLoaiXeCommand { get; set; }
        #endregion

        private ObservableCollection<XE> _XeList;
        public ObservableCollection<XE> XeList { get { return _XeList; } set { _XeList = value; OnPropertyChanged(); } }

        private ObservableCollection<LOAIXE> _LoaiXeList;
        public ObservableCollection<LOAIXE> LoaiXeList { get { return _LoaiXeList; } set { _LoaiXeList = value; OnPropertyChanged(); } }

        //Xe selected item
        #region MyRegion
        
        private XE _SelectedItem1;
        public XE SelectedItem1
        {
            get => _SelectedItem1; set
            {
                _SelectedItem1 = value; if (SelectedItem1 != null)
                {
                    BIENSO = SelectedItem1.BIENSO;
                    NHASANXUAT = SelectedItem1.NHASANXUAT;
                    NGAYMUA = SelectedItem1.NGAYMUA;
                    SelectedLoaiXe = SelectedItem1.LOAIXE;
                };
            }
        }
        private LOAIXE _SelectedLoaiXe;
        public LOAIXE SelectedLoaiXe { get => _SelectedLoaiXe; set { _SelectedLoaiXe = value; OnPropertyChanged(); } }
        private int _LOAIXE;
        public int LOAIXE { get => _LOAIXE; set { _LOAIXE = value; OnPropertyChanged(); } }

        private string _BIENSO;
        public string BIENSO { get => _BIENSO; set { _BIENSO = value; OnPropertyChanged(); } }

        private string _NHASANXUAT;
        public string NHASANXUAT { get => _NHASANXUAT; set { _NHASANXUAT = value; OnPropertyChanged(); } }

        private DateTime? _NGAYMUA;
        public DateTime? NGAYMUA { get => _NGAYMUA; set { _NGAYMUA = value; OnPropertyChanged(); } }
        #endregion

        //Loai xe selected item
        #region MyRegion

        private LOAIXE _SelectedItem;
        public LOAIXE SelectedItem { get => _SelectedItem; set { _SelectedItem = value; if (SelectedItem != null) {
                    IDLOAI = SelectedItem.IDLOAI;
                    TENLOAI = SelectedItem.TENLOAI;
                    SOCHONGOI = SelectedItem.SOCHONGOI;
                    HESOGIAVE = SelectedItem.HESOGIAVE;
                }; } }

        private int _IDLOAI;
        public int IDLOAI { get => _IDLOAI; set { _IDLOAI = value; OnPropertyChanged(); } }

        private string _TENLOAI;
        public string TENLOAI { get => _TENLOAI; set { _TENLOAI = value; OnPropertyChanged(); } }

        private int? _SOCHONGOI;
        public int? SOCHONGOI { get => _SOCHONGOI; set { _SOCHONGOI = value; OnPropertyChanged(); } }

        private double? _HESOGIAVE;
        public double? HESOGIAVE { get => _HESOGIAVE; set { _HESOGIAVE = value; OnPropertyChanged(); } }

        public bool Flag { get => flag; set => flag = value; }
        #endregion

        public QuanLyXeVM()
        {
            XeList = new ObservableCollection<XE>(DataProvider.Ins.DB.XEs);
            LoaiXeList = new ObservableCollection<LOAIXE>(DataProvider.Ins.DB.LOAIXEs);

            #region Command

            //Command xe
            AddCommand = new RelayCommand<object>((p) =>{ return true;}, (p) =>
            {
                var x = new XE();
                try
                {
                    x.BIENSO = BIENSO;
                    x.NHASANXUAT = NHASANXUAT;
                    x.NGAYMUA = NGAYMUA;
                    x.IDLOAI = SelectedLoaiXe.IDLOAI;
                    DataProvider.Ins.DB.XEs.Add(x);
                    DataProvider.Ins.DB.SaveChanges();
                    XeList.Add(x);
                }
                catch (Exception)
                {
                    MessageBox.Show("Trùng biển số!");
                }
               
            });
            EditCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    var x = DataProvider.Ins.DB.XEs.Where(t => t.BIENSO == BIENSO).SingleOrDefault();
                    x.BIENSO = BIENSO;
                    x.NHASANXUAT = NHASANXUAT;
                    x.NGAYMUA = NGAYMUA;
                    x.IDLOAI = SelectedLoaiXe.IDLOAI;
                    DataProvider.Ins.DB.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Xe đang sử dụng!");
                }
                
            });
            DeleteCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (SelectedItem1 != null)
                {
                    try
                    {
                        var x = DataProvider.Ins.DB.XEs.Where(t => t.BIENSO == BIENSO).SingleOrDefault();
                        DataProvider.Ins.DB.XEs.Remove(x);
                        DataProvider.Ins.DB.SaveChanges();
                        XeList.Remove(SelectedItem1);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xe đang sử dụng!");
                    }
                    
                }
            });

            //Commands loai xe
            AddLoaiXeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                int i = 1;
                foreach(LOAIXE x in LoaiXeList)
                {
                    if (TENLOAI == x.TENLOAI)
                        i = 0;
                }
                if (i == 1)
                {
                    var lx = new LOAIXE();
                    lx.TENLOAI = TENLOAI;
                    lx.SOCHONGOI = SOCHONGOI;
                    lx.HESOGIAVE = HESOGIAVE;
                    DataProvider.Ins.DB.LOAIXEs.Add(lx);
                    DataProvider.Ins.DB.SaveChanges();
                    LoaiXeList.Add(lx);
                }
                else MessageBox.Show("Loại xe đã tồn tại!");
            });
            EditLoaiXeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    var lx = DataProvider.Ins.DB.LOAIXEs.Where(x => x.IDLOAI == IDLOAI).SingleOrDefault();
                    lx.TENLOAI = TENLOAI;
                    lx.SOCHONGOI = SOCHONGOI;
                    lx.HESOGIAVE = HESOGIAVE;
                    DataProvider.Ins.DB.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Loại xe đang sử dụng!");
                }
                
            });
            DeleteLoaiXeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (SelectedItem != null)
                {
                    try
                    {
                        var lx = DataProvider.Ins.DB.LOAIXEs.Where(x => x.IDLOAI == IDLOAI).SingleOrDefault();
                        DataProvider.Ins.DB.LOAIXEs.Remove(lx);
                        DataProvider.Ins.DB.SaveChanges();
                        LoaiXeList.Remove(SelectedItem);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Loại xe đang sử dụng!");
                    }

                }
            });
            #endregion
        }
    }
}
