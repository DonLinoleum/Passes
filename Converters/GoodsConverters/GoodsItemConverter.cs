using Passes.Models.PassDetail;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Converters.GoodsConverters
{
    internal class GoodsItemConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string goodsItem)
                return $"- {goodsItem}";
            else if (value is GoodsModel goodsModelItem)
                return $"- Название:{goodsModelItem.Name}, Номер: {goodsModelItem.Number}, Количество: {goodsModelItem.Count}";
            return "";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
