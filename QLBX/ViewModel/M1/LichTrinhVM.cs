using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QLBX.ViewModel
{
    class LichTrinhVM : BaseViewModel
    {

        private int IDTAIXE;
        public int _IDTAIXE { get; set; }

        public LichTrinhVM()
        {
            TaiXeVM tx = new TaiXeVM();
            IDTAIXE = tx.ID;
            MessageBox.Show(IDTAIXE.ToString());
        }
    }
}
