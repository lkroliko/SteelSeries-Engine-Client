using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSenseClient
{
    public class GSStaticColor : GSColor
    {
        [JsonProperty(PropertyName = "red")]
        public int R { get; set; }
        [JsonProperty(PropertyName = "green")]
        public int G { get; set; }
        [JsonProperty(PropertyName = "blue")]
        public int B { get; set; }
        [JsonIgnore]
        public Color Color { set { SetColor(value); } }

        public GSStaticColor() { }

        private void SetColor(Color color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
        }
    }
}
