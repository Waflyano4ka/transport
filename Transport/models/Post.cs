using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.models
{
    public class Post
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("post_name")]
        public string post_name { get; set; }
    }
}
