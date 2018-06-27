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
    public class ChuyenXeVM:BaseViewModel
    {
        #region Commands

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
      
        #endregion

        private ObservableCollection<CHUYENXE> _ChuyenXeList;
        public ObservableCollection<CHUYENXE> ChuyenXeList{ get { return _ChuyenXeList; } set { _ChuyenXeList = value; OnPropertyChanged(); }}

        private ObservableCollection<NHANVIENXE> _NhanVienXeList;
        public ObservableCollection<NHANVIENXE> NhanVienXeList { get { return _NhanVienXeList; } set { _NhanVienXeList = value; OnPropertyChanged(); } }
        #region selectedItem

        //Selected item
        private CHUYENXE _SelectedItem;
        public CHUYENXE SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; if (SelectedItem != null)
                {
                    IDTUYEN = SelectedItem.IDTUYEN;
                    IDCHUYEN = SelectedItem.IDCHUYEN;
                    BIENSO = SelectedItem.BIENSO;
                    NGAYKHOIHANH = SelectedItem.NGAYKHOIHANH;
                    GIAVECHUYEN = SelectedItem.GIAVECHUYEN;
                    GIOKHOIHANH = SelectedItem.THOIGIANKHOIHANH;
                    SelectedTaiXe = SelectedItem.NHANVIENXE;
                };
            }
        }

        private NHANVIENXE selectedTaiXe;
        public NHANVIENXE SelectedTaiXe { get => selectedTaiXe; set { selectedTaiXe = value; OnPropertyChanged(); } }


        private int? _IDTUYEN;
        public int? IDTUYEN { get => _IDTUYEN; set { _IDTUYEN = value; OnPropertyChanged(); } }
        private int _IDCHUYEN;
        public int IDCHUYEN { get => _IDCHUYEN; set { _IDCHUYEN = value; OnPropertyChanged(); } }
        private string _BIENSO;
        public string BIENSO { get => _BIENSO; set { _BIENSO = value; OnPropertyChanged(); } }
        private DateTime? _NGAYKHOIHANH;
        public DateTime? NGAYKHOIHANH { get => _NGAYKHOIHANH; set { _NGAYKHOIHANH = value; OnPropertyChanged(); } }
        private TimeSpan? _GIOKHOIHANH;
        public TimeSpan? GIOKHOIHANH { get => _GIOKHOIHANH; set { _GIOKHOIHANH = value; OnPropertyChanged(); } }
        private decimal? _GIAVECHUYEN;
        public decimal? GIAVECHUYEN { get => _GIAVECHUYEN; set { _GIAVECHUYEN = value; OnPropertyChanged(); } }




        #endregion


        public ChuyenXeVM()
        {
            ChuyenXeList = new ObservableCollection<CHUYENXE>(DataProvider.Ins.DB.CHUYENXEs);
            NhanVienXeList = new ObservableCollection<NHANVIENXE>(DataProvider.Ins.DB.NHANVIENXEs);
            #region Command

            AddCommand = new RelayCommand<object>((p) =>{ return true;}, (p) => {
                //MessageBox.Show("Ngày không hộp lệ!");
                if (NGAYKHOIHANH >= DateTime.Now)
                {
                    var cx = new CHUYENXE();
                    try
                    {
                        cx.IDTUYEN = IDTUYEN;
                        cx.BIENSO = BIENSO;
                        cx.NGAYKHOIHANH = NGAYKHOIHANH;
                        cx.THOIGIANKHOIHANH = GIOKHOIHANH;
                        cx.GIAVECHUYEN = GIAVECHUYEN;
                        cx.IDNV1 = selectedTaiXe.IDNHANVIENXE;
                        DataProvider.Ins.DB.CHUYENXEs.Add(cx);
                        DataProvider.Ins.DB.SaveChanges();
                        ChuyenXeList.Add(cx);
                        
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không hợp lệ!");
                    }
                }
                else MessageBox.Show("Ngày không hộp lệ!");
            });

            EditCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                if (NGAYKHOIHANH >= DateTime.Now)
                {
                    try
                    {
                        var cx = DataProvider.Ins.DB.CHUYENXEs.Where(x => x.IDCHUYEN == IDCHUYEN).SingleOrDefault(); ;
                        cx.IDTUYEN = IDTUYEN;
                        cx.BIENSO = BIENSO;
                        cx.NGAYKHOIHANH = NGAYKHOIHANH;
                        cx.THOIGIANKHOIHANH = SelectedItem.THOIGIANKHOIHANH;
                        cx.GIAVECHUYEN = GIAVECHUYEN;
                        cx.IDNV1 = selectedTaiXe.IDNHANVIENXE;
                        //DataProvider.Ins.DB.CHUYENXEs.Add(cx);
                        DataProvider.Ins.DB.SaveChanges();
                        //ChuyenXeList.Add(cx);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không hợp lệ!");
                        throw;
                    }
                }
                else MessageBox.Show("Ngày không hộp lệ!");
            });

            DeleteCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (NGAYKHOIHANH >= DateTime.Now)
                {
                    try
                    {
                        var cx = DataProvider.Ins.DB.CHUYENXEs.Where(x => x.IDCHUYEN == IDCHUYEN).SingleOrDefault(); ;
                        //cx.IDTUYEN = IDTUYEN;
                        //cx.BIENSO = BIENSO;
                        //cx.NGAYKHOIHANH = NGAYKHOIHANH;
                        //cx.THOIGIANKHOIHANH = GIOKHOIHANH;
                        //cx.GIAVECHUYEN = GIAVECHUYEN;
                        //cx.IDNV1 = selectedTaiXe.IDNHANVIENXE;
                        DataProvider.Ins.DB.CHUYENXEs.Remove(cx);
                        DataProvider.Ins.DB.SaveChanges();
                        ChuyenXeList.Remove(cx);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không hợp lệ!");
                        throw;
                    }
                }
                else MessageBox.Show("Ngày không hộp lệ!");
            });
            #endregion
        }
    }
}
