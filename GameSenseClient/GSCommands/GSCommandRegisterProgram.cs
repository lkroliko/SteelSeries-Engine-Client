using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient
{
    public class GSCommandRegisterProgram : GSCommand
    {
        private string name;
        [JsonProperty(PropertyName = "game")]
        internal string Name { get { return name; } set { name = value.ToUpper(); } }
        [JsonProperty(PropertyName = "game_display_name")]
        public string DisplayName { get; set; }
        [JsonProperty(PropertyName = "developer")]
        public string DeveloperName { get; set; }

        internal GSCommandRegisterProgram(string programName) => Name = programName;
    }
    
}

