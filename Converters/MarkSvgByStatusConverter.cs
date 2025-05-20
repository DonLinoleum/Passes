using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Converters
{
    public class MarkSvgByStatusConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string status)
            {
                switch (status)
                {
                    case "Согласован":
                            return "aggrement_mark";
                    case "Отменен":
                        return "decline_mark";
                    case "Ожидает":
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
