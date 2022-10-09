using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PostCodeWebAPI.Service
{
    public class PostCodeService:IPostCodeService
    {
        public IConfiguration _configuration;
        public readonly string _baseAPIURL;
        public PostCodeService(IConfiguration configuration )
        {
            this._configuration = configuration;
            this._baseAPIURL = _configuration.GetValue<string>("PostCodeAPI:BaseAPIUrl");
        }

        /// <summary>
        /// GetPostCodes
        /// </summary>
        /// <param name="postcode"></param>
        /// <returns></returns>
        public async Task<string> GetPostCodes(string postcode)
        {
            HttpClient httpClient = new HttpClient();

            return await httpClient.GetStringAsync(this._baseAPIURL + postcode + "/autocomplete");
        }

        /// <summary>
        /// GetPostCodeDetail
        /// </summary>
        /// <param name="postcode"></param>
        /// <returns></returns>
        public async Task<string> GetPostCodeDetail(string postcode)
        {
            HttpClient httpClient = new HttpClient();

            return await httpClient.GetStringAsync(this._baseAPIURL + postcode);
        }
    }
}
