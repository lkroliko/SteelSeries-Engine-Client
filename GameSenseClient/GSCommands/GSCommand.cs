using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient.Commands
{
    abstract class GSCommand : IGSCommand
    {
        [JsonProperty(PropertyName = "game")]
        string _programName;
        [JsonIgnore]
        public string ProgramName { get => _programName; set => _programName = value.ToUpper(); }
        public abstract string Uri { get; protected set; }

        public string GetCommand()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
