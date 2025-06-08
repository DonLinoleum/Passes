using Passes.Models.PassDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Passes.Models.JsonConverters
{
    public class GoodsJsonConverter : JsonConverter<object>
    {
        public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                var root = doc.RootElement;
                if(root.ValueKind == JsonValueKind.Array)
                {
                    if (root.EnumerateArray().Any() && root.EnumerateArray().First().ValueKind == JsonValueKind.Object)
                        return JsonSerializer.Deserialize<List<GoodsModel>>(root.GetRawText(), options);
                    else
                        return JsonSerializer.Deserialize<List<string>>(root.GetRawText(), options);
                }
                return new List<string>();
            }
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            if (value is List<GoodsModel> instruments)
                JsonSerializer.Serialize(writer, instruments, options);
            if (value is List<string> goods)
                JsonSerializer.Serialize(writer, goods, options);
        }
    }
}
