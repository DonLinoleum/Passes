using Passes.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Converters
{
    public class PassStateToColorConverter : IValueConverter
    {
        Dictionary<string,string> stateColors = new Dictionary<string, string>()
            {
                { "На согласовании", "#dadada" },
                { "Готов к выдаче", "#50c787" },
                { "На территории", "#8d8bf8" },
                { "Выдан", "#edbc74" },
                { "Отклонен", "#ec6e6e" },
                { "Использован", "#3f5468" },
                { "На согласовании МОЛ", "#e0e077" },
                { "На согласовании руководителем ПСП", "#b8b858" },
                { "На складе","#4682B4" },
                { "Покинула склад","#00008B" },
                { "Истек срок" , "#4B0082" }
            };

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string passStateName)
            {
                if (stateColors.TryGetValue(passStateName, out var color) == true)
                    return Color.FromArgb(color);
            }           
            return Colors.LightGray;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
