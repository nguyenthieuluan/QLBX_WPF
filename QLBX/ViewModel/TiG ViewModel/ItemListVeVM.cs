using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBX.ViewModel
{
    public class ItemListVeVM
    {
        public int? chongoi { get; set; }
        public bool? trangthai { get; set; }
        public int? idkhach { get; set; }
        public ItemListVeVM()
        {
            chongoi = null;
            trangthai = null;
            idkhach = null;
        }
    }
}
