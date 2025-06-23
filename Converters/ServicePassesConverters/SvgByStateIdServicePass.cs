using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Converters.ServicePassesConverters
{
    internal class SvgByStateIdServicePass : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string statusId)
            {
                switch (statusId)
                {
                    case "4":
                    case "5":
                        return "aggrement_mark";
                    case "3":
                    case "19":
                        return "decline_mark";
                    default:
                        return "awaiting_mark";
                }
            }
            return "calendar";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
