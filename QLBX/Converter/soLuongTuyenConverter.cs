
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace QLBX
{
    public class soLuongTuyenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int a = 0;
            int.TryParse(value.ToString(), out a);
            List<int> arr = new List<int>();
            for(int i=1;i<=a;i++)
            {
                arr.Add(i);
            }
            List<int> arr1 = new List<int>() { 1,2,3,4};
            return arr;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
