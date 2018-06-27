
using System;
using System.Globalization;
using System.Windows.Data;

namespace QLBX
{
    public class tuyenConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double xe = 0.0;
            double gio = 0.0;
            double result = 0.0;
            double val = 0.0;

            foreach (var txt in values)
            {
                if (double.TryParse(txt.ToString(), out val))
                    xe = val;
                else
                    gio = ConvertHours(txt.ToString());
            }
            result = (24 * xe) / (gio * 2);
            int x = (int)result;
            return x.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public double ConvertHours(string sample)
        {
            string[] samplesplit = sample.Split(':');
            return double.Parse(samplesplit[0]) + double.Parse(samplesplit[1]) / 60 + double.Parse(samplesplit[2]) / 6000;
        }
        
    }
}
