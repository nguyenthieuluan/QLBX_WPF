using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace QLBX.ViewModel
{
    public class testVM:BaseViewModel
    {
        public ICommand test { get; set; }
        public testVM()
        {
            test = new RelayCommand<object>((p) => { return true; }, (p) => {
                //var ellipse = p as Ellipse;

                //if (ellipse != null && p.LeftButton == MouseButtonState.Pressed)
                //{
                //    // Send obj to target
                //    DragDrop.DoDragDrop(ellipse, ellipse,DragDropEffects.Move);
                //}
            });
        }
    }
}
