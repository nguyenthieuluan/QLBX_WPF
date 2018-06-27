using QLBX.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBX.ViewModel
{
    public class ModelTuyen
    {
        //private ObservableCollection<TUYENXE> _TuyenXeList;

        public int IDTUYEN { get; set; }
        public int BENDI { get; set; }
        public int BENDEN { get; set; }
        public float GIAVEMATDINH { get; set; }
    }
}
