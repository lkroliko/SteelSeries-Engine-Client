using GameSenseClient.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient
{
    [JsonConverter(typeof(GSGradientColorJsonConverter))]
    public class GSGradientColor : GSColor
    {
        /// <summary>
        /// Color when event value is "0"
        /// </summary>
        [JsonProperty(PropertyName = "zero")]
        public GSColor From { get; set; }

        /// <summary>
        /// Color when event value is "100"
        /// </summary>
        [JsonProperty(PropertyName = "hundred")]
        public GSColor To { get; set; }
    }
}
