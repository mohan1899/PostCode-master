using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostCodeWebAPI.Modal
{
    public class PostCode
    {
        [JsonProperty("status")]
        public int Status;

        [JsonProperty("error")]
        public string? Error;

        [JsonProperty("result")]
        public List<string>? Result;
    }
}
