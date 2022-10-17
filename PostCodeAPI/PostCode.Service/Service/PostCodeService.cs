using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PostCode.Service.Service
{
    public class PostCodeService:IPostCodeService
    {
        public IConfiguration _configuration;
        public readonly string _baseAPIURL;
        private readonly ILogger<PostCodeService> _logger;
        public PostCodeService(IConfiguration configuration, ILogger<PostCodeService> logger)
        {
            this._logger = logger;
            this._configuration = configuration;
            this._baseAPIURL = _configuration["PostCodeAPI:BaseAPIUrl"];
        }

        /// <summary>
        /// This function return postcodes
        /// </summary>
        /// <param name="postcode"></param>
        /// <returns></returns>
        public async Task<string> GetPostCodes(string postcode)
        {
            _logger.LogInformation("PostCodeService.GetPostCodes");
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetStringAsync(this._baseAPIURL + postcode + "/autocomplete");
        }

        /// <summary>
        /// This function return PostCodeDetail
        /// </summary> 
        /// <param name="postcode"></param>
        /// <returns></returns>
        public async Task<string> GetPostCodeDetail(string postcode)
        {
            _logger.LogInformation("PostCodeService.GetPostCodeDetail");
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetStringAsync(this._baseAPIURL + postcode);
        }
    }
}
