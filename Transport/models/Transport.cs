using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.models
{
    public class Transport
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("car_number")]
        public string car_number { get; set; }
        [JsonProperty("total_seats")]
        public byte total_seats { get; set; }
        [JsonProperty("model")]
        public Model model { get; set; }
    }
}
