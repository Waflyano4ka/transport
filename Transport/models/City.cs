using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.models
{
    public class City
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("city_name")]
        public string city_name { get; set; }
    }
}
