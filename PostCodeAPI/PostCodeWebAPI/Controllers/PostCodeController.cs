using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PostCode.Model.Model;
using PostCode.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostCodeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCodeController : ControllerBase
    {
        private readonly ILogger<PostCodeController> _logger;
        private readonly IPostCodeService _postCodeService;

        /// <summary>
        /// PostCodeController Constructor
        /// </summary>
        /// <param name="postCodeService"></param>
        /// <param name="logger"></param>
        public PostCodeController(IPostCodeService postCodeService, ILogger<PostCodeController> logger)
        {
            this._logger = logger;
            this._postCodeService = postCodeService;
        }


        /// <summary>
        /// GetPostCodes function use to get postcode
        /// </summary>
        /// <param name="postcode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/GetPostCodes")]
        public async Task<IActionResult> GetPostCodes(string postcode)
        {
            _logger.LogInformation("PostCodeController.GetPostCodes");
            if (string.IsNullOrEmpty(postcode))
                return BadRequest("Request is Empty");

            string response = await _postCodeService.GetPostCodes(postcode);
            if (string.IsNullOrEmpty(response))
                return BadRequest("Response is Empty");

            PostCodes postCode =  JsonConvert.DeserializeObject<PostCodes>(response);
            if (postCode?.Status != 200)
               return BadRequest(postCode?.Error);

            _logger.LogInformation("PostCodeController.GetPostCodes", postCode.Result);

            return Ok(postCode.Result);

        }

        /// <summary>
        /// GetPostCodeDetail function will return post code details
        /// </summary>
        /// <param name="postcode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/GetPostCodeDetail")]
        public async Task<IActionResult> GetPostCodeDetail(string postcode)
        {
            _logger.LogInformation("PostCodeController.GetPostCodeDetail");
            if (string.IsNullOrEmpty(postcode))
                return BadRequest("Request is Empty");

            if (postcode.Length < 6 )
                return BadRequest("Please provide valid postcode in request");

            string response = await _postCodeService.GetPostCodeDetail(postcode);
            if (string.IsNullOrEmpty(response))
                return BadRequest("Response is Empty");

            PostCodeDetail postCodeDetail = JsonConvert.DeserializeObject<PostCodeDetail>(response);
            if (postCodeDetail?.Status != 200)
                return BadRequest(postCodeDetail?.Error);

            _logger.LogInformation("PostCodeController.GetPostCodeDetail", postCodeDetail.Result);

            return Ok(postCodeDetail.Result);

        }

    }
}
