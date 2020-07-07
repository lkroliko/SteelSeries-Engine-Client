using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient.Commands
{
    class GSCommandRegisterEvent : GSCommand
    {
        private string eventName;
        [JsonProperty(PropertyName = "event")]
        public string Name { get { return eventName; } set { eventName = value.ToUpper(); } }
        [JsonProperty(PropertyName = "min_value")]
        public int MinValue { get; set; }
        [JsonProperty(PropertyName = "max_value")]
        public int MaxValue { get; set; }
        [JsonProperty(PropertyName = "icon_id")]
        /// <summary>
        /// "0" means no icon
        /// </summary>
        public int IconId { get; set; } = 0;
        [JsonProperty(PropertyName = "value_optional")]
        public bool ValueOptional { get; set; } = true;
        [JsonIgnore]
        public override string Uri { get; protected set; } = "register_game_event";
    }
}
