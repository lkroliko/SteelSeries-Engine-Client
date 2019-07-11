using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient
{
    public class GSCommandUnregisterProgram : GSCommand
    {
        [JsonProperty(PropertyName = "game")]
        internal string Name { get; set; }

        internal GSCommandUnregisterProgram(string programName) => Name = programName;
    }
}
