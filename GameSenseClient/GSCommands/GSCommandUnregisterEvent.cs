using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient.Commands
{
    class GSCommandUnregisterEvent : GSCommand
    {
        [JsonProperty(PropertyName = "event")]
        public string Name { get; set; }
        [JsonIgnore]
        public override string Uri { get; protected set; } = "remove_game_event";
    }
}
