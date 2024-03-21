using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Business.CoSoVatChatService;
using NS.Core.Commons;

namespace NS.Core.API.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class CoSoVatChatController : ControllerBase
    {
        private readonly ICoSoVatChatService _coSoVatChatService;
        public CoSoVatChatController (ICoSoVatChatService coSoVatChatService)
        {
            _coSoVatChatService = coSoVatChatService;
        }
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] long id)
        {
            var res = await _coSoVatChatService.GetById(id);
            return Ok(res);
        }
        [HttpGet] 
        public async Task<IActionResult> GetAll()
        {
            var res = await _coSoVatChatService.GetAll();
            return Ok(res);
        }
        [HttpGet] 
        public async Task<IActionResult> GetAllLandingPage()
        {
            var res = await _coSoVatChatService.GetAllLandingPage();
            return Ok(res);
        }
    }
}
