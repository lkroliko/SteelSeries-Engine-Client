using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient
{
    public class GSRangeColor : GSColor
    {
        [JsonProperty(PropertyName = "low")]
        public int Low { get; set; }
        [JsonProperty(PropertyName = "high")]
        public int High { get; set; }
        [JsonProperty(PropertyName = "color")]
        public GSColor Color { set; get; }
    }
}
