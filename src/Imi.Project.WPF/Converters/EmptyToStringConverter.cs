using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace Imi.Project.WPF.Converters
{
    public class EmptyToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           var text = value as string;

            if (string.IsNullOrWhiteSpace(text))
                return "Not specified";
            else return value as string;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
