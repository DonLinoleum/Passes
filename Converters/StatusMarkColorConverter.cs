using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Converters
{
    public class StatusMarkColorConverter : IValueConverter
    {
        private Dictionary<string,string> StatusMarksColors = new Dictionary<string, string>()
        {
            {"Согласован" , "#5DBB81" } ,
            {"Отменен","#e55952" },
            {"Ожидает" , "#EBB144" }
        };
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            
            if (value is string colorHex)
            {
                if (StatusMarksColors.TryGetValue(colorHex, out var color) == true)
                return Color.FromRgba(color);
            }
            return Color.FromRgba("#5DBB81");
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
