using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GameSenseClient
{
    public class GSCommandBindEvent : GSCommand
    {
        //{
        //  "game": "ADVENTURE",
        //  "event": "HEALTH",
        //  "min_value": 0,
        //  "max_value": 100,
        //  "icon_id": 1,
        //  "handlers": [
        //  ]
        //}
        [JsonProperty(PropertyName = "game")]
        private string ProgramName { get; set; }
        [JsonProperty(PropertyName = "event")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "min_value")]
        public int MinimumValue { get; set; } = 0;
        [JsonProperty(PropertyName = "max_value")]
        public int MaximumValue { get; set; } = 100;
        /// <summary>
        /// "0" means no icon
        /// </summary>
        public int IconId { get; set; } = 0;

        public List<GSHandler> Handlers = new List<GSHandler>();

        internal GSCommandBindEvent(string programName)
        {
            ProgramName = programName;
        }
    }
}
