using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PostCodesAPI.Modal
{
    public class PostCodeDetail
    {
        [JsonProperty("status")]
        public int Status;
        [JsonProperty("error")]
        public string? Error;
        [JsonProperty("result")]
        public PostcodeResult? Result;
    }

    public class PostcodeResult
    {
        [JsonProperty("postcode")]
        public string? Postcode { get; set; }
        [JsonProperty("country")]
        public string? Country { get; set; }
        [JsonProperty("region")]
        public string? Region { get; set; }
        [JsonProperty("admin_district")]
        public string? AdminDistrict { get; set; }
        [JsonProperty("parliamentary_constituency")]
        public string? ParliamentaryConstituency { get; set; }
        [JsonProperty("longitude")]
        public double Longitude;
        [JsonProperty("latitude")]
        public double Latitude;
        public string Area
        {
            get
            {
                if (Latitude < 52.229466)
                {
                    return "South";
                }
                else if (52.229466 <= Latitude && Latitude < 53.27169)
                {
                    return "Midlands";
                }
                else if (Latitude >= 53.27169)
                {
                    return "North";
                }
                else return "";
            }
        }
    }
}