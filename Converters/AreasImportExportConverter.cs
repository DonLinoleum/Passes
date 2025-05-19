using Passes.Models.PassDetail;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Converters
{
    internal class AreasImportExportConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is Areas areas)
            {
                switch (parameter?.ToString())
                {
                    case "ExportName":
                        return !string.IsNullOrEmpty(areas?.ExportName);
                    case "ImportName":
                        return !string.IsNullOrEmpty(areas?.ImportName);
                    default:
                        return false;
                }
            }
            return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
