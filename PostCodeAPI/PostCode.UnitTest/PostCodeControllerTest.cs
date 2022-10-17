using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using PostCode.Model.Model;
using PostCode.Service.Service;
using PostCodeWebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PostCode.UnitTest
{

    public class PostCodeControllerTest
    {
        private readonly Mock<IPostCodeService> service;
        private readonly Mock<ILogger<PostCodeController>> logger;
        private readonly ITestOutputHelper output;
        public PostCodeControllerTest(ITestOutputHelper output)
        {
            service = new Mock<IPostCodeService>();
            logger = new Mock<ILogger<PostCodeController>>();
            this.output = output;
        }

        [Fact]
        public async Task GetPostCodes_Returns_PostCodes()
        {
            //arrange
            var controller = new PostCodeController(service.Object, logger.Object);
            service.Setup(x => x.GetPostCodes(It.IsAny<string>()))
                    .Returns(Task.FromResult(@"{'status':200,'result':['EX10 0AA', 'EX10 0BB', 'EX100 CC']}"));

            //act
            IActionResult actionResult  = await controller.GetPostCodes("ex");
            ObjectResult objectResponse = Assert.IsType<OkObjectResult>(actionResult);

            //assert 
            Assert.NotNull(actionResult);
            Assert.IsAssignableFrom<IStatusCodeActionResult>(actionResult);
            Assert.Equal(200, objectResponse.StatusCode);
            Assert.Equal(_postCodeList(), objectResponse.Value);
        }

        [Fact]
        //naming convention MethodName_expectedBehavior_StateUnderTest
        public async Task GetPostCodes_Returns_404_Bad_Request_Empty_Response_Msg()
        {
            //arrange
            var controller = new PostCodeController(service.Object, logger.Object);
            service.Setup(x => x.GetPostCodes(It.IsAny<string>()))
                    .Returns(Task.FromResult(""));

            //act
            IActionResult actionResult = await controller.GetPostCodes("ex");
            BadRequestObjectResult objectResponse = Assert.IsType<BadRequestObjectResult>(actionResult);

            //assert 
            Assert.NotNull(actionResult);
            Assert.IsAssignableFrom<IStatusCodeActionResult>(actionResult);
            Assert.Equal(400, objectResponse.StatusCode);
            Assert.Equal("Response is Empty", objectResponse.Value);
        }


        [Fact]
        public async Task GetPostCodes_Returns_404_Bad_Request_Empty_Request_Msg()
        {
            //arrange
            var controller = new PostCodeController(service.Object, logger.Object);
            service.Setup(x => x.GetPostCodes(It.IsAny<string>()))
                    .Returns(Task.FromResult(""));

            //act
            IActionResult actionResult = await controller.GetPostCodes("");
            BadRequestObjectResult objectResponse = Assert.IsType<BadRequestObjectResult>(actionResult);

            //assert 
            Assert.NotNull(actionResult);
            Assert.IsAssignableFrom<IStatusCodeActionResult>(actionResult);
            Assert.Equal(400, objectResponse.StatusCode);
            Assert.Equal("Request is Empty", objectResponse.Value);
        }


        [Fact]
        //naming convention MethodName_expectedBehavior_StateUnderTest
        public async Task GetPostCodeDetail_Returns_404_Bad_Request_Empty_Response_Msg()
        {
            //arrange
            var controller = new PostCodeController(service.Object, logger.Object);
            service.Setup(x => x.GetPostCodeDetail(It.IsAny<string>()))
                    .Returns(Task.FromResult(""));

            //act
            IActionResult actionResult = await controller.GetPostCodeDetail("EX10 0AA");
            BadRequestObjectResult objectResponse = Assert.IsType<BadRequestObjectResult>(actionResult);

            //assert 
            Assert.NotNull(actionResult);
            Assert.IsAssignableFrom<IStatusCodeActionResult>(actionResult);
            Assert.Equal(400, objectResponse.StatusCode);
            Assert.Equal("Response is Empty", objectResponse.Value);
        }


        [Fact]
        public async Task GetPostCodeDetail_Returns_404_Bad_Request_Empty_Request_Msg()
        {
            //arrange
            var controller = new PostCodeController(service.Object, logger.Object);
            service.Setup(x => x.GetPostCodeDetail(It.IsAny<string>()))
                    .Returns(Task.FromResult(""));

            //act
            IActionResult actionResult = await controller.GetPostCodeDetail("");
            BadRequestObjectResult objectResponse = Assert.IsType<BadRequestObjectResult>(actionResult);

            //assert 
            Assert.NotNull(actionResult);
            Assert.IsAssignableFrom<IStatusCodeActionResult>(actionResult);
            Assert.Equal(400, objectResponse.StatusCode);
            Assert.Equal("Request is Empty", objectResponse.Value);
        }

        [Fact]
        public async Task GetPostCodeDetail_Returns_404_Bad_Request_Valid_PostCode_Msg()
        {
            //arrange
            var controller = new PostCodeController(service.Object, logger.Object);
            service.Setup(x => x.GetPostCodeDetail(It.IsAny<string>()))
                    .Returns(Task.FromResult(""));

            //act
            IActionResult actionResult = await controller.GetPostCodeDetail("ex");
            BadRequestObjectResult objectResponse = Assert.IsType<BadRequestObjectResult>(actionResult);

            //assert 
            Assert.NotNull(actionResult);
            Assert.IsAssignableFrom<IStatusCodeActionResult>(actionResult);
            Assert.Equal(400, objectResponse.StatusCode);
            Assert.Equal("Please provide valid postcode in request", objectResponse.Value);
        }

        [Fact]
        public async Task GetPostCodeDetail_Returns_PostCodeDetail()
        {
            //arrange
            var controller = new PostCodeController(service.Object, logger.Object);
            service.Setup(x => x.GetPostCodeDetail(It.IsAny<string>()))
                    .Returns(Task.FromResult(@"{'status':200,'result':{'postcode':'EX10 0AA','quality':1,'eastings':309130,'northings':91762,'country':'England','nhs_ha':'South West','longitude':-3.288576,'latitude':50.718356,'european_electoral_region':'South West','primary_care_trust':'Devon','region':'South West'}}"));

            //act
            IActionResult actionResult = await controller.GetPostCodeDetail("EX10 0AA");
            ObjectResult objectResponse = Assert.IsType<OkObjectResult>(actionResult);

            //assert 
            Assert.NotNull(actionResult);
            Assert.IsAssignableFrom<IStatusCodeActionResult>(actionResult);
            Assert.Equal(200, objectResponse.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(_postcodeResult()), JsonConvert.SerializeObject(objectResponse.Value));
        }

        private List<string> _postCodeList()
        {
            List<string> poscodeList = new List<string> { "EX10 0AA", "EX10 0BB", "EX100 CC" };

            return poscodeList;
        }

        private PostcodeResult _postcodeResult()
        {
            PostcodeResult postcodeResult = new PostcodeResult();
            postcodeResult.Postcode = "EX10 0AA";
            postcodeResult.Region = "South West";
            postcodeResult.Latitude = 50.718356;
            postcodeResult.Longitude = -3.288576;
            postcodeResult.ParliamentaryConstituency =null;
            postcodeResult.Country = "England";
            postcodeResult.AdminDistrict = null;

            return postcodeResult;
        }
    }
}
