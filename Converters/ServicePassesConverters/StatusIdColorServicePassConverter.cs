using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Converters.ServicePassesConverters
{
    internal class StatusIdColorServicePassConverter : IValueConverter
    {
        private Dictionary<string, string> StatusMarksColors = new Dictionary<string, string>()
        {
            {"5" , "#5DBB81" },
            {"4" , "#5DBB81" },
            {"3" , "#e55952" },
            {"19","#e55952" },
            {"1" , "#EBB144" },
            {"8" , "#3f5468" },
        };
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string colorHex)
            {
                if (StatusMarksColors.TryGetValue(colorHex, out var color) == true)
                    return Color.FromRgba(color);
            }
            return Color.FromRgba("#EBB144");
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
