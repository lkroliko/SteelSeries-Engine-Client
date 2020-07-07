using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient.JsonConverters
{
    class GSGradientColorJsonConverter : JsonConverter<GSGradientColor>
    {
        public override GSGradientColor ReadJson(JsonReader reader, Type objectType, GSGradientColor existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, GSGradientColor value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("gradient", false);
            writer.WriteStartObject();
            writer.WritePropertyName("zero", false);
            serializer.Serialize(writer, value.From);
            writer.WritePropertyName("hundred", false);
            serializer.Serialize(writer, value.To);
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
}
