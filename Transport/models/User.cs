using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.models
{
    public class User
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("email")]
        public string email { get; set; }
        [JsonProperty("surname")]
        public string surname { get; set; }
        [JsonProperty("first_name")]
        public string first_name { get; set; }
        [JsonProperty("second_name")]
        public string second_name { get; set; }
        [JsonProperty("passport_series")]
        public string passport_series { get; set; }
        [JsonProperty("passport_number")]
        public string passport_number { get; set; }
        [JsonProperty("inn")]
        public string inn { get; set; }
        [JsonProperty("scan")]
        public string scan { get; set; }
        [JsonProperty("birthday")]
        public string birthday { get; set; }
        [JsonProperty("dismissed")]
        public bool dismissed { get; set; }
    }
}