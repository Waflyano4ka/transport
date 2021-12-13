using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.models
{
    public class OfficeUser
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("user")]
        public User user { get; set; }
        [JsonProperty("office")]
        public Office office { get; set; }
    }
}
