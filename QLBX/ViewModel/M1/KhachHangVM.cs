using QLBX.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLBX.ViewModel
{
    public class KhachHangVM
    {
        private ObservableCollection<KHACHDIXE> _KhachHangList;
        public ObservableCollection<KHACHDIXE> KhachHangList
        {
            get { return _KhachHangList; }
            set { _KhachHangList= value; }
        }
        public KhachHangVM()
        {
            //KhachHangList = new ObservableCollection<KHACHDIXE>(DataProvider.Ins.DB.KHACHDIXEs);
        }

    //public ICommand DeleteCommand { get; set; }

    //public ICommand Command { get; set; }


}
}
