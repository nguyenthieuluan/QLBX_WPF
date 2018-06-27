using QLBX.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace QLBX.ViewModel
{
    public class ThongKeVM:BaseViewModel
    {
        //List<ThongKeChuyen> listThongKe = new List<ThongKeChuyen>();

        private ObservableCollection<ThongKeChuyen> _listviewThongKe;
        public ObservableCollection<ThongKeChuyen> listviewThongKe { get => _listviewThongKe; set { _listviewThongKe = value; OnPropertyChanged(); } }
        public ThongKeVM()
        {
            var result = (from a in DataProvider.Ins.DB.CHUYENXEs
                         join b in DataProvider.Ins.DB.VEXEs
                         on a.IDCHUYEN equals b.IDCHUYEN
                         join c in DataProvider.Ins.DB.CHITIETVEs
                         on b.IDVE equals c.IDVE
                         select new
                         {
                             idchuyen=a.IDCHUYEN,
                             idtuyen = a.IDTUYEN,
                             trangthai=b.TRANGTHAI,
                             tenghe=c.SOGHE,
                             tine=a.GIAVECHUYEN
                         }).ToList();
            listviewThongKe = new ObservableCollection<ThongKeChuyen>();
            foreach (var item in result)
            {
                ThongKeChuyen a = new ThongKeChuyen();
                a.TenTuyen = TenTuyen(item.idtuyen,item.idchuyen,item.tine);
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
        string TenTuyen(int? id,int? idchuyen,Decimal? tien)
        {
            int dem = 0;
            var ben = DataProvider.Ins.DB.TUYENXEs.Where(x => x.IDTUYEN == id);
            var kq = DataProvider.Ins.DB.VEXEs.Where(x => x.IDCHUYEN == idchuyen).ToList();
            var kq2 = DataProvider.Ins.DB.CHUYENXEs.Where(x => x.IDCHUYEN == idchuyen).ToList();
            string ngay = kq2[0].NGAYKHOIHANH.ToString();
            foreach(var item in kq)
            {
                var kq1 = DataProvider.Ins.DB.CHITIETVEs.Where(x => x.IDVE == item.IDVE).ToList();
                dem += kq1.Count();
            }
            int n = dem*Convert.ToInt32(tien);
            int? bendi = ben.First().BENDI;
            int? benden = ben.First().BENDEN;
            return layben(bendi).Replace(" ", "") + " - " + layben(benden).Replace(" ", "")+"  Tong Tien: "+n.ToString()+"  Ngay Khoi Hanh:  "+ngay;
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


    //}
}
