using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Converters
{
    internal class PassStatesIdToTextConverter : IValueConverter
    {
        private Dictionary<string, string> passStates = new Dictionary<string, string>()
        {
            {"1" , "на согласовании" },
            {"3" , "отклонен" },
            {"4" , "готов к выдаче" },
            {"6" , "на согласовании ОТ и ПК" },
            {"8" , "использован" },
            {"15" , "на согласовании ответственным" },
            {"17" , "используется" },
            {"18" , "на согласовании ГБ" },
            {"19" , "аннулирован" },
            {"20" , "на согласовании руководителеим ОТ и ПК" },
            
        };
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string stateId)
            {
                if (passStates.TryGetValue(stateId ,out string? color))
                    return color;
            }
            return "";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
