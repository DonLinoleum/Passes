using Passes.Models.PassDetail;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Converters
{
    class IsMarksListEmptyConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is MarksForPassModel marks && parameter is string isEmptyValue)
            {
                if (isEmptyValue == "empty")
                    return marks?.PrintMark?.Count == 0 && marks.Movement?.Count == 0;
                else if (isEmptyValue == "notEmpty")
                    return marks?.PrintMark?.Count > 0 || marks?.Movement?.Count > 0;
            }
            return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
