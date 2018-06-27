using QLBX.FormChucNang;
using QLBX.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Linq;

namespace QLBX.ViewModel
{
    public delegate void SendID(int value);
    public class BenXeVM : BaseViewModel
    {
        #region Commands

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        #endregion

        private ObservableCollection<BENXE> _BenXeList;
        public ObservableCollection<BENXE> BenXeList { get { return _BenXeList; } set { _BenXeList = value; OnPropertyChanged(); } }
        private ObservableCollection<NHANVIENXE> _NhanVienXeSubList;
        public ObservableCollection<NHANVIENXE> NhanVienXeSubList { get { return _NhanVienXeSubList; } set { _NhanVienXeSubList = value; OnPropertyChanged(); } }

        #region SelectedItem

        private BENXE _SelectedItem;
        public BENXE SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; if (SelectedItem != null)
                {
                    ID = SelectedItem.IDBEN;
                    TENBEN = SelectedItem.TENBEN;
                    TINH = SelectedItem.TINH;
                };
            }
        }

        private int _ID;
        public int ID { get => _ID; set { _ID = value; OnPropertyChanged(); } }
        private string _TENBEN;
        public string TENBEN { get => _TENBEN; set { _TENBEN = value; OnPropertyChanged(); } }
        private string _TINH;
        public string TINH { get => _TINH; set { _TINH = value; OnPropertyChanged(); } }
        #endregion

        public BenXeVM()
        {
            BenXeList = new ObservableCollection<BENXE>(DataProvider.Ins.DB.BENXEs);
            SelectionChangedCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                NhanVienXeSubList = new ObservableCollection<NHANVIENXE>(DataProvider.Ins.DB.NHANVIENXEs.Where(q => q.BENHIENTAI == ID));
                BenXeSubVM w = new BenXeSubVM(ID);
                BenXeSubForm bxsf = new BenXeSubForm();
                bxsf.ShowDialog();
            });

            //Commands
            #region Command
            AddCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    var bx = new BENXE();
                    bx.TENBEN = TENBEN;
                    bx.TINH = TINH;
                    DataProvider.Ins.DB.BENXEs.Add(bx);
                    DataProvider.Ins.DB.SaveChanges();
                    BenXeList.Add(bx);
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Bến đã tồn tại!");
                }
                
            });

            EditCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    var bx = DataProvider.Ins.DB.BENXEs.Where(x => x.IDBEN == ID).SingleOrDefault();
                    bx.TENBEN = TENBEN;
                    bx.TINH = TINH;
                    DataProvider.Ins.DB.SaveChanges();
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Bến đang sử dụng!");
                }
            });

            DeleteCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                try
                {
                    var bx = DataProvider.Ins.DB.BENXEs.Where(x => x.IDBEN == ID).SingleOrDefault();
                    DataProvider.Ins.DB.BENXEs.Remove(bx);
                    DataProvider.Ins.DB.SaveChanges();
                    BenXeList.Remove(bx);
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Bến đang sử dụng!");
                }
                
            });
            #endregion

        }
    }
}
