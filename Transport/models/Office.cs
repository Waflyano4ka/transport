using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.models
{
    public class Office
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("phone")]
        public string phone { get; set; }
        [JsonProperty("address")]
        public string address { get; set; }
        [JsonProperty("city")]
        public City city { get; set; }
    }
}
