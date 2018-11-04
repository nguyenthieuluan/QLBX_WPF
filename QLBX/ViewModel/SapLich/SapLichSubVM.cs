using GongSolutions.Wpf.DragDrop;
using QLBX.Model;
using QLBX.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace QLBX.ViewModel
{
    class SapLichSubVM:BaseViewModel,IDropTarget
    {
        //private NHANVIENXE selectedTaiXe;
        //public NHANVIENXE SelectedTaiXe { get => selectedTaiXe; set { selectedTaiXe = value; OnPropertyChanged(); } }


        //private int? _IDTUYEN;
        //public int? IDTUYEN { get => _IDTUYEN; set { _IDTUYEN = value; OnPropertyChanged(); } }
        //private int _IDCHUYEN;
        //public int IDCHUYEN { get => _IDCHUYEN; set { _IDCHUYEN = value; OnPropertyChanged(); } }
        //private string _BIENSO;
        //public string BIENSO { get => _BIENSO; set { _BIENSO = value; OnPropertyChanged(); } }
        //private DateTime? _NGAYKHOIHANH;
        //public DateTime? NGAYKHOIHANH { get => _NGAYKHOIHANH; set { _NGAYKHOIHANH = value; OnPropertyChanged(); } }
        //private TimeSpan? _GIOKHOIHANH;
        //public TimeSpan? GIOKHOIHANH { get => _GIOKHOIHANH; set { _GIOKHOIHANH = value; OnPropertyChanged(); } }
        //private decimal? _GIAVECHUYEN;
        //public decimal? GIAVECHUYEN { get => _GIAVECHUYEN; set { _GIAVECHUYEN = value; OnPropertyChanged(); } }

        //Command
        public ICommand Command { get; set; }
        public ICommand LuuCommand { get; set; }

        //Chi tiet tuyen sap lich
        private ChiTietTuyen _ChiTietTuyen;
        public ChiTietTuyen ChiTietTuyen { get => _ChiTietTuyen; set { _ChiTietTuyen = value; OnPropertyChanged(); } }

        //List xe uu tien    
        private ObservableCollection<XE> _ListXeUuTien;
        public ObservableCollection<XE> ListXeUuTien { get => _ListXeUuTien; set { _ListXeUuTien = value; OnPropertyChanged(); } }
        //List nhan vien uu tien
        private ObservableCollection<XE> _ListNhanVienUuTien;
        public ObservableCollection<XE> ListNhanVienUuTien { get => _ListNhanVienUuTien; set { _ListNhanVienUuTien = value; OnPropertyChanged(); } }

        //Chuyen xe kq
        private ObservableCollection<CHUYENXE> _ListChuyenXe;
        public ObservableCollection<CHUYENXE> ListChuyenXe { get => _ListChuyenXe; set { _ListChuyenXe = value; OnPropertyChanged(); } }

        private List<int> sort;
        public List<int> Sort { get => sort; set { sort = value; OnPropertyChanged(); } }


        public SapLichSubVM()
        {
            

            #region Command

            Command = new RelayCommand<object>((p) => { return true; }, (p) => {

                //var cx = new CHUYENXE();
                //    cx.IDTUYEN = ChiTietTuyen.IDTUYEN;
                //    cx.BIENSO = "bs001";
                //    cx.NGAYKHOIHANH = NGAYKHOIHANH;
                //    cx.THOIGIANKHOIHANH = GIOKHOIHANH;
                //    cx.GIAVECHUYEN = 100;
                //    cx.IDNV1 = 1;
                //    DataProvider.Ins.DB.CHUYENXEs.Add(cx);
                //    DataProvider.Ins.DB.SaveChanges();
                //    ListChuyenXe.Add(cx);


                int soluongchuyen = ChiTietTuyen.SOCHUYEN;
                int soluongxe = ChiTietTuyen.SOLUONGXE;
                int soluongtaixe = ChiTietTuyen.SOLUONGTAIXE;
                int IDTUYEN = ChiTietTuyen.IDTUYEN;
                var XeList = ChiTietTuyen.XELIST;
                var TaiXeList = ChiTietTuyen.NHANVIENLIST;
                DateTime NGAYKHOIHANH = ChiTietTuyen.NGAYDI;

                //ObservableCollection<XE> danhsachxe = new ObservableCollection<XE>();
                //if (ListXeUuTien != null)
                //{
                //    foreach (XE x1 in ListXeUuTien)
                //    {
                //        danhsachxe.Add(x1);
                //    }
                //}
                //if (XeList != null)
                //{
                //    foreach (XE x2 in XeList)
                //    {
                //        danhsachxe.Add(x2);
                //    }
                //}
                //ObservableCollection<XE> danhsachxe = new ObservableCollection<XE>();
                int tam1 = 0;
                int tam2 = 0;
                int tam3 = ChiTietTuyen.X;
                for (int i = 0; i < soluongchuyen; i++)
                {

                    var x = new CHUYENXE();
                    x.IDCHUYEN = 100;
                    x.IDTUYEN = IDTUYEN;
                    x.NGAYKHOIHANH = NGAYKHOIHANH;
                    x.GIAVECHUYEN = 100;
                    x.THOIGIANKHOIHANH = TimeSpan.FromHours(tam3); ;
                    //x.IDNV2 = 3;
                    //x.IDNV3 = 2;
                    //x.IDNV4 = 1;
                    x.THOIGIANDEN = DateTime.Now;
                    x.IDNV1 = 1;
                    x.BIENSO = "bs001";
                    try
                    {
                        if (tam1 < soluongxe)
                        {
                            x.BIENSO = XeList[tam1].BIENSO;
                            tam1++;
                        }
                        else
                        {
                            x.BIENSO = XeList[0].BIENSO;
                            tam1 = 1;
                        }
                        if (tam2 < soluongtaixe)
                        {
                            x.IDNV1 = TaiXeList[tam2].IDNHANVIENXE;
                            tam2++;
                        }
                        else
                        {
                            x.IDNV1 = TaiXeList[0].IDNHANVIENXE;
                            tam2 = 1;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không thành công!");
                    }

                    //MessageBox.Show(x.BIENSO+ "  "+x.IDNV1);
                    //x.IDNV1 = TaiXeList[0].IDNHANVIENXE;
                    DataProvider.Ins.DB.CHUYENXEs.Add(x);
                    DataProvider.Ins.DB.SaveChanges();
                    //ListChuyenXe.Add(x);
                    tam3 += ChiTietTuyen.X;
                }
                MessageBox.Show("Xuất Thành Công!");
                //UserControl1 x = new UserControl1();
                //x.ListXe = ChiTietTuyen.XELIST;
                //x.ShowDialog();
            });
            LuuCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                UserControl1 x = new UserControl1();
                x.ListXe = ChiTietTuyen.XELIST;
                x.ShowDialog();
            });
            #endregion
        }

        #region Drop and Drag

        void IDropTarget.DragOver(IDropInfo dropInfo)
        {
            throw new System.NotImplementedException();
        }

        void IDropTarget.Drop(IDropInfo dropInfo)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
