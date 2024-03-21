using Microsoft.AspNetCore.Mvc;
using NS.Core.Business;
using NS.Core.Business.SampleService;
using NS.Core.Commons;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;

namespace NS.Core.API.Controllers
{

    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ISampleService _sampleService;

        public SampleController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        [HttpGet]
        public async Task<ActionResult<BasePaginationResponseModel<SampleData>>> GetAll([FromQuery]SampleRequestModel input)
        {
            var result = await _sampleService.GetAll(input);
            return Ok(result);
        }
    }
}
