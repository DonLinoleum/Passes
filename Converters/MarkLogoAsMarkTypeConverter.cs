using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Passes.Converters
{
    class MarkLogoAsMarkTypeConverter : IValueConverter
    {
        private Dictionary<string, string> logosByType = new Dictionary<string, string>()
        {
            {"warehouse","mark_warehouse" },
            {"guard","mark_shield" }
        };
            
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string markType)
            {
                logosByType.TryGetValue(markType, out var svg);
                return svg;
            }
            return String.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
