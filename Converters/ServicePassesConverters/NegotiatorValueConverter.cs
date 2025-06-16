using Passes.Models.PassDetail;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Converters.ServicePassesConverters
{
    internal class NegotiatorValueConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is Negotiator negotiator)
            {
                return $" - {negotiator.LAST_NAME} {negotiator.NAME} {negotiator.SECOND_NAME}";
            }
            return "";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
