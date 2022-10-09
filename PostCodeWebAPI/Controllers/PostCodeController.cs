using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PostCodesAPI.Modal;
using PostCodeWebAPI.Modal;
using PostCodeWebAPI.Service;
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

        public PostCodeController(IPostCodeService postCodeService, ILogger<PostCodeController> logger)
        {
            this._logger = logger;
            this._postCodeService = postCodeService;
        }

        [HttpGet]
        [Route("/GetPostCodes")]
        public async Task<IActionResult> GetPostCodes(string postcode)
        {
            if (string.IsNullOrEmpty(postcode))
                return BadRequest("Request is Empty");

            string response = await _postCodeService.GetPostCodes(postcode);
            if (string.IsNullOrEmpty(response))
                return BadRequest("Response is Empty");

            PostCode postCode =  JsonConvert.DeserializeObject<PostCode>(response);
            if (postCode?.Status != 200)
               return BadRequest(postCode?.Error);

            return Ok(postCode.Result);

        }

        [HttpGet]
        [Route("/GetPostCodeDetail")]
        public async Task<IActionResult> GetPostCodeDetail(string postcode)
        {
            if (string.IsNullOrEmpty(postcode))
                return BadRequest("Request is Empty");

            string response = await _postCodeService.GetPostCodeDetail(postcode);
            if (string.IsNullOrEmpty(response))
                return BadRequest("Response is Empty");

            PostCodeDetail postCodeDetail = JsonConvert.DeserializeObject<PostCodeDetail>(response);
            if (postCodeDetail?.Status != 200)
                return BadRequest(postCodeDetail?.Error);

            return Ok(postCodeDetail.Result);

        }

    }
}
