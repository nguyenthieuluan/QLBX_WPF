using QLBX.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace QLBX.ViewModel
{
    public class TuyenXe0VM:BaseViewModel
    {
        #region Command
        public ICommand AddCommand { get; set; }
        //public ICommand SelectionChangedCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        #endregion

        #region List
        //List tuyến xe
        private ObservableCollection<TUYENXE> _TuyenXeList;
        public ObservableCollection<TUYENXE> TuyenXeList { get { return _TuyenXeList; } set { _TuyenXeList = value; OnPropertyChanged(); } }
        //List bến xe
        private ObservableCollection<BENXE> _BenXeList;
        public ObservableCollection<BENXE> BenXeList { get { return _BenXeList; } set { BenXeList = value; OnPropertyChanged(); } }
        #endregion


        public TuyenXe0VM()
        {
            TuyenXeList = new ObservableCollection<TUYENXE>(DataProvider.Ins.DB.TUYENXEs);
        }
    }
}
