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
    public class NegateBooleanConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var isTrue = value as bool?;

           if(!isTrue.HasValue)
                return DependencyProperty.UnsetValue;

            return !isTrue.Value;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }
    }
}
