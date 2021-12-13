using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.models
{
    public class Route
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("departure_city")]
        public City departure_city { get; set; }
        [JsonProperty("arrival_city")]
        public City arrival_city { get; set; }
        [JsonProperty("distance")]
        public int distance { get; set; }
        [JsonProperty("user")]
        public User user { get; set; }
    }
}
