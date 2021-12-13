using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.models
{
    public class Ticket
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("passenger")]
        public Passenger passenger { get; set; }
        [JsonProperty("schedule")]
        public Schedule schedule { get; set; }
    }
}
