using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient.Commands
{
    class GSCommandRegisterProgram : GSCommand
    {
        [JsonProperty(PropertyName = "game_display_name")]
        public string DisplayName { get; set; }
        [JsonProperty(PropertyName = "developer")]
        public string DeveloperName { get; set; }
        [JsonIgnore]
        public override string Uri { get; protected set; } = "game_metadata";
    }
    
}

