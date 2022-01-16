using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Imi.Project.Mobile.Converters
{
    public class TextToVisibilityConverter : IValueConverter
    {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                var text = value as string;

                if (string.IsNullOrWhiteSpace(text))
                    return false;

                return true;
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        
    }
}
