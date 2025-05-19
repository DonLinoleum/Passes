using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Converters
{
    internal class StatusMarkColorConverter : IValueConverter
    {
        private Dictionary<string,Color> StatusMarksColors = new Dictionary<string, Color>()
        {
            {"Согласован" , Color.FromRgba("#5DBB81") } ,
            {"Отменен",Color.FromRgba("#e55952") },
            {"Ожидает" , Color.FromRgba("#EBB144") }
        };
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is Color valueData && parameter is string param)
            {
                StatusMarksColors.TryGetValue(param, out var color);
                return color;
            }
            return Color.FromRgba("#5DBB81");
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
