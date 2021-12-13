using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.models
{
    public class Model
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("model_name")]
        public string model_name { get; set; }
    }
}
