using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostCodeWebAPI.Modal
{
    public class PostCode
    {
        //The HTTP status response from Postcodes.IO.
        [JsonProperty("status")]
        public int Status;

        //If an error is returned, it is held here.
        [JsonProperty("error")]
        public string? Error;

        //The actual result of the API call.
        [JsonProperty("result")]
        public List<string>? Result;
    }
}
