using Newtonsoft.Json;

namespace GameSenseClient.Commands
{
    class GSCommandEvent : GSCommand
    {
        [JsonProperty(PropertyName = "event")]
        internal string Name { get; set; }
        [JsonProperty(PropertyName = "data")]
        public GSEventData Data { get; }
        [JsonIgnore]
        public override string Uri { get; protected set; } = "game_event";

        internal GSCommandEvent(int value)
        {
            Data = new GSEventData() { Value = value };
        }
    }
}
