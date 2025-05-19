using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Converters
{
    public class NumberToYesOrNoConverter : IValueConverter
    {
            public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
            {
            if (value is string data)
                {
                    return !string.IsNullOrEmpty(data) || data == "1" ? "Да" : null;
                }
                return value;
            }

            public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }

