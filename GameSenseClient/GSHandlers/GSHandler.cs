using GameSenseClient.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GameSenseClient
{
    [JsonConverter(typeof(GSHandlerJsonConverter))]
    public class GSHandler
    {
        [JsonProperty(PropertyName = "device-type")]
        internal string device;

        [JsonProperty]
        internal string zone;

        [JsonProperty]
        internal string mode;
        
        [JsonIgnore]
        public GSEventMode Mode { set { SetMode(value); } }

        [JsonIgnore]
        public GSDeviceZone Zone { set { SetZone(value); SetDevice(value); } }

        [JsonProperty(PropertyName = "color")]
        public List<GSColor> Colors { set; get; } = new List<GSColor>();

        private void SetMode(GSEventMode gSEventMode)
        {
            mode = gSEventMode.ToString().ToLower();
        }

        private void SetZone(GSDeviceZone gSDeviceZone)
        {
            zone = GetZone(gSDeviceZone);
        }

        private void SetDevice(GSDeviceZone gSDeviceZone)
        {
            device = GetDevice(gSDeviceZone);
        }

        private string GetDevice(GSDeviceZone gSDeviceZone)
        {
            string tmp = gSDeviceZone.ToString();
            if (tmp.StartsWith("RgbZonedDevice"))
                return "rgb-zoned-device";
            return ConverToGSFormat(tmp.Split('_')[0]);
        }

        private string GetZone(GSDeviceZone gSDeviceZone)
        {
            string tmp = gSDeviceZone.ToString();
            return ConverToGSFormat(tmp.Split('_')[1]);
        }

        private string ConverToGSFormat(string value)
        {
            string[] words = Regex.Split(value, @"(?<!^)(?=[A-Z])");
            string tmp = string.Empty;

            for (int i = 0; i < words.Length; i++)
                if (i < words.Length - 1)
                    tmp = $"{tmp}{words[i]}-";
                else
                    tmp = $"{tmp}{words[i]}";

            return tmp.ToLower();
        }
    }
}
