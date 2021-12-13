using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.models
{
    public class Schedule
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("time")]
        public string time { get; set; }
        [JsonProperty("cost")]
        public double cost { get; set; }
        [JsonProperty("confirmed")]
        public bool confirmed { get; set; }
        [JsonProperty("transport")]
        public Transport transport { get; set; }
        [JsonProperty("route")]
        public Route route { get; set; }
    }
}
