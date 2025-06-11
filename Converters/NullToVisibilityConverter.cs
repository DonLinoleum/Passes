using Passes.Models.PassDetail;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Converters
{
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value switch
            {
                IList list => NullToVisibilityConverter.CheckIsValueList(value, parameter),
                string str => string.IsNullOrEmpty(str) ? false : true,
                bool boolVal => boolVal,
                ChildrenModel children => children is not null, 
                null => false,
                _ => false
            };
        }

        public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static bool CheckIsValueList(object? value, object? parameter)
        {
            if (value is IList list)
            {
                if (list is List<Visitor> visitors && parameter is string paramStr) return NullToVisibilityConverter.CheckVisitor(visitors,paramStr); 
                if (parameter is string param && bool.TryParse(param, out bool needToShowOnlyOne))
                    return list.Count == 1 && needToShowOnlyOne;
                return list.Count > 0;
            }
            return false;
        }
        private static bool CheckVisitor(List<Visitor> visitors, string paramStr)
        {
            if (visitors?.Count > 0 && visitors[0] != null)
            {
                switch (paramStr)
                {
                    case "LastName":
                        return !String.IsNullOrEmpty(visitors[0].LastName);
                    case "BirthDate":
                        return !String.IsNullOrEmpty(visitors[0].BirthDate);
                    case "Phone":
                        return !String.IsNullOrEmpty(visitors[0].Phone);
                    case "number_of_pass":
                        return !String.IsNullOrEmpty(visitors[0].number_of_pass);
                    case "date_of_pass":
                        return !String.IsNullOrEmpty(visitors[0].date_of_pass);
                }
            }
            return false;
        }
    }
}
