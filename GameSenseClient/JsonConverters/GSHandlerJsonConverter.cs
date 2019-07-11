using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //  {
            //      "device-type": "keyboard",
            //      "zone": "function-keys",
            //      "color": {"gradient": {"zero": {"red": 255, "green": 0, "blue": 0},
            //                             "hundred": {"red": 0, "green": 255, "blue": 0}}},
            //      "mode": "percent"
            //    }

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
                foreach(GSColor color in value.Colors)
                    serializer.Serialize(writer, color);
                writer.WriteEndArray();
            }

            writer.WritePropertyName("mode", false);
            serializer.Serialize(writer, value.mode);
            writer.WriteEndObject();
        }
    }
}
