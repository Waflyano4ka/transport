using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.models
{
    public class PostUser
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("user")]
        public User user { get; set; }
        [JsonProperty("post")]
        public Post post { get; set; }
    }
}
