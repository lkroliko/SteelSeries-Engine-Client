using Newtonsoft.Json;
using System;

namespace GameSenseClient.JsonConverters
{
    internal class GSHandlerJsonConverter : JsonConverter<GSHandler>
    {
        public override GSHandler ReadJson(JsonReader reader, Type objectType, GSHandler existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, GSHandler value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("device-type", false);
            serializer.Serialize(writer, value.device);
            writer.WritePropertyName("zone", false);
            serializer.Serialize(writer, value.zone);

            writer.WritePropertyName("color", false);
            if (value.Colors.Count == 1)
                serializer.Serialize(writer, value.Colors[0]);
            else
            {
                writer.WriteStartArray();
                foreach (GSColor color in value.Colors)
                    serializer.Serialize(writer, color);
                writer.WriteEndArray();
            }

            writer.WritePropertyName("mode", false);
            serializer.Serialize(writer, value.mode);
            writer.WriteEndObject();
        }
    }
}
