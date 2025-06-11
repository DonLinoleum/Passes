using Passes.Models.PassDetail;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Converters
{
    class DateFromDateToConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is PassDetailModel pass && pass is not null)
            {
                if (!String.IsNullOrEmpty(pass.date_from) && !String.IsNullOrEmpty(pass.date_to))
                    return $"с {pass.date_from} по {pass.date_to}";
                if (!String.IsNullOrEmpty(pass.date_from))
                    return pass.date_from;
            }
            return "";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
