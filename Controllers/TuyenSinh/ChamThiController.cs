using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.ChamThiService;
using NS.Core.Models.RequestModels;
using NS.Core.Commons;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class ChamThiController : ControllerBase
    {
        private readonly IChamThiService _chamThiService;
        public ChamThiController(IChamThiService chamThiService)
        {
            _chamThiService = chamThiService;
        }
        [HttpPost]
        public async Task<IActionResult> ChamThi([FromBody]List<ChamThiRequestModel> input)
        {
            await _chamThiService.ChamThi(input);
            return Ok();
        }
    }
}
