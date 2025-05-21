using Passes.Models.PassDetail;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Converters.PassMarksConverters
{
    class IsMarksListEmptyConverter : IMultiValueConverter
    {
        public object? Convert(object[]? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not null && value.Length == 2 && parameter is string isEmptyValue)
            {
                MarksForPassModel? marks = value[0] as MarksForPassModel;
                string? passType = value[1] as string;
                if (isEmptyValue == "empty" && passType != "1")
                    return marks?.Movement?.Count == 0;
                else if (isEmptyValue == "empty" && passType == "1")
                    return marks?.PrintMark?.Count == 0 && marks?.Movement?.Count == 0;
                else if (isEmptyValue == "notEmpty")
                    return marks?.PrintMark?.Count > 0 || marks?.Movement?.Count > 0;
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
