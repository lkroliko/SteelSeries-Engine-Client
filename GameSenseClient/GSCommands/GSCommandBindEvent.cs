﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GameSenseClient.Commands
{
    class GSCommandBindEvent : GSCommand
    {
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
        [JsonIgnore]
        public override string Uri { get; protected set; } = "bind_game_event";

        public List<GSHandler> Handlers = new List<GSHandler>();
    }
}
