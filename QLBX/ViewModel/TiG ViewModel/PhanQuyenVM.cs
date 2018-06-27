using QLBX.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBX.ViewModel
{
    public class PhanQuyenVM:BaseViewModel
    {
        private ObservableCollection<USER> _ListUserChuaQuyen;
        public ObservableCollection<USER> ListUserChuaQuyen { get => _ListUserChuaQuyen;set { _ListUserChuaQuyen = value;OnPropertyChanged(); } }
        public PhanQuyenVM()
        {
            ListUserChuaQuyen = new ObservableCollection<USER>(DataProvider.Ins.DB.USERs);
        }
    }
}
