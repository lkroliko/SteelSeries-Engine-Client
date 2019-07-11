using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient
{
    public class GSCommandUnregisterEvent : GSCommand
    {
        [JsonProperty(PropertyName = "game")]
        internal string ProgramName { get; set; }
        [JsonProperty(PropertyName = "event")]
        public string Name { get; set; }

        internal GSCommandUnregisterEvent(string programName) => ProgramName = programName;
    }
}
