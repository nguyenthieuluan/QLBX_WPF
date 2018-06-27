
using QLBX.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace QLBX.ViewModel
{
    public class BenXeSubVM:BaseViewModel
    {
        private ObservableCollection<NHANVIENXE> _NhanVienXeList;
        public ObservableCollection<NHANVIENXE> NhanVienXeList { get { return _NhanVienXeList; } set { _NhanVienXeList = value; OnPropertyChanged(); } }
        private int _IDBEN;
        public int IDBEN { get => _IDBEN; set { _IDBEN = value;OnPropertyChanged(); } }

        public BenXeSubVM()
        {
        }
        public BenXeSubVM(int IdBen)
        {
            NhanVienXeList = new ObservableCollection<NHANVIENXE>(DataProvider.Ins.DB.NHANVIENXEs.Where((p => p.BENHIENTAI == 1)));

        }

    }
}
