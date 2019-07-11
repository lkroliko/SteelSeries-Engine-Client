using Newtonsoft.Json;

namespace GameSenseClient
{
    public class GSCommandEvent : GSCommand
    {
        [JsonProperty(PropertyName = "game")]
        internal string ProgramName { get; set; }
        [JsonProperty(PropertyName = "event")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "data")]
        public GSEventData Data { get;  }

        internal GSCommandEvent(string programName)
        {
            ProgramName = programName;
            Data = new GSEventData();
        }
    }
}
