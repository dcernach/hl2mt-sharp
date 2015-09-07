using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MeHZ.HeroLab2MapTool.App.Converters {
    public class StringToUriConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var path = value as string;

            try {
                Path.GetDirectoryName(path);
            }
            catch (Exception) {
                path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                //return DependencyProperty.UnsetValue;
            }

            return path;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
            //  throw new NotImplementedException();
        }
    }
}
