using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient
{
    public class GSEventData
    {
        [JsonProperty(PropertyName = "value")]
        [DefaultValue(0)]
        public int Value { get; set; } = 0;

        internal GSEventData() { }
    }
}
